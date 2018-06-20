using System;
using System.Collections.Generic;
using System.Linq;

namespace MoreBotProgrammer.Core
{
    class UserProgramEntity
    {
        List<BlockEntity> blockEntities;

        public UserProgramEntity()
        {
            // So json can deserialize
            blockEntities = new List<BlockEntity>();
        }

        public string Name { get; set; }

        public DateTime LastModified { get; set; }

        public IEnumerable<BlockEntity> BlockEntities {
            get { return blockEntities; }

            set {
                blockEntities.Clear();
                if (value != null) {
                    blockEntities.AddRange(value);
                }
            }
        }

        public IEnumerable<Block> GetBlocks()
        {
            return BlockEntities.Select(entity => entity.ToBlock());
        }
    }
}
