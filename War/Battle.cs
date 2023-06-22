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
        private readonly IBattleParticipantSelector participantSelector;

        public bool IsFinished { get; private set; }

        public uint Round { get; private set; }

        public IList<IHero> Heroes { get; private set; }

        public Battle(IList<IHero> heroes, IBattleParticipantSelector participantSelector)
        {
            this.participantSelector = participantSelector ?? throw new ArgumentNullException(nameof(participantSelector));
            
            IsFinished = false;
            Round = 0;
            Heroes = heroes;
        }

        public bool ExecuteNextRound()
        {

            BattleParticipants participants = participantSelector.SelectParticipants(Heroes);

            IHero attacker = participants.Attacker;
            IHero defender = participants.Defender;

            foreach (IHero hero in Heroes)
            {
                if (hero != attacker && hero != defender)
                {
                    hero.Rest();
                }
            }

            //call attacker/defender functions on others

            Round++;

            IsFinished = Heroes.Count(hero => hero.IsAlive) <= 1;

            return IsFinished;
        }
       

    }
}
