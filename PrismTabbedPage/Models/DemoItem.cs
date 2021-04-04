using System;
namespace PrismTabbedPage.Models
{
    public class DemoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position {
            get => Name + " Demo";
            set { }
        }
    }
}
