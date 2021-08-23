using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TgameBot.Models.Commands
{
    public class HelpCommand : Command
    {
        public override string Name => @"/help";

        public override bool Contains(Message message)
        {
            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Context context, CancellationToken token = default)
        {
            var chatid = context.Message.Chat.Id;
            await context.BotClient.SendTextMessageAsync(
                chatid, 
                @"Available commands:
/start - start bot
/join - join to game
/leave - leave from game
/message - send anonymous message to all
/battle - start battle game
/help - see all commands", cancellationToken: token);   
        }
    }
}