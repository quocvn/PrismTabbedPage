using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Newtonsoft.Json;
using PrismTabbedPage.Helpers;
using PrismTabbedPage.Models;
using PrismTabbedPage.Resources;
using Xamarin.Forms;

namespace PrismTabbedPage.Services
{
    public class UserServices
    {
        HttpClient httpClient = new HttpClient();

        public UserServices()
        {
            httpClient = new HttpClient();
        }

        public static async Task<ObservableCollection<User>> GetUserList()
        {
            string url = "https://reqres.in/api/users?delay=1";
            if (AppHelpers.IsHaveInternet() && await AppHelpers.IsHostAvailable("https://reqres.in/"))
            {
                UserDialogs.Instance.ShowLoading(AppResources.PleaseWait);
                using (var client = new HttpClient())
                {
                    try
                    {
                        UserResponse taskResult = new UserResponse();

                        var response = await client.GetAsync(url);
                        if (response.IsSuccessStatusCode)
                        {
                            var str = await response.Content.ReadAsStringAsync();
                            taskResult = JsonConvert.DeserializeObject<UserResponse>(str);
                            UserDialogs.Instance.HideLoading();
                        }
                        else
                        {
                            UserDialogs.Instance.HideLoading();
                        }

                        return taskResult.UserList;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception", e);
                    }
                }
            }
            else
            {
                ((App)Application.Current).ShowAlertInternet();
            }

            return new ObservableCollection<User>();
        }
    }
}
