using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace AndroidHttpApp.ViewHolders
{
    public class PostViewHolder : RecyclerView.ViewHolder
    {
        public TextView Title { get; set; }
        public TextView Body { get; set; }
        public TextView UserId { get; set; }
        public TextView Id { get; set; }

        public PostViewHolder(View itemView, Action<int> onClickListener) : base(itemView)
        {
            Title = itemView.FindViewById<TextView>(Resource.Id.titleTextView);
            Body = itemView.FindViewById<TextView>(Resource.Id.bodyTextView);
            UserId = itemView.FindViewById<TextView>(Resource.Id.userIdTextView);
            Id = itemView.FindViewById<TextView>(Resource.Id.idTextView);

            itemView.Click += (s, e) =>
            {
                onClickListener(base.LayoutPosition);
            };
        }
    }
}