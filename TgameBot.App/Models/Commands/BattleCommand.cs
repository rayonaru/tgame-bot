using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TgameBot.Battle;

namespace TgameBot.Models.Commands
{
    public class BattleCommand : Command
    {
        public override string Name => @"/battle";

        public override bool Contains(Message message)
        {
            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Context context, CancellationToken token = default)
        {
            Console.WriteLine($"BattleGame started");

            var battle = new BattleGame();

            var players = context.State.Users
                .Select(x => $"@{x.Value.Username}")
                .ToArray();

            var warriors =  battle.CreateWarriors(players);
            var battleResult = battle.StartFight(warriors);


            foreach (var chat in context.State.Chats)
                await context.BotClient.SendTextMessageAsync(chat.Value.Id, battleResult, cancellationToken: token);
        }
    }
}