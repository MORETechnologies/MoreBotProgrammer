namespace MoreBotProgrammer.Core
{
    public class AppMain
    {
        IBotClient client;
        Compiler compiler;
        string baseDirectory;

        public AppMain(string baseDirectory)
        {
            this.baseDirectory = baseDirectory;

            client = new BotClient();
            compiler = new Compiler(client);
        }

        public ConnectViewModel GetConnectViewModel()
        {
            return new ConnectViewModel(this, client);
        }

        public ProgrammerViewModel GetProgrammerViewModel()
        {
            return new ProgrammerViewModel(compiler, new UserProgramRepository(new JsonProgramStorage(baseDirectory)));
        }

        internal void SwitchToDebugMode()
        {
            if (!(client is DebugClient)) {
                client = new DebugClient();
                compiler = new Compiler(client);
            }
        }

        internal void SwitchToReleaseMode()
        {
            if (client is DebugClient) {
                client = new BotClient();
                compiler = new Compiler(client);
            }
        }
    }
}
