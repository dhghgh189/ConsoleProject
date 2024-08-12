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
        protected Define.EActor _type;

        public Define.EActor Type { get { return _type; } }

        public Actor(Define.EActor type)
        {
            _type = type;
        }

        // 각 Actor 마다 필요한 정보를 설정
        public virtual void SetInfo()
        {

        }
    }
}
