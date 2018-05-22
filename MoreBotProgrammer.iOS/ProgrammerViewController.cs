using UIKit;
using MoreBotProgrammer.Core;

namespace MoreBotProgrammer.iOS
{
    public partial class ProgrammerViewController : UIViewController
    {
        ProgrammerViewModel viewModel;
        BlockListDataSource dataSource;
        BlockBuilderViewControllerFactory blockBuilderFactory;

        public ProgrammerViewController() : base("ProgrammerViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            viewModel = new ProgrammerViewModel();
            dataSource = new BlockListDataSource(viewModel);
            blockBuilderFactory = new BlockBuilderViewControllerFactory();
            blockCollectionView.RegisterNibForCell(BlockViewCell.Nib, BlockType.Move.ToString());
            blockCollectionView.RegisterNibForCell(BlockViewCell.Nib, BlockType.Sleep.ToString());
            blockCollectionView.DataSource = dataSource;
            blockCollectionView.Delegate = new BlockListDelegateLayout(viewModel);

            var longPressGesture = new UILongPressGestureRecognizer(gesture => {
                switch (gesture.State) {
                    case UIGestureRecognizerState.Began:
                        var selectedIndexPath = blockCollectionView.IndexPathForItemAtPoint(gesture.LocationInView(blockCollectionView));
                        if (selectedIndexPath != null) {
                            blockCollectionView.BeginInteractiveMovementForItem(selectedIndexPath);
                        }
                        break;
                    case UIGestureRecognizerState.Changed:
                        blockCollectionView.UpdateInteractiveMovement(gesture.LocationInView(blockCollectionView));
                        break;
                    case UIGestureRecognizerState.Ended:
                        blockCollectionView.EndInteractiveMovement();
                        break;
                    default:
                        blockCollectionView.CancelInteractiveMovement();
                        break;
                }
            });

            blockCollectionView.AddGestureRecognizer(longPressGesture);

            addMoveBlockButton.TouchUpInside += (sender, e) => {
                viewModel.AddBlock(BlockType.Move);
            };

            addSleepBlockButton.TouchUpInside += (sender, e) => {
                viewModel.AddBlock(BlockType.Sleep);
            };

            viewModel.BlocksChanged += (sender, e) => {
                blockCollectionView.ReloadData();
            };

            viewModel.BlockBuilderAdded += (sender, e) => {
                NavigationController.PushViewController(blockBuilderFactory.CreateBlockBuilderViewController(e), true);
            };

            viewModel.BlockBuilderRemoved += (sender, e) => {
                NavigationController.PopViewController(true);
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

