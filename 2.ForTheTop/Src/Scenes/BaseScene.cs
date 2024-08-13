using ConsoleProject2_ForTheTop.Utils;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public abstract class BaseScene
    {
        protected Define.EScene _sceneType;
        protected ConsoleKey _inputKey;

        public Define.EScene SceneType { get { return _sceneType; } }
        public ConsoleKey InputKey { get { return _inputKey; } }

        public BaseScene(Define.EScene type)
        {
            _sceneType = type;
        }

        public abstract void Enter();
        public abstract void Render();
        public abstract void Input();
        public abstract void Update();
        public abstract void Exit();
    }
}
