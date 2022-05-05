using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NOC.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NOC.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

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
            //    webView.Source = localHtmlViewSource;
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



        }


    }
}
