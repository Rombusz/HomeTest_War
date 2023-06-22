using Serilog;
using Serilog.Core;
using Serilog.Sinks.SystemConsole.Themes;
using System.Net.Security;
using War.Heroes;
using War.War;

namespace War
{
    internal class Program
    {
        static void Main(string[] args)
        {


            var log = new LoggerConfiguration()
              .WriteTo.Console(theme: AnsiConsoleTheme.Code)
              .CreateLogger();

            IHeroFactory heroFactory = new HeroFactory(log);
            ICombat combat = new Combat(log);
            ICombatParticipantSelector participantSelector = new RandomAliveParticipantSelector();


            IBattleFactory battleFactory = new BattleFactory(
                10,
                heroFactory,
                participantSelector,
                combat,
                log
                );

            IBattle battle = battleFactory.CreateBattle();

            while (!battle.IsFinished)
            {
                battle.ExecuteNextRound();
            }

            var lastHero = battle.Heroes.Where(hero=>hero.IsAlive).SingleOrDefault();

            if( lastHero != null )
            {
                log.Information($"Battle finished the winner is a {lastHero.HeroType} with ID: {lastHero.Id}");
            }
            else
            {
                log.Information($"Battle finished everyone died.");
            }

        }
    }
}