using System;

namespace MoreBotProgrammer.Core
{
    public class MoveBlockBuilderViewModel
    {
        private MoveDirection currentDirection;

        public MoveBlockBuilderViewModel()
        {
            currentDirection = MoveDirection.Forward;
            Speed = 80;
            DirectionOptions = Enum.GetNames(typeof(MoveDirection));
        }

        public event EventHandler ValuesChanged;

        public BlockType BlockType => BlockType.Move;

        public string SelectedDirection => currentDirection.ToString();

        public int Speed { get; private set; }

        public string[] DirectionOptions { get; private set; }

        public int MaxSpeed => 100;

        public int MinSpeed => 0;

        public void OnDirectionChanged(int index)
        {
            if (index > 0 && index < DirectionOptions.Length) {
                currentDirection = (MoveDirection)index;
                ValuesChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void OnSpeedChanged(int speed)
        {
            if (speed < 0) {
                speed = 0;
            } else if (speed > 100) {
                speed = 100;
            }

            if (speed != Speed) {
                Speed = speed;
                ValuesChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
