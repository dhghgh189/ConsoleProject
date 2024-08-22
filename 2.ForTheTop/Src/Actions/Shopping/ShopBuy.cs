using ConsoleProject2_ForTheTop.Datas;
using ConsoleProject2_ForTheTop.Items;
using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;

namespace ConsoleProject2_ForTheTop.Actions
{
    public class ShopBuy : Shopping
    {
        public ShopBuy() : base(Define.ESubAction.ShopBuy)
        {
        }

        public override void Execute()
        {
            if (string.IsNullOrEmpty(_name))
                return;

            if (Game.Data.ItemDict.TryGetValue(_name, out ItemData data) == false)
                return;

            if (Game.Actor.Player.Gold < data.Price)
                return;

            Item item = Item.MakeItem(_customer, data);

            if (item == null)
                return;

            if (Game.Actor.Player.Inventory.AddItem(item) == false)
                return;

            Game.Actor.Player.Gold -= data.Price;
        }
    }
}
