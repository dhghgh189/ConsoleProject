using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public class EquipScene : BaseScene, IActable
    {

        public event Action OnCompleteAction;

        public EquipScene() : base(Define.EScene.Equip)
        {

        }

        public override void Enter()
        {

        }

        public override void Render()
        {
            Console.Clear();

            Util.PrintLine("[ EquipScene ]\n", Define.homeMenu[(int)Define.EAction.Equip].TextColor);
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
