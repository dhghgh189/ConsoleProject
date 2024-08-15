using ConsoleProject2_ForTheTop.Inventory;
using ConsoleProject2_ForTheTop.Utils;

namespace ConsoleProject2_ForTheTop.Actors
{
    public class Player : Warrior
    {
        Define.ECondition _condition;
        int _gold;
        Inven _inventory;

        public int Gold { get { return _gold; } set { _gold = value; } }
        public Inven Inventory { get { return _inventory;} }

        public Define.ECondition Condition
        {
            get { return _condition; }
            set { _condition = value; }
        }

        public Player(string name) : base(name, Define.EActor.Player)
        {
            _inventory = new Inven();
        }

        public override void SetInfo(int maxHp, int attackPoint, int defense)
        {
            base.SetInfo(maxHp, attackPoint, defense);

            _condition = Define.ECondition.Good;
            _gold = 10000;
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
