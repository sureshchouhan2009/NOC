using System;
using System.IO;
using Android.Content.Res;
using NOC.Droid.Implementation;
using NOC.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(MapBaseUrl_Android))]
namespace NOC.Droid.Implementation
{
    public class MapBaseUrl_Android : IBaseUrl
    {
        public string Get()
        {
            return "file:///android_asset/";

            //string content;
            //AssetManager assets = this.Assets;
            //using (StreamReader sr = new StreamReader(assets.Open("read_asset.txt")))
            //{
            //    content = sr.ReadToEnd();
            //}
        }
    }
}
