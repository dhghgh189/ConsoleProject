using ConsoleProject2_ForTheTop.Datas;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Items
{
    public abstract class Consumable : Item
    {
        protected Define.EConsumeType _consumeType;
        protected int _amount;

        public ConsumeData Data
        {
            get
            {
                return (ConsumeData)_data;
            }
        }

        public Define.EConsumeType ConsumeType { get { return Data.ConsumeType; } }      
        public int Amount { get { return Data.Amount; } }

        public override void SetInfo(string name)
        {
            base.SetInfo(name);

            _consumeType = Data.ConsumeType;
            _amount = Data.Amount;
        }

        public abstract void Use();
    }
}
