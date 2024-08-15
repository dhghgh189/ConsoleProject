using ConsoleProject2_ForTheTop.Actions;
using ConsoleProject2_ForTheTop.Inventory;
using ConsoleProject2_ForTheTop.Items;
using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public class EquipItemScene : BaseScene
    {
        int _itemPosX = 5;
        int _itemPosY = 8;

        int _InfoPosY = 22;

        Define.ESubAction _actionType;

        int _menuIndex;
        ConsoleKey _input;

        public EquipItemScene() : base(Define.EScene.EquipItem)
        {
            _actionType = Define.ESubAction.EquipItem;
        }

        public override void Enter()
        {
            _menuIndex = 0;
        }

        public override void Render()
        {
            Console.SetCursorPosition(0, 0);

            Util.PrintLine("[ EquipItem ]\n", Define.homeMenu[(int)Define.EAction.Equip].TextColor);

            PrintStatus();

            PrintItem();

            PrintInfoMsg();
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

        void PrintItem()
        {
            List<Item> equipItems = Game.Actor.Player.Inventory.Equippable;
            // 아이템 출력
            for (int i = 0; i < Inven.INVENTORY_MAX; i++)
            {
                Console.SetCursorPosition(_itemPosX - 3, _itemPosY + i * 2);
                if (equipItems.Count <= 0 || i != _menuIndex)
                {
                    Util.Print("   ");
                }
                else
                {
                    Util.Print("-> ");
                }

                Console.SetCursorPosition(_itemPosX, _itemPosY + i * 2);
                if (i < equipItems.Count)
                {
                    Util.Print("[");
                    Util.Print($"{equipItems[i].Name}", ConsoleColor.Green);
                    Util.Print("] ");

                    Util.Print($"{equipItems[i].Description} ", ConsoleColor.Cyan);
                    Util.Print("                       ");
                }
                else
                {
                    Util.Print("                                                                        ");
                }
            }
        }

        void PrintInfoMsg()
        {
            // Menu 출력
            Console.SetCursorPosition(0, _InfoPosY);
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);

            Console.SetCursorPosition(0, _InfoPosY + 3);
            Util.Print("   장비할 아이템을 선택하세요!", ConsoleColor.Cyan);
            Util.PrintLine(" (위 아래키로 이동, 엔터로 선택, ESC로 돌아가기)\n", ConsoleColor.Green);
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
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    {
                        if (_menuIndex > 0)
                            _menuIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    {
                        if (_menuIndex < Game.Actor.Player.Inventory.Equippable.Count - 1)
                            _menuIndex++;
                    }
                    break;
                case ConsoleKey.Enter:
                    {
                        // equip item

                        if (Game.Actor.Player.Inventory.Equippable.Count <= 0)
                            return;

                        Item equipItem = Game.Actor.Player.Inventory.Equippable[_menuIndex];
                        Game.Actions.GetAction<EquipItem>(_actionType).SetItem(equipItem);
                        Game.Actions.ExecuteAction(_actionType);

                        _menuIndex = 0;
                    }
                    break;
                case ConsoleKey.Escape:
                    {
                        Game.Scene.ChangeScene(Define.EScene.Equip);
                    }
                    break;
            }
        }
        public override void Exit()
        {

        }
    }
}
