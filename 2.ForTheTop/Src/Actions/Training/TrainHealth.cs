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
        public TrainHealth(int amount) : base(amount, Define.ETrainType.Health)
        {
        }

        public override void Execute()
        {
            Game.Player.Stat.HP += _amount;
        }
    }
}
