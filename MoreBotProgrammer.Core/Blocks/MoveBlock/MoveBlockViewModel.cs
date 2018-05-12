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

        internal override Block Block => block;
    }
}
