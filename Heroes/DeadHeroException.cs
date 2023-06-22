using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War.Heroes
{
    public class DeadHeroException : Exception
    {
        public DeadHeroException(string? message) : base(message)
        {
        }
    }
}
