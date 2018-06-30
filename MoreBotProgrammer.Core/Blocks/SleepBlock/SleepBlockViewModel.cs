using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoreBotProgrammer.Core
{
    public class SleepBlockViewModel : BlockViewModel
    {
        SleepBlock block;

        internal SleepBlockViewModel(Block block, List<Block> contextBlocks)
        {
            this.block = (SleepBlock)block;
            Milliseconds = "Wait for " + this.block.Milliseconds.ToString() + " milliseconds";

            // Change text based on previous block
            int thisIndex = contextBlocks.FindIndex(b => b == block);
            if (thisIndex - 1 >= 0) {
                if (contextBlocks[thisIndex - 1].BlockType == BlockType.Move) {
                    Milliseconds = "for " + this.block.Milliseconds.ToString() + " milliseconds";
                }
            }
        }

        public override BlockType BlockType => block.BlockType;

        public override int Lines => 1;

        public string Milliseconds { get; private set; }

        internal override Block Block => block;

        public override async Task Run()
        {
            Running = true;
            await Task.Delay(block.Milliseconds);
            Running = false;
        }
    }
}
