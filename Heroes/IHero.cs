using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War.Heroes
{
    internal interface IHero
    {
        Guid Id { get; }
        uint Health { get; }
        bool IsAlive { get; }
        void Rest();
        void Die();
        void SufferDamage(uint damage);

    }
}
