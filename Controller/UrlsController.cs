using Microsoft.AspNetCore.Mvc;
using URLShortener.API.DTOs;
using URLShortener.API.Services;

namespace URLShortener.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlsController : ControllerBase
    {
        private readonly UrlService _urlService;

        public UrlsController(UrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpPost("shorten")]
        public async Task<IActionResult> ShortenUrl(
            [FromBody] ShortenUrlRequest request)
        {
            if (!Uri.TryCreate(request.OriginalUrl, UriKind.Absolute, out var uri) ||
                (uri.Scheme != Uri.UriSchemeHttp &&
                 uri.Scheme != Uri.UriSchemeHttps))
            {
                return BadRequest("Please provide a valid HTTP or HTTPS URL.");
            }

            var mapping = await _urlService.CreateShortUrlAsync(
                request.OriginalUrl);

            var shortUrl = $"{Request.Scheme}://{Request.Host}/{mapping.ShortCode}";

            return Ok(new
            {
                originalUrl = mapping.OriginalUrl,
                shortCode = mapping.ShortCode,
                shortUrl = shortUrl
            });
        }
        [HttpGet("~/{shortCode}")]
public async Task<IActionResult> RedirectToOriginalUrl(string shortCode)
{
    var mapping = await _urlService.GetByShortCodeAsync(shortCode);

    if (mapping == null)
    {
        return NotFound("Short URL not found.");
    }

    return Redirect(mapping.OriginalUrl);
}
    }
}