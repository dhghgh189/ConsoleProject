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
    public class HomeMenu : Menu
    {
        public HomeMenu(string name, string description, ConsoleColor textColor, Define.EScene scene) : 
            base(name, description, textColor, scene)
        {           
        }

        // Home에서 메뉴를 선택하면 매칭되는 Scene으로 이동된다.
        public override void Select()
        {
            Game.Scene.ChangeScene(_scene);
        }
    }
}
