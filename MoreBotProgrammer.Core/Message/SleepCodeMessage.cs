namespace MoreBotProgrammer.Core
{
    class SleepCodeMessage : CodeMessage
    {
        public SleepCodeMessage(SleepBlock sleepBlock)
        {
            command = "sleep";
            data = sleepBlock.Milliseconds.ToString();
        }
    }
}
