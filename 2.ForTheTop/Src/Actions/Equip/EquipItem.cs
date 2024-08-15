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
    public class EquipItem : Equip
    {
        public EquipItem() : base(Define.ESubAction.EquipItem)
        {
        }

        public override void Execute()
        {
            if (_item.ItemType != Define.EItemType.Equipment)
                return;

            Game.Actor.Player.Inventory.Equip((Equipment)_item);
        }
    }
}
