using Telegram.Bot;
using Telegram.Bot.Types;

namespace TgameBot.Models
{
   public sealed class Context
   {
       public Context(TelegramBotClient botClient, Message message, State state)
       {
           this.BotClient = botClient;
           this.Message = message;
           this.State = state;
       }

       public TelegramBotClient BotClient { get; set; }
       public Message Message { get; set; }
       public State State { get; set; }
   }
}