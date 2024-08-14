using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actors
{
    public class Actor
    {
        protected string _name;
        protected Define.EActor _type;

        public string Name { get { return _name; } }
        public Define.EActor Type { get { return _type; } }

        public Actor(string name, Define.EActor type)
        {
            _name = name;
            _type = type;
        }
    }
}
