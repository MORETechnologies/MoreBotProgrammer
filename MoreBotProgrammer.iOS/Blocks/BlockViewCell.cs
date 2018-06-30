using System;
using Foundation;
using MoreBotProgrammer.Core;
using UIKit;

namespace MoreBotProgrammer.iOS
{
    public partial class BlockViewCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("BlockViewCell");
        public static readonly UINib Nib;

        static BlockViewCell()
        {
            Nib = UINib.FromName("BlockViewCell", NSBundle.MainBundle);
        }

        protected BlockViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public BlockViewModel BlockViewModel { get; private set; }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            new UIStyler.ShadowBuilder().Apply(cellContainer);
        }

        public void SetViewModel(BlockViewModel viewModel)
        {
            if (BlockViewModel != null) {
                BlockViewModel.RunningChanged -= OnRunChanged;
            }

            BlockViewModel = viewModel;

            BlockViewModel.RunningChanged += OnRunChanged;

            SetRunning(BlockViewModel.Running);

            BlockView blockView = null;
            if (cellContainer.Subviews.Length > 0) {
                blockView = cellContainer.Subviews[0] as BlockView;
                if (blockView != null && (blockView.BlockViewModel == null || blockView.BlockViewModel.BlockType != viewModel.BlockType)) {
                    blockView.RemoveFromSuperview();
                    blockView = null;
                }
            }

            if (blockView == null) {
                blockView = BlockView.Create(viewModel.BlockType);
            }

            if (blockView.Superview != cellContainer) {
                blockView.TranslatesAutoresizingMaskIntoConstraints = false;
                cellContainer.Add(blockView);

                var topConstraint = NSLayoutConstraint.Create(blockView, NSLayoutAttribute.Top, NSLayoutRelation.Equal, cellContainer, NSLayoutAttribute.Top, 1, 0);
                var bottomConstraint = NSLayoutConstraint.Create(blockView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, cellContainer, NSLayoutAttribute.Bottom, 1, 0);
                var leadingConstraint = NSLayoutConstraint.Create(blockView, NSLayoutAttribute.Leading, NSLayoutRelation.Equal, cellContainer, NSLayoutAttribute.Leading, 1, 0);
                var trailingConstraint = NSLayoutConstraint.Create(blockView, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, cellContainer, NSLayoutAttribute.Trailing, 1, 0);

                cellContainer.AddConstraints(new[] { topConstraint, bottomConstraint, leadingConstraint, trailingConstraint });
            }

            blockView.SetViewModel(viewModel);
        }

        void OnRunChanged(object sender, bool running)
        {
            InvokeOnMainThread(() => SetRunning(running));
        }

        void SetRunning(bool running)
        {
            if (running) {
                BackgroundColor = Colors.PrimaryLight;
            } else {
                BackgroundColor = UIColor.Clear;
            }
        }
    }
}
