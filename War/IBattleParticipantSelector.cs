using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War.Heroes;

namespace War.War
{
    public class BattleParticipants
    {
        public IHero Attacker { get; set; }

        public IHero Defender { get; set; }
    }

    public interface IBattleParticipantSelector
    {
        BattleParticipants SelectParticipants(IList<IHero> heroList);

    }
}
