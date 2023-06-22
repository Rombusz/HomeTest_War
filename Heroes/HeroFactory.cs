using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War.Heroes
{
    public class HeroFactory : IHeroFactory
    {
        private readonly ILogger logger;

        public HeroFactory(ILogger logger)
        {
            this.logger = logger;
        }

        public IHero Create(IHeroFactory.HeroType type)
        {

            switch (type)
            {
                case IHeroFactory.HeroType.Archer:
                    return new Hero(100, IHeroFactory.HeroType.Archer, logger);
                case IHeroFactory.HeroType.SwordsMan:
                    return new Hero(120, IHeroFactory.HeroType.SwordsMan, logger);
                case IHeroFactory.HeroType.Calvalry:
                    return new Hero(150, IHeroFactory.HeroType.Calvalry, logger);
                default:
                    throw new ArgumentException("Unknown hero type.");
            }
        }

        public IHero CreateRandomHero()
        {
            var heroTypes = Enum.GetValues<IHeroFactory.HeroType>();
            Random random = new Random();

            int randomIndex = random.Next(heroTypes.Length);

            IHeroFactory.HeroType type = heroTypes[randomIndex];

            return Create(type);
        }
    }
}
