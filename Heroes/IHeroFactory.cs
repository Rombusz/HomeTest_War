using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War.Heroes
{
    internal interface IHeroFactory
    {
        enum HeroType
        {
            Archer,
            SwordsMan,
            Calvalry
        }

        IHero Create(HeroType type);

    }
}
