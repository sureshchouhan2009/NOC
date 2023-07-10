using System;
using System.IO;
using Android.Content;
using NOC.Droid.Implementation;
using NOC.Interfaces;
using NOC.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidPdfFileDownloader))]

namespace NOC.Droid.Implementation
{
    public class AndroidPdfFileDownloader : IPdfFileDownloader
    {
        public void downloadLocalyStoredPdfFile(string fileName, byte[] data)
        {
            try
            {
                // Get my downloads path
                string filePath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, Android.OS.Environment.DirectoryDownloads);

                // Combine with filename
                string fullName = Path.Combine(filePath, fileName);

                // If the file exist on device delete it
                if (File.Exists(fullName))
                {
                  
                    // Note: In the second run of this method, the file exists
                    File.Delete(fullName);
                }

                // Write bytes on "My documents"
                File.WriteAllBytes(fullName, data);

                // Get the uri for the saved file
                //Android.Net.Uri file = AndroidX.Core.Content.FileProvider.GetUriForFile(
                //    Xamarin.Forms.Forms.Context,
                //    Xamarin.Forms.Forms.Context.PackageName + ".provider",
                //    new Java.IO.File(fileName));

                Android.Net.Uri file = Android.Net.Uri.Parse("content:///" + fullName);

              //  if(file.exi)


                Intent intent = new Intent(Intent.ActionView);
                intent.SetDataAndType(file, "application/pdf");
                intent.SetFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask | ActivityFlags.GrantReadUriPermission | ActivityFlags.NewTask);
                Xamarin.Forms.Forms.Context.ApplicationContext.StartActivity(intent);

               // return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message + ex.StackTrace);
              //  return false;
            }
        }

        //void IPdfFileDownloader.downloadLocalyStoredPdfFile(string localFilePath, string test)
        //{
        //    // Android.Net.Uri uri = Android.Net.Uri.Parse("file:///" + localFilePath);
        //    Android.Net.Uri uri = Android.Net.Uri.Parse("file:///" + localFilePath);


        //    Intent intent = new Intent(Intent.ActionView);
        //    intent.SetDataAndType(uri, "application/pdf");
        //    intent.SetFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);

        //    try
        //    {
        //        Xamarin.Forms.Forms.Context.StartActivity(intent);
        //    }
        //    catch (Exception ex)
        //    {
        //       // Toast.MakeText(Xamarin.Forms.Forms.Context, "No Application Available to View PDF", ToastLength.Short).Show();
        //    }
        //}
    }
}
