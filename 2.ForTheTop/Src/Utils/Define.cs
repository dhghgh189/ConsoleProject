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
        #region constant
        public const string RESOURCES_PATH = "G:\\KGA\\Project\\ConsoleProject\\2.ForTheTop\\Src\\Resources";
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
                ShopBuy,
                ShopSell,
            Equip,
                EquipItem,
                UnEquipItem,
            Battle,
                BattleAttack,
                BattleDefense,
                BattleUse,
                BattleEnemyAI,
                BattleEnemyAttack,
                BattleEnemyDefense,
            Max
        }
        #endregion

        #region Actions
        public enum EAction { Training, Shopping, Equip, Battle, Max }
        public enum ESubAction 
        { 
            TrainHealth, 
            TrainAttack, 
            TrainDefense,

            ShopBuy,
            ShopSell,

            EquipItem,
            UnEquipItem,

            BattleAttack,
            BattleDefense,
            BattleUse,
            BattleEnemyAttack,
            BattleEnemyDefense,
        }
        #endregion

        #region Items
        public enum EItemType { Equipment, Consumable }
        public enum EEquipType { Weapon, Armor }
        public enum EEquipSlot { Weapon, Helmet, Upper, Lower, Max }
        public enum EConsumeType { Potion }
        #endregion

        public enum EActor { Player, Enemy }
        public enum EBattleState { Idle, Attack, Defense }

        public enum ECondition { Good, Normal, Bad }

        public enum EEffect { Hp, AttackPoint, Defense }

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
