using System;
using Android.Widget;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android;
using Android.Graphics;

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

			Console.WriteLine ("-------------------------------");
			Console.WriteLine ("HomeScreenAdapter >>HomeScreenAdapter() >> context: " + context);
			foreach (MainTableItem01 mt in items) 
				Console.WriteLine ("HomeScreenAdapter >>HomeScreenAdapter() >> mt Film Name: " + mt.Name + ". FilmID: " + mt.FilmID);
			Console.WriteLine ("-------------------------------");

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
			var item = this.items[position];
			var view = convertView;//View

			if (view == null)  // no view is re-usable, so create a new one
			{
//				
				Console.Write("view was null.");
				//view = context.LayoutInflater.Inflate(Resource.Layout.HomeRowLayout, null);
				view = context.LayoutInflater.Inflate (Resource.Layout.HomeRowLayout, parent, false);
			}
//			view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Heading;
//			view.FindViewById<TextView>(Resource.Id.Text2).Text = item.SubHeading;
//			view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);
			view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Name;
			view.FindViewById<TextView>(Resource.Id.Text2).Text = item.Length;
			//view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(Resource.Drawable.star_off);

			Console.WriteLine ("HomeScreenAdapter >> GetView >> ImageButton #" + position + " item.Name:" + item.Name + ".");

			ImageButton imgButton = view.FindViewById<ImageButton>(Resource.Id.favorite_button);
			imgButton.Focusable = false;
			imgButton.FocusableInTouchMode = false;
			imgButton.Clickable = true;
			imgButton.Click => 
			{




				
			
			
			
			
			
				//Android.Widget.Toast.MakeText (context, item.FilmID + " | Name for film: " + item.Name, Android.Widget.ToastLength.Short).Show ();
			
				
			//imgButton.Click += (sender, args) => 
			
				//Colors:
				//Regular row gray: (157,157,163)
				//Yellowish row:    (188,185,133)

				//Console.WriteLine ("HomeScreenAdapter >> GetView >> ImageButton " + position + " clicked. Favorited: " + item.Favorited);


				//Android.Widget.Toast.MakeText(context, item.FilmID + " | Name for film: " + item.Name, Android.Widget.ToastLength.Short).Show();
				/*
				if(item.Favorited == false)//catch null first
				{
					imgButton.SetImageResource(Resource.Drawable.star_on);
					item.Favorited = true;
					view.SetBackgroundColor(Color.Rgb(188,185,133));
					//Android.Widget.Toast.MakeText(Activity, item.Name + " removed from Favorites!", Android.Widget.ToastLength.Short).Show();
				}//end if
				else if (item.Favorited)
				{
					imgButton.SetImageResource(Resource.Drawable.star_off);
					item.Favorited = false;
					view.SetBackgroundColor(Color.Rgb(157,157,163));
					//Android.Widget.Toast.MakeText(typeof(MainActivity), item.Name + " added to Favorites!", Android.Widget.ToastLength.Short).Show();
				}//end else if
				*/




				//adding overlapping form controls
				});


			//return the view
			return view;

		}//end GetView() function


		private void ToJson()
		{}

	}//end class
}//end namespace
