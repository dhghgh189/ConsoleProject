using ConsoleProject2_ForTheTop.Scenes;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Managers
{
    public class SceneManager
    {
        BaseScene[] _scenes;
        BaseScene _currentScene;
        public BaseScene CurrentScene { get { return _currentScene; } }

        public SceneManager()
        {
            _scenes = new BaseScene[(int)Define.EScene.Max];
            _scenes[(int)Define.EScene.Title] = new TitleScene();
            _scenes[(int)Define.EScene.Tutorial] = new TutorialScene();
            _scenes[(int)Define.EScene.Home] = new HomeScene();
        }

        public void ChangeScene(Define.EScene type)
        {
            // 유효한 씬이 아님
            if (!Enum.IsDefined(type))
                return;

            // 이전 씬이 존재함
            if (_currentScene != null)
            {
                _currentScene.Exit();
            }

            // 씬 변경 처리
            _currentScene = _scenes[(int)type];
            _currentScene?.Enter();
        }
    }
}
