using toolCrawler.Lib;

namespace toolCrawler.Components.TikTok
{
    public class TikTokService
    {
        public bool CrawlData(string sourceUrl, string desPath)
        {
            APIWorker worker = new APIWorker();
            worker.ProcessAPI(null);
            return true;
        }

        public async Task GetUserInfo()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tiktok-video-no-watermark2.p.rapidapi.com/user/info?unique_id=%40tiktok&user_id=107955"),
                Headers =
                {
                    { "X-RapidAPI-Key", "32d64590cemshdf9e2f09e142dd2p12615bjsnbb2dff66efb7" },
                    { "X-RapidAPI-Host", "tiktok-video-no-watermark2.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
            return Task;

        }
            }
}
