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
    public class UnEquipItem : Equip
    {
        public UnEquipItem() : base(Define.ESubAction.UnEquipItem)
        {
        }

        public override void Execute()
        {
            if (!Item.IsEquipment(_item.ItemType))
                return;

            Game.Actor.Player.Inventory.UnEquip((Equipment)_item);
        }
    }
}
