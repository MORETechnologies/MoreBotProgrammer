namespace MoreBotProgrammer.Core
{
    class MoveBlock : Block
    {
        public MoveBlock(MoveDirection direction, int speed)
        {
            Direction = direction;
            Speed = speed;
        }

        public override BlockType BlockType => BlockType.Move;

        public override CodeMessage CodeMessage => new MoveCodeMessage(this);

        public MoveDirection Direction { get; private set; }

        public int Speed { get; private set; }
    }
}
