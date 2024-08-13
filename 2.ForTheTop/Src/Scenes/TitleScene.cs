using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public class TitleScene : BaseScene
    {
        public TitleScene() : base(Define.EScene.Title)
        {

        }

        public override void Enter()
        {

        }

        public override void Render()
        {
            Console.Clear();

            PrintTitle();

            Util.PrintLine();
            Util.PrintLine(">        Press Any Key        <", ConsoleColor.Green);
        }

        void PrintTitle()
        {
            Util.PrintLine("┌─────────────────────────────┐", ConsoleColor.Yellow);
            Util.PrintLine($"│{"│",30}", ConsoleColor.Yellow);
            Util.PrintLine("│         For The Top         │", ConsoleColor.Yellow);
            Util.PrintLine($"│{"│",30}", ConsoleColor.Yellow);
            Util.PrintLine("└─────────────────────────────┘", ConsoleColor.Yellow);
        }

        public override void Input()
        {
            Console.ReadKey(true);
        }

        public override void Update()
        {
            Game.Scene.ChangeScene(Define.EScene.Tutorial);
        }

        public override void Exit()
        {
            
        }
    }
}
