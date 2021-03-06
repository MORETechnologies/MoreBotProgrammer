using System;
using Foundation;
using MoreBotProgrammer.Core;
using ObjCRuntime;

namespace MoreBotProgrammer.iOS
{
    public partial class MoveBlockView : BlockView
    {
        MoveBlockViewModel viewModel;

        public MoveBlockView(IntPtr handle) : base(handle)
        {
        }

        public override BlockViewModel BlockViewModel => viewModel;

        public static MoveBlockView Create()
        {
            var objects = NSBundle.MainBundle.LoadNib("MoveBlockView", null, null);
            var view = Runtime.GetNSObject<MoveBlockView>(objects.ValueAt(0));

            return view;
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            StyleUI();
        }

        public override void SetViewModel(BlockViewModel blockViewModel)
        {
            viewModel = (MoveBlockViewModel)blockViewModel;
            UpdateView();
        }

        void UpdateView()
        {
            directionLabel.Text = viewModel.Direction;
            speedLabel.Text = viewModel.Speed;
        }

        void StyleUI()
        {
            Fonts.ApplyFont(Fonts.MainFont, directionLabel, speedLabel);
        }
    }
}