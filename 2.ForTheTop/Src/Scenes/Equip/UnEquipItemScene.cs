using ConsoleProject2_ForTheTop.Actions;
using ConsoleProject2_ForTheTop.Inventory;
using ConsoleProject2_ForTheTop.Items;
using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;
using System.Runtime.CompilerServices;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public class UnEquipItemScene : BaseScene
    {
        int _itemPosX = 5;
        int _itemPosY = 8;

        int _infoPosY = 22;

        Define.ESubAction _actionType;

        int _menuIndex;
        ConsoleKey _input;

        public UnEquipItemScene() : base(Define.EScene.UnEquipItem)
        {
            _actionType = Define.ESubAction.UnEquipItem;
        }

        public override void Enter()
        {
            for (int i = 0; i < Game.Actor.Player.Inventory.EquipSlot.Length; i++)
            {
                if (Game.Actor.Player.Inventory.EquipSlot[i] != null)
                {
                    _menuIndex = i;
                    break;
                }
            }
        }

        public override void Render()
        {
            Console.SetCursorPosition(0, 0);

            Util.PrintLine("[ UnEquipItem ]\n", Define.homeMenu[(int)Define.EAction.Equip].TextColor);

            PrintStatus();

            PrintItem();

            PrintInfoMsg();
        }

        void PrintStatus()
        {
            // 플레이어의 상태 출력
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
            Util.Print($" HP: {$"{Game.Actor.Player.Stat.HP} / {Game.Actor.Player.Stat.MaxHP}",-11}", ConsoleColor.Green);
            Util.Print($"Attack: {Game.Actor.Player.Stat.AttackPoint}+{Game.Actor.Player.AdditionalStat.AttackPoint,-5}", ConsoleColor.Red);
            Util.Print($"Defense: {Game.Actor.Player.Stat.Defense}+{Game.Actor.Player.AdditionalStat.Defense,-5}", ConsoleColor.DarkCyan);
            Util.Print($"컨디션: {Game.Actor.Player.Condition,-8}", ConsoleColor.Gray);
            Util.PrintLine($"Gold: {Game.Actor.Player.Gold}G", ConsoleColor.Yellow);
            Util.PrintLine("\n==================================================================================\n", ConsoleColor.Gray);
        }

        void PrintItem()
        {
            Equipment[] equipItems = Game.Actor.Player.Inventory.EquipSlot;
            // 아이템 출력
            for (int i = 0; i < (int)Define.EEquipSlot.Max; i++)
            {
                Console.SetCursorPosition(_itemPosX - 3, _itemPosY + i * 2);
                if (equipItems[i] == null || i != _menuIndex)
                {
                    Util.Print("   ");
                }
                else
                {
                    Util.Print("-> ");
                }

                Console.SetCursorPosition(_itemPosX, _itemPosY + i * 2);

                if (equipItems[i] != null)
                {
                    Util.Print("[");
                    Util.Print($"{(Define.EEquipSlot)i}", ConsoleColor.Yellow);
                    Util.Print("] ");
                    Util.Print("[");
                    Util.Print($"{equipItems[i].Name}", ConsoleColor.Green);
                    Util.Print("] ");

                    Util.Print($"{equipItems[i].Description} ", ConsoleColor.Cyan);
                    Util.Print("                       ");
                }
                else
                {
                    Util.Print("[Empty]                                                                 ", ConsoleColor.Red);
                }
            }
        }

        void PrintInfoMsg()
        {
            // Menu 출력
            Console.SetCursorPosition(0, _infoPosY);
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);

            Console.SetCursorPosition(0, _infoPosY + 3);
            Util.Print("   해제할 아이템을 선택하세요!", ConsoleColor.Cyan);
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
                        for (int i = _menuIndex - 1; i >= 0; i--)
                        {
                            if (Game.Actor.Player.Inventory.EquipSlot[i] != null)
                            {
                                _menuIndex = i;
                                break;
                            }
                        }
                    }
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    {
                        for (int i = _menuIndex + 1; i < Game.Actor.Player.Inventory.EquipSlot.Length; i++)
                        {
                            if (Game.Actor.Player.Inventory.EquipSlot[i] != null)
                            {
                                _menuIndex = i;
                                break;
                            }
                        }
                    }
                    break;
                case ConsoleKey.Enter:
                    {
                        // UnEquip item

                        if (Game.Actor.Player.Inventory.EquipSlot[_menuIndex] == null)
                            return;

                        Item equipItem = Game.Actor.Player.Inventory.EquipSlot[_menuIndex];
                        Game.Actions.GetAction<UnEquipItem>(_actionType).SetItem(equipItem);
                        Game.Actions.ExecuteAction(_actionType);

                        _menuIndex = 0;

                        for (int i = _menuIndex; i < Game.Actor.Player.Inventory.EquipSlot.Length; i++)
                        {
                            if (Game.Actor.Player.Inventory.EquipSlot[i] != null)
                            {
                                _menuIndex = i;
                                break;
                            }
                        }                        
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
