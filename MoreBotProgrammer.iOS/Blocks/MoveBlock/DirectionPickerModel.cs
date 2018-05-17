using System;
using MoreBotProgrammer.Core;
using UIKit;

namespace MoreBotProgrammer.iOS
{
    public class DirectionPickerModel : UIPickerViewModel
    {
        MoveBlockBuilderViewModel viewModel;

        public DirectionPickerModel(MoveBlockBuilderViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return viewModel.DirectionOptions.Length;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return viewModel.DirectionOptions[row];
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            viewModel.ChangeDirection((int)row);
        }
    }
}
