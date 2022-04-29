﻿using System;
using System.ComponentModel;
using NOC.Components;
using NOC.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]

namespace NOC.iOS.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            Control.Layer.BorderWidth = 0;
            //Control.BorderStyle = UITextBorderStyle.None;
          //  Control.BackgroundColor = UIColor.Clear ;
            
        }
    }
}
