using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NOC.Interfaces;
using NOC.Utility;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NOC.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            try
            {

                InitializeComponent();


                //Task.Run(async () => await BackgroundMethodAsync());



            }
            catch (Exception ex)
            {

            }
            #region Tried Code

            //webView.EvaluateJavaScriptAsync()

            //          var htmlSource = new HtmlWebViewSource();
            //          htmlSource.Html = @"<html><body>
            //<h1>Xamarin.Forms</h1>
            //<p>Welcome to WebView.</p>
            //</body></html>";
            //          webView.Source = htmlSource;

            //try
            //{

            //    Task.Run(async () => {
            //        var fileName = "index.html";
            //        using (var stream = await FileSystem.OpenAppPackageFileAsync(fileName))
            //        {
            //            using (var reader = new StreamReader(stream))
            //            {
            //                var fileContents = await reader.ReadToEndAsync();
            //            }
            //        }
            //    });

            //    // Use DI function to get the BaseUrl for the platform
            //    var baseUrl = DependencyService.Get<IBaseUrl>().Get();

            //    // You could append subfolders here if you don't 
            //    // want all the HTML files mixed with other resources:
            //    // var baseUrl = System.IO.Path.Combine(DependencyService.Get<IBaseUrl>().Get(), "subfolder");

            //    // Define the location of your initial HTML page using the base url
            //    var initialHtmlPath = System.IO.Path.Combine(baseUrl, "index.html");

            //    // Create the viewsource, loading the first HTML file as a string
            //    var localHtmlViewSource = new HtmlWebViewSource();
            //    localHtmlViewSource.BaseUrl = baseUrl;
            //    //localHtmlViewSource.Html = System.IO.File.ReadAllText(initialHtmlPath);

            //    // Set the webview to use the local source
            //webView.Source = localHtmlViewSource;
            // webView.EvaluateJavaScriptAsync("");
            //}
            //catch (Exception ex)
            //{
            //    Task.Run(async () => {
            //        var fileName = "mybundledfile.txt";
            //        using (var stream = await FileSystem.OpenAppPackageFileAsync(fileName))
            //        {
            //            using (var reader = new StreamReader(stream))
            //            {
            //                var fileContents = await reader.ReadToEndAsync();
            //            }
            //        }
            //    });

            //}
            #endregion
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await BackgroundMethodAsync();
        }

        private async Task<bool> BackgroundMethodAsync()
        {
            try
            {
                var fileName = "index.html";
                HtmlWebViewSource htmlWebViewSource = new HtmlWebViewSource();
                var token = Session.Instance.Token;
                var TransactionID = Session.Instance.CurrentTransaction.Transaction.TransactionID;
               
                int roleID = 1;
                using (var stream = await FileSystem.OpenAppPackageFileAsync(fileName))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string htmlString = await reader.ReadToEndAsync();
                        string replace1 = htmlString.Replace("dynamicTransactionID", TransactionID.ToString());
                        string replace2 = replace1.Replace("dynamicRoleID", roleID.ToString());
                        string replace3 = replace2.Replace("dynamicTokenID", Session.Instance.Token);
                        webView.Source = new HtmlWebViewSource { Html = replace3 };
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
