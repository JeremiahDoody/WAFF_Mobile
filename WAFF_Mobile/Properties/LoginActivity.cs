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

namespace WAFF_Mobile.ViewModels
{
    public class LoginActivity : CompositeControl
    {
        async void OnLoginClicked (Object sender, EventArgs e)
        {
            MobileServiceUser user;

            //specifies the identity provider (google, facebook, etc.) for authentication
            user = await DependencyService.Get<IMobileClient>().LoginAsync(MobileServiceAuthenticationProvider.Google);
        }

        public async Task<MobileServiceUser> LoginAsync (MobileServiceAuthenticationProvider provider)
        {
            return await App.Client.LoginAsync(Forms.Context, provider);
        }

        async void OnLogoutClicked(Object sender, EventArgs e)
        {
            DependencyService.Get<IMobileClient>().Logout();
        }

        public void Logout()
        {
            CookieManager.Instance.RemoveAllCookie();
            App.Client.Logout();
        }
    }
}