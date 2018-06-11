namespace MoreBotProgrammer.Core
{
    public abstract class CodeMessage
    {
        const string Delimiter = "|";

        protected string command;
        protected string data;

        public string Serialize()
        {
            return command + Delimiter + data;
        }
    }
}
