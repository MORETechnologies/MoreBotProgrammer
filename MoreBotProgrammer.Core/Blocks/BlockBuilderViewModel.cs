using System;

namespace MoreBotProgrammer.Core
{
    public abstract class BlockBuilderViewModel
    {
        internal event EventHandler<Block> BlockBuilt;

        internal void OnBlockBuilt(object sender, Block block)
        {
            BlockBuilt?.Invoke(sender, block);
        }
    }
}
