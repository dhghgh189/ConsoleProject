﻿using ConsoleProject2_ForTheTop.Actions;
using ConsoleProject2_ForTheTop.Datas;
using ConsoleProject2_ForTheTop.Inventory;
using ConsoleProject2_ForTheTop.Items;
using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public class ShopSellScene : BaseScene
    {
        int _itemPosX = 5;
        int _itemPosY = 8;

        int _infoPosY = 22;

        Define.ESubAction _actionType;

        int _menuIndex;
        ConsoleKey _input;

        public ShopSellScene() : base(Define.EScene.ShopSell)
        {
            _actionType = Define.ESubAction.ShopSell;
        }

        public override void Enter()
        {
            _menuIndex = 0;
            Game.Actions.GetAction<Shopping>(_actionType).SetCustomer(Game.Actor.Player);
        }

        public override void Render()
        {
            Console.SetCursorPosition(0, 0);

            Util.PrintLine("[ ShopSell ]\n", Define.homeMenu[(int)Define.EAction.Shopping].TextColor);

            PrintStatus();

            PrintItem();

            PrintInfoMsg();
        }

        void PrintStatus()
        {
            // 소지 Gold 출력
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
            Util.Print($"   소지 Gold: {Game.Actor.Player.Gold}G", ConsoleColor.Yellow);
            Util.PrintLine($"   소지한 아이템 갯수 : {Game.Actor.Player.Inventory.AllItems.Count}개    ", ConsoleColor.Green);
            Util.PrintLine("\n==================================================================================\n", ConsoleColor.Gray);
        }

        void PrintItem()
        {
            // 소지중인 아이템 출력
            List<Item> playerItems = Game.Actor.Player.Inventory.AllItems;
            for (int i = 0; i < Inven.INVENTORY_MAX; i++)
            {
                Console.SetCursorPosition(_itemPosX - 3, _itemPosY + i * 2);
                if (playerItems.Count <= 0 || i != _menuIndex)
                {
                    Util.Print("   ");
                }
                else
                {
                    Util.Print("-> ");
                }

                Console.SetCursorPosition(_itemPosX, _itemPosY + i * 2);
                if (i < playerItems.Count)
                {
                    if (Item.IsEquipment(playerItems[i].ItemType))
                    {
                        Define.EEquipSlot slot = ((Equipment)playerItems[i]).EquipSlot;

                        Util.Print("[");
                        Util.Print($"{slot}", ConsoleColor.Yellow);
                        Util.Print("] ");
                    }
                    else
                    {
                        Util.Print("[");
                        Util.Print("소모품", ConsoleColor.Red);
                        Util.Print("] ");
                    }
                    Util.Print("[");
                    Util.Print($"{playerItems[i].Name}", ConsoleColor.Green);
                    Util.Print("] ");

                    Util.Print($"{playerItems[i].Description} ", ConsoleColor.Cyan);

                    Util.Print("(");
                    Util.Print($"{playerItems[i].Price} G", ConsoleColor.Yellow);
                    Util.Print(")                       ");
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
            Console.SetCursorPosition(0, _infoPosY);
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);

            Console.SetCursorPosition(0, _infoPosY + 3);
            Util.Print("   판매할 아이템을 선택하세요!", ConsoleColor.Cyan);
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
                        if (_menuIndex < Game.Actor.Player.Inventory.AllItems.Count - 1)
                            _menuIndex++;
                    }
                    break;
                case ConsoleKey.Enter:
                    {
                        // Sell Action
                        if (Game.Actor.Player.Inventory.IsInventoryEmpty())
                            return;

                        Item sellItem = Game.Actor.Player.Inventory.AllItems[_menuIndex];
                        Game.Actions.GetAction<Shopping>(_actionType).SetItem(sellItem);
                        Game.Actions.ExecuteAction(_actionType);

                        _menuIndex = 0;
                    }
                    break;
                case ConsoleKey.Escape:
                    {
                        Game.Scene.ChangeScene(Define.EScene.Shop);
                    }
                    break;
            }
        }
        public override void Exit()
        {

        }
    }
}
