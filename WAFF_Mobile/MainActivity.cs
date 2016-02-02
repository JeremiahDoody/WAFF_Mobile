using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using Android.Graphics;

using Mono;

//import JSON packages
using Org.Json;
using static Org.Json.JSONException;
using static Org.Json.JSONTokener;


namespace WAFF_Mobile
{

	 

	[Activity (Label = "WAFF_Mobile", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
//		public struct Film{
//			public String name;
//			public String time;
//		}

	
		//private ArrayList tempList = new ArrayList();
		List<MainTableItem01> tempList = new List<MainTableItem01>();

		//List<Film> filmList = new List<Film>();
		//init buttons
		Button leaderboardButton, favoritesButton;
		//init views
		ScrollView scrollView;


		//temp data
		//Film first;
		//first.name = "";

		//init other global variables
		private int favoriteColorState = 0;
		//ConsoleColor favoriteButtonDefaultColor;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);


			//tempList.Add ("1. First movie.   50%");
			//tempList.Add ("2. Second movie.  50%");

			//set buttons
			leaderboardButton = FindViewById<Button> (Resource.Id.leaderboard_mainButton);

			leaderboardButton.Click  += delegate
			{
				Intent i = new Intent(this, typeof(Activity_Leaderboard));
				//go to Activity_Leaderboard.cs
				StartActivity(i);

			};//end listener



			//set views
			//scrollView = FindViewById<ScrollView> (Resource.Id.mainScrollView);


			int lbCount = 0;

			//create SYstem.Threading.Timer object. Acts as Updater for leaderboard button.
			Timer timer = new Timer((o) =>
			{
					RunOnUiThread(() =>
					{

							/*
							//set text
							leaderboardButton.Text = tempList[lbCount].;
							//change counter for next iteration
							lbCount++;
							//if too high set to 0.
							if(lbCount >= tempList.Count)
								lbCount = 0;

							Console.WriteLine("lbCount: " + lbCount);
							Console.WriteLine("message: %d" + tempList[lbCount]);
							*/
					});


			}, null, 0, 10000);


			favoritesButton = FindViewById<Button> (Resource.Id.favorites);
			//get starting color of favorite button (will be the default)
			//favoriteButtonDefaultColor = new SolidColorBrush(favoritesButton.Background);
			//now set to off option.
			//favoritesButton.Background = new SolidColorBrush(Colors.DarkGray);

			favoritesButton.Click += delegate
			{
				if(favoriteColorState == 0)
				{
					//favoritesButton.Background = favoriteButtonDefaultColor;
					var onButtonText = Resources.GetString(Resource.String.favOn);
					favoritesButton.Text = onButtonText;
					favoriteColorState = 1;
				}
				else if(favoriteColorState == 1)
				{
					//favoritesButton.Background = new SolidColorBrush(Colors.DarkGray);
					var offButtonText = Resources.GetString(Resource.String.favOff);
					favoritesButton.Text = offButtonText;
					favoriteColorState = 0;
				}
			};//end listener
				





			ListView listView = FindViewById<ListView>(Resource.Id.listView1);

			listView.Adapter = new HomeScreenAdapter(this, tempList);//, tableItems);

			Console.WriteLine ("listView height: " + listView.Height);

			listView.ItemClick += OnListItemClick;

			//Setup the demo data
			SetupDemoData ();


			for(int i = 0; i<=10; i++)
			{
				


			}//end temp for loop



		}//end onCreate() method

//		private void tmrUpdate(System.Object sender, System.EventArgs e)
//		{
//
//
//			for (int i = 0; i < tempList.Count; i++) 
//			{ 
//				RunOnUiThread(() => leaderboardButton.Text = tempList[i] );
//			}
//
//		}
//



		//used to add menu to main page
		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			menu.Add(0,0,0,"Options");
			//menu.add //Logout. NOTE: will need to hide logout buttons while user is not logged in, but will need to use another method to do so.
			return true;
		}

		//dictates what happens for those menu buttons
		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
			case 0: //Do stuff for button 0
				//TODO... add functinality for Options menu item
				return true;
			case 1: //Do stuff for button 1
				//TODO... add functinality for LogOut menu item
				return true;
			default:
				return base.OnOptionsItemSelected(item);
			}
		}//end OnOptionsItemSelected()

//////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Sets up temp demo data for tempList. Will be replaced later.
		/// </summary>
		private void SetupDemoData()
		{

			JSONArray array = new JSONArray(tempList);

			MainTableItem01 item0 = new MainTableItem01 ();
			item0.Heading = "This Tree Can Walk";
			item0.SubHeading = "15 minutes";
			item0.ImageResourceId = 2130837505;

			MainTableItem01 item1 = new MainTableItem01 ();
			item1.Heading = "Marry's Home Film";
			item1.SubHeading = "20 minutes";
			item1.ImageResourceId = 2130837505;



			tempList.Add (item0);
			tempList.Add (item1);


		}

////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Raises the list item click event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var listView = sender as ListView;
			var t = tempList[e.Position];
			Android.Widget.Toast.MakeText(this, t.Heading + " - Playing in 10 minutes.", Android.Widget.ToastLength.Short).Show();


		}


	}
}


