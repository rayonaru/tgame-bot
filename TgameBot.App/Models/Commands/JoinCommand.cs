using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TgameBot.Models.Commands
{
    public class JoinCommand : Command
    {
        public override string Name => @"/join";

        public override bool Contains(Message message)
        {
            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Context context, CancellationToken token = default)
        {
            bool isUserJoined = context.State.Users.TryAdd(context.Message.From.Id, context.Message.From);

            if (!isUserJoined)
            {
                await context.BotClient.SendTextMessageAsync(context.Message.Chat.Id, "You already joined", cancellationToken: token);
                return;
            }

            Console.WriteLine($"{context.Message.From.Username} join");

            foreach (var chat in context.State.Chats)
                await context.BotClient.SendTextMessageAsync(chat.Value.Id, $"@{context.Message.From.Username} joined", cancellationToken: token);
        }
    }
}