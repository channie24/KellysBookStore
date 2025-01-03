namespace KellysBookStore.Service
{
    using System;
    using System.Net.Http;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using System.Runtime.InteropServices;
    using System.Text.Json.Serialization;
    using Newtonsoft.Json;

    public class GoogleBooksAPI
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task FetchBooks(string query)
        {
            string url = $"https://www.googleapis.com/books/v1/volumes?q={query}";
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var booksData = JsonConvert.DeserializeObject<GoogleBooksResponse>(content);

                Console.WriteLine("\nLatest Books from Google Books API:");
                foreach (var item in booksData?.Items ?? Enumerable.Empty<GoogleBookItem>())
                {
                    string authors = item.VolumeInfo.Authors != null ? string.Join(", ", item.VolumeInfo.Authors) : "Unknown";
                    Console.WriteLine($"- {item.VolumeInfo.Title} by {authors}");
                }
            }
            else
            {
                Console.WriteLine($"Failed to fetch books: {response.ReasonPhrase}");
            }
        }
    }

    // Classes for deserializing Google Books API response
    public class GoogleBooksResponse
    {
        public List<GoogleBookItem> Items { get; set; }
    }

    public class GoogleBookItem
    {
        public string kind { get; set; }

        public string id { get; set; }

        public string etag { get; set; }

        public string selfLink { get; set; }

        public GoogleBookVolumeInfo VolumeInfo { get; set; }
    }

    public class GoogleBookVolumeInfo
    {
        public string Title { get; set; }

        public List<string> Authors { get; set; }

        public string publisher { get; set; }

        public DateTime publishedDate { get; set; }

        public string description { get; set; }
    }

}
