using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actions.Training
{
    public abstract class Training : BaseAction
    {
        protected int _amount;
        protected Define.ETrainType _type;

        public int Amount { get { return _amount; } }
        public Define.ETrainType Type { get { return _type; } }

        public Training(int amount, Define.ETrainType type)
        {
            _amount = amount;
            _type = type;
        }
    }
}
