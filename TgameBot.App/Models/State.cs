using System.Collections.Generic;
using Telegram.Bot.Types;

namespace TgameBot.Models
{
   public class State
   {
      public Dictionary<long, User> Users = new Dictionary<long, User>();

      public Dictionary<long, Chat> Chats = new Dictionary<long, Chat>();
   }
}