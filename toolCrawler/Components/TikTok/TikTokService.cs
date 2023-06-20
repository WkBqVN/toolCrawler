using System;
using System.Net;
using System.Text.Json;
using Newtonsoft.Json;
using toolCrawler.Lib;

namespace toolCrawler.Components.TikTok
{
    public class TikTokService
    {
        public bool CrawlData( string userName,string desPath )
        {
            APIWorker worker = new APIWorker();
            //worker.ProcessAPI(null);
            var m = GetUserInfo(userName,desPath);
            return true;
        }

        public async Task<TikTokModel> GetUserInfo(string userName, string desPath)
        {
            string videoBaseURL = "https://tiktok-video-no-watermark2.p.rapidapi.com/user/posts";
            string url = makeUrl(videoBaseURL, userName);
            var t = new TikTokModel();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    { "X-RapidAPI-Key", "b3470ef89emshccb2fbc24f3837bp108053jsn64a8bb6f104e" },
                    { "X-RapidAPI-Host", "tiktok-video-no-watermark2.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                t.TiktokUserName = response.Content.ToString();
                t.LocalPathStored = response.Content.ToString();
                var obj = JsonConvert.DeserializeObject<TikTokResponse>(body.ToString());
                t.Obj = obj;
                Console.WriteLine("---------->");
                Console.WriteLine(t.Obj?.code);
                Console.WriteLine(t.Obj?.msg);
                Console.WriteLine(t.Obj?.data?.videos);
		        for (int index = 0; index < t.Obj?.data?.videos?.Count; index++) {
                    var vid = t.Obj?.data?.videos?[index];
                    DownloadVideo(vid.play,desPath + vid.title + ".mp4");
		        }
            }
            return t;
        }
        public string makeUrl( string baseUrl, string source) {
            return baseUrl + "?" + "unique_id=" + source + "&count=1";
	    }
        public async void DownloadVideo(string path,string localPath) {
            var httpClient = new HttpClient();

            using (var stream = await httpClient.GetStreamAsync(path))
            {
                using (var fileStream = new FileStream(localPath, FileMode.CreateNew))
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
        }
    }
}
