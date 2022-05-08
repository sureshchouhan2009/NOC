using System;
using CoreGraphics;
using NOC.Components;
using NOC.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace NOC.iOS.Renderers
{
	public class CustomPickerRenderer : PickerRenderer
	{
		//protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		//{
		//	base.OnElementChanged(e);

		//	var element = (CustomPicker)this.Element;

		//	if (this.Control != null && this.Element != null && !string.IsNullOrEmpty(element.Image))
		//	{
		//		var downarrow = UIImage.FromBundle(element.Image);
		//		Control.RightViewMode = UITextFieldViewMode.Always;
		//		Control.RightView = new UIImageView(downarrow);
		//	}
		//}

		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);

			var element = (CustomPicker)this.Element;

			if (this.Control != null && this.Element != null && !string.IsNullOrEmpty(element.Image))
			{
				//var downarrow = UIImage.FromBundle(element.Image);
				//Control.RightViewMode = UITextFieldViewMode.Always;
				//var imgView= new UIImageView(downarrow);
				//imgView.Frame= new CoreGraphics.CGRect(0.1, 0.1, 0.1, 0.1);
				//imgView.ContentMode = UIViewContentMode.ScaleAspectFit;
				//Control.RightView = imgView;


				var template = new UIView();
				template.Frame = new CGRect(0, 0, 10, 10);

				var image = new UIImageView();
				image.Frame = new CGRect(0, 0, 10, 10);
				image.Image = UIImage.FromBundle(element.Image);
				template.AddSubview(image);

				Control.RightViewMode = UITextFieldViewMode.Always;
				Control.RightView = template;


			}
		}
	}
}
