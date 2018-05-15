using System;
using MoreBotProgrammer.Core;
using UIKit;

namespace MoreBotProgrammer.iOS
{
    public abstract class BlockView : UIView
    {
        public BlockView(IntPtr handle) : base(handle)
        {
        }

        public static BlockView Create(BlockType blockType)
        {
            switch (blockType) {
                case BlockType.Move:
                    return MoveBlockView.Create();
                case BlockType.Sleep:
                    return SleepBlockView.Create();
            }

            return null;
        }

        public abstract BlockViewModel BlockViewModel { get; }

        public abstract void SetViewModel(BlockViewModel blockViewModel);
    }
}
