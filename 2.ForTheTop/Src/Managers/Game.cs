using ConsoleProject2_ForTheTop.Actors;
using ConsoleProject2_ForTheTop.Scenes;
using ConsoleProject2_ForTheTop.Utils;

namespace ConsoleProject2_ForTheTop.Managers
{
    public class Game
    {
        #region Singleton
        static Game s_instance = null;
        public static Game Instance
        {
            get
            {
                if (s_instance == null)
                {
                    Game instance = new Game();
                    s_instance = instance;

                    if (_isInit == false)
                    {
                        s_instance.Init();
                    }
                }

                return s_instance;
            }
        }
        #endregion

        #region Managers
        SceneManager _scene;
        ActorManager _actor;
        ActionManager _action;

        public static SceneManager Scene { get { return Instance._scene; } }
        public static ActorManager Actor { get { return Instance._actor; } }
        public static ActionManager Actions { get { return Instance._action; } }
        #endregion

        // 최초 실행시 false
        static bool _isInit = false;

        // 게임 진행 상태
        bool _isRunning;
        // 남은 제한 일 수
        int _leftDays;
        // 남은 적 수
        int _leftEnemies;
        // 플레이어

        public static bool IsRunning { get { return Instance._isRunning; } }
        public static int LeftDays { get { return Instance._leftDays; } }
        public static int LeftEnemies { get {  return Instance._leftEnemies; } }
        public static int CurrentEnemyIdx => Define.ENEMY_COUNT - LeftEnemies;

        void Init()
        {
            // Game Class를 위한 초기화
            _scene = new SceneManager();
            _actor = new ActorManager();
            _action = new ActionManager();
        }

        public void RunGame()
        {
            Start();

            while (_isRunning)
            {
                Render();

                Input();

                Update();
            }

            End();
        }

        void Start()
        {
            Console.CursorVisible = false;

            // data load 필요?

            _isRunning = true;

            // 남은 일 수
            _leftDays = 30; // 임시 값

            // 남은 적 수
            _leftEnemies = Define.ENEMY_COUNT;

            // Player 생성, 임시
            Player player = new Player("플레이어");
            player.SetInfo(100, 10, 0);
            Actor.AddActor(player, Define.EActor.Player);

            // Enemy 생성, 임시
            for (int i = 0; i < Define.ENEMY_COUNT; i++)
            {
                Enemy enemy = new Enemy($"CPU{i + 1}");
                enemy.SetInfo(100 + (i * 10), 10 + (i * 10), 0 + (i * 10));
                enemy.SetReward(1000 + (i * 2000));

                Actor.AddActor(enemy, Define.EActor.Enemy);
            }

            // event bind
            foreach (BaseScene scene in Scene.AllScene)
            {
                IActionable actScene = scene as IActionable;
                if (actScene != null)
                {
                    actScene.OnCompleteAction += EndDay;
                }
            }

            // Title 씬 부터 시작
            Scene.ChangeScene(Define.EScene.Title);
        }

        void Render()
        {
            Scene.CurrentScene.Render();
        }

        void Input()
        {
            Scene.CurrentScene.Input();
        }

        void Update()
        {
            Scene.CurrentScene.Update();
        }

        // 전투에서 enemy를 물리치면 leftEnemies를 차감 (callback)
        public void RemoveEnemy()
        { 
            if (_leftEnemies <= 0)
                return;

            _leftEnemies--;
        }

        // 전투에서 enemy를 물리치면 Reward 획득
        public void GetReward()
        {
            Actor.Player.Gold += Actor.CurrentEnemy.Gold;
        }

        // action 종료 후 하루를 마무리
        void EndDay()
        {
            Console.Clear();
            Util.PrintLine("┌─────────────────────────────┐", ConsoleColor.Yellow);
            Util.PrintLine($"│{"│",30}", ConsoleColor.Yellow);
            Util.PrintLine("│     하루가 지나갑니다..     │", ConsoleColor.Yellow);
            Util.PrintLine($"│{"│",30}", ConsoleColor.Yellow);
            Util.PrintLine("└─────────────────────────────┘", ConsoleColor.Yellow);
            Thread.Sleep(2500);

            _leftDays--;
            if (_leftDays <= 0)
            {
                GameOver();
                return;
            }

            // 아직 leftDay가 남았으면 다시 Home으로
            Scene.ChangeScene(Define.EScene.Home);
        }

        public void GameOver()
        {
            // TODO : Game Over
            _isRunning = false;
        }

        void End()
        {
            Console.Clear();

            Util.PrintLine("┌─────────────────────────────┐", ConsoleColor.DarkRed);
            Util.PrintLine($"│{"│",30}", ConsoleColor.DarkRed);
            Util.PrintLine("│          GAME OVER          │", ConsoleColor.DarkRed);
            Util.PrintLine($"│{"│",30}", ConsoleColor.DarkRed);
            Util.PrintLine("└─────────────────────────────┘", ConsoleColor.DarkRed);
        }
    }
}
