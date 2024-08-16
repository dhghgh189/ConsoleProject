using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;

namespace ConsoleProject2_ForTheTop.Actions
{
    public class BattleEnemyDefense : BaseAction
    {
        public BattleEnemyDefense() : base(Define.ESubAction.BattleEnemyDefense)
        {

        }

        public override void Execute()
        {
            Game.Actor.CurrentEnemy.State = Define.EBattleState.Defense;
        }
    }
}
