using ConsoleProject2_ForTheTop.Actions;
using ConsoleProject2_ForTheTop.Actors;
using ConsoleProject2_ForTheTop.Datas;
using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleProject2_ForTheTop.Items
{
    public abstract class Item
    {
        protected Player _owner;
        protected ItemData _data;

        public Player Owner { get { return _owner; } }
        public string Name { get { return _data.Name; } }
        public Define.EItemType ItemType { get { return _data.ItemType; } }
        public string Description { get { return _data.Description; } }
        public int Price { get { return _data.Price; } }

        public virtual void SetInfo(Player owner, ItemData data)
        {
            _data = data;
            _owner = owner;
        }

        public abstract void Use();

        public static Item MakeItem(Player owner, ItemData data) 
        {
            Item item = null;

            if (IsEquipment(data.ItemType))
                item = new Equipment();
            else
                item = new Consumable();

            item.SetInfo(owner, data);
            return item;
        }

        public static bool IsEquipment(Define.EItemType itemType)
        {
            if (itemType > Define.EItemType.EquipmentMax)
                return false;
            else
                return true;
        }
    }
}
