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
    [Register ("ConnectViewController")]
    partial class ConnectViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView connectBox { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint connectBoxCenterYConstraint { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton connectButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel statusLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel titleLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField wifiNameField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (connectBox != null) {
                connectBox.Dispose ();
                connectBox = null;
            }

            if (connectBoxCenterYConstraint != null) {
                connectBoxCenterYConstraint.Dispose ();
                connectBoxCenterYConstraint = null;
            }

            if (connectButton != null) {
                connectButton.Dispose ();
                connectButton = null;
            }

            if (statusLabel != null) {
                statusLabel.Dispose ();
                statusLabel = null;
            }

            if (titleLabel != null) {
                titleLabel.Dispose ();
                titleLabel = null;
            }

            if (wifiNameField != null) {
                wifiNameField.Dispose ();
                wifiNameField = null;
            }
        }
    }
}