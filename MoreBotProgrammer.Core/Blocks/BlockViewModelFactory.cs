using System.Collections.Generic;

namespace MoreBotProgrammer.Core
{
    class BlockViewModelFactory
    {
        public BlockViewModel CreateBlockViewModel(Block block, List<Block> contextBlocks)
        {
            switch (block.BlockType) {
                case BlockType.Move:
                    return new MoveBlockViewModel(block);
                case BlockType.Sleep:
                    return new SleepBlockViewModel(block, contextBlocks);
            }

            return null;
        }
    }
}
