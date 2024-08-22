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
    public class BattleUse : BaseAction
    {
        protected Item _item;

        public BattleUse() : base(Define.ESubAction.BattleUse)
        {
        }

        public void SetItem(Item item)
        {
            _item = item;
        }

        public override void Execute()
        {
            if (Item.IsEquipment(_item.ItemType))
                return;

            Consumable consumable = (Consumable)_item;

            if (consumable == null)
                return;

            consumable.Use();
            Game.Actor.Player.Inventory.RemoveItem(consumable);
        }        
    }
}
