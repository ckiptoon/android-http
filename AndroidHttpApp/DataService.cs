using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AndroidHttpApp
{
    public class DataService : IDataService
    {
        HttpClient client;
        public List<Post> Posts { get; private set; }
        private const string postsUrl = "https://jsonplaceholder.typicode.com/posts";

        public DataService(HttpClient httpClient)
        {
            client = httpClient;
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<Post>> GetPostAsync()
        {
            Posts = new List<Post>();
            Uri uri = new Uri(postsUrl);

            try
            {
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Posts = JsonConvert.DeserializeObject<List<Post>>(content);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error Getting Posts: {ex.Message}");
            }

            return Posts;
        }

        public async Task SavePostAsync(Post post)
        {
            Uri uri = new Uri(postsUrl);
            try
            {
                var json = JsonConvert.SerializeObject(post);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine("Post successfully saved.");
                }

            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine($"Error Saving: {ex.Message}");
            }
        }

        public async Task DeletePostAsync(int id)
        {
            var uri = new Uri(postsUrl + $"/{id}");

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine("Post successfully deleted.");
                }
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine($"Error Saving: {ex.Message}");
            }
        }
    }
}