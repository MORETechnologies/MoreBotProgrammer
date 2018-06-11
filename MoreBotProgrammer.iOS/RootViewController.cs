using UIKit;
using MoreBotProgrammer.Core;

namespace MoreBotProgrammer.iOS
{
    public partial class RootViewController : UIViewController
    {
        AppMain main;

        public RootViewController() : base("RootViewController", null)
        {
            main = new AppMain();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            NavigationController.PopViewController(false);
            NavigationController.PushViewController(new ConnectViewController(main), false);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

