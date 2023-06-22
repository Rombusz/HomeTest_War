using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War.Heroes;

namespace War.War
{
    public class CombatParticipants
    {
        public IHero Attacker { get; set; }

        public IHero Defender { get; set; }
    }

    public interface ICombatParticipantSelector
    {
        CombatParticipants SelectParticipants(IList<IHero> heroList);

    }
}
