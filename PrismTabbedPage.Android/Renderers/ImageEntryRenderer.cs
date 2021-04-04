using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using AndroidX.Core.Content;
using PrismTabbedPage.Controls;
using PrismTabbedPage.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntryWithImage), typeof(ImageEntryRenderer))]
namespace PrismTabbedPage.Droid.Renderers
{
    public class ImageEntryRenderer : EntryRenderer
    {
        CustomEntryWithImage element;

        public ImageEntryRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            element = (CustomEntryWithImage)this.Element;

            var editText = this.Control;
            if (!string.IsNullOrEmpty(element.Image))
            {
                switch (element.ImageAlignment)
                {
                    case ImageAlignment.Left:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.Image), null, null, null);
                        break;
                    case ImageAlignment.Right:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(element.Image), null);
                        break;
                }
            }

            // creating gradient drawable for the curved background
            var _gradientBackground = new GradientDrawable();
            _gradientBackground.SetShape(ShapeType.Rectangle);
            _gradientBackground.SetColor(element.BackgroundColor.ToAndroid());

            // Thickness of the stroke line
            _gradientBackground.SetStroke(element.BorderWidth, element.BorderColor.ToAndroid());

            // Radius for the curves
            _gradientBackground.SetCornerRadius(
                DpToPixels(this.Context, Convert.ToSingle(element.CornerRadius)));

            // set the background of the
            editText.SetBackground(_gradientBackground);

            // Set padding for the internal text from border
            editText.SetPadding(
                (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingTop,
                (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingBottom);

            // Padding image icon
            editText.CompoundDrawablePadding = 25;

            //editText.Background.SetColorFilter(element.LineColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
        }

        private BitmapDrawable GetDrawable(string imageEntryImage)
        {
            int resID = Resources.GetIdentifier(imageEntryImage, "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;

            return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, element.ImageWidth * 1, element.ImageHeight * 1, true));
        }

        private static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}
