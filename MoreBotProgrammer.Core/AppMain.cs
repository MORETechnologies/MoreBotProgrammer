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
    }
}
