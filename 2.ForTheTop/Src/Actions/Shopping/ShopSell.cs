using ConsoleProject2_ForTheTop.Datas;
using ConsoleProject2_ForTheTop.Items;
using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actions
{
    public class ShopSell : Shopping
    {
        public ShopSell() : base(Define.ESubAction.ShopSell)
        {
        }

        public override void Execute()
        {
            if (_item == null)
                return;

            if (Game.Actor.Player.Inventory.RemoveItem(_item) == false)
                return;

            Game.Actor.Player.Gold += _item.Price;
        }
    }
}
