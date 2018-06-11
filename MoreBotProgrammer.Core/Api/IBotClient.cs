using System;
using System.Threading.Tasks;

namespace MoreBotProgrammer.Core
{
    public interface IBotClient
    {
        event EventHandler Disconnected;

        Task<bool> ConnectAsync(string host, int portNumber);

        Task SendMessage(CodeMessage message);

        void Disconnect();
    }
}
