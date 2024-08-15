using ConsoleProject2_ForTheTop.Items;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actions
{
    public abstract class Equip : BaseAction
    {
        protected Item _item;

        public Equip(Define.ESubAction type) : base(type)
        {
        }

        public void SetItem(Item item)
        {
            _item = item;
        }
    }
}
