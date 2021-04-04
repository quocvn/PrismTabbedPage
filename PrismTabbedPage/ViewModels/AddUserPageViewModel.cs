using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Acr.UserDialogs;
using PrismTabbedPage.Helpers;
using PrismTabbedPage.Models;
using PrismTabbedPage.Resources;
using Xamarin.Forms;

namespace PrismTabbedPage.ViewModels
{
    public class AddUserPageViewModel : INotifyPropertyChanged
    {
        ImageModel imageModel;
        public ImageSource UserAvatar { get; set; }
        public User User { get; set; }
        public AddUserPageViewModel(User user)
        {
            imageModel = new ImageModel();
            UserAvatar = imageModel.UserAvatar;

            if (user != null)
            {
                User = user;
                FirstName = User.FirstName;
                LastName = User.LastName;
                Email = User.Email;
                TextButton = "Update User";
            }
            else
            {
                User = new User();
                TextButton = "Create User";
            }
        }

        #region Properties

        public string FirstName
        {
            get => User.FirstName;
            set
            {
                User.FirstName = value;
                RaisedOnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get => User.LastName;
            set
            {
                User.LastName = value;
                RaisedOnPropertyChanged("LastName");
            }
        }

        public string Email
        {
            get => User.Email;
            set
            {
                User.Email = value;
                RaisedOnPropertyChanged("Email");
            }
        }

        private string textButton { get; set; }
        public string TextButton
        {
            get => textButton;
            set
            {
                textButton = value;
                RaisedOnPropertyChanged("TextButton");
            }
        }

        #endregion

        public ICommand CreateUserClicked => new Command(() =>
        {
            if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(Email))
            {
                MessagingCenter.Send<User>(User, AppHelpers.AddUserKey);
            }
            else
            {
                AlertConfig alertConfig = new AlertConfig();
                alertConfig.SetOkText(AppResources.Close);
                alertConfig.SetTitle(AppResources.notification);
                alertConfig.SetMessage(AppResources.pleaseEnterInfo);
                UserDialogs.Instance.Alert(alertConfig);
            }
        });

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisedOnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
