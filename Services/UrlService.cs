using Microsoft.EntityFrameworkCore;
using URLShortener.API.Data;
using URLShortener.API.Models;

namespace URLShortener.API.Services
{
    public class UrlService
    {
        private readonly AppDbContext _context;
        private readonly ShortCodeGenerator _codeGenerator;

        public UrlService(
            AppDbContext context,
            ShortCodeGenerator codeGenerator)
        {
            _context = context;
            _codeGenerator = codeGenerator;
        }

        public async Task<UrlMapping> CreateShortUrlAsync(string originalUrl)
        {
            var urlMapping = new UrlMapping
            {
                OriginalUrl = originalUrl,
                ShortCode = _codeGenerator.GenerateCode(),
                CreatedAt = DateTime.UtcNow
            };

            _context.UrlMappings.Add(urlMapping);

            await _context.SaveChangesAsync();

            return urlMapping;
        }

        public async Task<UrlMapping?> GetByShortCodeAsync(string shortCode)
        {
            return await _context.UrlMappings
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ShortCode == shortCode);
        }
    }
}