using System;
using System.Net;
using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Microsoft.Identity.Client;
using NOC.Constants;
using NOC.Service;
using Plugin.CurrentActivity;
using Prism;
using Prism.AppModel;
using Prism.Ioc;
using Xamarin.Forms;

namespace NOC.Droid
{
    [Activity(Theme = "@style/MainTheme",
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity   ,Interfaces.IPlatform
    {
       

        protected override void OnCreate(Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            DependencyService.Register<IParentWindowLocatorService, AndroidParentWindowLocatorService>();

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            UserDialogs.Init(this);
            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(this));
           
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public IPublicClientApplication GetIdentityClient(string applicationId) //.WithRedirectUri($"msauth://ae.etihadrail.enoc/VzSiQcXRmi2kyjzcA%2BmYLEtbGVs%3D")
        {
            //var identityClient = PublicClientApplicationBuilder.Create(applicationId)
            //    .WithRedirectUri($"msal{applicationId}://auth")
            //     .WithAuthority(AzureCloudInstance.AzurePublic, "common")
            //     .WithParentActivityOrWindow(() => this)
            //.Build();

              string authurl = "https://login.microsoftonline.com/" + Constant.TenantID;

            var identityClient=   PublicClientApplicationBuilder
        .Create(applicationId)
        .WithRedirectUri($"msal{applicationId}://auth")// Replace with actual redirect URI
        .WithAuthority(authurl)
        .WithParentActivityOrWindow(() => this)
        .Build();

            return identityClient;
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            // Return control to MSAL
            AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(requestCode, resultCode, data);
        }


    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}

