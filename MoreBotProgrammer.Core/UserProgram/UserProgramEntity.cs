using System;
using System.Collections.Generic;
using System.Linq;

namespace MoreBotProgrammer.Core
{
    class UserProgramEntity
    {
        IEnumerable<BlockEntity> blockEntities;

        public string Name { get; set; }

        public DateTime LastModified { get; set; }

        public IEnumerable<BlockEntity> BlockEntities {
            get {
                if (blockEntities == null) {
                    return Enumerable.Empty<BlockEntity>();
                }

                return blockEntities;
            }

            set { blockEntities = value; }
        }

        public IEnumerable<Block> GetBlocks()
        {
            return BlockEntities.Select(entity => entity.ToBlock());
        }
    }
}
