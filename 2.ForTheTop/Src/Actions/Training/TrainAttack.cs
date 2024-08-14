using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actions.Training
{
    public class TrainAttack : Training
    {
        public TrainAttack(int amount) : base(Define.ESubAction.TrainAttack, amount)
        {
        }

        public override void Execute()
        {
            Game.Actor.Player.Stat.AttackPoint += _amount;
        }
    }
}
