using ConsoleProject2_ForTheTop.Actions;
using ConsoleProject2_ForTheTop.Items;
using ConsoleProject2_ForTheTop.Utils;

namespace ConsoleProject2_ForTheTop.Inventory
{
    public class Inven
    {
        public const int INVENTORY_MAX = 7;

        // 소지중인 아이템
        List<Item> _items;
        // 장착중인 아이템
        Equipment[] _equipSlot;

        public List<Item> AllItems { get { return _items; } }
        public Equipment[] EquipSlot {  get { return _equipSlot; } }     
        public List<Item> Equippable
        {
            get { return _items.Where(x => x.ItemType == Define.EItemType.Equipment).ToList(); }
        }
        public List<Item> Consumable 
        { 
            get { return _items.Where(x => x.ItemType == Define.EItemType.Consumable).ToList(); } 
        }

        public Inven()
        {
            _items = new List<Item>(INVENTORY_MAX);
            _equipSlot = new Equipment[(int)Define.EEquipSlot.Max];
        }

        public bool IsInventoryEmpty()
        {
            return _items.Count <= 0;
        }

        public bool IsInventoryFull()
        {
            return _items.Count >= INVENTORY_MAX;
        }

        public bool AddItem(Item item)
        {
            if (IsInventoryFull())
            {
                return false;
            }

            _items.Add(item);

            return true;
        }

        public bool RemoveItem(Item item)
        {
            return _items.Remove(item);
        }

        public bool Equip(Equipment equipment)
        {
            if (equipment == null)
                return false;

            // 기존 장착중이던 아이템이 있으면
            if (_equipSlot[(int)equipment.EquipSlot] != null)
            {
                Equipment beforeEquipment = _equipSlot[(int)equipment.EquipSlot];

                if (UnEquip(beforeEquipment) == false)
                    return false;
            }

            // 인벤에서 장착할 아이템을 제거
            if (RemoveItem(equipment) == false)
                return false;

            // 새 아이템 장착
            _equipSlot[(int)equipment.EquipSlot] = equipment;
            equipment.Equip();

            return true;
        }

        public bool UnEquip(Equipment equipment)
        {
            if (equipment == null)
                return false;

            // 슬롯에 있는 아이템이 매개변수로 받은 아이템과 다르면 안됨
            if (_equipSlot[(int)equipment.EquipSlot] != equipment)
                return false;

            // inventory로 보내기
            if (AddItem(equipment) == false)
                return false;

            // 아이템을 해제
            equipment.UnEquip();

            // 슬롯에서 제거
            _equipSlot[(int)equipment.EquipSlot] = null;

            return true;
        }
    }
}
