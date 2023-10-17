using System;
using Foundation;
using Microsoft.Identity.Client;
using Prism;
using Prism.Ioc;
using UIKit;

namespace NOC.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate,NOC.Interfaces.IPlatform
    {
        



        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(this));
            return base.FinishedLaunching(app, options);
        }

        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            bool result = AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(url);
            return result || base.OpenUrl(app, url, options);
        }

        public IPublicClientApplication GetIdentityClient(string applicationId)
        {
            var identityClient = PublicClientApplicationBuilder.Create(applicationId)
                .WithIosKeychainSecurityGroup("com.microsoft.adalcache")
                .WithRedirectUri($"msal{applicationId}://auth")
                .Build();
            return identityClient;
        }
    }



    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}
