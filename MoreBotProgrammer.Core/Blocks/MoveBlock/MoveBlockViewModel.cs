namespace MoreBotProgrammer.Core
{
    public class MoveBlockViewModel : BlockViewModel
    {
        MoveBlock block;

        internal MoveBlockViewModel(Block block)
        {
            this.block = (MoveBlock)block;
        }

        public override BlockType BlockType => block.BlockType;

        public string Direction {
            get {
                if (block.Direction == MoveDirection.Forward || block.Direction == MoveDirection.Backward) {
                    return "Move " + block.Direction.ToString();
                }

                return "Turn " + block.Direction.ToString();
            }
        }

        public string Speed => "at " + block.Speed + "% speed";

        public override int Lines => 2;

        internal override Block Block => block;
    }
}
