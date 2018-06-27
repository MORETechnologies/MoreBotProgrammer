﻿using MoreBotProgrammer.Core;
using UIKit;

namespace MoreBotProgrammer.iOS
{
    public partial class MoveBlockBuilderViewController : UIViewController
    {
        MoveBlockBuilderViewModel viewModel;

        public MoveBlockBuilderViewController(BlockBuilderViewModel viewModel) : base("MoveBlockBuilderViewController", null)
        {
            this.viewModel = (MoveBlockBuilderViewModel)viewModel;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            directionPickerView.Model = new DirectionPickerModel(viewModel);

            UpdateView();

            speedSlider.ValueChanged += (sender, e) => {
                speedLabel.Text = "Speed: " + (int)speedSlider.Value + "%";
            };

            saveButton.TouchUpInside += (sender, e) => {
                viewModel.ChangeSpeed((int)speedSlider.Value);
                viewModel.Save();
            };

            deleteButton.TouchUpInside += (sender, e) => {
                viewModel.Delete();
            };

            viewModel.ValuesChanged += (sender, e) => {
                UpdateView();
            };
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            StyleUI();
        }

        void UpdateView()
        {
            speedLabel.Text = "Speed: " + viewModel.SpeedText;
            speedSlider.MinValue = viewModel.MinSpeed;
            speedSlider.MaxValue = viewModel.MaxSpeed;
            speedSlider.Value = viewModel.Speed;

            directionPickerView.Select(viewModel.CurrentDirectionIndex, 0, false);
        }

        void StyleUI()
        {
            UIStyler.Style(deleteButton, saveButton);
            deleteButton.SetTitleColor(Colors.LightText, UIControlState.Normal);

            Fonts.ApplyFont(Fonts.MainFont, directionHeaderLabel, speedLabel);
            Fonts.ApplyFont(Fonts.MainFontBold, titleLabel, deleteButton.TitleLabel, saveButton.TitleLabel);

            View.LayoutIfNeeded();
        }
    }
}

