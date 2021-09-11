using System.Net;

namespace Sandbox
{
    public class TestingRestApi
    {
        private readonly string _url;
        private readonly WebClient _client;

        public TestingRestApi(string url)
        {
            _url = url;
            _client = new WebClient();

            _client.Headers.Add("FSPO", "true");
            _client.Headers.Add("Student", "Artamonov Artem");
        }

        public string Run(string endpoint, string a, string b)
        {
            SetParameters(a, b);

            var response = Execute(endpoint);

            return response;
        }

        private string Execute(string endpoint)
        {
            var response = _client.DownloadString(_url + endpoint);
            return response;
        }

        private void SetParameters(string a, string b)
        {
            _client.QueryString.Set("a", a);
            _client.QueryString.Set("b", b);
        }
    }
}
