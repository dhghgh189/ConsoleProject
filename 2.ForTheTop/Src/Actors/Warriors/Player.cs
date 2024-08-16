using ConsoleProject2_ForTheTop.Actors.Stats;
using ConsoleProject2_ForTheTop.Inventory;
using ConsoleProject2_ForTheTop.Utils;

namespace ConsoleProject2_ForTheTop.Actors
{
    public class Player : Warrior
    {
        Define.ECondition _condition;

        // 아이템으로 인해 추가되는 스탯을 분리
        Stat _additionalStat;

        int _gold;
        Inven _inventory;

        public int Gold { get { return _gold; } set { _gold = value; } }
        public Inven Inventory { get { return _inventory;} }
        public Stat AdditionalStat { get { return _additionalStat; } }

        public int FinalAttackPoint 
        { 
            get { return _stat.AttackPoint + _additionalStat.AttackPoint; } 
        }

        public int FinalDefense
        {
            get { return _stat.Defense + _additionalStat.Defense; }
        }

        public Define.ECondition Condition
        {
            get { return _condition; }
            set { _condition = value; }
        }

        public Player(string name) : base(name, Define.EActor.Player)
        {
            _inventory = new Inven();
            _additionalStat = new Stat();
        }

        public override void SetInfo(int maxHp, int attackPoint, int defense)
        {
            base.SetInfo(maxHp, attackPoint, defense);

            _condition = Define.ECondition.Good;

            _gold = 1000;
        }

        public override void TakeDamage(int amount)
        {
            int finalDamage = 0;
            if (_state == Define.EBattleState.Defense)
            {
                finalDamage = (int)(amount - FinalDefense);
            }
            else
            {
                finalDamage = (int)(amount - FinalDefense * 0.5f);
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
