using System;
using System.Threading.Tasks;

namespace MoreBotProgrammer.Core
{
    public abstract class BlockViewModel
    {
        protected bool running;

        public event EventHandler<bool> RunningChanged;

        public abstract BlockType BlockType { get; }

        public abstract int Lines { get; }

        public bool Running {
            get { return running; }
            set {
                if (running != value) {
                    running = value;
                    RunningChanged?.Invoke(this, running);
                }
            }
        }

        internal abstract Block Block { get; }

        public virtual async Task Run()
        {
            Running = true;
            Task.Run(async () => {
                await Task.Delay(250);
                Running = false;
            });
        }
    }
}
