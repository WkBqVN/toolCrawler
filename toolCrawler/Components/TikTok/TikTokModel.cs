using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Newtonsoft.Json;

namespace toolCrawler.Components.TikTok
{
    public class TikTokModel
    {
        [Required]
        [StringLength(100,ErrorMessage = "len")]
        public string? TiktokUserName { get; set; }
        public string? LocalPathStored { get; set; }
        //public string[]? ListVideoId { get; set; }
        public TikTokResponse? Obj { get; set; }
    }
}
