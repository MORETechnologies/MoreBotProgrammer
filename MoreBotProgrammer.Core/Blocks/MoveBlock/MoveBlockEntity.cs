namespace MoreBotProgrammer.Core
{
    class MoveBlockEntity : BlockEntity
    {
        public MoveBlockEntity()
        {
        }

        public MoveBlockEntity(MoveBlock block)
        {
            Direction = block.Direction;
            Speed = block.Speed;
        }

        public MoveDirection Direction { get; set; }

        public int Speed { get; set; }

        public override Block ToBlock()
        {
            return new MoveBlock(Direction, Speed);
        }
    }
}
