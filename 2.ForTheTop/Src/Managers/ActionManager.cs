using ConsoleProject2_ForTheTop.Actions;
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
        List<BaseAction> _actions = new List<BaseAction>();

        Dictionary<Define.ETrainType, Training> _actTraining;

        public List<BaseAction> AllActions { get { return _actions; } }

        public ActionManager()
        {
            _actions.Add(new TrainHealth(10));
            _actions.Add(new TrainAttack(10));
            _actions.Add(new TrainDefense(10));

            // Training Action Dictionary
            _actTraining = new Dictionary<Define.ETrainType, Training>();
            foreach(BaseAction action in _actions.Where(x => x is Training))
            {
                Training training = action as Training;
                if (training != null)
                {
                    _actTraining.Add(training.Type, training);
                }             
            }
        }

        public Training GetTraining(Define.ETrainType type)
        {
            _actTraining.TryGetValue(type, out Training training);

            return training;
        }

        public void ExecuteTraining(Define.ETrainType type)
        {
            _actTraining.TryGetValue(type, out Training action);
            action?.Execute();
        }
    }
}
