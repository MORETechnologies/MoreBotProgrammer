using System;
using System.Collections.Generic;

namespace MoreBotProgrammer.Core
{
    public class ProgrammerViewModel
    {
        BlockViewModelFactory blockViewModelFactory;
        BlockBuilderViewModelFactory blockBuilderViewModelFactory;
        List<Block> blocks;
        List<BlockViewModel> blockViewModels;

        public ProgrammerViewModel()
        {
            blockViewModelFactory = new BlockViewModelFactory();
            blockBuilderViewModelFactory = new BlockBuilderViewModelFactory();

            blocks = new List<Block>();
            blockViewModels = new List<BlockViewModel>();
        }

        public event EventHandler BlocksChanged;

        public event EventHandler<BlockBuilderViewModel> BlockBuilderAdded;

        public event EventHandler<BlockBuilderViewModel> BlockBuilderRemoved;

        public IReadOnlyList<BlockViewModel> BlockViewModels => blockViewModels;

        public void AddBlock(BlockType blockType)
        {
            BlockBuilderViewModel blockBuilder = blockBuilderViewModelFactory.CreateBlockBuilderViewModel(blockType);
            blockBuilder.BlockBuilt += (sender, e) => {
                AddBlock(e);
                BlockBuilderRemoved?.Invoke(this, blockBuilder);
            };

            BlockBuilderAdded?.Invoke(this, blockBuilder);
        }

        public void RemoveBlock(BlockViewModel block)
        {
            blocks.Remove(block.Block);
            blockViewModels.Remove(block);

            BlocksChanged?.Invoke(this, EventArgs.Empty);
        }

        void AddBlock(Block block)
        {
            blocks.Add(block);
            blockViewModels.Add(blockViewModelFactory.CreateBlockViewModel(block));

            BlocksChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
