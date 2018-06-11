using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MoreBotProgrammer.Core
{
    public class DebugClient : IBotClient
    {
        public event EventHandler Disconnected;

        public async Task<bool> ConnectAsync(string host, int portNumber)
        {
            Debug.WriteLine("Connecting to " + host + ":" + portNumber);
            await Task.Delay(100);
            return true;
        }

        public void Disconnect()
        {
            Disconnected?.Invoke(this, EventArgs.Empty);
        }

        public async Task SendMessage(CodeMessage message)
        {
            Debug.WriteLine(message.Serialize());
            await Task.Delay(100);
        }
    }
}
