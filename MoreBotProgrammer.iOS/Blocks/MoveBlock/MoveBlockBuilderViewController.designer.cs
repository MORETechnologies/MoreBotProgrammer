// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MoreBotProgrammer.iOS
{
    [Register ("MoveBlockBuilderViewController")]
    partial class MoveBlockBuilderViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton deleteButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView directionPickerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton saveButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel speedLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider speedSlider { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (deleteButton != null) {
                deleteButton.Dispose ();
                deleteButton = null;
            }

            if (directionPickerView != null) {
                directionPickerView.Dispose ();
                directionPickerView = null;
            }

            if (saveButton != null) {
                saveButton.Dispose ();
                saveButton = null;
            }

            if (speedLabel != null) {
                speedLabel.Dispose ();
                speedLabel = null;
            }

            if (speedSlider != null) {
                speedSlider.Dispose ();
                speedSlider = null;
            }
        }
    }
}