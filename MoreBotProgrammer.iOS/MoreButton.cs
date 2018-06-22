using System;
using System.ComponentModel;
using Foundation;
using UIKit;

namespace MoreBotProgrammer.iOS
{
    [Register("MoreButton"), DesignTimeVisible(true)]
    public class MoreButton : UIButton
    {
        public MoreButton()
        {
            Initialize();
        }

        public MoreButton(IntPtr ptr) : base(ptr)
        {
            Initialize();
        }

        [Export("CornerRadius")]
        public nfloat CornerRadius {
            get => Layer.CornerRadius;
            set {
                Layer.CornerRadius = value;
                SetNeedsDisplay();
            }
        }

        void Initialize()
        {
            BackgroundColor = Colors.Primary;
            SetTitleColor(Colors.LightText, UIControlState.Normal);
            SetTitleColor(Colors.LightText.ColorWithAlpha(0.75f), UIControlState.Highlighted);
            SetTitleColor(Colors.LightText.ColorWithAlpha(0.5f), UIControlState.Disabled);
        }
    }
}
