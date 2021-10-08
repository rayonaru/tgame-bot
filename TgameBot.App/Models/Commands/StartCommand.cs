using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

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

            // await context.BotClient.SendTextMessageAsync(context.Message.Chat.Id, "Bot started, enter /join to start game", cancellationToken: token);

            var keyboardMarkup = GetKeyboard();

            await context.BotClient.SendTextMessageAsync(context.Message.Chat.Id, "Bot started, enter /join to start game", replyMarkup: keyboardMarkup, cancellationToken: token);
        }

        private ReplyKeyboardMarkup GetKeyboard()
        {
            var keyboard = new ReplyKeyboardMarkup();

            keyboard.ResizeKeyboard = true;
            keyboard.OneTimeKeyboard = true;
            keyboard.Keyboard = new KeyboardButton[][]
            {
                new KeyboardButton[]
                {
                    new KeyboardButton("/join")
                }
            };

            return keyboard;
        }
    }
}