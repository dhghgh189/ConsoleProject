using ConsoleProject2_ForTheTop.Actors;
using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Menus;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public class HomeScene : BaseScene
    {
        int _actionPosX = 16;
        int _actionPosY = 13;

        int _menuIndex;
        ConsoleKey _input;

        // 컨디션 회복을 위한 게이지
        int _recoveryGauge;

        public HomeScene() : base(Define.EScene.Home)
        {
            _recoveryGauge = 0;
        }

        public override void Enter()
        {
            _menuIndex = 0;

            // 당일 최초 Enter시 체력 회복
            if (Game.IsNewDay)
            {
                Recovery();
            }

            CheckCondition();

            Util.ClearBuffer();
            Console.Clear();
        }

        public override void Render()
        {
            Console.SetCursorPosition(0, 0);

            Util.PrintLine("[ Home ]\n", ConsoleColor.Cyan);

            PrintStatus();

            PrintMenu();

            PrintDescription();

            PrintInfoMsg();   
        }

        #region Render   
        void PrintStatus()
        {
            // 플레이어의 상태 출력
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
            Util.Print($" HP: {$"{Game.Actor.Player.Stat.HP} / {Game.Actor.Player.Stat.MaxHP}", -11}", ConsoleColor.Green);
            Util.Print($"Attack: {Game.Actor.Player.Stat.AttackPoint}+{Game.Actor.Player.AdditionalStat.AttackPoint, -5}", ConsoleColor.Red);
            Util.Print($"Defense: {Game.Actor.Player.Stat.Defense}+{Game.Actor.Player.AdditionalStat.Defense, -5}", ConsoleColor.DarkCyan);
            Util.Print($"컨디션: {Game.Actor.Player.Condition,-8}", ConsoleColor.Gray);
            Util.PrintLine($"Gold: {Game.Actor.Player.Gold}G", ConsoleColor.Yellow);
            Util.PrintLine("\n==================================================================================\n", ConsoleColor.Gray);

            // 남은 날짜 출력
            Util.Print(" 남은 날짜 : ");
            Util.Print($"{Game.LeftDays}", ConsoleColor.DarkRed);
            Util.PrintLine("일");

            // 남은 적 수 출력
            Util.Print(" 남은 적들 : ");
            Util.Print($"{Game.LeftEnemies}", ConsoleColor.DarkRed);
            Util.PrintLine("명");
        }

        void PrintMenu()
        {
            // 행동 메뉴 출력
            for (int i = 0; i < Define.homeMenu.Length; i++)
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
                Util.PrintLine($"{Define.homeMenu[i].Name}", Define.homeMenu[i].TextColor);
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
                    Util.Print($"    {Define.homeMenu[_menuIndex].Description}", Define.homeMenu[_menuIndex].TextColor);
                    int descLength = 4 + Define.homeMenu[_menuIndex].Description.Length;
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
            int descPosY = (_actionPosY + ((int)Define.EAction.Max - 1) * 2) + 4;
            Console.SetCursorPosition(0, descPosY);
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
            Util.Print("         플레이어의 행동을 선택해주세요!", ConsoleColor.Yellow);
            Util.PrintLine(" (위 아래키로 이동, 엔터로 선택)\n", ConsoleColor.Green);
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
                        if (_menuIndex < (int)Define.EAction.Max-1)
                            _menuIndex++;
                    }                  
                    break;
                case ConsoleKey.Enter:
                    {
                        Define.homeMenu[_menuIndex].Select();
                    }
                    break;
            }
        }

        void Recovery()
        {
            Player player = Game.Actor.Player;

            switch (player.Condition)
            {
                case Define.ECondition.Good:
                    {
                        // 풀 회복
                        player.Stat.HP = player.Stat.MaxHP;
                    }
                    break;
                case Define.ECondition.Normal:
                    {
                        // 절반 회복
                        player.Stat.HP += (int)(player.Stat.MaxHP * 0.5f);
                    }
                    break;
                case Define.ECondition.Bad:
                    {
                        // 최악의 컨디션
                        player.Stat.HP += (int)(player.Stat.MaxHP * 0.25f);
                    }
                    break;
            }
               
            Game.IsNewDay = false;
        }

        void CheckCondition()
        {
            Player player = Game.Actor.Player;

            // 컨디션이 최상이 아니라면 컨디션 관리 절차 진행
            if (player.Condition > Define.ECondition.Good)
            {
                _recoveryGauge += 20;

                if (_recoveryGauge >= 100)
                {
                    player.Condition -= 1;
                    _recoveryGauge = 0;
                }
            }
            else
            {
                _recoveryGauge = 0;
            }
        }
        
        public override void Exit()
        {

        }
    }
}
