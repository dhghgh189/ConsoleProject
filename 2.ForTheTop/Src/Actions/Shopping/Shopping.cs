using ConsoleProject2_ForTheTop.Actors;
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
        protected Player _customer;
        protected string _name;
        protected Item _item;

        public Shopping(Define.ESubAction type) : base(type)
        {
            
        }

        public void SetCustomer(Player customer)
        {
            _customer = customer;
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
