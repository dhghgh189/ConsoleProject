using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public class HomeScene : BaseScene
    {
        public HomeScene() : base(Define.EScene.Home)
        {

        }

        public override void Enter()
        {

        }

        public override void Render()
        {
            Console.Clear();

            Util.PrintLine("[ HomeScene ]\n", ConsoleColor.Yellow);

            Util.PrintLine
                ($"HP: {Game.Player.Stat.HP, -8} AP: {Game.Player.Stat.AttackPoint, -8} Defense: {Game.Player.Stat.Defense}");
            Util.PrintLine($"컨디션 : {Game.Player.Stat.Condition}");
            Util.PrintLine($"Gold : {Game.Player.Gold}G");
        }

        public override void Input()
        {
            Console.ReadKey(true);
        }

        public override void Update()
        {

        }

        public override void Exit()
        {

        }
    }
}
