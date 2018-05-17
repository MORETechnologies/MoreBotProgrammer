using System;

namespace MoreBotProgrammer.Core
{
    public abstract class BlockBuilderViewModel
    {
        public abstract BlockType BlockType { get; }

        internal event EventHandler<Block> BlockBuilt;

        internal event EventHandler<Block> BlockDeleted;

        public abstract void Save();

        public abstract void Delete();

        internal abstract void UpdateValues(Block block);

        internal void OnBlockBuilt(object sender, Block block)
        {
            BlockBuilt?.Invoke(sender, block);
        }

        internal void OnBlockDelete(object sender, Block block)
        {
            BlockDeleted?.Invoke(sender, block);
        }
    }
}
