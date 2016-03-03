using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Support.V7.AppCompat;

using Xamarin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


//import JSON packages
using Org.Json;
//using Org.Json.JSONException;
//using Org.Json.JSONTokener;


namespace WAFF_Mobile
{
	[Activity (Label = "WAFF_Mobile", MainLauncher = true, Icon = "@drawable/icon", Theme="@style/Theme.AppCompatActivity", ParentActivity = typeof(MainActivity))]
    [Register ("com.WAFF_Mobile.MainActivity")] //sets the source activity for the action bar
    [Register("android/app/ActionBar",DoNotGenerateAcw=true)] 
    [MetaData ("android.support.PARENT_ACTIVITY", Value="WAFF_Mobile.MainActivity")] //Sets the action bars Parent Activity for older versions < v4.1
	public class MainActivity : Activity
	{
        //public override Intent SupportParentActivityIntent { get { return new Intent(this, typeof(MainActivity)); } }

//		public struct Film{
//			public String name;
//			public String time;
//		}
		public static MainActivity mainActivity; 
	
		//private ArrayList tempList = new ArrayList();
		List<MainTableItem01> tempList = new List<MainTableItem01>();
		HomeScreenAdapter adapter;

		//List<Film> filmList = new List<Film>();
		//init buttons
		Xamarin.Forms.Button leaderboardButton, favoritesButton;

		//init other global variables
		private int favoriteColorState = 0;
		//ConsoleColor favoriteButtonDefaultColor;

        /*public override ActionBar ActionBar
        {
            get{return base.ActionBar;}

        }*/

        protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate (bundle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            //sets the Toolbar/ActionBar with backward compatibility
            Android.Widget.Toolbar waffToolbar = (Toolbar)FindViewById(Resource.Id.WAFF_toolbar);
            SetActionBar(waffToolbar);

			string title = "World Arts Film Festival " + DateTime.Now.Year.ToString();
			this.Title = title;

            //Xamarin built-in Navigation Bar using crosslight reference
            //this.ActionBar.Title = FindViewById(Resource.Id.action_bar_title);
            //SupportActionBar = FindViewById(Resource.Id.); //this doesn't appear to be supported...ironic

			//tempList.Add ("1. First movie.   50%");
			//tempList.Add ("2. Second movie.  50%");

			//set buttons
			var leaderboardButton = FindViewById<Android.Widget.Button> (Resource.Id.leaderboard_mainButton);

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

							string output = (lbCount+1) + ". " + tempList[lbCount].Name;
							//set text
							leaderboardButton.Text = output;
							//change counter for next iteration
							lbCount++;
							//if too high set to 0.
							if(lbCount >= tempList.Count)
								lbCount = 0;

							Console.WriteLine("lbCount: " + lbCount);
							Console.WriteLine("message: " + output);

					});


			}, null, 0, 10000);


			var favoritesButton = FindViewById<Android.Widget.Button> (Resource.Id.favorite_button);
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
				


			//Setup the demo data
			SetupDemoData ();

			//setup list view ref
		    Android.Widget.ListView listView = FindViewById<Android.Widget.ListView>(Resource.Id.listView1);

//			foreach (MainTableItem01 mt in tempList) {
//
//				Console.WriteLine ("MainActivity >> OnCreate() >> mt Film Name: " + mt.Name + ". FilmID: " + mt.FilmID);
//
//			}

			//set up adapter
			adapter = new HomeScreenAdapter(this, tempList);//(this, tableItems);
			listView.Adapter = adapter;
			adapter.NotifyDataSetChanged ();
			//listView.Adapter = new HomeScreenAdapter(this, tempList);
			Console.WriteLine ("listView height: " + listView.Height);

			listView.ItemClick += OnListItemClick;//ItemClick
			//View view = adapter.GetView();
			//get the listView
			//get row clicked
			//get button clicked

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

		//used to add menu to main page
		public override bool OnCreateOptionsMenu(IMenu menu)
		{
            MenuInflater.Inflate(Resource.Menu.Options, menu);
			menu.Add(0,0,0,"Favorites");
			menu.Add(1,1,1,"Refresh");
            menu.Add(2, 2, 2, "Settings");
			menu.Add (0, 3, 3, "Uninstall");
			return true;
		}

		//dictates what happens for those menu buttons
		public override bool OnOptionsItemSelected(IMenuItem item)
		{
          switch (item.ItemId)
			{
				case Resource.Id.action_favorites:
                    //mark the current item as favorite
					return true;
				case Resource.Id.action_refresh: //allows the user to refresh
                    //refresh the current 
					return true;
              case Resource.Id.action_settings:
                    //show the app settings UI
                    return true;
              case Resource.Id.action_uninstall:
                    //run the installation package
                    return true;
				default:
					return base.OnOptionsItemSelected(item);
			}
			return base.OnOptionsItemSelected(item);
		}//end OnOptionsItemSelected()


//////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Sets up temp demo data for tempList. Will be replaced later.
		/// </summary>
		private void SetupDemoData()
		{

			JSONArray array = new JSONArray(tempList);

			MainTableItem01 item0 = new MainTableItem01 ();
			item0.FilmID = 0;
			item0.Name = "This Tree Can Walk";
			item0.Length = "15 minutes";
			item0.Favorited = false;

			MainTableItem01 item1 = new MainTableItem01 ();
			item1.FilmID = 1;
			item1.Name = "Mary's Home Film";
			item1.Length = "20 minutes";
			item1.Favorited = false;

			MainTableItem01 item2 = new MainTableItem01 ();
			item2.FilmID = 2;
			item2.Name = "Not Star Wars";
			item2.Length = "20 minutes";
			item2.Favorited = false;

			MainTableItem01 item3 = new MainTableItem01 ();
			item3.FilmID = 3;
			item3.Name = "Variable Film";
			item3.Length = "20 minutes";
			item3.Favorited = false;

			MainTableItem01 item4 = new MainTableItem01 ();
			item4.FilmID = 4;
			item4.Name = "Once Upon a SkyScrapper";
			item4.Length = "20 minutes";
			item4.Favorited = false;

			MainTableItem01 item5 = new MainTableItem01 ();
			item5.FilmID = 5;
			item5.Name = "This Was A Film";
			item5.Length = "1 Hour";
			item5.Favorited = false;

			MainTableItem01 item6 = new MainTableItem01 ();
			item6.FilmID = 6;
			item6.Name = "Baking With Lily";
			item6.Length = "10 Hours";
			item6.Favorited = false;

			MainTableItem01 item7 = new MainTableItem01 ();
			item7.FilmID = 7;
			item7.Name = "There and Back";
			item7.Length = "1:00PM - 2:00PM";
			item7.Favorited = false;

			tempList.Add (item0);
			tempList.Add (item1);
			tempList.Add (item2);
			tempList.Add (item3);
			tempList.Add (item4);
			tempList.Add (item5);
			tempList.Add (item6);
			tempList.Add (item7);




//			adapter.NotifyDataSetChanged ();

		}//end SetupDemoData() function

////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Raises the list item click event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{

			Console.WriteLine ("OnListItemClick >> In OnListItemClick");
			var listView = sender as Xamarin.Forms.ListView;
			var t = tempList[e.Position];
			Android.Widget.Toast.MakeText(this, t.Name + " - Playing in 10 minutes.", Android.Widget.ToastLength.Short).Show();


		}


	}
}


