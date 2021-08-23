using System;
using System.Linq;
using System.Threading;
using TgameBot.Models;

namespace TgameBot
{
    class Worker
    {
        private static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        [Obsolete]
        static void Main(string[] args)
        {
            Console.WriteLine("TgameBot started...");

            var state = new State();
            var botClient = Bot.GetBotClient();
            var commands = Bot.Commands;

            botClient.StartReceiving();

            Console.WriteLine("Wait messages...");

            botClient.OnMessage += async (sender, e) =>
            {
                // чтобы не ломался при не текстовых сообщениях
                if (e.Message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                    return;

                var context = new Context(botClient, e.Message, state);

                Console.WriteLine($"Receiver message: {e.Message.Text}");

                var command = commands.SingleOrDefault(x => x.Contains(e.Message));

                if (!e.Message.Text.Trim().StartsWith("/"))
                {
                    Console.WriteLine("Received not command");
                    command = commands.Single(x => x.Name == "noCommand");
                }

                if (command == null)
                {
                    Console.WriteLine("Received unknown command");
                    command = commands.Single(x => x.Name == "unknownCommand");
                }

                try
                {
                    Console.WriteLine($"Executing command: {command.Name}");

                    await command.Execute(context, cancellationTokenSource.Token);

                    Console.WriteLine($"Command success executed: {command.Name}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error when command executing\nCommand: {command.Name}\nError: {ex.Message}");
                }

                Console.WriteLine("Wait messages...");
            };

            Console.Read();

            botClient.StopReceiving();
        }
    }
}
