using ConsoleProject2_ForTheTop.Actions;
using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Menus;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public class ShopScene : BaseScene, IActable
    {
        int menuIndex;
        ConsoleKey input;

        public event Action OnCompleteAction;

        public ShopScene() : base(Define.EScene.Shop)
        {

        }

        public override void Enter()
        {

        }

        public override void Render()
        {
            Console.Clear();

            Util.PrintLine("[ ShopScene ]\n", Define.homeMenu[(int)Define.EAction.Shopping].TextColor);
        }

        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }

        public override void Update()
        {
            switch (input)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    {
                        if (menuIndex > 0)
                            menuIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    {
                        //if (menuIndex < menus.Length - 1)
                        //    menuIndex++;
                    }
                    break;
                case ConsoleKey.Enter:
                    {
                        //menus[menuIndex].Select();
                    }
                    break;
            }
        }

        public override void Exit()
        {

        }
    }
}
