using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Menus;
using ConsoleProject2_ForTheTop.Utils;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public class TrainingScene : BaseScene
    {
        int _actionPosX = 16;
        int _actionPosY = 10;

        int _menuIndex;
        ConsoleKey _input;

        SceneMenu[] _menus;

        public TrainingScene() : base(Define.EScene.Training)
        {
            _menus = new SceneMenu[]
            {
                new SceneMenu("체력 단련", "HP가 증가합니다.", ConsoleColor.Green, Define.EScene.TrainHealth),
                new SceneMenu("공격 연습", "공격력이 증가합니다.", ConsoleColor.Red, Define.EScene.TrainAttack),
                new SceneMenu("방어 연습", "방어력이 증가합니다.", ConsoleColor.DarkCyan, Define.EScene.TrainDefense)
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

            Util.PrintLine("[ Training ]\n", Define.homeMenu[(int)Define.EAction.Training].TextColor);

            PrintStatus();

            PrintMenu();

            PrintDescription();

            PrintInfoMsg();
        }

        #region Render
        public void PrintStatus()
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
            // 훈련 메뉴 출력
            for (int i = 0; i < _menus.Length; i++)
            {
                Console.SetCursorPosition(_actionPosX - 3, _actionPosY + i * 2);
                if (i == _menuIndex)
                {
                    Util.Print("-> ");
                }
                else
                {
                    Util.Print("   ");
                }

                Console.SetCursorPosition(_actionPosX, _actionPosY + i * 2);
                Util.PrintLine($"{_menus[i].Name}", _menus[i].TextColor);
            }
        }

        void PrintDescription()
        {
            // 행동 메뉴 설명 출력
            int lineCount = 4;
            for (int i = 0; i <= lineCount; i++)
            {
                Console.SetCursorPosition(_actionPosX + 17, _actionPosY + i);
                if (i == 0)
                {
                    Util.Print("┌──────────────────────────────────────┐", ConsoleColor.Gray);
                }
                else if (i == lineCount)
                {
                    Util.Print("└──────────────────────────────────────┘", ConsoleColor.Gray);
                }
                else if (i == lineCount / 2)
                {
                    Util.Print($"    {_menus[_menuIndex].Description}", _menus[_menuIndex].TextColor);
                    int descLength = 4 + _menus[_menuIndex].Description.Length;
                    while (++descLength < 25)
                    {
                        Util.Print(" ");
                    }
                }
            }
        }

        void PrintInfoMsg()
        {
            // Info 메세지 출력
            int descPosY = _actionPosY + (_menus.Length - 1) * 2 + 4;
            Console.SetCursorPosition(0, descPosY);
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
            Util.Print("     훈련 항목을 선택해주세요!", ConsoleColor.Cyan);
            Util.PrintLine(" (위 아래키로 이동, 엔터로 선택, ESC로 돌아가기)\n", ConsoleColor.Green);
            Util.PrintLine("==================================================================================", ConsoleColor.Gray);
        }
        #endregion

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
