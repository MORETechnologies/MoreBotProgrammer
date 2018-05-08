using CoreGraphics;
using Foundation;
using MoreBotProgrammer.Core;
using UIKit;

namespace MoreBotProgrammer.iOS
{
    public class BlockListDelegateLayout : UICollectionViewDelegateFlowLayout
    {
        ProgrammerViewModel viewModel;

        public BlockListDelegateLayout(ProgrammerViewModel programmerViewModel)
        {
            viewModel = programmerViewModel;
        }

        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            return new CGSize(collectionView.Frame.Width, collectionView.Frame.Width * 3 / 5);
        }
    }
}
