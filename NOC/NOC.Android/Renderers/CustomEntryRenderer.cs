using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NOC.Components;
using NOC.Droid.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]

namespace NOC.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
            }
        }
        //protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        //{
        //    base.OnElementChanged(e);
        //    if (e.OldElement == null)
        //    {
        //        var nativeEditText = (global::Android.Widget.EditText)Control;
        //        var shape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());
        //        shape.Paint.Color = Xamarin.Forms.Color.Gray.ToAndroid();
        //        shape.Paint.SetStyle(Paint.Style.Stroke);
        //        nativeEditText.Background = shape;
        //    }
        //}
    }
}