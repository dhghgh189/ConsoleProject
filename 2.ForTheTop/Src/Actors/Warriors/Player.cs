using ConsoleProject2_ForTheTop.Actors.Stats;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actors.Warriors
{
    public class Player : Actor, IDamagable
    {
        PlayerStat _stat;
        int _gold;
        // inventory 필요 

        public PlayerStat Stat { get { return _stat; } }
        public int Gold { get { return _gold; } }

        public Player() : base(Define.EActor.Player)
        {
            _stat = new PlayerStat();
        }

        public override void SetInfo()
        {
            // 임시           
            _stat.HP = 100;
            _stat.AttackPoint = 10;
            _stat.Defense = 10;
            _stat.Condition = Define.ECondition.Good;

            _gold = 1000;
        }

        public void TakeDamage(int damage)
        {
            _stat.HP -= damage;
            if (_stat.HP <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            // TODO : 사망처리
        }

    }
}
