using MoreBotProgrammer.Core;
using UIKit;

namespace MoreBotProgrammer.iOS
{
    public class BlockBuilderViewControllerFactory
    {
        public UIViewController CreateBlockBuilderViewController(BlockBuilderViewModel viewModel)
        {
            switch (viewModel.BlockType) {
                case BlockType.Move:
                    return new MoveBlockBuilderViewController(viewModel);
                case BlockType.Sleep:
                    return new SleepBlockBuilderViewController(viewModel);
            }

            return null;
        }
    }
}
