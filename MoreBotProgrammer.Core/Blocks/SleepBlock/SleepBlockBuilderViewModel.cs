namespace MoreBotProgrammer.Core
{
    public class SleepBlockBuilderViewModel : BlockBuilderViewModel
    {
        Block currentBlock;

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

        public override void Save()
        {
            OnBlockBuilt(this, new SleepBlock(Milliseconds));
        }

        public override void Delete()
        {
            OnBlockDelete(this, currentBlock);
        }

        internal override void UpdateValues(Block block)
        {
            SleepBlock sleepBlock = (SleepBlock)block;

            Milliseconds = sleepBlock.Milliseconds;

            currentBlock = block;
        }
    }
}
