using ConsoleProject2_ForTheTop.Scenes;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Menus
{
    public abstract class Menu
    {
        // 메뉴 이름
        string _name;   
        // 메뉴 설명
        string _description;      
        // 메뉴 텍스트 색상
        ConsoleColor _textColor;      
        // 메뉴 선택시 매칭되는 Scene으로 이동하기 위한 변수
        protected Define.EScene _scene;

        public string Name { get { return _name; } }
        public string Description { get { return _description; } }
        public ConsoleColor TextColor { get { return _textColor; } }

        public Menu(string name, string description, ConsoleColor textColor, Define.EScene scene)
        {
            _name = name;
            _description = description;
            _textColor = textColor;
            _scene = scene;
        }

        public abstract void Select();
    }
}
