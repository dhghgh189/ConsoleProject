using ConsoleProject2_ForTheTop.Datas;
using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;

namespace ConsoleProject2_ForTheTop.Items
{
    public class Item
    {
        protected ItemData _data;
        protected string _name;
        protected Define.EItemType _itemType;
        protected string _description;
        protected int _price;

        public string Name { get { return _name; } }
        public Define.EItemType ItemType { get { return _itemType; } }
        public string Description { get { return _description; } }
        public int Price { get { return _price; } }

        public virtual void SetInfo(string name)
        {
            if (Game.Data.ItemDict.TryGetValue(name, out _data) == false)
                return;

            _name = _data.Name;
            _itemType = _data.ItemType;
            _description = _data.Description;
            _price = _data.Price;
        }

        public static Item MakeItem(ItemData data)
        {
            Item item = null;

            if (data.ItemType == Define.EItemType.Equipment)
            {
                EquipmentData equipData = (EquipmentData)data;

                switch (equipData.EquipType)
                {
                    case Define.EEquipType.Weapon:
                        {
                            Weapon weapon = new Weapon();
                            weapon.SetInfo(equipData.Name);
                            item = weapon;
                        }
                        break;
                    case Define.EEquipType.Armor:
                        {
                            Armor armor = new Armor();
                            armor.SetInfo(equipData.Name);
                            item = armor;
                        }
                        break;
                }
            }
            else if (data.ItemType == Define.EItemType.Consumable)
            {
                ConsumeData consumeData = (ConsumeData)data;

                switch (consumeData.ConsumeType)
                {
                    case Define.EConsumeType.Potion:
                        {
                            Potion potion = new Potion();
                            potion.SetInfo(consumeData.Name);
                            item = potion;
                        }
                        break;
                }
            }

            return item;
        }
    }
}
