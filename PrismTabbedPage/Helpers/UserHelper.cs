using System;
using System.Collections.ObjectModel;
using PrismTabbedPage.Models;
using System.Linq;

namespace PrismTabbedPage.Helpers
{
    public static class UserHelper
    {
        private static Random random;

        public static User GetRandomUser()
        {
            return Users[random.Next(0, Users.Count)];
        }

        public static ObservableCollection<Grouping<string, User>> UsersGrouped { get; set; }

        public static ObservableCollection<User> Users { get; set; }

        public static ObservableCollection<Grouping<string, User>> GetUsersGrouped(ObservableCollection<User> UserList)
        {
            var sorted = from user in UserList
                         orderby user.FirstName
                         group user by user.NameSort into userGroup
                         select new Grouping<string, User>(userGroup.Key, userGroup);

            UsersGrouped = new ObservableCollection<Grouping<string, User>>(sorted);

            return UsersGrouped;
        }
    }
}
