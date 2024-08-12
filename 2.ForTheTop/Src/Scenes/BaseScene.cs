using ConsoleProject2_ForTheTop.Utils;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public abstract class BaseScene
    {
        protected Define.EScene _type;
        protected ConsoleKey _inputKey;

        public Define.EScene Type { get { return _type; } }
        public ConsoleKey InputKey { get { return _inputKey; } }


        public BaseScene(Define.EScene type)
        {
            _type = type;
        }

        public abstract void Enter();
        public abstract void Render();
        public abstract void Input();
        public abstract void Update();
        public abstract void Exit();
    }
}
