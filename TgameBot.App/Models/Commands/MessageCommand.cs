using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TgameBot.Models.Commands
{
    public class MessageCommand : Command
    {
        public override string Name => @"/message";

        public override bool Contains(Message message)
        {
            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Context context, CancellationToken token = default)
        {
            var request = context.Message.Text?.Trim();

            var message = request.Remove(request.IndexOf("/"), request.IndexOf(" "));

            if (message == null)
            {
                await context.BotClient.SendTextMessageAsync(context.Message.Chat.Id, "Empty message, please write some text", cancellationToken: token);
                return;
            }

            Console.WriteLine($"{context.Message.From.Username} send message: {context.Message.Text}");

            foreach (var chat in context.State.Chats)
                await context.BotClient.SendTextMessageAsync(chat.Value.Id, $"Anonymous message: {message}", cancellationToken: token);
        }
    }
}