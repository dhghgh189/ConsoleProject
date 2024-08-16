using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actions
{
    public class BattleDefense : BaseAction
    {
        public BattleDefense() : base(Define.ESubAction.BattleDefense)
        {

        }

        public override void Execute()
        {
            Game.Actor.Player.State = Define.EBattleState.Defense;
        }
    }
}
