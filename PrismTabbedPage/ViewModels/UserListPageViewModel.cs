using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using PrismTabbedPage.Helpers;
using PrismTabbedPage.Models;
using PrismTabbedPage.Resources;
using PrismTabbedPage.Services;
using PrismTabbedPage.Views.Account;
using Xamarin.Forms;

namespace PrismTabbedPage.ViewModels
{
    public class UserListPageViewModel : INotifyPropertyChanged
    {
        private IUserDialogs UserDialog { get; }
        public ObservableCollection<User> UserList { get; set; }

        #region Properties
        public UserServices userServices { get; private set; }

        public ObservableCollection<Grouping<string, User>> _usersGrouped { get; set; }
        public ObservableCollection<Grouping<string, User>> UserListGrouped
        {
            get { return _usersGrouped; }
            set
            {
                _usersGrouped = value;
                //OnPropertyChanged();
                RaisedOnPropertyChanged("UserListGrouped");
            }
        }
        public bool IsBusy { get; set; }

        public int userCount { get; set; }
        public int UserCount
        {
            get { return userCount = UserList?.Count ?? 0; }
            set
            {
                userCount = value;
                RaisedOnPropertyChanged();
            }
        }

        #endregion

        #region Constructor
        public UserListPageViewModel()
        {
            userServices = new UserServices();
        }

        public UserListPageViewModel(IUserDialogs dialogs)
        {
            UserDialog = dialogs;
            // Setup web requests and such
            RetrieveDataAsync();

            MessagingCenter.Subscribe<User>(this, AppHelpers.AddUserKey, (user) =>
            {
                if (user != null)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if (user.Id > 0)
                        {
                            var index = UserList.IndexOf(user);
                            UserList[index] = user;
                        }
                        else
                        {
                            int userID = UserList.Count() + 1;
                            user.Id = userID;
                            UserList.Add(user);
                        }

                        UserListGrouped = UserHelper.GetUsersGrouped(UserList);
                        Application.Current.MainPage.Navigation.PopAsync();
                    });
                }
            });
        }
        #endregion

        #region Method

        public async void RetrieveDataAsync()
        {
            UserList = await UserServices.GetUserList();
            UserListGrouped = UserHelper.GetUsersGrouped(UserList);
        }

        private async Task DeleteUserAsync(User user)
        {
            var result = await UserDialog.ConfirmAsync(
                string.Format(AppResources.ConfirmDelete, user.FullName),
                AppResources.notification,
                okText: AppResources.oKText,
                cancelText: AppResources.cancelText);

            if (result) // OK
            {
                UserList.Remove(user);
                // Update user list group
                UserListGrouped = UserHelper.GetUsersGrouped(UserList);
            }
        }

        private async Task EditUserAsync(User user)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddUserPage(user));
            Console.WriteLine(user);
        }

        #endregion

        #region Events

        private ICommand deleteClicked;
        public ICommand DeleteClicked => deleteClicked ?? (deleteClicked = new Command<User>((userItem) =>
        {
            _ = DeleteUserAsync(userItem);
        }));

        private ICommand editClicked;
        public ICommand EditClicked => editClicked ?? (editClicked = new Command<User>((userItem) =>
        {
            _ = EditUserAsync(userItem);
        }));

        public ICommand SearchCommand => new Command<string>((string query) =>
        {
            var normalizedQuery = query?.ToLower() ?? "";
            var newSearchList = UserList.Where(user => user.FullName.ToLowerInvariant().Contains(normalizedQuery)).ToList();
            UserListGrouped = UserHelper.GetUsersGrouped(new ObservableCollection<User>(newSearchList));
        });

        public ICommand AddUserClicked => new Command(async () =>
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddUserPage());
        });

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisedOnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
