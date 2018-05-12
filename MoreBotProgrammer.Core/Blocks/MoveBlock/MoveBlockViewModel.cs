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

        public string Direction => block.Direction.ToString();

        public int Speed => block.Speed;

        internal override Block Block => block;
    }
}
