namespace MoreBotProgrammer.Core
{
    public class SleepBlockViewModel : BlockViewModel
    {
        SleepBlock block;

        internal SleepBlockViewModel(Block block)
        {
            this.block = (SleepBlock)block;
        }

        public override BlockType BlockType => block.BlockType;

        public override int Lines => 1;

        internal override Block Block => block;
    }
}
