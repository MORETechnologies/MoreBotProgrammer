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
            blockBuilder.BlockDeleted += (sender, e) => {
                BlockBuilderRemoved?.Invoke(this, blockBuilder);
            };

            BlockBuilderAdded?.Invoke(this, blockBuilder);
        }

        public void EditBlock(BlockViewModel blockViewModel)
        {
            BlockBuilderViewModel blockBuilder = blockBuilderViewModelFactory.CreateBlockBuilderViewModel(blockViewModel.Block);
            blockBuilder.BlockBuilt += (sender, e) => {
                ReplaceBlock(blockViewModel.Block, e);
                BlockBuilderRemoved?.Invoke(this, blockBuilder);
            };
            blockBuilder.BlockDeleted += (sender, e) => {
                RemoveBlock(e);
                BlockBuilderRemoved?.Invoke(this, blockBuilder);
            };

            BlockBuilderAdded?.Invoke(this, blockBuilder);
        }

        public void SwapBlocks(int sourceIndex, int destinationIndex)
        {
            Block block = blocks[sourceIndex];
            BlockViewModel blockViewModel = blockViewModels[sourceIndex];

            blocks.RemoveAt(sourceIndex);
            blockViewModels.RemoveAt(sourceIndex);

            blocks.Insert(destinationIndex, block);
            blockViewModels.Insert(destinationIndex, blockViewModel);

            BlocksChanged?.Invoke(this, EventArgs.Empty);
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

        void RemoveBlock(Block block)
        {
            int index = blocks.FindIndex(b => b == block);
            if (index >= 0) {
                blocks.RemoveAt(index);
                blockViewModels.RemoveAt(index);

                BlocksChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
