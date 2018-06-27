using System;
using Foundation;
using MoreBotProgrammer.Core;
using ObjCRuntime;

namespace MoreBotProgrammer.iOS
{
    public partial class SleepBlockView : BlockView
    {
        SleepBlockViewModel viewModel;

        public SleepBlockView(IntPtr handle) : base(handle)
        {
        }

        public static SleepBlockView Create()
        {
            var objects = NSBundle.MainBundle.LoadNib("SleepBlockView", null, null);
            var view = Runtime.GetNSObject<SleepBlockView>(objects.ValueAt(0));

            return view;
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            StyleUI();
        }

        public override BlockViewModel BlockViewModel => viewModel;

        public override void SetViewModel(BlockViewModel blockViewModel)
        {
            viewModel = (SleepBlockViewModel)blockViewModel;

            sleepLabel.Text = viewModel.Milliseconds;
        }

        void StyleUI()
        {
            Fonts.ApplyFont(Fonts.MainFont, sleepLabel);
        }
    }
}