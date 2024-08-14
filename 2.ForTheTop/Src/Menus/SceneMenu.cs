using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Menus
{
    public class SceneMenu : Menu
    {
        // 메뉴 선택시 매칭되는 Scene으로 이동하기 위한 변수
        Define.EScene _scene;

        public SceneMenu(string name, string description, ConsoleColor textColor, Define.EScene scene) : base(name, description, textColor)
        {
            _scene = scene;
        }

        public override void Select()
        {
            Game.Scene.ChangeScene(_scene);
        }
    }
}
