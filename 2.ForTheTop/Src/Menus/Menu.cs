using ConsoleProject2_ForTheTop.Scenes;
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
        public string Name;
        // 메뉴 설명
        public string Description;      // 18자 이내로 작성
        // 메뉴 텍스트 색상
        public ConsoleColor TextColor;

        public Menu(string name, string description, ConsoleColor textColor)
        {
            Name = name;
            Description = description;
            TextColor = textColor;
        }

        public abstract void Select();
    }
}
