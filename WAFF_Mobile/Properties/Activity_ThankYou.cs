
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

using Xamarin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WAFF_Mobile
{
	[Activity (Label = "Activity_ThankYou")]	
    

	public class Fragment_ThankYou : Activity
	{
        /*Code to include a Context Menu for a particular View or Fragment
        this.RegisterForContextMenu (ThankYou); //optional use for Context Menu of a View
        
        public override void OnCreateContextMenu (IContextMenu Menu, View view, IContextMenuContextMenuInfo menuInfo){
            base.OnCreateContextMenu(menu, view, menuInfo);
            MenuInflater.Inflate(Resource.Menu.Main_Options, menu);}
        
        public override bool OnContextItemSelected (IMenuItem item){
            if (item.ItemId == Resource.Id.action_refresh){
                //this code is useful for context menus within a view or fragment, must set the RegisterForContextMenu of the vew first
                return true;
            }
            return base.OnContextItemSelected(item);
        }
        */
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.ThankYou);

			// Create your fragment here
		}			
	}
}

