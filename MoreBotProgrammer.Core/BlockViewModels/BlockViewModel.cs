namespace MoreBotProgrammer.Core
{
    public abstract class BlockViewModel
    {
        public abstract BlockType BlockType { get; }

        internal Block Block { get; }
    }
}
