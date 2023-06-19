namespace toolCrawler.Lib
{
    public class APIModel
    {
        private Request? Request { get; set; }
        private Response? Response { get; set; }
    }
    public class Request
    {
        private string? Url { get; set; }
        private string? Method { get; set; }
        private string? Body { get; set; }
        private string? Header { get; set; }
    }
    public class Response
    {
        private string? ToString { get; set; }
    }
}
