using System;

namespace MoreBotProgrammer.Core
{
    public abstract class BlockBuilderViewModel
    {
        public abstract BlockType BlockType { get; }

        internal event EventHandler<Block> BlockBuilt;

        internal abstract void UpdateValues(Block block);

        internal void OnBlockBuilt(object sender, Block block)
        {
            BlockBuilt?.Invoke(sender, block);
        }
    }
}
