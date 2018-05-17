﻿namespace MoreBotProgrammer.Core
{
    public class SleepBlockBuilderViewModel : BlockBuilderViewModel
    {
        public SleepBlockBuilderViewModel()
        {
            Milliseconds = 1000;
        }

        public int Milliseconds { get; private set; }

        public override BlockType BlockType => BlockType.Sleep;

        public void ChangeMilliseconds(int milliseconds)
        {
            Milliseconds = milliseconds;
        }

        public void Save()
        {
            OnBlockBuilt(this, new SleepBlock(Milliseconds));
        }

        internal override void UpdateValues(Block block)
        {
            SleepBlock sleepBlock = (SleepBlock)block;

            Milliseconds = sleepBlock.Milliseconds;
        }
    }
}
