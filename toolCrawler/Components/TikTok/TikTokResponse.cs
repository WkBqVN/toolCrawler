using System;
using Newtonsoft.Json;

namespace toolCrawler.Components.TikTok
{
	public class TikTokResponse
	{
        [JsonProperty("code")]
        public int code { get; set; }
        [JsonProperty("msg")]
        public string? msg { get; set; }
        [JsonProperty("prcoessd_time")]
        public double processed_time { get; set; }
        [JsonProperty("data")]
        public Data? data { get; set; }
        public class Data
        {
            [JsonProperty("videos")]
            public List<Video>? videos { get; set; }
            [JsonProperty("cursos")]
            public string? cursor { get; set; }
            [JsonProperty("hasMore")]
            public bool hasMore { get; set; }
        }
        public class Video
        {
            [JsonProperty("aweme_id")]
            public string? aweme_id { get; set; }
            [JsonProperty("video_id")]
            public string? video_id { get; set; }
            [JsonProperty("region")]
            public string? region { get; set; }
            [JsonProperty("title")]
            public string? title { get; set; }
            [JsonProperty("cover")]
            public string? cover { get; set; }
            [JsonProperty("origin_cover")]
            public string? origin_cover { get; set; }
            [JsonProperty("duration")]
            public int? duration { get; set; }
            [JsonProperty("play")]
            public string? play { get; set; }
            [JsonProperty("wmplay")]
            public string? wmplay { get; set; }
            [JsonProperty("size")]
            public int size { get; set; }
            [JsonProperty("wm_size")]
            public int wm_size { get; set; }
            [JsonProperty("music")]
            public string? music { get; set; }
            [JsonProperty("music_info")]
            public MusicInfo? music_info { get; set; }
            [JsonProperty("play_count")]
            public int? play_count { get; set; }
            [JsonProperty("digg_count")]
            public int? digg_count { get; set; }
            [JsonProperty("comment_count")]
            public int? comment_count { get; set; }
            [JsonProperty("share_count")]
            public int? share_count { get; set; }
            [JsonProperty("download_count")]
            public int? download_count { get; set; }
            [JsonProperty("collect_count")]
            public int? collect_count { get; set; }
            [JsonProperty("create_time")]
            public int? create_time { get; set; }
            [JsonProperty("anchors")]
            public object? anchors { get; set; }
            [JsonProperty("anchors_extras")]
            public string? anchors_extras { get; set; }
            [JsonProperty("is_ad")]
            public bool is_ad { get; set; }
            [JsonProperty("author")]
            public Author? author { get; set; }
            [JsonProperty("is_top")]
            public int is_top { get; set; }
        }
        public class Author
        {
            [JsonProperty("id")]
            public string? id { get; set; }
            [JsonProperty("unique_id")]
            public string? unique_id { get; set; }
            [JsonProperty("nickname")]
            public string? nickname { get; set; }
            [JsonProperty("avatar")]
            public string? avatar { get; set; }
        }
        public class MusicInfo
        {
            [JsonProperty("id")]
            public string? id { get; set; }
            [JsonProperty("title")]
            public string? title { get; set; }
            [JsonProperty("play")]
            public string? play { get; set; }
            [JsonProperty("cover")]
            public string? cover { get; set; }
            [JsonProperty("author")]
            public string? author { get; set; }
            [JsonProperty("original")]
            public bool original { get; set; }
            [JsonProperty("duration")]
            public int duration { get; set; }
            [JsonProperty("album")]
            public string? album { get; set; }
        }
    }
}

