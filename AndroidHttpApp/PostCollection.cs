using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidHttpApp
{
    public class PostCollection
    {
        private List<Post> posts;
        // PostsRepository repository;
        IDataService dataService;
        HttpClient httpClient;

        public PostCollection(HttpClient httpClient)
        {
            posts = new List<Post>();
            this.httpClient = httpClient;
            dataService = new DataService(this.httpClient);
            LoadPosts();
            //LoadLocalPosts();
        }

        private async void LoadPosts()
        {
            var posts = await dataService.GetPostAsync();

            this.posts.AddRange(posts);

            System.Diagnostics.Debug.WriteLine("Posts No: " + this.posts[0].Title);
        }

        public int NumberPosts => posts.Count;

        public Post this[int position] => posts[position];

        private void LoadLocalPosts()
        {
            posts = new List<Post>();
            for (int i = 0; i < 10; i++)
            {
                Post post = new Post
                {
                    Id = i,
                    UserId = i,
                    Title = "Title " + i,
                    Body = "Post " + i + " Description"
                };

                posts.Add(post);
            }
           
        }
    }
}