using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Threading;
using Mono;
//using System.Windows.Media;
using Android.Graphics.Drawables;
using Android.Graphics;




namespace WAFF_Mobile
{

	 

	[Activity (Label = "WAFF_Mobile", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
//		public struct Film{
//			public String name;
//			public String time;
//		}

		//int count = 1;
		List<String> tempList = new List<String>();
		//List<Film> filmList = new List<Film>();
		//init buttons
		Button leaderboardButton, favoritesButton;
		//init views
		ScrollView scrollView;


		//temp data
		//Film first;
		//first.name = "";

		//init other global variables
		int favoriteColorState = 0;
		//ConsoleColor favoriteButtonDefaultColor;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			tempList.Add ("1. First movie.   50%");
			tempList.Add ("2. Second movie.  50%");

			//set buttons
			leaderboardButton = FindViewById<Button> (Resource.Id.leaderboard);
			//set views
			scrollView = FindViewById<ScrollView> (Resource.Id.mainScrollView);

			int lbCount = 0;

			//create SYstem.Threading.Timer object. Acts as Updater for leaderboard button.
			Timer timer = new Timer((o) =>
			{
					RunOnUiThread(() =>
					{


							//set text
							leaderboardButton.Text = tempList[lbCount];
							//change counter for next iteration
							lbCount++;
							//if too high set to 0.
							if(lbCount >= tempList.Count)
								lbCount = 0;

							Console.WriteLine("lbCount: " + lbCount);
							Console.WriteLine("message: %d" + tempList[lbCount]);
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

			//*********TESTING**************

//			// Get our button from the layout resource,
//			// and attach an event to it
//			Button button = FindViewById<Button> (Resource.Id.myButton);
//			
//			button.Click += delegate {
//				button.Text = string.Format ("{0} clicks!", count++);
//			};



			// Creating a new RelativeLayout
			//new RelativeLayout(this);
			//relativeLayout.RemoveView ((ScrollView)relativeLayout.Parent);

			// Defining the RelativeLayout layout parameters.
			// In this case I want to fill its parent
			//RelativeLayout.LayoutParams rlp = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);

			//rlp.AddRule (LayoutRules.);
				//RelativeLayout.LayoutParams.FILL_PARENT,
				//RelativeLayout.LayoutParams.FILL_PARENT);




			//lp.addRule(RelativeLayout.CENTER_IN_PARENT);



			// Setting the RelativeLayout as our content view
			//SetContentView(relativeLayout, lp);

			LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.linearLayout2);

			for(int i = 0; i<=10; i++)
			{
				
				Button btn1 = new Button (this);
				btn1.Text = "btn" + i;
				btn1.Id = i;

				// Defining the layout parameters of the TextView
				LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(
					LinearLayout.LayoutParams.WrapContent,
					LinearLayout.LayoutParams.WrapContent);



				// Setting the parameters on the TextView
				btn1.LayoutParameters = lp;

				//set layout orientation
				linearLayout.Orientation = Orientation.Vertical;

				//ctrl-alt-space after term for auto import

				//set border
				GradientDrawable border = new GradientDrawable();
				border.SetColor(0x7FFFFFFF); //white background
				border.SetStroke(1, Color.Black); //black border with full opacity//0xFF000000
				if(Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.JellyBean) 
				{
					linearLayout.SetBackgroundDrawable(border);
				} 
				else 
				{
					linearLayout.SetBackgroundDrawable(border);
				}

				// Adding the TextView to the RelativeLayout as a child
				linearLayout.AddView(btn1);

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
			return true;
		}


		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
			case 0: //Do stuff for button 0
				return true;
			case 1: //Do stuff for button 1
				return true;
			default:
				return base.OnOptionsItemSelected(item);
			}
		}

	}
}


