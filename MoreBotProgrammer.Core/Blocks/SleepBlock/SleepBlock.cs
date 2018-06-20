namespace MoreBotProgrammer.Core
{
    class SleepBlock : Block
    {
        public SleepBlock(int milliseconds)
        {
            Milliseconds = milliseconds;
        }

        public override BlockType BlockType => BlockType.Sleep;

        public override CodeMessage CodeMessage => new SleepCodeMessage(this);

        public int Milliseconds { get; private set; }

        public override BlockEntity ToEntity()
        {
            return new SleepBlockEntity(this);
        }
    }
}
