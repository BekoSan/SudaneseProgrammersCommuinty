using System.Net.Http;
using System.Net.Http.Headers;

namespace SudaneseProgComLibrary
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static string apiUrl = "http://localhost:52891/api";

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}