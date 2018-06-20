using System;
using System.Collections.Generic;
using System.Linq;

namespace MoreBotProgrammer.Core
{
    class UserProgramRepository
    {
        const string DefaultName = "Program";

        JsonProgramStorage storage;
        UserProgramEntity userProgramEntity;

        public UserProgramRepository(JsonProgramStorage storage)
        {
            this.storage = storage;
        }

        public IEnumerable<Block> GetBlocks()
        {
            if (userProgramEntity == null) {
                userProgramEntity = storage.Read();
            }

            return userProgramEntity.BlockEntities.Select(b => b.ToBlock());
        }

        public void Update(IEnumerable<Block> blocks)
        {
            userProgramEntity.BlockEntities = blocks.Select(b => b.ToEntity());
            userProgramEntity.LastModified = DateTime.UtcNow;

            storage.Write(userProgramEntity);
        }
    }
}
