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
    public class ShopScene : BaseScene, IActionable
    {
        int _menuPosY = 22;

        int _menuIndex;
        ConsoleKey _input;

        public event Action OnCompleteAction;

        SceneMenu[] _menus;

        public ShopScene() : base(Define.EScene.Shop)
        {
            _menus = new SceneMenu[]
            {
                new SceneMenu("구매한다", "", ConsoleColor.Green, Define.EScene.ShopBuy),
                new SceneMenu("판매한다", "", ConsoleColor.Cyan, Define.EScene.ShopSell),
            };
        }

        public override void Enter()
        {
            _menuIndex = 0;

            Console.Clear();
        }

        public override void Render()
        {
            Console.SetCursorPosition(0, 0);

            Util.PrintLine("[ Shop ]\n", Define.homeMenu[(int)Define.EAction.Shopping].TextColor);

            PrintStatus();

            PrintMenu();
        }

        void PrintStatus()
        {
            // 소지 Gold 출력
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
            Util.Print($"   소지 Gold: {Game.Actor.Player.Gold}G", ConsoleColor.Yellow);
            Util.PrintLine($"   소지한 아이템 갯수 : {Game.Actor.Player.Inventory.AllItems.Count}개    ", ConsoleColor.Green);
            Util.PrintLine("\n==================================================================================\n", ConsoleColor.Gray);
        }

        void PrintMenu()
        {
            // Menu 출력
            Console.SetCursorPosition(0, _menuPosY);
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);

            Console.SetCursorPosition(0, _menuPosY+3);
            for (int i = 0; i < _menus.Length; i++)
            {
                if (i == _menuIndex)
                {
                    Util.Print($"{_menus[i].Name,7}", _menus[i].TextColor);
                }
                else
                {
                    Util.Print($"{_menus[i].Name,7}", ConsoleColor.Gray);
                }
            }
            Util.PrintLine("\n");
            Util.PrintLine("");
            Util.PrintLine("==================================================================================", ConsoleColor.Gray);
        }

        public override void Input()
        {
            _input = Console.ReadKey(true).Key;
        }

        public override void Update()
        {
            switch (_input)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    {
                        if (_menuIndex > 0)
                            _menuIndex--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    {
                        if (_menuIndex < _menus.Length - 1)
                            _menuIndex++;
                    }
                    break;
                case ConsoleKey.Enter:
                    {
                        _menus[_menuIndex].Select();
                    }
                    break;
                case ConsoleKey.Escape:
                    {
                        OnCompleteAction?.Invoke();
                    }
                    break;
            }
        }

        public override void Exit()
        {

        }
    }
}
