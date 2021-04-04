using System.Threading.Tasks;
using Plugin.Connectivity;

namespace PrismTabbedPage.Helpers
{
    public static class AppHelpers
    {
        public const string AddUserKey = "AddUserKey";
        public const string AddUserComplete = "AddUserComplete";
        // Check internet connection
        public static bool IsHaveInternet()
        {
            if (!CrossConnectivity.IsSupported)
                return true;

            return CrossConnectivity.Current.IsConnected;
        }

        // Check a host if available
        public static async Task<bool> IsHostAvailable(string HostName)
        {
            var connectivity = CrossConnectivity.Current;
            if (!connectivity.IsConnected)
                return false;

            var reachable = await connectivity.IsRemoteReachable(HostName);

            return reachable;
        }
    }
}
