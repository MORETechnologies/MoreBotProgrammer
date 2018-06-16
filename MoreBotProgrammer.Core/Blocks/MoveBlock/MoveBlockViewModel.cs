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
                if (block.Direction == MoveDirection.Left || block.Direction == MoveDirection.Right) {
                    return "Turn " + block.Direction.ToString();
                }

                if (block.Direction == MoveDirection.Stop) {
                    return "Stop";
                }

                return "Move " + block.Direction.ToString();
            }
        }

        public string Speed => block.Direction != MoveDirection.Stop ? "at " + block.Speed + "% speed" : "moving";

        public override int Lines => 2;

        internal override Block Block => block;
    }
}
