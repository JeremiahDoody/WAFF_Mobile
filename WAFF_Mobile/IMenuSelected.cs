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
    public interface IMenuSelected
    {
        void OnMenuSelected(string text);
    }
}