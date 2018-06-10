namespace MoreBotProgrammer.Core
{
    class SleepBlock : Block
    {
        public SleepBlock(int milliseconds)
        {
            Milliseconds = milliseconds;
        }

        public override BlockType BlockType => BlockType.Sleep;

        public override CodeMessage CodeMessage => throw new System.NotImplementedException();

        public int Milliseconds { get; private set; }

        class SleepCodeMessage : CodeMessage
        {
            public SleepCodeMessage(SleepBlock sleepBlock)
            {
                command = "sleep";
                data = sleepBlock.Milliseconds.ToString();
            }
        }
    }
}
