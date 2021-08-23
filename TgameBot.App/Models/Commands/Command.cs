using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TgameBot.Models.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract Task Execute(Context context, CancellationToken token = default);
        public abstract bool Contains(Message message);
    }
}