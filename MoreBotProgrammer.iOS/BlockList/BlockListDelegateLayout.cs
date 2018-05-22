using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using MoreBotProgrammer.Core;
using UIKit;

namespace MoreBotProgrammer.iOS
{
    public class BlockListDelegateLayout : UICollectionViewDelegateFlowLayout
    {
        const float HeightPerLine = 40;

        ProgrammerViewModel viewModel;
        List<BlockViewModel> blocks;

        public BlockListDelegateLayout(ProgrammerViewModel programmerViewModel)
        {
            viewModel = programmerViewModel;
            blocks = viewModel.BlockViewModels.ToList();

            viewModel.BlocksChanged += (sender, e) => {
                blocks = viewModel.BlockViewModels.ToList();
            };
        }

        public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            float height = blocks[indexPath.Row].Lines * HeightPerLine;
            return new CGSize(collectionView.Frame.Width, height);
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            viewModel.EditBlock(blocks[indexPath.Row]);
        }

        public override NSIndexPath GetTargetIndexPathForMove(UICollectionView collectionView, NSIndexPath originalIndexPath, NSIndexPath proposedIndexPath)
        {
            if (originalIndexPath.Row != proposedIndexPath.Row) {
                var block = blocks[originalIndexPath.Row];

                blocks.RemoveAt(originalIndexPath.Row);
                blocks.Insert(proposedIndexPath.Row, block);
            }
            return proposedIndexPath;
        }
    }
}
