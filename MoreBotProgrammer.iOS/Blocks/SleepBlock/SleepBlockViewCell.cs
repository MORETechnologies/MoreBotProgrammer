using System;
using Foundation;
using MoreBotProgrammer.Core;
using UIKit;

namespace MoreBotProgrammer.iOS
{
    public partial class SleepBlockViewCell : BlockViewCell
    {
        public static readonly NSString Key = new NSString("SleepBlockViewCell");
        public static readonly UINib Nib;

        SleepBlockViewModel viewModel;

        static SleepBlockViewCell()
        {
            Nib = UINib.FromName("SleepBlockViewCell", NSBundle.MainBundle);
        }

        protected SleepBlockViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override BlockViewModel BlockViewModel => viewModel;

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            OnAwake(cellContainer);
        }

        public override void SetViewModel(BlockViewModel blockViewModel)
        {
            viewModel = (SleepBlockViewModel)blockViewModel;

            sleepLabel.Text = viewModel.Milliseconds;
        }
    }
}
