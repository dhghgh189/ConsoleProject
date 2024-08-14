using ConsoleProject2_ForTheTop.Actors.Stats;
using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actors
{
    public class Player : Warrior
    {
        Define.ECondition _condition;
        int _gold;
        // inventory 필요 

        public int Gold { get { return _gold; } set { _gold = value; } }

        public Define.ECondition Condition
        {
            get { return _condition; }
            set { _condition = value; }
        }

        public Player(string name) : base(name, Define.EActor.Player)
        {
            
        }

        public override void SetInfo(int maxHp, int attackPoint, int defense)
        {
            base.SetInfo(maxHp, attackPoint, defense);

            _condition = Define.ECondition.Good;
            _gold = 1000;
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }

        public override void Die()
        {
            base.Die();
        }

    }
}
