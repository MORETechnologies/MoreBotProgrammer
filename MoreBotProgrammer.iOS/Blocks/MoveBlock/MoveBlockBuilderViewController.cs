using MoreBotProgrammer.Core;
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

            UpdateView();

            speedSlider.ValueChanged += (sender, e) => {
                speedLabel.Text = "Speed: " + (int)speedSlider.Value;
            };

            saveButton.TouchUpInside += (sender, e) => {
                viewModel.ChangeSpeed((int)speedSlider.Value);
                viewModel.Save();
            };

            viewModel.ValuesChanged += (sender, e) => {
                UpdateView();
            };
        }

        private void UpdateView()
        {
            directionButton.SetTitle(viewModel.SelectedDirection, UIControlState.Normal);
            speedLabel.Text = "Speed: " + viewModel.Speed;
            speedSlider.MinValue = viewModel.MinSpeed;
            speedSlider.MaxValue = viewModel.MaxSpeed;
            speedSlider.Value = viewModel.Speed;
        }
    }
}

