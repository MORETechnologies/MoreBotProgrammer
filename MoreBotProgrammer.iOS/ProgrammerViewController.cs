using UIKit;
using MoreBotProgrammer.Core;

namespace MoreBotProgrammer.iOS
{
    public partial class ProgrammerViewController : UIViewController
    {
        ProgrammerViewModel viewModel;
        BlockListDataSource dataSource;

        public ProgrammerViewController() : base("ProgrammerViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            viewModel = new ProgrammerViewModel();
            dataSource = new BlockListDataSource(viewModel);
            blockCollectionView.RegisterNibForCell(MoveBlockViewCell.Nib, BlockType.Move.ToString());
            blockCollectionView.DataSource = dataSource;
            blockCollectionView.Delegate = new BlockListDelegateLayout(viewModel);

            addMoveBlockButton.TouchUpInside += (sender, e) => {
                viewModel.OnAddBlock(BlockType.Move);
            };

            viewModel.BlocksChanged += (sender, e) => {
                blockCollectionView.ReloadData();
            };

            viewModel.BlockBuilderAdded += (sender, e) => {
                NavigationController.PushViewController(new MoveBlockBuilderViewController(e), true);
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

