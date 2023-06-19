using System.Net;

namespace toolCrawler.Lib
{
    public class APIWorker
    {
        //private static readonly HttpClient client = new HttpClient();

        public async void ProcessAPI(Request Request)
        {
            var client = new HttpClient();
            var url = "https://tiktok-video-no-watermark2.p.rapidapi.com/collection/list?unique_id=@super_sexy_gir&count=10&cursor=0";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    {"X-RapidAPI-Key", "b3470ef89emshccb2fbc24f3837bp108053jsn64a8bb6f104e" },
                    {"X-RapidAPI-Host", "tiktok-video-no-watermark2.p.rapidapi.comJ" }
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
            return ;
        }
    }
}
