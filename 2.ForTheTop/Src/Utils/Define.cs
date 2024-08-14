using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleProject2_ForTheTop.Menus;

namespace ConsoleProject2_ForTheTop.Utils
{
    public class Define
    {
        #region Constants
        public const int ENEMY_COUNT = 8;
        #endregion

        #region Scenes
        public enum EScene
        { 
            Title, 
            Tutorial, 
            Home, 
            Training,
                TrainHealth,
                TrainAttack,
                TrainDefense,
            Shop, 
            Equip,
            Battle,
                BattleAttack,
                BattleDefense,
                BattleUse,
                BattleEnemyAttack,
            Max
        }
        #endregion

        #region Define Actions
        public enum EAction { Training, Shopping, Equip, Battle, Max }
        public enum ESubAction 
        { 
            TrainHealth, 
            TrainAttack, 
            TrainDefense,

            BattleAttack,
            BattleDefense,
            BattleUse,
            BattleEnemyAttack,
        }
        #endregion

        public enum EActor { Player, Enemy }

        public enum ECondition { Good, Normal, Bad }

        #region Define Menus
        public static readonly SceneMenu[] homeMenu = new SceneMenu[(int)EAction.Max]
        {
            new SceneMenu("훈련하기", "플레이어를 단련시켜 능력을 강화", ConsoleColor.Yellow, EScene.Training),
            new SceneMenu("상점이동", "전투에 도움이 되는 아이템을 구매", ConsoleColor.DarkCyan, EScene.Shop),
            new SceneMenu("장비하기", "소지중인 아이템을 장비하거나 해제", ConsoleColor.Cyan, EScene.Equip),
            new SceneMenu("전투개시", "콜로세움으로 이동하여 전투를 진행", ConsoleColor.Red, EScene.Battle)
        };
        #endregion
    }
}
