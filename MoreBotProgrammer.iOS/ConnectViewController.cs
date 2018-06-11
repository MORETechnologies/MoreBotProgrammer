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

            hostField.Text = viewModel.Host;
            portField.Text = viewModel.Port;

            statusLabel.Text = "";

            viewModel.StatusChanged += (sender, text) => {
                statusLabel.Text = text;
            };

            connectButton.TouchUpInside += async (sender, e) => {
                connectButton.Enabled = false;
                if (await viewModel.Connect(hostField.Text, portField.Text)) {
                    NavigationController.PushViewController(new ProgrammerViewController(main), true);
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

