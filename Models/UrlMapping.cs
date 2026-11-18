using System.ComponentModel.DataAnnotations;

namespace URLShortener.API.Models
{
    public class UrlMapping
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string ShortCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(2048)]
        public string OriginalUrl { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}