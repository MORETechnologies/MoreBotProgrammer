using System;
using CoreGraphics;
using MoreBotProgrammer.Core;
using UIKit;

namespace MoreBotProgrammer.iOS
{
    public abstract class BlockViewCell : UICollectionViewCell
    {
        protected BlockViewCell(IntPtr handle) : base(handle)
        {
        }

        public abstract BlockViewModel BlockViewModel { get; }

        public abstract void SetViewModel(BlockViewModel blockViewModel);

        protected void OnAwake(UIView container)
        {
            container.Layer.ShadowOffset = new CGSize(4, 4);
        }
    }
}
