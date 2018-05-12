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

        public string Speed => block.Speed.ToString();

        public override int Lines => 2;

        internal override Block Block => block;
    }
}
