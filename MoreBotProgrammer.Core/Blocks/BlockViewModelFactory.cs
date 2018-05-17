namespace MoreBotProgrammer.Core
{
    class BlockViewModelFactory
    {
        public BlockViewModel CreateBlockViewModel(Block block)
        {
            switch (block.BlockType) {
                case BlockType.Move:
                    return new MoveBlockViewModel(block);
                case BlockType.Sleep:
                    return new SleepBlockViewModel(block);
            }

            return null;
        }
    }
}
