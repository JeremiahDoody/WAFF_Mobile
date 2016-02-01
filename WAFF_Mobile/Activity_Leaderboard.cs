
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WAFF_Mobile
{
	[Activity (Label = "Activity_Leaderboard")]			
	public class Activity_Leaderboard : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Leaderboard);
			//furthur code goes beyond here..

			//set back button
			//set buttons
			Button backButton = FindViewById<Button> (Resource.Id.leaderboard_backButton);

			//set eventListener
			backButton.Click += delegate {

				//Intent i = new Intent(this, typeof(MainActivity));

				Finish();

			};

			// Create your application here
		}
	}
}

