using ConsoleProject2_ForTheTop.Actions;
using ConsoleProject2_ForTheTop.Actions.Training;
using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public class TrainHelathScene : BaseScene, IActionable
    {

        int _infoPosX = 16;
        int _infoPosY = 16;
        int _beforeHp;

        Define.ESubAction _actionType;
        ConsoleColor _textColor;

        enum EState { Process, Finish }
        EState _state;

        public event Action OnCompleteAction;

        public TrainHelathScene() : base(Define.EScene.TrainHealth)
        {
            _actionType = Define.ESubAction.TrainHealth;
            _textColor = ConsoleColor.Green;
        }

        public override void Enter()
        {
            Console.Clear();

            _beforeHp = Game.Actor.Player.Stat.MaxHP;
            _state = EState.Process;
        }

        public override void Exit()
        {

        }

        public override void Input()
        {

        }

        public override void Render()
        {
            Console.SetCursorPosition(0, 0);

            Util.PrintLine("[ TrainHealth ]\n", _textColor);

            PrintStatus();

            switch (_state)
            {
                case EState.Process:
                    {
                        PrintProcess();
                    }
                    break;
                case EState.Finish:
                    {
                        PrintResult();
                    }
                    break;
            }
        }

        #region Render
        public void PrintStatus()
        {
            // 플레이어의 상태 출력
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
            Util.Print($" HP: {$"{Game.Actor.Player.Stat.HP} / {Game.Actor.Player.Stat.MaxHP}",-11}", ConsoleColor.Green);
            Util.Print($"Attack: {Game.Actor.Player.Stat.AttackPoint}+{Game.Actor.Player.AdditionalStat.AttackPoint,-5}", ConsoleColor.Red);
            Util.Print($"Defense: {Game.Actor.Player.Stat.Defense}+{Game.Actor.Player.AdditionalStat.Defense,-5}", ConsoleColor.DarkCyan);
            Util.Print($"컨디션: {Game.Actor.Player.Condition,-8}", ConsoleColor.Gray);
            Util.PrintLine($"Gold: {Game.Actor.Player.Gold}G", ConsoleColor.Yellow);
            Util.PrintLine("\n==================================================================================\n", ConsoleColor.Gray);
        }

        void PrintProcess()
        {
            // 훈련 진행 내용 출력
            Console.SetCursorPosition(_infoPosX, _infoPosY);
            Util.Print($"체력 단련을 진행합니다...", _textColor);
            Thread.Sleep(2500);
        }

        void PrintResult()
        {
            int amount = Game.Actions.GetAction<TrainHealth>(_actionType).Amount;

            // 훈련 결과 출력
            Console.SetCursorPosition(_infoPosX, _infoPosY);
            for (int j = 0; j < 30; j++)
            {
                Util.Print(" ");
            }

            Console.SetCursorPosition(_infoPosX, _infoPosY);
            Util.Print($"HP가 ");
            Util.Print($"{amount} ", _textColor);
            Util.Print($"증가했습니다! ({_beforeHp} => ");
            Util.Print($"{Game.Actor.Player.Stat.MaxHP}", _textColor);
            Util.PrintLine(")");
            Thread.Sleep(2500);
        }
        #endregion

        public override void Update()
        {
            switch (_state)
            {
                case EState.Process:
                    {
                        // Action 실행
                        Game.Actions.ExecuteAction(_actionType);
                        _state = EState.Finish;
                    }
                    break;
                case EState.Finish:
                    {
                        // Action 완료
                        OnCompleteAction?.Invoke();
                    }
                    break;
            }
        }
    }
}
