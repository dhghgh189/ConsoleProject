using ConsoleProject2_ForTheTop.Utils;

namespace ConsoleProject2_ForTheTop.Datas
{
    public class ItemData
    {
        public string Name;
        public Define.EItemType ItemType;
        public string Description;
        public int Price;
    }

    public class EquipmentData : ItemData
    {
        public Define.EEquipType EquipType;
        public Define.EEquipSlot EquipSlot;
        public int Value;
    }

    public class ConsumeData : ItemData
    {
        public Define.EConsumeType ConsumeType;
        public int Amount;
    }
}
