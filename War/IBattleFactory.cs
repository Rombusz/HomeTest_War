﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War.War
{
    internal interface IBattleFactory
    {
        IBattle CreateBattle();
    }
}
