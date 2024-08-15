using ConsoleProject2_ForTheTop.Managers;

namespace ConsoleProject2_ForTheTop.Items
{
    public class Weapon : Equipment
    {
        public override void Equip()
        {
            Game.Actor.Player.Stat.AttackPoint += Data.Value;
        }

        public override void UnEquip()
        {
            Game.Actor.Player.Stat.AttackPoint -= Data.Value;
        }
    }
}
