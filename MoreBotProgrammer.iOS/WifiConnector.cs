using System.Threading.Tasks;
using NetworkExtension;
using System.Diagnostics;

namespace MoreBotProgrammer.iOS
{
    public static class WifiConnector
    {
        public static Task Connect(string ssid, string password)
        {
            NEHotspotConfiguration configuration;
            if (string.IsNullOrEmpty(password)) {
                configuration = new NEHotspotConfiguration(ssid);
            } else {
                configuration = new NEHotspotConfiguration(ssid, password, false);
            }

            configuration.JoinOnce = true;

            TaskCompletionSource<bool> source = new TaskCompletionSource<bool>();

            NEHotspotConfigurationManager.SharedManager.ApplyConfiguration(configuration, async err => {
                if (err == null) {
                    // Wait a bit for connection to fully establish
                    await Task.Delay(1000);
                    source.TrySetResult(true);
                } else {
                    Debug.WriteLine(err.Description);
                    source.TrySetResult(false);
                }
            });

            return source.Task;
        }
    }
}
