namespace MoreBotProgrammer.Core
{
    class SleepBlock : Block
    {
        public SleepBlock(int milliseconds)
        {
            Milliseconds = milliseconds;
        }

        public override BlockType BlockType => BlockType.Sleep;

        public int Milliseconds { get; private set; }
    }
}
