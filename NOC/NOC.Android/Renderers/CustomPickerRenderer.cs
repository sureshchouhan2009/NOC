﻿using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using AndroidX.Core.Content;
using NOC.Components;
using NOC.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace NOC.Droid.Renderers
{
    //public class CustomPickerRenderer : PickerRenderer
    //{
    //    CustomPicker element;

    //    public CustomPickerRenderer(Context context) : base(context)
    //    {
    //    }
    //    protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
    //    {
    //        base.OnElementChanged(e);

    //        element = (CustomPicker)this.Element;

    //        if (Control != null && this.Element != null && !string.IsNullOrEmpty(element.Image))
    //            Control.Background = AddPickerStyles(element.Image);

    //    }

    //    public LayerDrawable AddPickerStyles(string imagePath)
    //    {
    //        ShapeDrawable border = new ShapeDrawable();
    //        border.Paint.Color = Android.Graphics.Color.Gray;
    //        border.SetPadding(10, 10, 10, 10);
    //        border.Paint.SetStyle(Paint.Style.Stroke);

    //        Drawable[] layers = { border, GetDrawable(imagePath) };
    //        LayerDrawable layerDrawable = new LayerDrawable(layers);
    //        layerDrawable.SetLayerInset(0, 0, 0, 0, 0);

    //        return layerDrawable;
    //    }

    //    private BitmapDrawable GetDrawable(string imagePath)
    //    {
    //        int resID = Resources.GetIdentifier(imagePath, "drawable", this.Context.PackageName);
    //        var drawable = ContextCompat.GetDrawable(this.Context, resID);
    //        var bitmap = ((BitmapDrawable)drawable).Bitmap;

    //        var result = new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, 70, 70, true));
    //        result.Gravity = Android.Views.GravityFlags.Right;

    //        return result;
    //    }

    //}


    public class CustomPickerRenderer : PickerRenderer
    {
        CustomPicker element;

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            element = (CustomPicker)this.Element;

            if (Control != null && this.Element != null && !string.IsNullOrEmpty(element.Image))
            {
                Control.Background = AddPickerStyles(element.Image);
            }

        }

        public LayerDrawable AddPickerStyles(string imagePath)
        {

            ShapeDrawable border = new ShapeDrawable();
            border.Paint.Color = Android.Graphics.Color.Gray;
            border.SetPadding(10, 10, 10, 10);
            border.Paint.SetStyle(Paint.Style.Stroke);
            Drawable[] layers = { border, GetDrawable(imagePath) };
            LayerDrawable layerDrawable = new LayerDrawable(layers);
            layerDrawable.SetLayerInset(0, 0, 0, 0, 0);

            return layerDrawable;
        }

        private BitmapDrawable GetDrawable(string imagePath)
        {
            int resID = Resources.GetIdentifier(imagePath.ToLower(), "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;

            var result = new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, 10, 10, true));
            result.Gravity = Android.Views.GravityFlags.Right;

            return result;
        }
    }
}
