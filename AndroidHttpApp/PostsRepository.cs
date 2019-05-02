using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidHttpApp
{
    public class PostsRepository
    {
        IDataService dataService;

        public PostsRepository(IDataService dataService)
        {
            this.dataService = dataService;
        }

        public Task<List<Post>> GetPostsAsync()
        {
            return this.dataService.GetPostAsync();
        }

        public Task SavePostAsync(Post post)
        {
            return this.dataService.SavePostAsync(post);
        }

        public Task DeletePostAsync(int id)
        {
            return this.dataService.DeletePostAsync(id);
        }
    }
}