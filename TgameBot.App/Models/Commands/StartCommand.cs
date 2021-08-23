using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TgameBot.Models.Commands
{
    public class StartCommand : Command
    {
        public override string Name => @"/start";

        public override bool Contains(Message message)
        {
            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Context context, CancellationToken token = default)
        {
            bool isChatStarted = context.State.Chats.TryAdd(context.Message.From.Id, context.Message.Chat);

            Console.WriteLine($"{context.Message.From.Username} started chat");

            await context.BotClient.SendTextMessageAsync(context.Message.Chat.Id, "Bot started, enter /join to start game", cancellationToken: token);
        }
    }
}