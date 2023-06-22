using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static War.Heroes.IHeroFactory;

namespace War.Heroes
{
    public interface IHero
    {
        HeroType HeroType { get; }
        Guid Id { get; }
        uint Health { get; }
        bool IsAlive { get; }
        void Rest();
        void Die();
        void Fight();

    }
}
