using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War.Heroes;

namespace War.War
{
    public interface IBattle
    {
        public bool IsFinished { get; }
        public uint Round { get; }
        public IList<IHero> Heroes { get; }
        bool ExecuteNextRound();
    }
}
