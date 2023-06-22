using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War.War
{
    public class ParticipantSelectorException : Exception
    {
        public ParticipantSelectorException(string? message) : base(message)
        {
        }
    }
}
