using UIKit;

namespace MoreBotProgrammer.iOS
{
    public partial class ProgrammerViewController : UIViewController
    {
        public ProgrammerViewController() : base("ProgrammerViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

