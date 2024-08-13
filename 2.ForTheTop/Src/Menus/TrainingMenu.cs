using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Scenes;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Menus
{
    public class TrainingMenu : Menu
    {
        Define.ETrainType _type;
        public Define.ETrainType Type {  get { return _type; } }

        public TrainingMenu(string name, string description, ConsoleColor textColor, Define.ETrainType type) 
            : base(name, description, textColor)
        {
            _type = type;
        }

        public override void Select()
        {
            
        }
    }
}
