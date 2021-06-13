using System;
using System.Collections.Generic;

namespace PrismTabbedPage.Models
{
    public class ImageSetting
    {
        public string SettingName { get; set; }
        public List<ImageList> Images { get; set; }
    }

    public class ImageList
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class Monkey
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
    }
}
