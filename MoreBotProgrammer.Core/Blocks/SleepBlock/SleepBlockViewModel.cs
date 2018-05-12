﻿namespace MoreBotProgrammer.Core
{
    public class SleepBlockViewModel : BlockViewModel
    {
        SleepBlock block;

        internal SleepBlockViewModel(Block block)
        {
            this.block = (SleepBlock)block;
        }

        public override BlockType BlockType => block.BlockType;

        public override int Lines => 1;

        public string Milliseconds => "Wait for " + block.Milliseconds.ToString() + " milliseconds";

        internal override Block Block => block;
    }
}
