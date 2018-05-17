using System;

namespace MoreBotProgrammer.Core
{
    public class MoveBlockBuilderViewModel : BlockBuilderViewModel
    {
        Block currentBlock;
        MoveDirection currentDirection;

        internal MoveBlockBuilderViewModel()
        {
            currentDirection = MoveDirection.Forward;
            Speed = 80;
            DirectionOptions = Enum.GetNames(typeof(MoveDirection));
        }

        public event EventHandler ValuesChanged;

        public string SelectedDirection => currentDirection.ToString();

        public int Speed { get; private set; }

        public string SpeedText => Speed + "%";

        public string[] DirectionOptions { get; private set; }

        public int MaxSpeed => 100;

        public int MinSpeed => 0;

        public int CurrentDirectionIndex => (int)currentDirection;

        public override BlockType BlockType => BlockType.Move;

        public void ChangeDirection(int index)
        {
            if (index > 0 && index < DirectionOptions.Length) {
                currentDirection = (MoveDirection)index;
                ValuesChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void ChangeSpeed(int speed)
        {
            if (speed < MinSpeed) {
                speed = MinSpeed;
            } else if (speed > MaxSpeed) {
                speed = MaxSpeed;
            }

            if (speed != Speed) {
                Speed = speed;
                ValuesChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public override void Save()
        {
            OnBlockBuilt(this, new MoveBlock(currentDirection, Speed));
        }

        public override void Delete()
        {
            OnBlockDelete(this, currentBlock);
        }

        internal override void UpdateValues(Block block)
        {
            MoveBlock moveBlock = (MoveBlock)block;

            currentDirection = moveBlock.Direction;
            Speed = moveBlock.Speed;

            currentBlock = block;
        }
    }
}
