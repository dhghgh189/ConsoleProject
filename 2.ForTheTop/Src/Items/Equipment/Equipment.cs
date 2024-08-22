using ConsoleProject2_ForTheTop.Actors;
using ConsoleProject2_ForTheTop.Datas;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Items
{
    public class Equipment : Item
    {
        bool _isEquipped;

        public Equipment()
        {
            _isEquipped = false;
        }

        public EquipmentData Data { get { return (EquipmentData)_data; } }
        public Define.EEquipSlot EquipSlot { get { return Data.EquipSlot; } }
        public int MaxHp { get { return Data.MaxHp; } }
        public int AttackPoint { get { return Data.AttackPoint; } }
        public int Defense {  get { return Data.Defense; } }
        public bool IsEquipped { get { return _isEquipped; } }

        public override void Use()
        {
            if (_isEquipped == false)
            {
                _owner.AdditionalStat.MaxHP += MaxHp;
                _owner.AdditionalStat.AttackPoint += AttackPoint;
                _owner.AdditionalStat.Defense += Defense;
            }
            else
            {
                _owner.AdditionalStat.MaxHP -= MaxHp;
                _owner.AdditionalStat.AttackPoint -= AttackPoint;
                _owner.AdditionalStat.Defense -= Defense;
            }

            _isEquipped = !_isEquipped;
        }
    }
}
