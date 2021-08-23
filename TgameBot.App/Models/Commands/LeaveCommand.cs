using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TgameBot.Models.Commands
{
    public class LeaveCommand : Command
    {
        public override string Name => @"/leave";

        public override bool Contains(Message message)
        {
            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Context context, CancellationToken token = default)
        {
            bool isuserStoped = context.State.Users.Remove(context.Message.From.Id);

            if (!isuserStoped)
            {
                await context.BotClient.SendTextMessageAsync(context.Message.Chat.Id, "You already leave", cancellationToken: token);
                return;
            }

            Console.WriteLine($"{context.Message.From.Username} leaved");

            foreach (var chat in context.State.Chats)
                await context.BotClient.SendTextMessageAsync(chat.Value.Id, $"@{context.Message.From.Username} leaved", cancellationToken: token);
        }
    }
}