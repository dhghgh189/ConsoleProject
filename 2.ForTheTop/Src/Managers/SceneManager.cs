using ConsoleProject2_ForTheTop.Scenes;
using ConsoleProject2_ForTheTop.Utils;

namespace ConsoleProject2_ForTheTop.Managers
{
    public class SceneManager
    {
        BaseScene[] _scenes;
        BaseScene _currentScene;

        public BaseScene CurrentScene { get { return _currentScene; } }
        public BaseScene[] AllScene { get { return _scenes; } }
        public BaseScene GetScene(Define.EScene scene) => _scenes[(int)scene];
        public T GetSceneAs<T>(Define.EScene scene) where T : BaseScene
        {
            return _scenes[(int)scene] as T;
        }

        public SceneManager()
        {
            _scenes = new BaseScene[(int)Define.EScene.Max];
            _scenes[(int)Define.EScene.Title] = new TitleScene();
            _scenes[(int)Define.EScene.Tutorial] = new TutorialScene();
            _scenes[(int)Define.EScene.Home] = new HomeScene();
            _scenes[(int)Define.EScene.Training] = new TrainingScene();
            {
                _scenes[(int)Define.EScene.TrainHealth] = new TrainHelathScene();
                _scenes[(int)Define.EScene.TrainAttack] = new TrainAttackScene();
                _scenes[(int)Define.EScene.TrainDefense] = new TrainDefenseScene();
            }
            _scenes[(int)Define.EScene.Shop] = new ShopScene();
            {
                _scenes[(int)Define.EScene.ShopBuy] = new ShopBuyScene();
                _scenes[(int)Define.EScene.ShopSell] = new ShopSellScene();
            }
            _scenes[(int)Define.EScene.Equip] = new EquipScene();
            {
                _scenes[(int)Define.EScene.EquipItem] = new EquipItemScene();
                _scenes[(int)Define.EScene.UnEquipItem] = new UnEquipItemScene();
            }
            _scenes[(int)Define.EScene.Battle] = new BattleScene();
            {
                _scenes[(int)Define.EScene.BattleAttack] = new BattleAttackScene();
                _scenes[(int)Define.EScene.BattleDefense] = new BattleDefenseScene();
                _scenes[(int)Define.EScene.BattleUse] = new BattleUseScene();
                _scenes[(int)Define.EScene.BattleEnemyAI] = new BattleEnemyAIScene();
                _scenes[(int)Define.EScene.BattleEnemyAttack] = new BattleEnemyAttackScene();
                _scenes[(int)Define.EScene.BattleEnemyDefense] = new BattleEnemyDefenseScene();
            }
        }

        public void ChangeScene(Define.EScene type)
        {
            // 유효한 씬이 아님
            if (!Enum.IsDefined(type))
                return;

            // Enum에 정의된 씬이 실존하지 않는 경우
            if (_scenes[(int)type] == null)
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
