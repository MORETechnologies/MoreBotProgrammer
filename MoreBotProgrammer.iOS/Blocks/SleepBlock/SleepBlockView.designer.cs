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
    [Register ("SleepBlockView")]
    partial class SleepBlockView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel sleepLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (sleepLabel != null) {
                sleepLabel.Dispose ();
                sleepLabel = null;
            }
        }
    }
}