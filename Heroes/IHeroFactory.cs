using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War.Heroes
{
    public interface IHeroFactory
    {
        enum HeroType
        {
            Archer,
            SwordsMan,
            Calvalry
        }

        IHero Create(HeroType type);

        IHero CreateRandomHero();

    }
}
