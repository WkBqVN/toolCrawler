using System.ComponentModel.DataAnnotations;

namespace toolCrawler.Components.TikTok
{
    public class TikTokModel
    {
        [Required]
        [StringLength(100,ErrorMessage = "suck")]
        public string? TiktokUserName { get; set; }
        public string? LocalPathStored { get; set; }
    }
}
