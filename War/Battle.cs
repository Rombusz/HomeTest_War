using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War.Heroes;

namespace War.War
{
    public class Battle : IBattle
    {
        private readonly ICombatParticipantSelector participantSelector;
        private readonly ICombat combat;
        private readonly ILogger logger;

        public bool IsFinished { get; private set; }

        public uint Round { get; private set; }

        public IList<IHero> Heroes { get; private set; }

        public Battle(IList<IHero> heroes, ICombatParticipantSelector participantSelector, ICombat combat, ILogger logger)
        {
            this.participantSelector = participantSelector ?? throw new ArgumentNullException(nameof(participantSelector));
            this.combat = combat ?? throw new ArgumentNullException(nameof(combat));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            IsFinished = false;
            Round = 1;
            Heroes = heroes;
        }

        public bool ExecuteNextRound()
        {

            logger.Information(string.Empty);
            logger.Information($"Round {Round}");

            CombatParticipants participants = participantSelector.SelectParticipants(Heroes);

            IHero attacker = participants.Attacker;
            IHero defender = participants.Defender;

            logger.Information($"Resting heros:");

            foreach (IHero hero in Heroes)
            {
                if (hero != attacker && hero != defender && hero.IsAlive)
                {
                    hero.Rest();
                }
            }

            logger.Information($"Fighting heros:");

            combat.CombatParticipants = participants;
            combat.EvaluateCombat();

            Round++;

            IsFinished = Heroes.Count(hero => hero.IsAlive) <= 1;

            return IsFinished;
        }       

    }
}
