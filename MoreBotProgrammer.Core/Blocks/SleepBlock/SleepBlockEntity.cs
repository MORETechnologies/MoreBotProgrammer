namespace MoreBotProgrammer.Core
{
    class SleepBlockEntity : BlockEntity
    {
        public SleepBlockEntity()
        {
        }

        public SleepBlockEntity(SleepBlock block)
        {
            Milliseconds = block.Milliseconds;
        }

        public int Milliseconds { get; set; }

        public override Block ToBlock()
        {
            return new SleepBlock(Milliseconds);
        }
    }
}
