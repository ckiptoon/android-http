using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidHttpApp.Adapters;
using static Android.Support.V7.Widget.RecyclerView;
using V4Fragment = Android.Support.V4.App.Fragment;

namespace AndroidHttpApp.Fragments
{
    public class PostListFragment : V4Fragment
    {
        IDataService dataService;
        PostCollection collection;
        HttpClient httpClient;

        public PostListFragment()
        {
            httpClient = new HttpClient { MaxResponseContentBufferSize = 256000 };
            //this.dataService = new DataService(httpClient);
            //LoadPosts();
        }

        //private async void LoadPosts()
        //{
        //    collection = await this.dataService.GetPostAsync();
        //}

        public static PostListFragment NewInstance()
        {
            return new PostListFragment { Arguments = new Bundle() };
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.postlist_fragment, container, false);
            Button getPostsButton = view.FindViewById<Button>(Resource.Id.getPostsButton);

            var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView1);

            LayoutManager layoutManager = new LinearLayoutManager(Application.Context);
            PostCollection postCollection = new PostCollection(httpClient);

            //getPostsButton.Click += async (s, e) =>
            //{
            //    postCollection.Posts = await this.dataService.GetPostAsync();
            //};
            
            System.Diagnostics.Debug.WriteLine("No. of Posts: " + postCollection.NumberPosts);

            PostListAdapter adapter = new PostListAdapter(postCollection);
            adapter.ItemClick += (s, e) =>
            {
                Snackbar.Make(view, $"Post clicked: {e}", Snackbar.LengthShort)
                .SetAction("Action", (View.IOnClickListener)null)
                .Show();
            };

            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(adapter);

            return view;
        }
    }
}