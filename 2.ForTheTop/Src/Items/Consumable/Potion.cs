using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Items
{
    public class Potion : Consumable
    {
        public override void Use()
        {
            Game.Actor.Player.Stat.HP += Data.Amount;
        }
    }
}
