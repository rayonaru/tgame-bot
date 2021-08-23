using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TgameBot.Models.Commands
{
    public class OnlineCommand : Command
    {
        public override string Name => @"/online";

        public override bool Contains(Message message)
        {
            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Context context, CancellationToken token = default)
        {
            string onlinePlayers = string.Empty;

            if (context.State.Users.Count != 0)
                onlinePlayers = context.State.Users
                    .Select(x => $"@{x.Value?.Username}")
                    .Aggregate((current, next) => $"{current}\n{next}");

            await context.BotClient.SendTextMessageAsync(context.Message.Chat.Id, $"Online players: {context.State.Users.Count}\n{onlinePlayers}", cancellationToken: token);
        }
    }
}