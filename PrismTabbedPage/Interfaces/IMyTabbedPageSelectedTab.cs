using System;
namespace PrismTabbedPage.Interfaces
{
    public interface IMyTabbedPageSelectedTab
    {
        int SelectedTab { get; set; }

        void SetSelectedTab(int tabIndex);
    }
}
