using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public class BattleScene : BaseScene, IActable
    {

        public event Action OnCompleteAction;

        public BattleScene() : base(Define.EScene.Battle)
        {

        }

        public override void Enter()
        {

        }

        public override void Render()
        {
            Console.Clear();

            Util.PrintLine("[ BattleScene ]\n", Define.homeMenu[(int)Define.EAction.Battle].TextColor);
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
