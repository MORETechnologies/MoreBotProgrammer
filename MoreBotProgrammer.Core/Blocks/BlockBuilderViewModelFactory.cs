using System;

namespace MoreBotProgrammer.Core
{
    class BlockBuilderViewModelFactory
    {
        public BlockBuilderViewModel CreateBlockBuilderViewModel(BlockType blockType)
        {
            return new MoveBlockBuilderViewModel();
        }
    }
}
