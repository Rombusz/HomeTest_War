using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War.Heroes;

namespace War.War
{
    public class RandomAliveParticipantSelector : IBattleParticipantSelector
    {
        public BattleParticipants SelectParticipants(IList<IHero> heroList)
        {
            IList<IHero> aliveHeroes = heroList.Where(hero => hero.IsAlive).ToList();
            var aliveHeroCount = aliveHeroes.Count();

            if (aliveHeroCount < 2)
            {
                throw new ParticipantSelectorException($"Number of heroes alive: {aliveHeroCount} it should be 2 atleast.");
            }

            BattleParticipants participants = new BattleParticipants();

            participants.Attacker = SelectAttacker(aliveHeroes);
            participants.Defender = SelectDefender(participants.Attacker, aliveHeroes);

            return participants;
        }
        private IHero SelectAttacker(IList<IHero> aliveHeroList)
        {
            return SelectHeroRandomly(aliveHeroList);
        }

        private IHero SelectDefender(IHero attacker, IList<IHero> aliveHeroList)
        {
            IHero defender = SelectHeroRandomly(aliveHeroList);

            while (attacker == defender)
            {
                defender = SelectHeroRandomly(aliveHeroList);
            }

            return defender;
        }

        private IHero SelectHeroRandomly(IList<IHero> aliveHeroList)
        {
            Random rnd = new Random();
            int aliveHeroNumber = aliveHeroList.Count();

            int randomIndex = rnd.Next(0, aliveHeroNumber);

            return aliveHeroList.ElementAt(randomIndex);
        }
    }
}
