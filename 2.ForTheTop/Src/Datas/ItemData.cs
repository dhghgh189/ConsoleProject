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
        public Define.EEquipSlot EquipSlot;
        public int MaxHp;
        public int AttackPoint;
        public int Defense;
    }

    public class ConsumeData : ItemData
    {
        public int Hp;
    }
}
