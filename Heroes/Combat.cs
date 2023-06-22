using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War.War;
using static War.Heroes.IHeroFactory;

namespace War.Heroes
{
    public class Combat : ICombat
    {
        private readonly ILogger logger;

        public Combat(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public CombatParticipants CombatParticipants { get; set; }

        public void EvaluateCombat()
        {
            HeroType attackerType = CombatParticipants.Attacker.HeroType;
            HeroType defenderType = CombatParticipants.Defender.HeroType;

            var attacker = CombatParticipants.Attacker;
            var defender = CombatParticipants.Defender;

            logger.Information($"{attacker.HeroType} with ID: {attacker.Id} attacked {defender.HeroType} with ID: {defender.Id}");

            attacker.Fight();
            defender.Fight();

            switch (attackerType)
            {
                case HeroType.Archer:
                    ArcherAttacked(defenderType);
                    break;
                case HeroType.SwordsMan:
                    SwordsManAttacked(defenderType);
                    break;
                case HeroType.Calvalry:
                    CalvalryAttacked(defenderType);
                    break;
            }
        }

        private void ArcherAttacked(HeroType defenderType)
        {
            switch (defenderType)
            {
                case HeroType.Archer:
                    KillHero(CombatParticipants.Defender);
                    break;
                case HeroType.SwordsMan:
                    KillHero(CombatParticipants.Defender);
                    break;
                case HeroType.Calvalry:
                    if (ShouldCalvalryDie())
                    {
                        KillHero(CombatParticipants.Defender);
                    }
                    break;
            }
        }

        private void SwordsManAttacked(HeroType defenderType)
        {
            switch (defenderType)
            {
                case HeroType.Archer:
                    KillHero(CombatParticipants.Defender);
                    break;
                case HeroType.SwordsMan:
                    KillHero(CombatParticipants.Defender);
                    break;
                case HeroType.Calvalry:
                    break;
            }
        }

        private void CalvalryAttacked(HeroType defenderType)
        {
            switch (defenderType)
            {
                case HeroType.Archer:
                    KillHero(CombatParticipants.Defender);
                    break;
                case HeroType.SwordsMan:
                    KillHero(CombatParticipants.Attacker);
                    break;
                case HeroType.Calvalry:
                    KillHero(CombatParticipants.Defender);
                    break;
            }
        }

        bool ShouldCalvalryDie()
        {
            Random random = new Random();

            return random.Next(10) < 4;

        }

        void KillHero(IHero hero)
        {
            if (hero.IsAlive)
            {
                hero.Die();
            }
        }

    }
}
