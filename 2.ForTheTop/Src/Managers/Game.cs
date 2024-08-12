using ConsoleProject2_ForTheTop.Actors.Warriors;
using ConsoleProject2_ForTheTop.Utils;
using System.Runtime.CompilerServices;

namespace ConsoleProject2_ForTheTop.Managers
{
    public class Game
    {
        #region Singleton
        static Game s_instance = null;
        static Game Instance
        {
            get
            {
                if (s_instance == null)
                {
                    Game instance = new Game();
                    s_instance = instance;
                }

                return s_instance;
            }
        }
        #endregion

        #region Managers
        SceneManager _scene = new SceneManager();

        public static SceneManager Scene { get { return Instance._scene; } }
        #endregion

        // 게임 진행 상태
        bool _isRunning;
        // 남은 제한 일 수
        int _leftDays;
        // 플레이어
        Player _player;


        public static bool IsRunning { get { return Instance._isRunning; } }
        public static int LeftDays { get { return Instance._leftDays; } }
        public static Player Player { get { return Instance._player; } }

        public static void Run()
        {
            Instance.RunGame();
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
        }

        void Start()
        {
            Console.CursorVisible = false;

            // data load 필요?

            _isRunning = true;

            // 제한 일 수
            _leftDays = 30; // 임시 값

            // Player 생성
            _player = new Player();
            _player.SetInfo(); 

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
    }
}
