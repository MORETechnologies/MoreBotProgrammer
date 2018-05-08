using System;
using System.Collections.Generic;

namespace MoreBotProgrammer.Core
{
    public class ProgrammerViewModel
    {
        BlockFactory blockFactory;
        BlockViewModelFactory blockViewModelFactory;
        List<Block> blocks;
        List<BlockViewModel> blockViewModels;

        public ProgrammerViewModel()
        {
            blockFactory = new BlockFactory();
            blockViewModelFactory = new BlockViewModelFactory();
            blocks = new List<Block>();
            blockViewModels = new List<BlockViewModel>();
        }

        public event EventHandler BlocksChanged;

        public IReadOnlyList<BlockViewModel> BlockViewModels => blockViewModels;

        public void OnAddBlock(BlockType blockType)
        {
            Block newBlock = blockFactory.CreateBlock(blockType);
            blocks.Add(newBlock);
            blockViewModels.Add(blockViewModelFactory.CreateBlockViewModel(newBlock));

            BlocksChanged?.Invoke(this, EventArgs.Empty);
        }

        public void OnRemoveBlock(BlockViewModel block)
        {
            blocks.Remove(block.Block);
            blockViewModels.Remove(block);

            BlocksChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
