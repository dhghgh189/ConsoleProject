using ConsoleProject2_ForTheTop.Actors;
using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actions.Battle
{
    public class BattleAttack : BaseAction
    {
        public BattleAttack() : base(Define.ESubAction.BattleAttack) 
        {
            
        }

        public override void Execute()
        {
            int amount = Game.Actor.Player.Stat.AttackPoint;
            Game.Actor.CurrentEnemy.TakeDamage(amount);
        }
    }
}
