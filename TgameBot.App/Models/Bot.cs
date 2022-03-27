using System.Collections.Generic;
using Telegram.Bot;
using TgameBot.Models.Commands;

namespace TgameBot.Models
{
    public static class Bot
    {
        private static TelegramBotClient botClient;
        private static List<Command> commands;

        public static IReadOnlyList<Command> Commands => commands.AsReadOnly();

        public static TelegramBotClient GetBotClient()
        {
            commands = new List<Command>();

            commands.Add(new NoCommand());
            commands.Add(new UnknownCommand());

            commands.Add(new StartCommand());
            commands.Add(new JoinCommand());
            commands.Add(new BattleCommand());
            commands.Add(new LeaveCommand());
            commands.Add(new MessageCommand());
            commands.Add(new OnlineCommand());
            commands.Add(new HelpCommand());

            botClient = new TelegramBotClient("token");

            return botClient; 
        }
    }
}
