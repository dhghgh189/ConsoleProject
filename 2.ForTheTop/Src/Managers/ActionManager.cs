using ConsoleProject2_ForTheTop.Actions;
using ConsoleProject2_ForTheTop.Actions.Battle;
using ConsoleProject2_ForTheTop.Actions.Training;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Managers
{
    public class ActionManager
    {
        // Action Dictionary
        Dictionary<Define.ESubAction, BaseAction> _actionDict;

        public List<BaseAction> AllActions { get { return _actionDict.Values.ToList(); } }

        public ActionManager()
        {            
            _actionDict = new Dictionary<Define.ESubAction, BaseAction>();

            // 훈련하기
            _actionDict.Add(Define.ESubAction.TrainHealth, new TrainHealth(10));
            _actionDict.Add(Define.ESubAction.TrainAttack, new TrainAttack(10));
            _actionDict.Add(Define.ESubAction.TrainDefense, new TrainDefense(10));

            // 전투개시
            _actionDict.Add(Define.ESubAction.BattleAttack, new BattleAttack());
            //_actionDict.Add(Define.ESubAction.BattleDefense, new BattleDefense());
            //_actionDict.Add(Define.ESubAction.BattleUse, new BattleUse());
            _actionDict.Add(Define.ESubAction.BattleEnemyAttack, new BattleEnemyAttack());
        }

        public T GetAction<T>(Define.ESubAction type) where T : BaseAction 
        {
            if (_actionDict.TryGetValue(type, out BaseAction baseAction) == false)
                return null;

            T action = baseAction as T;
            return action;
        }

        public void ExecuteAction(Define.ESubAction type)
        {
            if (_actionDict.TryGetValue(type, out BaseAction action) == false)
                return;

            action?.Execute();
        }
    }
}
