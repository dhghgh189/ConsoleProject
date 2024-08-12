using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public class TutorialScene : BaseScene
    {
        public TutorialScene() : base(Define.EScene.Tutorial)
        {

        }

        public override void Enter()
        {
            
        }

        public override void Render()
        {
            Console.Clear();

            Console.CursorVisible = true;

            Define.ActionInfo actionInfo = null;

            Util.PrintLine("===============================", ConsoleColor.Yellow);
            Util.PrintLine($"={"=",30}", ConsoleColor.Yellow);
            Util.PrintLine("=         How To Play         =", ConsoleColor.Yellow);
            Util.PrintLine($"={"=",30}", ConsoleColor.Yellow);
            Util.PrintLine("===============================", ConsoleColor.Yellow);

            Util.PrintLine();
            Util.PrintLine("당신은 가장 강한 검투사가 되기 위한 여정을 떠납니다.\n");

            Util.Print("게임에서 ");
            Util.Print($"{Game.LeftDays}", ConsoleColor.Green);
            Util.PrintLine("일 내에 모든 적들을 물리쳐야 하며");
            Util.PrintLine("아래의 Action들 중 하나를 선택하여 게임을 진행합니다.");

            Util.PrintLine();
            for (int i = 0; i < Define.actionInfo.Length; i++)
            {
                actionInfo = Define.actionInfo[i];
                Util.PrintLine($"  {actionInfo.Name} : {actionInfo.Description}", actionInfo.TextColor);
            }

            Util.PrintLine();
            Util.PrintLine("선택한 Action이 완료되면 하루가 지나갑니다.\n");

            Util.PrintLine("전투는 턴제 방식으로 진행되며, 한 전투에 한 명의 적이 등장합니다.\n");
            
            Util.PrintLine($"전투에서 패배하거나, {Game.LeftDays}일이 지나면 게임 오버입니다.\n");

            Util.PrintLine("모든 적을 물리치고 최고의 검투사가 되세요!", ConsoleColor.Cyan);

            Util.PrintLine();
            Util.PrintLine(">        Press Enter Key        <", ConsoleColor.Green);
        }

        public override void Input()
        {
            Console.ReadLine();
        }

        public override void Update()
        {
            // Home Scene으로 이동
            Game.Scene.ChangeScene(Define.EScene.Home);
        }

        public override void Exit()
        {
            Console.CursorVisible = false;
        }
    }
}
