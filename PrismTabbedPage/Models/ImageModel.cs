using System;
using System.Reflection;
using Xamarin.Forms;

namespace PrismTabbedPage.Models
{
    public class ImageModel
    {
        public ImageSource UserAvatar { get; set; }

        public ImageModel()
        {
            UserAvatar = ImageSource.FromResource("PrismTabbedPage.Images.user_default.png", typeof(App).GetTypeInfo().Assembly);
        }
    }
}
