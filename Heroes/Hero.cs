using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static War.Heroes.IHeroFactory;

namespace War.Heroes
{
    public class Hero : IHero
    {
        private readonly uint HealFactor = 10;
        private bool IsKilled;
        protected uint InitialHealth;
        private readonly ILogger logger;

        public Hero(uint initialHealth, HeroType heroType, ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            Id = Guid.NewGuid();
            InitialHealth = initialHealth;
            HeroType = heroType;
            Health = initialHealth;
            IsKilled = false;
        }

        public Guid Id { get; private set; }

        public uint Health { get; protected set; }

        public bool IsAlive => Health > InitialHealth / 4 && !IsKilled;

        public HeroType HeroType { get; private set; }

        public void Rest()
        {
            if (!IsAlive)
            {
                throw new DeadHeroException("Rest called on a dead hero.");
            }

            uint healingFrom = Health;
            Health = Math.Min(InitialHealth, Health + HealFactor);
            logger.Information($"{HeroType} with ID: {Id} is resting and healed from {healingFrom} to {Health}.");

        }

        public void Die()
        {
            if (!IsAlive)
            {
                throw new DeadHeroException("Die called on a dead hero.");
            }
            
            IsKilled = true;
            logger.Information($"{HeroType} with ID: {Id} died.");            
        }

        public void Fight()
        {
            if (!IsAlive)
            {
                throw new DeadHeroException("Fight called on a dead hero.");
            }

            uint healthBeforeFight = Health;
            Health /= 2;
            logger.Information($"{HeroType} with ID: {Id} is fighting, health changed from {healthBeforeFight} to {Health}.");
            
        }

    }
}
