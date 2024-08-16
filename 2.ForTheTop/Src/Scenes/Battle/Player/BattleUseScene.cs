using ConsoleProject2_ForTheTop.Actions;
using ConsoleProject2_ForTheTop.Actors;
using ConsoleProject2_ForTheTop.Datas;
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
    public class BattleUseScene : BaseScene
    {
        int _itemPosX = 5;
        int _itemPosY = 4;

        int _playerPosX = 3;
        int _playerPosY = 12;

        int _enemyPosX = 45;
        int _enemyPosY = 4;

        int _infoPosY = 18;

        int _enemyMaxHp;
        int _playerMaxHp;

        Define.ESubAction _actionType;
        ConsoleColor _textColor;

        int _menuIndex;
        ConsoleKey _input;

        ConsumeData _usedItem;

        enum EState { Process, Finish }
        EState _state;

        public BattleUseScene() : base(Define.EScene.BattleUse)
        {
            _actionType = Define.ESubAction.BattleUse;
            _textColor = ConsoleColor.Green;
        }

        public override void Enter()
        {
            _menuIndex = 0;

            _enemyMaxHp = Game.Actor.CurrentEnemy.Stat.MaxHP / 10;
            _playerMaxHp = Game.Actor.Player.Stat.MaxHP / 10;

            _state = EState.Process;

            _usedItem = null;
        }

        public override void Render()
        {
            Console.SetCursorPosition(0, 0);

            Util.PrintLine("[ BattleUse ]\n", Define.homeMenu[(int)Define.EAction.Battle].TextColor);

            switch (_state)
            {
                case EState.Process:
                    {
                        PrintItem();

                        PrintInfoMsg();
                    }
                    break;
                case EState.Finish:
                    {
                        PrintActors();

                        PrintResult();
                    }
                    break;
            }          
        }

        #region Render
        void PrintItem()
        {
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
            // 이전화면 지우기
            for (int i = _enemyPosY; i < _infoPosY; i++)
            {
                Console.SetCursorPosition(0, i);
                Util.Print("                                                                                   ");
            }
            Console.SetCursorPosition(0, _infoPosY);
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);

            List<Item> consumable = Game.Actor.Player.Inventory.Consumable;
            // 소지중인 소모템 출력
            for (int i = 0; i < Inven.INVENTORY_MAX; i++)
            {
                Console.SetCursorPosition(_itemPosX - 3, _itemPosY + i * 2);
                if (consumable.Count <= 0 || i != _menuIndex)
                {
                    Util.Print("   ");
                }
                else
                {
                    Util.Print("-> ");
                }

                Console.SetCursorPosition(_itemPosX, _itemPosY + i * 2);
                if (i < consumable.Count)
                {
                    Util.Print("[");
                    Util.Print($"{consumable[i].Name}", ConsoleColor.Green);
                    Util.Print("] ");

                    Util.Print($"{consumable[i].Description} ", ConsoleColor.Cyan);

                    Util.Print("(");
                    Util.Print($"{consumable[i].Price} G", ConsoleColor.Yellow);
                    Util.Print(")                       ");
                }
                else
                {
                    Util.Print("                                                                        ");
                }

                Console.SetCursorPosition(0, _infoPosY);
                Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
            }
        }

        void PrintInfoMsg()
        {
            Util.Print("                                                                  ");
            Util.PrintLine("\n");

            Util.Print($"   사용할 아이템을 선택하세요!", ConsoleColor.Cyan);
            Util.PrintLine(" (위 아래키로 이동, 엔터로 선택, ESC로 돌아가기)\n", ConsoleColor.Green);
            Util.PrintLine("\n");
            Util.PrintLine("==================================================================================", ConsoleColor.Gray);
        }

        void PrintActors()
        {
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
            // 이전화면 지우기
            for (int i = _enemyPosY; i < _infoPosY; i++)
            {
                Console.SetCursorPosition(0, i);
                Util.Print("                                                                                   ");
            }

            // Actor들의 현재 체력
            int enemyHp = Game.Actor.CurrentEnemy.Stat.HP / 10;
            int playerHp = Game.Actor.Player.Stat.HP / 10;

            // Enemy Info
            int lineCount = 0;
            Enemy enemy = Game.Actor.CurrentEnemy;
            Console.SetCursorPosition(_enemyPosX, _enemyPosY + lineCount++);
            Util.Print($"{enemy.Name}", ConsoleColor.Red);

            Console.SetCursorPosition(_enemyPosX, _enemyPosY + lineCount++);
            for (int i = 0; i < _enemyMaxHp; i++)
            {
                if (i < enemyHp)
                    Util.Print("■", ConsoleColor.DarkRed);
                else
                    Util.Print("□");
            }

            Console.SetCursorPosition(_enemyPosX, _enemyPosY + lineCount++);
            Util.Print("HP ", ConsoleColor.DarkRed);
            Util.Print($": {enemy.Stat.HP,-3}");

            Console.SetCursorPosition(_enemyPosX, _enemyPosY + lineCount++);
            Util.Print("AP ", ConsoleColor.Red);
            Util.Print($": {enemy.Stat.AttackPoint,-3}");

            Console.SetCursorPosition(_enemyPosX, _enemyPosY + lineCount);
            Util.Print("Defense ", ConsoleColor.DarkCyan);
            Util.Print($": {enemy.Stat.Defense,-3}");

            // Player Info
            lineCount = 0;
            Player player = Game.Actor.Player;
            Console.SetCursorPosition(_playerPosX, _playerPosY + lineCount++);
            Util.Print($"{player.Name}", ConsoleColor.Green);

            Console.SetCursorPosition(_playerPosX, _playerPosY + lineCount++);
            for (int i = 0; i < _playerMaxHp; i++)
            {
                if (i < playerHp)
                    Util.Print("■", ConsoleColor.DarkRed);
                else
                    Util.Print("□");
            }

            Console.SetCursorPosition(_playerPosX, _playerPosY + lineCount++);
            Util.Print("HP ", ConsoleColor.DarkRed);
            Util.Print($": {player.Stat.HP,-3}");

            Console.SetCursorPosition(_playerPosX, _playerPosY + lineCount++);
            Util.Print("AP ", ConsoleColor.Red);
            Util.Print($": {player.Stat.AttackPoint}+{player.AdditionalStat.AttackPoint,-3}");

            Console.SetCursorPosition(_playerPosX, _playerPosY + lineCount);
            Util.Print("Defense ", ConsoleColor.DarkCyan);
            Util.Print($": {player.Stat.Defense}+{player.AdditionalStat.Defense,-3}");

            Console.SetCursorPosition(0, _infoPosY);
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
        }

        void PrintResult()
        {
            Util.Print("                                                                                     ");
            Util.PrintLine("\n");

            Util.Print($"   {_usedItem.Name}", ConsoleColor.Green);
            Util.PrintLine(" 사용!                                                                          ");
            Util.PrintLine("");
            Util.PrintLine("\n");
            Util.PrintLine("==================================================================================", ConsoleColor.Gray);
            Thread.Sleep(2000);
        }

        #endregion

        public override void Input()
        {
            if (_state != EState.Process)
                return;

            _input = Console.ReadKey(true).Key;
        }

        public override void Update()
        {
            switch (_state)
            {
                case EState.Process:
                    {
                        UpdateProcess();
                    }
                    break;
                case EState.Finish:
                    {
                        UpdateFinish();
                    }
                    break;
            }
        }

        void UpdateProcess()
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
                        if (_menuIndex < Game.Actor.Player.Inventory.Consumable.Count - 1)
                            _menuIndex++;
                    }
                    break;
                case ConsoleKey.Enter:
                    {
                        // Use

                        if (Game.Actor.Player.Inventory.Consumable.Count <= 0)
                            return;

                        Item useItem = Game.Actor.Player.Inventory.Consumable[_menuIndex];

                        Game.Actions.GetAction<BattleUse>(_actionType).SetItem(useItem);
                        Game.Actions.ExecuteAction(_actionType);

                        _usedItem = ((Consumable)useItem).Data;

                        _state = EState.Finish;
                    }
                    break;
                case ConsoleKey.Escape:
                    {
                        Game.Scene.ChangeScene(Define.EScene.Battle);
                    }
                    break;
            }
        }

        void UpdateFinish()
        {
            // 아이템 사용 시 턴 종료
            Game.Scene.ChangeScene(Define.EScene.BattleEnemyAI);
        }

        public override void Exit()
        {
            
        }
    }
}
