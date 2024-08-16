using ConsoleProject2_ForTheTop.Datas;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleProject2_ForTheTop.Actors
{
    public class Enemy : Warrior
    {
        EnemyData _data;

        // reward
        int _gold;

        public EnemyData Data { get { return _data; } }
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
            int finalDamage = 0;
            if (_state == Define.EBattleState.Defense)
            {
                finalDamage = (int)(amount - _stat.Defense);
            }
            else
            {
                finalDamage = (int)(amount - _stat.Defense * 0.5f);
            }

            if (finalDamage <= 0)
            {
                finalDamage = (int)(amount * 0.2f);
            }

            base.TakeDamage(finalDamage);
        }

        public override void Die()
        {
            base.Die();
        }
    }
}
