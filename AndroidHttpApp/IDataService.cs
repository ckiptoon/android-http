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
    public interface IDataService
    {
        Task<List<Post>> GetPostAsync();
        Task SavePostAsync(Post post);
        Task DeletePostAsync(int id);

    }
}