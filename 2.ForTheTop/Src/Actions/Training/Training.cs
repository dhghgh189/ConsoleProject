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

        public int Amount { get { return _amount; } }

        public Training(Define.ESubAction type, int amount) : base(type)
        {
            _amount = amount;
        }
    }
}
