// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace MoreBotProgrammer.iOS
{
    [Register ("SleepBlockViewCell")]
    partial class SleepBlockViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView cellContainer { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel sleepLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (cellContainer != null) {
                cellContainer.Dispose ();
                cellContainer = null;
            }

            if (sleepLabel != null) {
                sleepLabel.Dispose ();
                sleepLabel = null;
            }
        }
    }
}