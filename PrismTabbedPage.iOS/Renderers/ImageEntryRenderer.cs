using System;
using System.Drawing;
using CoreGraphics;
using UIKit;
using PrismTabbedPage.Controls;
using PrismTabbedPage.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntryWithImage), typeof(ImageEntryRenderer))]
namespace PrismTabbedPage.iOS.Renderers
{
    public class ImageEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            var element = (CustomEntryWithImage)this.Element;
            var textField = this.Control;
            if (!string.IsNullOrEmpty(element.Image))
            {
                switch (element.ImageAlignment)
                {
                    case ImageAlignment.Left:
                        textField.LeftViewMode = UITextFieldViewMode.Always;
                        textField.LeftView = GetImageView(element.Image, element.ImageHeight, element.ImageWidth);
                        // Padding right
                        textField.RightView = new UIView(new CGRect(0, 0, 10, 0));
                        textField.RightViewMode = UITextFieldViewMode.Always;
                        break;
                    case ImageAlignment.Right:
                        textField.RightViewMode = UITextFieldViewMode.Always;
                        textField.RightView = GetImageView(element.Image, element.ImageHeight, element.ImageWidth);
                        // Padding left
                        textField.LeftView = new UIView(new CGRect(0, 0, 10, 0));
                        textField.LeftViewMode = UITextFieldViewMode.Always;
                        break;
                }
            }
            else
            {
                textField.LeftViewMode = UITextFieldViewMode.Always;
                textField.RightViewMode = UITextFieldViewMode.Always;
                textField.LeftView = new UIView(new CGRect(0, 0, 15, 0));
                textField.RightView = new UIView(new CGRect(0, 0, 15, 0));
            }

            textField.BorderStyle = UITextBorderStyle.None;
            textField.Layer.CornerRadius = Convert.ToSingle(element.CornerRadius);
            textField.Layer.BorderWidth = element.BorderWidth;
            textField.Layer.BorderColor = element.BorderColor.ToCGColor();
            textField.BackgroundColor = UIColor.Clear;
            textField.ClipsToBounds = true;

            //CALayer bottomBorder = new CALayer
            //{
            //    Frame = new CGRect(0.0f, element.HeightRequest - 1, this.Frame.Width, 1.0f),
            //    BorderWidth = 2.0f,
            //    BorderColor = element.LineColor.ToCGColor()
            //};

            //textField.Layer.AddSublayer(bottomBorder);
            textField.Layer.MasksToBounds = true;
        }

        private UIView GetImageView(string imagePath, int height, int width)
        {
            var uiImageView = new UIImageView(UIImage.FromBundle(imagePath))
            {
                Frame = new RectangleF(10, 0, width, height)
            };
            UIView objLeftView = new UIView(new System.Drawing.Rectangle(0, 0, width + 15, height));
            objLeftView.AddSubview(uiImageView);

            return objLeftView;
        }
    }
}
