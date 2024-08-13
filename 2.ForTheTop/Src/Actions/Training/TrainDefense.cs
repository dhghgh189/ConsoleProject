using ConsoleProject2_ForTheTop.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actions.Training
{
    public class TrainDefense : Training
    {
        public TrainDefense(int amount) : base(amount, Utils.Define.ETrainType.Defense)
        {
        }

        public override void Execute()
        {
            Game.Player.Stat.Defense += _amount;
        }
    }
}
