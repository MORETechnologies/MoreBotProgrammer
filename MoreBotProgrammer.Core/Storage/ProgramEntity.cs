using System;
using System.Collections.Generic;
using System.Linq;

namespace MoreBotProgrammer.Core
{
    class ProgramEntity
    {
        public ProgramEntity()
        {
        }

        public ProgramEntity(string name, IEnumerable<Block> blocks)
        {
            Name = name;
            BlockEntities = blocks.Select(block => block.ToEntity());
        }

        public string Name { get; set; }

        public DateTime LastModified { get; set; }

        public IEnumerable<BlockEntity> BlockEntities { get; set; }

        public IEnumerable<Block> GetBlocks()
        {
            return BlockEntities.Select(entity => entity.ToBlock());
        }
    }
}
