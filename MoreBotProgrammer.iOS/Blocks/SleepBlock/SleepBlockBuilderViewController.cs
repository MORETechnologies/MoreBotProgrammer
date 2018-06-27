using MoreBotProgrammer.Core;
using UIKit;

namespace MoreBotProgrammer.iOS
{
    public partial class SleepBlockBuilderViewController : UIViewController
    {
        SleepBlockBuilderViewModel viewModel;

        public SleepBlockBuilderViewController(BlockBuilderViewModel viewModel) : base("SleepBlockBuilderViewController", null)
        {
            this.viewModel = (SleepBlockBuilderViewModel)viewModel;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

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

        void StyleUI()
        {
            UIStyler.Style(deleteButton, saveButton);
            deleteButton.SetTitleColor(Colors.RedText, UIControlState.Normal);

            Fonts.ApplyFont(Fonts.MainFont, timeHeaderLabel, timeUnitLabel);
            Fonts.ApplyFont(Fonts.MainFont, sleepTextField);
            Fonts.ApplyFont(Fonts.MainFontBold, titleLabel, deleteButton.TitleLabel, saveButton.TitleLabel);

            View.LayoutIfNeeded();
        }
    }
}

