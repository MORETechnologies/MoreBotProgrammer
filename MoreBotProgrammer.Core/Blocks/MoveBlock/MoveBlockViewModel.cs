namespace MoreBotProgrammer.Core
{
    public class MoveBlockViewModel : BlockViewModel
    {
        private MoveBlock block;

        internal MoveBlockViewModel(Block block)
        {
            this.block = (MoveBlock)block;
        }

        public override BlockType BlockType => block.BlockType;

        internal override Block Block => block;
    }
}
