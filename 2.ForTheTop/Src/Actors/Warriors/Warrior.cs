using ConsoleProject2_ForTheTop.Actors.Stats;
using ConsoleProject2_ForTheTop.Utils;

namespace ConsoleProject2_ForTheTop.Actors
{
    public class Warrior : Actor
    {
        protected bool _isAlive;
        protected Stat _stat;

        public bool IsAlive { get { return _isAlive; } }
        public Stat Stat { get { return _stat; } }

        public Warrior(string name, Define.EActor type) : base(name, type)
        {
            
        }

        // 필요한 정보를 set
        public virtual void SetInfo(int maxHp, int attackPoint, int defense)
        {
            _isAlive = true;

            // 임시
            Stat stat = new Stat();
            stat.MaxHP = maxHp;
            stat.HP = maxHp;
            stat.AttackPoint = attackPoint;
            stat.Defense = defense;
            _stat = stat;
        }

        public virtual void TakeDamage(int amount)
        {
            _stat.HP -= amount;
            if (_stat.HP <= 0)
            {
                Die();
            }
        }

        public virtual void Die()
        {
            // TODO : 사망처리
            _isAlive = false;
        }
    }
}
