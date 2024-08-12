using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actors.Stats
{
    public class Stat
    {
        protected int _hp;
        protected int _attackPoint;
        protected int _defense;

        public int HP { get { return _hp; } set { _hp = value; } }
        public int AttackPoint { get { return _attackPoint; } set { _attackPoint = value; } }
        public int Defense { get { return _defense; } set { _defense = value; } }
    }
}
