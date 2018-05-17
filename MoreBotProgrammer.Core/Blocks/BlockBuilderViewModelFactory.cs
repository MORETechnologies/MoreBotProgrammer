namespace MoreBotProgrammer.Core
{
    class BlockBuilderViewModelFactory
    {
        public BlockBuilderViewModel CreateBlockBuilderViewModel(BlockType blockType)
        {
            switch (blockType) {
                case BlockType.Move:
                    return new MoveBlockBuilderViewModel();
                case BlockType.Sleep:
                    return new SleepBlockBuilderViewModel();
            }

            return null;
        }

        public BlockBuilderViewModel CreateBlockBuilderViewModel(Block block)
        {
            BlockBuilderViewModel builder = CreateBlockBuilderViewModel(block.BlockType);
            if (builder != null) {
                builder.UpdateValues(block);
            }

            return builder;
        }
    }
}
