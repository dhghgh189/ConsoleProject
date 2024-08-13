using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public interface IActable
    {
        public event Action OnCompleteAction;
    }
}
