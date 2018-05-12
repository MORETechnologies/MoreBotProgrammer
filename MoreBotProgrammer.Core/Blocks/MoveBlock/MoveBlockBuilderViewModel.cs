﻿using System;

namespace MoreBotProgrammer.Core
{
    public class MoveBlockBuilderViewModel : BlockBuilderViewModel
    {
        private MoveDirection currentDirection;

        internal MoveBlockBuilderViewModel()
        {
            currentDirection = MoveDirection.Forward;
            Speed = 80;
            DirectionOptions = Enum.GetNames(typeof(MoveDirection));
        }

        public event EventHandler ValuesChanged;

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

        public void OnSave()
        {
            OnBlockBuilt(this, new MoveBlock(currentDirection, Speed));
        }
    }
}
