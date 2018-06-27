using System;
using System.Threading.Tasks;
using CoreGraphics;
using Foundation;
using MoreBotProgrammer.Core;
using UIKit;

namespace MoreBotProgrammer.iOS
{
    public partial class ConnectViewController : UIViewController
    {
        const string TestWifi = "test";
#if SIMULATOR
        const string DefaultWifi = TestWifi;
#else
        const string DefaultWifi = "TestCompiler";
#endif

        AppMain main;
        ConnectViewModel viewModel;
        NSObject keyboardShowObserver;
        NSObject keyboardHideObserver;

        public ConnectViewController(AppMain main) : base("ConnectViewController", null)
        {
            this.main = main;
            viewModel = main.GetConnectViewModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationController?.SetNavigationBarHidden(true, false);

            wifiNameField.Text = DefaultWifi;
            statusLabel.Text = "";

            viewModel.StatusChanged += (sender, text) => {
                statusLabel.Text = text;
            };

            connectButton.TouchUpInside += (sender, e) => {
                Connect();
            };

            View.AddGestureRecognizer(new UITapGestureRecognizer(() => {
                View.EndEditing(true);
            }));

            wifiNameField.ShouldReturn += (textField) => {
                Connect();
                return true;
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

        async Task Connect()
        {
            connectButton.Enabled = false;
            if (wifiNameField.Text.ToLower() == TestWifi) {
                if (await viewModel.Connect(ConnectViewModel.TestHost, viewModel.Port)) {
                    NavigationController.PushViewController(new ProgrammerViewController(main), true);
                }
            } else {
                statusLabel.Text = "Connecting...";
                await WifiConnector.Connect(wifiNameField.Text, null);
                if (await viewModel.Connect(viewModel.Host, viewModel.Port)) {
                    NavigationController.PushViewController(new ProgrammerViewController(main), true);
                }
            }
            connectButton.Enabled = true;
        }

        void KeyboardWillShow(object sender, UIKeyboardEventArgs e)
        {
            double animationDuration = e.AnimationDuration;
            UIViewAnimationCurve animationCurve = e.AnimationCurve;
            CGRect frameEnd = e.FrameEnd;
            nfloat yDelta = frameEnd.Size.Height / 2;

            connectBoxCenterYConstraint.Constant = -yDelta;
            new UIViewPropertyAnimator(animationDuration, animationCurve, View.LayoutIfNeeded).StartAnimation();
        }

        void KeyboardWillHide(object sender, UIKeyboardEventArgs e)
        {
            double animationDuration = e.AnimationDuration;
            UIViewAnimationCurve animationCurve = e.AnimationCurve;

            connectBoxCenterYConstraint.Constant = 0;
            new UIViewPropertyAnimator(animationDuration, animationCurve, View.LayoutIfNeeded).StartAnimation();
        }

        void StyleUI()
        {
            UIStyler.Style(connectButton);

            new UIStyler.ShadowBuilder()
                        .WithOffset(new CGSize(0, 2))
                        .WithColor(Colors.PrimaryDark)
                        .Apply(connectBox);

            Fonts.ApplyFont(Fonts.MainFont, wifiNameField);
            Fonts.ApplyFont(Fonts.MainFont, statusLabel);
            Fonts.ApplyFont(Fonts.MainFontBold, titleLabel, connectButton.TitleLabel);
            connectBox.BackgroundColor = Colors.Primary;

            View.LayoutIfNeeded();
        }
    }
}

