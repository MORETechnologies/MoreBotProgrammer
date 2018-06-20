using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreBotProgrammer.Core
{
    public class ProgrammerViewModel
    {
        BlockViewModelFactory blockViewModelFactory;
        BlockBuilderViewModelFactory blockBuilderViewModelFactory;
        List<Block> blocks;
        List<BlockViewModel> blockViewModels;
        Compiler compiler;
        UserProgramRepository programRepository;

        internal ProgrammerViewModel(Compiler compiler, UserProgramRepository programRepository)
        {
            this.compiler = compiler;
            this.programRepository = programRepository;

            blockViewModelFactory = new BlockViewModelFactory();
            blockBuilderViewModelFactory = new BlockBuilderViewModelFactory();

            blocks = programRepository.GetBlocks().ToList();
            blockViewModels = blocks.Select(b => blockViewModelFactory.CreateBlockViewModel(b, blocks)).ToList();
        }

        public event EventHandler BlocksChanged;

        public event EventHandler<BlockBuilderViewModel> BlockBuilderAdded;

        public event EventHandler<BlockBuilderViewModel> BlockBuilderRemoved;

        public event EventHandler<bool> CompilingStateChanged;

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
            blocks.RemoveAt(sourceIndex);
            blocks.Insert(destinationIndex, block);

            // Context for moved block, source, source + 1, and destination + 1 blocks possibly changed so update viewmodels
            BlockViewModel movedBlockViewModel = blockViewModelFactory.CreateBlockViewModel(block, blocks);
            blockViewModels.RemoveAt(sourceIndex);
            blockViewModels.Insert(destinationIndex, movedBlockViewModel);

            BlockViewModel newBlockAtSource = blockViewModelFactory.CreateBlockViewModel(blocks[sourceIndex], blocks);
            blockViewModels[sourceIndex] = newBlockAtSource;

            if (sourceIndex + 1 < blocks.Count) {
                BlockViewModel afterSource = blockViewModelFactory.CreateBlockViewModel(blocks[sourceIndex + 1], blocks);
                blockViewModels[sourceIndex + 1] = afterSource;
            }

            if (destinationIndex + 1 < blocks.Count) {
                BlockViewModel afterDestination = blockViewModelFactory.CreateBlockViewModel(blocks[destinationIndex + 1], blocks);
                blockViewModels[destinationIndex + 1] = afterDestination;
            }

            programRepository.Update(blocks);
            BlocksChanged?.Invoke(this, EventArgs.Empty);
        }

        public async Task Run()
        {
            CompilingStateChanged?.Invoke(this, true);

            await compiler.Compile(blocks);

            CompilingStateChanged?.Invoke(this, false);
        }

        void AddBlock(Block block)
        {
            blocks.Add(block);
            blockViewModels.Add(blockViewModelFactory.CreateBlockViewModel(block, blocks));

            programRepository.Update(blocks);
            BlocksChanged?.Invoke(this, EventArgs.Empty);
        }

        void ReplaceBlock(Block oldBlock, Block newBlock)
        {
            int index = blocks.FindIndex(block => block == oldBlock);
            if (index >= 0) {
                blocks[index] = newBlock;
                blockViewModels[index] = blockViewModelFactory.CreateBlockViewModel(newBlock, blocks);

                programRepository.Update(blocks);
                BlocksChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        void RemoveBlock(Block block)
        {
            int index = blocks.FindIndex(b => b == block);
            if (index >= 0) {
                blocks.RemoveAt(index);
                blockViewModels.RemoveAt(index);

                // Create new view model to set new context blocks
                if (index < blocks.Count) {
                    BlockViewModel newBlockViewModel = blockViewModelFactory.CreateBlockViewModel(blocks[index], blocks);
                    blockViewModels[index] = newBlockViewModel;
                }

                programRepository.Update(blocks);
                BlocksChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
