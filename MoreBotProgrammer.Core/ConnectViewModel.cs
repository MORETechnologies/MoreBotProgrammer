using System;
using System.Threading.Tasks;

namespace MoreBotProgrammer.Core
{
    public class ConnectViewModel
    {
        public const string TestHost = "test";
        const string DefaultHost = "192.168.4.1";
        const int DefaultPort = 333;

        AppMain appMain;
        IBotClient client;

        public ConnectViewModel(AppMain appMain, IBotClient client)
        {
            this.appMain = appMain;
            this.client = client;

            Host = DefaultHost;
            Port = DefaultPort.ToString();
        }

        public event EventHandler<string> StatusChanged;

        public string Host { get; private set; }

        public string Port { get; private set; }

        public async Task<bool> Connect(string host, string port)
        {
            StatusChanged?.Invoke(this, "Connecting...");

            Host = host;
            Port = port;

            if (host == TestHost) {
                appMain.SwitchToDebugMode();
                StatusChanged?.Invoke(this, "");
                return true;
            }

            if (int.TryParse(port, out int portNumber)) {
                if (await client.ConnectAsync(host, portNumber)) {
                    StatusChanged?.Invoke(this, "");
                    return true;
                } else {
                    StatusChanged?.Invoke(this, "Connection failed");
                }
            } else {
                StatusChanged?.Invoke(this, "Invalid port number");
            }

            return false;
        }
    }
}
