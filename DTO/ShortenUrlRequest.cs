using System.ComponentModel.DataAnnotations;

namespace URLShortener.API.DTOs
{
    public class ShortenUrlRequest
    {
        [Required]
        [Url]
        public string OriginalUrl { get; set; } = string.Empty;
    }
}