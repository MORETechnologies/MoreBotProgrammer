using System;
namespace MoreBotProgrammer.Core
{
    class BlockFactory
    {
        public Block CreateBlock(BlockType blockType)
        {
            switch (blockType) {
                case BlockType.Move:
                    return new MoveBlock();
                case BlockType.Sleep:
                    return new SleepBlock();
            }

            return null;
        }
    }
}
