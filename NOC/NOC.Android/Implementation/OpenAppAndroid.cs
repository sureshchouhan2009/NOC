using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Content.PM;
using NOC.Droid.Implementation;
using NOC.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(OpenAppAndroid))]
namespace NOC.Droid.Implementation
{
    public class OpenAppAndroid : IAppHandler
    {
        public Task<bool> LaunchApp(string packageName)
        {


            bool result = false;

            try
            {

                PackageManager pm = Android.App.Application.Context.PackageManager;

                if (IsAppInstalled(packageName))
                {

                    Intent intent = pm.GetLaunchIntentForPackage(packageName);
                    if (intent != null)
                    {

                        intent.SetFlags(ActivityFlags.NewTask);
                        Android.App.Application.Context.StartActivity(intent);
                    }
                }

                else
                {

                    Intent intent = pm.GetLaunchIntentForPackage("the package name of play store on your device");
                    if (intent != null)
                    {

                        intent.SetFlags(ActivityFlags.NewTask);
                        Android.App.Application.Context.StartActivity(intent);
                    }
                }
            }
            catch (ActivityNotFoundException)
            {
                result = false;
            }

            return Task.FromResult(result);
        }


        private bool IsAppInstalled(string packageName)
        {
            PackageManager pm = Android.App.Application.Context.PackageManager;
            bool installed = false;
            try
            {
                pm.GetPackageInfo(packageName, PackageInfoFlags.Activities);
                installed = true;
            }
            catch (PackageManager.NameNotFoundException e)
            {
                installed = false;
            }

            return installed;
        }

    }
}
