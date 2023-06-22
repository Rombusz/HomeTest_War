using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War.War;
using static War.Heroes.IHeroFactory;

namespace War.Heroes
{
    public interface ICombat
    {
        CombatParticipants CombatParticipants { get; set; }
        void EvaluateCombat();

    }
}
