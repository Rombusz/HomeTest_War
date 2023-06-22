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
        private readonly IBattleParticipantSelector participantSelector;

        public BattleFactory(int numberOfHeroes, IHeroFactory heroFactory, IBattleParticipantSelector participantSelector) {

            this.numberOfHeroes = numberOfHeroes;
            this.heroFactory = heroFactory ?? throw new ArgumentNullException(nameof(heroFactory));
            this.participantSelector = participantSelector ?? throw new ArgumentNullException(nameof(participantSelector));
        
        }

        public IBattle CreateBattle()
        {
            //TODO null???
            IList<IHero> heroes = new List<IHero>();

            for(int i = 0; i < numberOfHeroes; i++)
            {
                var hero = heroFactory.CreateRandomHero();
                heroes.Add(hero);
            }

            return new Battle(heroes, participantSelector);
        }
    }
}
