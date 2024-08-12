using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actors.Stats
{
    public class PlayerStat : Stat
    {
        // 캐릭터의 컨디션
        Define.ECondition _condition;

        public Define.ECondition Condition { get { return _condition; } set { _condition = value; } }
    }
}
