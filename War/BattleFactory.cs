using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War.Heroes;
using static War.Heroes.IHeroFactory;

namespace War.War
{
    public class BattleFactory : IBattleFactory
    {
        private readonly int numberOfHeroes;
        private readonly IHeroFactory heroFactory;
        private readonly ICombatParticipantSelector participantSelector;
        private readonly ICombat combat;
        private readonly ILogger logger;

        public BattleFactory(
            int numberOfHeroes,
            IHeroFactory heroFactory,
            ICombatParticipantSelector participantSelector,
            ICombat combat,
            ILogger logger)
        {

            this.numberOfHeroes = numberOfHeroes;
            this.heroFactory = heroFactory ?? throw new ArgumentNullException(nameof(heroFactory));
            this.participantSelector = participantSelector ?? throw new ArgumentNullException(nameof(participantSelector));
            this.combat = combat ?? throw new ArgumentNullException(nameof(combat));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IBattle CreateBattle()
        {
            IList<IHero> heroes = new List<IHero>();

            for(int i = 0; i < numberOfHeroes; i++)
            {
                var hero = heroFactory.CreateRandomHero();
                heroes.Add(hero);
            }

            return new Battle(heroes, participantSelector, combat, logger);
        }
    }
}
