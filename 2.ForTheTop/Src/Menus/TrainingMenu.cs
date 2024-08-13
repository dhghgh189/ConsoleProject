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
        public TrainingMenu(string name, string description, ConsoleColor textColor, Define.EScene scene) 
            : base(name, description, textColor, scene)
        {           
        }

        public override void Select()
        {
            Game.Scene.ChangeScene(_scene);
        }
    }
}
