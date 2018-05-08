using System;
using MoreBotProgrammer.Core;
using UIKit;

namespace MoreBotProgrammer.iOS
{
    public abstract class BlockViewCell : UICollectionViewCell
    {
        protected BlockViewCell(IntPtr handle) : base(handle)
        {
        }

        public abstract nfloat Height { get; }

        public abstract BlockViewModel BlockViewModel { get; }

        public abstract void SetViewModel(BlockViewModel blockViewModel);
    }
}
