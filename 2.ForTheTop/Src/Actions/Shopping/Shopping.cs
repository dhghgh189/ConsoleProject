using ConsoleProject2_ForTheTop.Items;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actions
{
    public abstract class Shopping : BaseAction
    {
        protected string _name;
        protected Item _item;

        public Shopping(Define.ESubAction type) : base(type)
        {
            
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public void SetItem(Item item)
        {
            _item = item;
        }
    }
}
