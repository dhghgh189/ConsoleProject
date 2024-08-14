using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actors
{
    public class Enemy : Warrior
    {
        // reward
        int _gold;

        public int Gold { get { return _gold; } }

        public Enemy(string name) : base(name, Define.EActor.Enemy)
        {
            
        }

        public override void SetInfo(int maxHp, int attackPoint, int defense)
        {
            base.SetInfo(maxHp, attackPoint, defense);
        }

        public void SetReward(int gold)
        {
            _gold = gold;
        }

        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);
        }

        public override void Die()
        {
            base.Die();
        }
    }
}
