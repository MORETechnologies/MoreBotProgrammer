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

        public BlockListDelegateLayout(ProgrammerViewModel programmerViewModel)
        {
            viewModel = programmerViewModel;
        }

        public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            float height = viewModel.BlockViewModels[indexPath.Row].Lines * HeightPerLine;
            return new CGSize(collectionView.Frame.Width, height);
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            viewModel.EditBlock(viewModel.BlockViewModels[indexPath.Row]);
        }
    }
}
