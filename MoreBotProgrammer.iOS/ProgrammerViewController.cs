using CoreGraphics;
using Foundation;
using MoreBotProgrammer.Core;
using UIKit;

namespace MoreBotProgrammer.iOS
{
    public partial class ProgrammerViewController : UIViewController
    {
        ProgrammerViewModel viewModel;
        BlockListDataSource dataSource;
        BlockBuilderViewControllerFactory blockBuilderFactory;

        public ProgrammerViewController(AppMain main) : base("ProgrammerViewController", null)
        {
            viewModel = main.GetProgrammerViewModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

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
                        UIView.PerformWithoutAnimation(() => {
                            blockCollectionView.ReloadSections(NSIndexSet.FromIndex(0));
                        });
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

            runButton.TouchUpInside += async (sender, e) => {
                runButton.Enabled = false;
                await viewModel.Run();
                runButton.Enabled = true;
            };

            backButton.TouchUpInside += (sender, e) => {
                viewModel.Close();
                NavigationController.PopViewController(true);
            };
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            StyleUI();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void StyleUI()
        {
            UIStyler.Style(backButton, runButton, addMoveBlockButton, addSleepBlockButton);

            UIStyler.ShadowBuilder shadowBuilder = new UIStyler.ShadowBuilder().WithOffset(new CGSize(0, 2));

            shadowBuilder.Apply(headerView);

            shadowBuilder.WithOffset(new CGSize(0, -2))
                         .Apply(footerView);

            Fonts.ApplyFont(Fonts.MainFontBold, backButton.TitleLabel, titleLabel, runButton.TitleLabel, addMoveBlockButton.TitleLabel, addSleepBlockButton.TitleLabel);
            headerView.BackgroundColor = Colors.Primary;

            View.LayoutIfNeeded();
        }
    }
}

