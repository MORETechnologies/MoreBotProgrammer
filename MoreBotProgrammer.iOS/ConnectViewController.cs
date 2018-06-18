using MoreBotProgrammer.Core;
using UIKit;

namespace MoreBotProgrammer.iOS
{
    public partial class ConnectViewController : UIViewController
    {
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

            NavigationController?.SetNavigationBarHidden(true, false);

            statusLabel.Text = "";

            viewModel.StatusChanged += (sender, text) => {
                statusLabel.Text = text;
            };

            connectButton.TouchUpInside += async (sender, e) => {
                connectButton.Enabled = false;
                if (wifiNameField.Text.ToLower() == "test") {
                    if (await viewModel.Connect("test", viewModel.Port)) {
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
    }
}

