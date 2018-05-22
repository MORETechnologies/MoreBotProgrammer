using System;
using Foundation;
using MoreBotProgrammer.Core;
using UIKit;

namespace MoreBotProgrammer.iOS
{
    public class BlockListDataSource : UICollectionViewDataSource
    {
        ProgrammerViewModel viewModel;

        public BlockListDataSource(ProgrammerViewModel programmerViewModel)
        {
            viewModel = programmerViewModel;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            BlockViewModel block = viewModel.BlockViewModels[indexPath.Row];

            BlockViewCell cell = (BlockViewCell)collectionView.DequeueReusableCell(block.BlockType.ToString(), indexPath);

            if (cell.BlockViewModel != block) {
                cell.SetViewModel(block);
            }

            return cell;
        }

        public override void MoveItem(UICollectionView collectionView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath)
        {
            viewModel.SwapBlocks(sourceIndexPath.Row, destinationIndexPath.Row);
        }

        public override bool CanMoveItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            return true;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return viewModel.BlockViewModels.Count;
        }
    }
}
