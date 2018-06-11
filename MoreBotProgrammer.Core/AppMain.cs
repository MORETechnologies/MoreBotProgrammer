namespace MoreBotProgrammer.Core
{
    public class AppMain
    {
        IBotClient client;
        Compiler compiler;

        public AppMain()
        {
            client = new BotClient();
            compiler = new Compiler(client);
        }

        public ProgrammerViewModel GetProgrammerViewModel()
        {
            return new ProgrammerViewModel(compiler);
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
