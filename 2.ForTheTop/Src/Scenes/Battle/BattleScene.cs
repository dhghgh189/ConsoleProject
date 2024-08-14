using ConsoleProject2_ForTheTop.Actors;
using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Menus;
using ConsoleProject2_ForTheTop.Utils;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public class BattleScene : BaseScene, IActionable
    {
        int _playerPosX = 3;
        int _playerPosY = 12;

        int _enemyPosX = 59;
        int _enemyPosY = 4;

        int _menuPosY = 18;

        int _enemyMaxHp;
        int _playerMaxHp;

        int _menuIndex;
        ConsoleKey _input;

        enum eState { Process, Finish }
        eState _state;

        public event Action OnCompleteAction;

        SceneMenu[] _menus;

        public BattleScene() : base(Define.EScene.Battle)
        {
            _menus = new SceneMenu[]
            {
                new SceneMenu("공격한다", "", ConsoleColor.Red, Define.EScene.BattleAttack),
                new SceneMenu("방어한다", "", ConsoleColor.DarkCyan, Define.EScene.BattleDefense),
                new SceneMenu("사용한다", "", ConsoleColor.Green, Define.EScene.BattleUse)
            };
        }

        public override void Enter()
        {
            Util.ClearBuffer();
            Console.Clear();

            _menuIndex = 0;

            _enemyMaxHp = Game.Actor.CurrentEnemy.Stat.MaxHP / 10;
            _playerMaxHp = Game.Actor.Player.Stat.MaxHP / 10;

            if (Game.Actor.CurrentEnemy.IsAlive)
            {
                _state = eState.Process;
            }
            else
            {
                _state = eState.Finish;
            }
        }

        public override void Render()
        {
            Console.SetCursorPosition(0, 0);

            Util.PrintLine("[ Battle ]\n", Define.homeMenu[(int)Define.EAction.Battle].TextColor);

            PrintActors();

            switch (_state)
            {
                case eState.Process:
                    {
                        PrintMenu();
                    }
                    break;
                case eState.Finish:
                    {
                        PrintResult();
                    }
                    break;
            }   
        }

        #region Render
        void PrintActors()
        {
            // Actor들의 정보를 출력

            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);

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
            Util.Print($": {enemy.Stat.HP, -3}");

            Console.SetCursorPosition(_enemyPosX, _enemyPosY + lineCount++);
            Util.Print("AP ", ConsoleColor.Red);
            Util.Print($": {enemy.Stat.AttackPoint, -3}");

            Console.SetCursorPosition(_enemyPosX, _enemyPosY + lineCount);
            Util.Print("Defense ", ConsoleColor.DarkCyan);
            Util.Print($": {enemy.Stat.Defense, -3}");

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
            Util.Print($": {player.Stat.HP, -3}");

            Console.SetCursorPosition(_playerPosX, _playerPosY + lineCount++);
            Util.Print("AP ", ConsoleColor.Red);
            Util.Print($": {player.Stat.AttackPoint, -3}");

            Console.SetCursorPosition(_playerPosX, _playerPosY + lineCount);
            Util.Print("Defense ", ConsoleColor.DarkCyan);
            Util.Print($": {player.Stat.Defense, -3}");
        }

        void PrintMenu()
        {
            // Menu 출력
            Console.SetCursorPosition(0, _menuPosY);
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
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
            Util.PrintLine("\n");
            Util.PrintLine("\n");
            Util.PrintLine("==================================================================================", ConsoleColor.Gray);
        }

        void PrintResult()
        {
            // 결과 출력
            Console.SetCursorPosition(0, _menuPosY);
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
            Util.Print($"   전투에서 승리하였습니다!", ConsoleColor.Green);
            Util.PrintLine("\n");
            Util.PrintLine("\n");
            Util.PrintLine("\n");
            Util.PrintLine("==================================================================================", ConsoleColor.Gray);
            Thread.Sleep(1500);

            Console.SetCursorPosition(0, _menuPosY+3);
            Util.Print($"   {Game.Actor.CurrentEnemy.Gold}G ", ConsoleColor.Yellow);
            Util.Print("획득!!"                        );
            Thread.Sleep(2000);
        }
        #endregion

        public override void Input()
        {
            if (_state == eState.Finish)
                return;

            _input = Console.ReadKey(true).Key;
        }

        public override void Update()
        {
            switch (_state)
            {
                case eState.Process:
                    {
                        UpdateProcess();
                    }
                    break;
                case eState.Finish:
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
            }
        }

        void UpdateFinish()
        {
            Game.Instance.GetReward();
            Game.Instance.RemoveEnemy();

            OnCompleteAction?.Invoke();
        }

        public override void Exit()
        {

        }
    }
}
