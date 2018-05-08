using System;
using Foundation;
using UIKit;
using MoreBotProgrammer.Core;

namespace MoreBotProgrammer.iOS
{
    public partial class MoveBlockViewCell : BlockViewCell
    {
        public static readonly NSString Key = new NSString("MoveBlockViewCell");
        public static readonly UINib Nib;

        MoveBlockViewModel viewModel;

        static MoveBlockViewCell()
        {
            Nib = UINib.FromName("MoveBlockViewCell", NSBundle.MainBundle);
        }

        protected MoveBlockViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override nfloat Height => 300;

        public override BlockViewModel BlockViewModel => viewModel;

        public override void SetViewModel(BlockViewModel blockViewModel)
        {
            viewModel = (MoveBlockViewModel)blockViewModel;
        }
    }
}
