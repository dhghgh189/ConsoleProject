using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actions
{
    public abstract class BaseAction
    {
        protected Define.ESubAction _subType;
        public Define.ESubAction SubType { get { return _subType; } }

        public BaseAction(Define.ESubAction subType)
        {
            _subType = subType;
        }

        public abstract void Execute();
    }
}
