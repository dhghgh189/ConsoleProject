using ConsoleProject2_ForTheTop.Datas;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Items
{
    public abstract class Equipment : Item
    {
        protected Define.EEquipType _equipType;
        protected Define.EEquipSlot _equipSlot;
        protected int _value;

        public EquipmentData Data 
        {
            get
            {
                return (EquipmentData)_data; 
            }
        }

        public Define.EEquipType EquipType { get { return Data.EquipType; } }
        public Define.EEquipSlot EquipSlot { get { return Data.EquipSlot; } }
        public int Value { get { return Data.Value; } }

        public override void SetInfo(string name)
        {
            base.SetInfo(name);

            _equipType = Data.EquipType;
            _equipSlot = Data.EquipSlot;
            _value = Data.Value;
        }

        public abstract void Equip();

        public abstract void UnEquip();
    }
}
