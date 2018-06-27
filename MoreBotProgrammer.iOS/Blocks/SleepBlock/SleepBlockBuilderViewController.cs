using System;
using CoreGraphics;
using Foundation;
using MoreBotProgrammer.Core;
using UIKit;

namespace MoreBotProgrammer.iOS
{
    public partial class SleepBlockBuilderViewController : UIViewController
    {
        SleepBlockBuilderViewModel viewModel;
        NSObject keyboardShowObserver;
        NSObject keyboardHideObserver;
        nfloat buttonBottomConstraintConstant;

        public SleepBlockBuilderViewController(BlockBuilderViewModel viewModel) : base("SleepBlockBuilderViewController", null)
        {
            this.viewModel = (SleepBlockBuilderViewModel)viewModel;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            buttonBottomConstraintConstant = buttonBottomConstraint.Constant;

            sleepTextField.Text = viewModel.Milliseconds.ToString();

            saveButton.TouchUpInside += (sender, e) => {
                if (int.TryParse(sleepTextField.Text, out int milliseconds)) {
                    viewModel.ChangeMilliseconds(milliseconds);
                } else {
                    sleepTextField.Text = viewModel.Milliseconds.ToString();
                }
                viewModel.Save();
            };

            deleteButton.TouchUpInside += (sender, e) => {
                viewModel.Delete();
            };
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            keyboardShowObserver = UIKeyboard.Notifications.ObserveWillShow(KeyboardWillShow);
            keyboardHideObserver = UIKeyboard.Notifications.ObserveWillHide(KeyboardWillHide);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            NSNotificationCenter.DefaultCenter.RemoveObservers(new[] { keyboardShowObserver, keyboardHideObserver });
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

        void KeyboardWillShow(object sender, UIKeyboardEventArgs e)
        {
            double animationDuration = e.AnimationDuration;
            UIViewAnimationCurve animationCurve = e.AnimationCurve;
            CGRect frameEnd = e.FrameEnd;

            buttonBottomConstraint.Constant = frameEnd.Size.Height + buttonBottomConstraintConstant;
            new UIViewPropertyAnimator(animationDuration, animationCurve, View.LayoutIfNeeded).StartAnimation();
        }

        void KeyboardWillHide(object sender, UIKeyboardEventArgs e)
        {
            double animationDuration = e.AnimationDuration;
            UIViewAnimationCurve animationCurve = e.AnimationCurve;

            buttonBottomConstraint.Constant = buttonBottomConstraintConstant;
            new UIViewPropertyAnimator(animationDuration, animationCurve, View.LayoutIfNeeded).StartAnimation();
        }

        void StyleUI()
        {
            UIStyler.Style(deleteButton, saveButton);
            deleteButton.SetTitleColor(Colors.LightText, UIControlState.Normal);

            Fonts.ApplyFont(Fonts.MainFont, timeHeaderLabel, timeUnitLabel);
            Fonts.ApplyFont(Fonts.MainFont, sleepTextField);
            Fonts.ApplyFont(Fonts.MainFontBold, titleLabel, deleteButton.TitleLabel, saveButton.TitleLabel);
            timeHeaderView.BackgroundColor = Colors.Primary;

            View.LayoutIfNeeded();
        }
    }
}

