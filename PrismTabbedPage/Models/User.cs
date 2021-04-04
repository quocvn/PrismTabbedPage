using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace PrismTabbedPage.Models
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        public string NameSort => FirstName[0].ToString();

        public string FullName => string.Concat(FirstName, " ", LastName);
    }

    public class UserResponse
    {
        [JsonProperty(PropertyName = "data")]
        public ObservableCollection<User> UserList { get; set; }
    }
}
