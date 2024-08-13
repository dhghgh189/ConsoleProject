using ConsoleProject2_ForTheTop.Actions;
using ConsoleProject2_ForTheTop.Actions.Training;
using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Menus;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public class TrainingScene : BaseScene, IActable
    {
        int actionPosX = 16;
        int actionPosY = 10;

        int menuIndex;
        ConsoleKey input;

        public event Action OnCompleteAction;

        TrainingMenu[] menus;
        TrainingMenu selectedMenu;

        enum EState { Idle, Training, Finish }

        EState eState; 

        public TrainingScene() : base(Define.EScene.Training)
        {
            menus = new TrainingMenu[]
            {
                new TrainingMenu("체력 단련", "HP가 증가합니다.", ConsoleColor.Green, Define.ETrainType.Health),
                new TrainingMenu("공격 연습", "공격력이 증가합니다.", ConsoleColor.Red, Define.ETrainType.Attack),
                new TrainingMenu("방어 연습", "방어력이 증가합니다.", ConsoleColor.DarkCyan, Define.ETrainType.Defense)
            };
        }

        public override void Enter()
        {
            menuIndex = 0;
            eState = EState.Idle;

            Console.Clear();
        }

        public override void Render()
        {
            Console.SetCursorPosition(0, 0);

            Util.PrintLine("[ TrainingScene ]\n", Define.homeMenu[(int)Define.EAction.Training].TextColor);

            PrintStatus();

            PrintMenu();

            switch (eState)
            {
                case EState.Idle:
                    {
                        PrintDescription();
                    }
                    break;
                case EState.Training: 
                    {
                        PrintTraining();
                    }
                    break;
                case EState.Finish:
                    {
                        PrintFinish();
                    }
                    break;
            }

            PrintInfoMsg();
        }

        #region Render
        public void PrintStatus()
        {
            // 플레이어의 상태 출력
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
            Util.Print($" HP: {Game.Player.Stat.HP,-8}", ConsoleColor.Green);
            Util.Print($"AP: {Game.Player.Stat.AttackPoint,-8}", ConsoleColor.Red);
            Util.Print($"Defense: {Game.Player.Stat.Defense,-8}", ConsoleColor.DarkCyan);
            Util.Print($"컨디션 : {Game.Player.Stat.Condition,-8}", ConsoleColor.Gray);
            Util.PrintLine($"Gold : {Game.Player.Gold}G", ConsoleColor.Yellow);
            Util.PrintLine("\n==================================================================================", ConsoleColor.Gray);
        }

        void PrintMenu()
        {
            // 훈련 메뉴 출력
            for (int i = 0; i < menus.Length; i++)
            {
                Console.SetCursorPosition(actionPosX - 3, actionPosY + i * 2);
                if (i == menuIndex)
                {
                    Util.Print("-> ");
                }
                else
                {
                    Util.Print("   ");
                }

                Console.SetCursorPosition(actionPosX, actionPosY + i * 2);
                Util.PrintLine($"{menus[i].Name}", menus[i].TextColor);
            }
        }

        void PrintDescription()
        {
            // 행동 메뉴 설명 출력
            int lineCount = 4;
            for (int i = 0; i <= lineCount; i++)
            {
                Console.SetCursorPosition(actionPosX + 17, actionPosY + i);
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
                    Util.Print($"    {menus[menuIndex].Description}", menus[menuIndex].TextColor);
                    int descLength = 4 + menus[menuIndex].Description.Length;
                    while (++descLength < 25)
                    {
                        Util.Print(" ");
                    }
                }
            }
        }

        void PrintTraining()
        {
            // 훈련 진행 내용 출력
            int lineCount = 4;
            for (int i = 0; i <= lineCount; i++)
            {
                Console.SetCursorPosition(actionPosX + 17, actionPosY + i);
                if (i == lineCount / 2)
                {
                    for (int j = 0; j < 40; j++)
                    {
                        Util.Print(" ");
                    }

                    Console.SetCursorPosition(actionPosX + 17, actionPosY + i);
                    switch (menus[menuIndex].Type)
                    {
                        case Define.ETrainType.Health:
                            {
                                Util.Print($"    체력 단련을 진행합니다...", menus[menuIndex].TextColor);
                                Thread.Sleep(1500);
                            }
                            break;
                        case Define.ETrainType.Attack:
                            {
                                Util.Print($"    공격 연습을 진행합니다...", menus[menuIndex].TextColor);
                                Thread.Sleep(1500);
                            }
                            break;
                        case Define.ETrainType.Defense:
                            {
                                Util.Print($"    방어 연습을 진행합니다...", menus[menuIndex].TextColor);
                                Thread.Sleep(1500);
                            }
                            break;
                    }
                }
            }
        }

        void PrintFinish()
        {
            int amount = Game.Actions.GetTraining(selectedMenu.Type).Amount;

            // 훈련 결과 출력
            int lineCount = 4;
            for (int i = 0; i <= lineCount; i++)
            {
                Console.SetCursorPosition(actionPosX + 17, actionPosY + i);
                if (i == lineCount / 2)
                {
                    for (int j = 0; j < 40; j++)
                    {
                        Util.Print(" ");
                    }

                    Console.SetCursorPosition(actionPosX + 17, actionPosY + i);
                    switch (menus[menuIndex].Type)
                    {
                        case Define.ETrainType.Health:
                            {
                                Util.Print($"    HP가 ");
                                Util.Print($"{amount} ", ConsoleColor.Green);
                                Util.PrintLine("증가했습니다!");
                                Thread.Sleep(2500);
                            }
                            break;
                        case Define.ETrainType.Attack:
                            {
                                Util.Print($"    공격력이 ");
                                Util.Print($"{amount} ", ConsoleColor.Red);
                                Util.PrintLine("증가했습니다!");
                                Thread.Sleep(2500);
                            }
                            break;
                        case Define.ETrainType.Defense:
                            {
                                Util.Print($"    방어력이 ");
                                Util.Print($"{amount} ", ConsoleColor.DarkCyan);
                                Util.PrintLine("증가했습니다!");
                                Thread.Sleep(2500);
                            }
                            break;
                    }
                }
            }
        }

        void PrintInfoMsg()
        {
            // Info 메세지 출력
            int descPosY = (actionPosY + ((int)menus.Length - 1) * 2) + 4;
            Console.SetCursorPosition(0, descPosY);
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
            Util.Print("           훈련 항목을 선택해주세요!", ConsoleColor.Cyan);
            Util.PrintLine(" (위 아래키로 이동, 엔터로 선택)\n", ConsoleColor.Green);
            Util.PrintLine("==================================================================================", ConsoleColor.Gray);
        }
        #endregion

        public override void Input()
        {
            if (eState != EState.Idle)
                return;

            input = Console.ReadKey(true).Key;
        }

        public override void Update()
        {
            switch (eState)
            {
                case EState.Idle:
                    {
                        UpdateIdle();
                    }
                    break;
                case EState.Training:
                    {
                        UpdateTraining();
                    }
                    break;
                case EState.Finish:
                    {
                        UpdateFinish();
                    }
                    break;
            }
        }

        #region Update
        void UpdateIdle()
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
                        if (menuIndex < menus.Length - 1)
                            menuIndex++;
                    }
                    break;
                case ConsoleKey.Enter:
                    {
                        selectedMenu = menus[menuIndex];
                        if (Game.Actions.GetTraining(selectedMenu.Type) != null)
                        {
                            eState = EState.Training;
                        }
                    }
                    break;
            }
        }

        void UpdateTraining()
        {
            Game.Actions.ExecuteTraining(menus[menuIndex].Type);
            eState = EState.Finish;
        }

        void UpdateFinish()
        {
            OnCompleteAction?.Invoke();
        }
        #endregion

        public override void Exit()
        {

        }
    }
}
