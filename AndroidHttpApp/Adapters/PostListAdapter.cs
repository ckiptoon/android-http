using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using AndroidHttpApp.ViewHolders;
using static Android.Support.V7.Widget.RecyclerView;

namespace AndroidHttpApp.Adapters
{
    public class PostListAdapter : RecyclerView.Adapter
    {
        PostCollection collection;
        public event EventHandler<int> ItemClick;

        public PostListAdapter(PostCollection collection)
        {
            this.collection = collection;
        }

        public override int ItemCount => collection.NumberPosts;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PostViewHolder viewHolder = holder as PostViewHolder;
            viewHolder.Title.Text = collection[position].Title;
            viewHolder.Body.Text = collection[position].Body;
            viewHolder.Id.Text = (collection[position].Id).ToString();
            viewHolder.UserId.Text = (collection[position].UserId).ToString();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.postcardview, parent, false);
            PostViewHolder postViewHolder = new PostViewHolder(itemView, onClick);

            return postViewHolder;
        }

        private void onClick(int position)
        {
            //Toast.MakeText(Application.Context, $"Post position: {position}", ToastLength.Short);
            ItemClick?.Invoke(this, position);
        }
    }
}