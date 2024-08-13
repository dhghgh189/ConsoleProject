using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Menus;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public class HomeScene : BaseScene
    {
        int actionPosX = 16;
        int actionPosY = 12;

        int menuIndex;
        ConsoleKey input;

        public HomeScene() : base(Define.EScene.Home)
        {
            
        }

        public override void Enter()
        {
            menuIndex = 0;

            Console.Clear();
        }

        public override void Render()
        {
            Console.SetCursorPosition(0, 0);

            Util.PrintLine("[ HomeScene ]\n", ConsoleColor.Cyan);

            // 플레이어의 상태 출력
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
            Util.Print($" HP: {Game.Player.Stat.HP, -8}", ConsoleColor.Green);
            Util.Print($"AP: {Game.Player.Stat.AttackPoint, -8}", ConsoleColor.Red);
            Util.Print($"Defense: {Game.Player.Stat.Defense, -8}", ConsoleColor.DarkCyan);
            Util.Print($"컨디션 : {Game.Player.Stat.Condition, -8}", ConsoleColor.Gray);
            Util.PrintLine($"Gold : {Game.Player.Gold}G", ConsoleColor.Yellow);
            Util.PrintLine("\n==================================================================================\n", ConsoleColor.Gray);

            // 남은 날짜 출력
            Util.Print(" 남은 날짜 : ");
            Util.PrintLine($"{Game.LeftDays}일", ConsoleColor.DarkRed);

            // 행동 메뉴 출력
            for (int i = 0; i < Define.homeMenu.Length; i++)
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

                Console.SetCursorPosition(actionPosX, actionPosY+i*2);
                Util.PrintLine($"{Define.homeMenu[i].Name}", Define.homeMenu[i].TextColor);
            }

            // 행동 메뉴 설명 출력
            int lineCount = 4;
            for (int i = 0; i <= lineCount; i++)
            {
                Console.SetCursorPosition(actionPosX + 17, actionPosY+i);
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
                    Util.Print($"    {Define.homeMenu[menuIndex].Description}", Define.homeMenu[menuIndex].TextColor);
                    int descLength = 4 + Define.homeMenu[menuIndex].Description.Length;
                    while (++descLength < 25)
                    {
                        Util.Print(" ");
                    }
                }
            }

            // Info 메세지 출력
            int descPosY = (actionPosY + ((int)Define.EAction.Max-1) * 2) + 4;
            Console.SetCursorPosition(0, descPosY);
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
            Util.Print("         플레이어의 행동을 선택해주세요!", ConsoleColor.Cyan);
            Util.PrintLine(" (위 아래키로 이동, 엔터로 선택)\n", ConsoleColor.Green);
            Util.PrintLine("==================================================================================", ConsoleColor.Gray);
        }

        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }

        public override void Update()
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
                        if (menuIndex < (int)Define.EAction.Max-1)
                            menuIndex++;
                    }                  
                    break;
                case ConsoleKey.Enter:
                    {
                        Define.homeMenu[menuIndex].Select();
                    }
                    break;
            }
        }

        public override void Exit()
        {

        }
    }
}
