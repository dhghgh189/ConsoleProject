using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actors.Stats
{
    public class Stat
    {
        protected int _maxHp;
        protected int _hp;
        protected int _attackPoint;
        protected int _defense;

        public int MaxHP { get { return _maxHp; } set { _maxHp = value; } }
        public int HP { 
            get { return _hp; } 
            set 
            {
                if (value > _maxHp)     _hp = _maxHp;
                else if (value < 0)     _hp = 0;
                else                    _hp = value;
            } 
        }
        public int AttackPoint { get { return _attackPoint; } set { _attackPoint = value; } }
        public int Defense { get { return _defense; } set { _defense = value; } }
    }
}
