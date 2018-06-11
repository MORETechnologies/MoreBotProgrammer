using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreBotProgrammer.Core
{
    class Compiler
    {
        IBotClient client;

        public Compiler(IBotClient client)
        {
            this.client = client;
        }

        public async Task Compile(IEnumerable<Block> blocks)
        {
            List<CodeMessage> messages = new List<CodeMessage>();

            messages.Add(new BeginCodeMessage());
            messages.AddRange(blocks.Select(b => b.CodeMessage));
            messages.Add(new EndCodeMessage());

            foreach (var message in messages) {
                await client.SendMessage(message);
            }
        }
    }
}
