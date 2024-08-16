using ConsoleProject2_ForTheTop.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Items
{
    public class Armor : Equipment
    {
        public override void Equip()
        {
            Game.Actor.Player.AdditionalStat.Defense += Data.Value;
        }

        public override void UnEquip()
        {
            Game.Actor.Player.AdditionalStat.Defense -= Data.Value;
        }
    }
}
