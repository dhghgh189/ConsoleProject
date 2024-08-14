using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actions.Battle
{
    public class BattleEnemyAttack : BaseAction
    {
        public BattleEnemyAttack() : base(Define.ESubAction.BattleEnemyAttack)
        {

        }

        public override void Execute()
        {
            int amount = Game.Actor.CurrentEnemy.Stat.AttackPoint;
            Game.Actor.Player.TakeDamage(amount);
        }
    }
}
