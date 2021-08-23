using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TgameBot.Models.Commands
{
    public class UnknownCommand : Command
    {
        public override string Name => @"unknownCommand";

        public override bool Contains(Message message)
        {
            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Context context, CancellationToken token = default)
        {
            var chatid = context.Message.Chat.Id;
            await context.BotClient.SendTextMessageAsync(chatid, "Oops... This command not exist. Please use /help to see commands list", cancellationToken: token);   
        }
    }
}