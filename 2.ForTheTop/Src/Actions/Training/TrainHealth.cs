using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actions.Training
{
    public class TrainHealth : Training
    {
        public TrainHealth(int amount) : base(Define.ESubAction.TrainHealth, amount)
        {
        }

        public override void Execute()
        {
            Game.Actor.Player.Stat.MaxHP += _amount;
        }
    }
}
