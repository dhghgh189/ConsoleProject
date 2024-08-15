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
    public class EquipScene : BaseScene
    {
        int _menuPosY = 22;

        int _menuIndex;
        ConsoleKey _input;

        SceneMenu[] _menus;

        public EquipScene() : base(Define.EScene.Equip)
        {
            _menus = new SceneMenu[]
            {
                new SceneMenu("장비한다", "", ConsoleColor.Green, Define.EScene.EquipItem),
                new SceneMenu("해제한다", "", ConsoleColor.Red, Define.EScene.UnEquipItem),
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

            Util.PrintLine("[ Equip ]\n", Define.homeMenu[(int)Define.EAction.Equip].TextColor);

            PrintStatus();

            PrintMenu();
        }

        void PrintStatus()
        {
            // 플레이어의 상태 출력
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
            Util.Print($" HP: {$"{Game.Actor.Player.Stat.HP} / {Game.Actor.Player.Stat.MaxHP}",-14}", ConsoleColor.Green);
            Util.Print($"Attack: {Game.Actor.Player.Stat.AttackPoint,-8}", ConsoleColor.Red);
            Util.Print($"Defense: {Game.Actor.Player.Stat.Defense,-8}", ConsoleColor.DarkCyan);
            Util.Print($"컨디션: {Game.Actor.Player.Condition,-8}", ConsoleColor.Gray);
            Util.PrintLine($"Gold: {Game.Actor.Player.Gold}G", ConsoleColor.Yellow);
            Util.PrintLine("\n==================================================================================", ConsoleColor.Gray);
        }

        void PrintMenu()
        {
            // Menu 출력
            Console.SetCursorPosition(0, _menuPosY);
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);

            Console.SetCursorPosition(0, _menuPosY + 3);
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
                        Game.Scene.ChangeScene(Define.EScene.Home);
                    }
                    break;
            }
        }

        public override void Exit()
        {

        }
    }
}
