namespace MoreBotProgrammer.Core
{
    abstract class Block
    {
        public abstract BlockType BlockType { get; }

        public abstract CodeMessage CodeMessage { get; }

        public abstract BlockEntity ToEntity();
    }
}