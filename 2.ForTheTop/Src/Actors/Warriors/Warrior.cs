using ConsoleProject2_ForTheTop.Actors.Stats;
using ConsoleProject2_ForTheTop.Utils;

namespace ConsoleProject2_ForTheTop.Actors
{
    public class Warrior : Actor
    {
        protected bool _isAlive;
        protected Stat _stat;
        protected Define.EBattleState _state;

        public bool IsAlive { get { return _isAlive; } }
        public Stat Stat { get { return _stat; } }
        public Define.EBattleState State { get { return _state; } set { _state = value; } }

        // 가장 최근 받은 피해량
        public int LatestDamageAmount { get; set; }

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
            LatestDamageAmount = amount;
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
