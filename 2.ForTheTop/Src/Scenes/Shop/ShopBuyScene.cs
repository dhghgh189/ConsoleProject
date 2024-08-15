using ConsoleProject2_ForTheTop.Actions;
using ConsoleProject2_ForTheTop.Datas;
using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public class ShopBuyScene : BaseScene
    {
        int _itemPosX = 5;
        int _itemPosY = 8;

        int _InfoPosY = 22;

        Define.ESubAction _actionType;

        int _menuIndex;
        ConsoleKey _input;

        List<ItemData> _sellingItems;

        public ShopBuyScene() : base(Define.EScene.ShopBuy)
        {
            _actionType = Define.ESubAction.ShopBuy;
            _sellingItems = Game.Data.ItemDict.Values.ToList();
        }

        public override void Enter()
        {
            _menuIndex = 0;
        }

        public override void Render()
        {
            Console.SetCursorPosition(0, 0);

            Util.PrintLine("[ ShopBuy ]\n", Define.homeMenu[(int)Define.EAction.Shopping].TextColor);

            PrintStatus();

            PrintItem();

            PrintInfoMsg();
        }

        void PrintStatus()
        {
            // 플레이어의 상태 출력
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
            Util.Print($"   소지 Gold: {Game.Actor.Player.Gold}G", ConsoleColor.Yellow);
            Util.PrintLine($"   소지한 아이템 갯수 : {Game.Actor.Player.Inventory.AllItems.Count}개    ", ConsoleColor.Green);
            Util.PrintLine("\n==================================================================================\n", ConsoleColor.Gray);
        }

        void PrintItem()
        {
            int lineCount = 0;

            // 아이템 출력
            foreach (ItemData data in _sellingItems)
            {
                Console.SetCursorPosition(_itemPosX - 3, _itemPosY + lineCount * 2);
                if (lineCount == _menuIndex)
                {
                    Util.Print("-> ");
                }
                else
                {
                    Util.Print("   ");
                }

                Console.SetCursorPosition(_itemPosX, _itemPosY + lineCount * 2);
                Util.Print("[");
                Util.Print($"{data.Name}", ConsoleColor.Green);
                Util.Print("] ");

                Util.Print($"{data.Description} ", ConsoleColor.Cyan);

                Util.Print("(");
                Util.Print($"{data.Price} G", ConsoleColor.Yellow);
                Util.Print(")");

                lineCount++;
            }
        }

        void PrintInfoMsg()
        {
            // Menu 출력
            Console.SetCursorPosition(0, _InfoPosY);
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);

            Console.SetCursorPosition(0, _InfoPosY + 3);
            Util.Print("   구입할 아이템을 선택하세요!", ConsoleColor.Cyan);
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
                        if (_menuIndex < Game.Data.ItemDict.Count - 1)
                            _menuIndex++;
                    }
                    break;
                case ConsoleKey.Enter:
                    {
                        // buy
                        string name = _sellingItems[_menuIndex].Name;
                        Game.Actions.GetAction<ShopBuy>(_actionType).SetName(name);
                        Game.Actions.ExecuteAction(_actionType);
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
