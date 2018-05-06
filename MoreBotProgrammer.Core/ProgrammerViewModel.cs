using System.Collections.ObjectModel;

namespace MoreBotProgrammer.Core
{
    public class ProgrammerViewModel
    {
        ObservableCollection<IBlock> blocks;

        public ProgrammerViewModel()
        {
            blocks = new ObservableCollection<IBlock>();
            Blocks = new ReadOnlyObservableCollection<IBlock>(blocks);
        }

        public ReadOnlyObservableCollection<IBlock> Blocks { get; private set; }

        public void OnAddBlock(IBlock block)
        {
            blocks.Add(block);
        }

        public void OnRemoveBlock(IBlock block)
        {
            blocks.Remove(block);
        }
    }
}
