namespace MoreBotProgrammer.Core
{
    public abstract class CodeMessage
    {
        const string Delimiter = "|";

        protected string command;
        protected string data;

        public CodeMessage()
        {
            command = string.Empty;
            data = string.Empty;
        }

        public string Serialize()
        {
            return command + Delimiter + data;
        }
    }
}
