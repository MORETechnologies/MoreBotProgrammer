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
    [Register ("ProgrammerViewController")]
    partial class ProgrammerViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton addMoveBlockButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton addSleepBlockButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton backButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView blockCollectionView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView footerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView headerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton runButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel titleLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (addMoveBlockButton != null) {
                addMoveBlockButton.Dispose ();
                addMoveBlockButton = null;
            }

            if (addSleepBlockButton != null) {
                addSleepBlockButton.Dispose ();
                addSleepBlockButton = null;
            }

            if (backButton != null) {
                backButton.Dispose ();
                backButton = null;
            }

            if (blockCollectionView != null) {
                blockCollectionView.Dispose ();
                blockCollectionView = null;
            }

            if (footerView != null) {
                footerView.Dispose ();
                footerView = null;
            }

            if (headerView != null) {
                headerView.Dispose ();
                headerView = null;
            }

            if (runButton != null) {
                runButton.Dispose ();
                runButton = null;
            }

            if (titleLabel != null) {
                titleLabel.Dispose ();
                titleLabel = null;
            }
        }
    }
}