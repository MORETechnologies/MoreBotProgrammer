namespace MoreBotProgrammer.Core
{
    public abstract class BlockViewModel
    {
        public abstract BlockType BlockType { get; }

        public abstract int Lines { get; }

        internal abstract Block Block { get; }
    }
}
