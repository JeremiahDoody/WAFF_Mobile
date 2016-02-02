using System;
using Android.Widget;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android;

namespace WAFF_Mobile
{

	public class HomeScreenAdapter : BaseAdapter<MainTableItem01> 
	{

		List<MainTableItem01> items;
		Activity context;

		public HomeScreenAdapter(Activity context, List<MainTableItem01> items) : base()
		{
			this.context = context;
			this.items = items;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override MainTableItem01 this[int position]
		{
			get { return items[position]; }
		}

		public override int Count
		{
			get { return items.Count; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = items[position];
			View view = convertView;
			if (view == null) // no view is re-usable, so create a new one
				view = context.LayoutInflater.Inflate(Resource.Layout.HomeRowLayout, null);
			view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Heading;
			view.FindViewById<TextView>(Resource.Id.Text2).Text = item.SubHeading;
			view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);
			return view;
		}
	}//end class
}//end namespace
