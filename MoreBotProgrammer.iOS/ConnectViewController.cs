using CoreGraphics;
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

        public ConnectViewController(AppMain main) : base("ConnectViewController", null)
        {
            this.main = main;
            viewModel = main.GetConnectViewModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            StyleUI();

            NavigationController?.SetNavigationBarHidden(true, false);

            wifiNameField.Text = DefaultWifi;
            statusLabel.Text = "";

            viewModel.StatusChanged += (sender, text) => {
                statusLabel.Text = text;
            };

            connectButton.TouchUpInside += async (sender, e) => {
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
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void StyleUI()
        {
            UIStyler.Style(connectButton);

            new UIStyler.ShadowBuilder()
                        .WithColor(Colors.DarkText)
                        .WithOffset(new CGSize(0, 2))
                        .WithRadius(3)
                        .WithOpacity(0.5f)
                        .Apply(connectBox);
        }
    }
}

