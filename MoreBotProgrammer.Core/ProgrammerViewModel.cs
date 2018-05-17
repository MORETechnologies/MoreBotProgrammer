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

        public void EditBlock(BlockViewModel blockViewModel)
        {
            BlockBuilderViewModel blockBuilder = blockBuilderViewModelFactory.CreateBlockBuilderViewModel(blockViewModel.Block);
            blockBuilder.BlockBuilt += (sender, e) => {
                ReplaceBlock(blockViewModel.Block, e);
                BlockBuilderRemoved?.Invoke(this, blockBuilder);
            };

            BlockBuilderAdded?.Invoke(this, blockBuilder);
        }

        void AddBlock(Block block)
        {
            blocks.Add(block);
            blockViewModels.Add(blockViewModelFactory.CreateBlockViewModel(block));

            BlocksChanged?.Invoke(this, EventArgs.Empty);
        }

        void ReplaceBlock(Block oldBlock, Block newBlock)
        {
            int index = blocks.FindIndex(block => block == oldBlock);
            if (index >= 0) {
                blocks[index] = newBlock;
                blockViewModels[index] = blockViewModelFactory.CreateBlockViewModel(newBlock);

                BlocksChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
