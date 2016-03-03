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

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform;

namespace WAFF_Mobile
{
    public class Navigation : MasterDetailPage
    {
        Navigation masterPage;

        public Navigation()
        {
            masterPage = new Navigation();
            Master = masterPage;
            Detail = new NavigationPage(new Main());
        }
    }
}