using UIKit;

namespace MoreBotProgrammer.iOS
{
    public partial class RootViewController : UIViewController
    {
        public RootViewController() : base("RootViewController", null)
        {
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
            NavigationController.PushViewController(new ProgrammerViewController(), false);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

