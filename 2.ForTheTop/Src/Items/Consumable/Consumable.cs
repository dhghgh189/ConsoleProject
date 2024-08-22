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
    public class Consumable : Item
    {
        int _Hp;

        public ConsumeData Data { get { return (ConsumeData)_data; } }
        public int Hp { get { return Data.Hp; } }

        public override void Use()
        {
            _owner.Stat.HP += Hp;
        }
    }
}
