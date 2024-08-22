using ConsoleProject2_ForTheTop.Actors.Stats;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actors.Effects
{
    public class Effect
    {
        Define.EEffect _effectType;
        int _value;
        char _operator;

        public Define.EEffect EffectType { get { return _effectType; } }
        public int Value { get { return _value; } }
        public char Operator { get { return _operator; } }

        public Effect(Define.EEffect type, int value, char op)
        {
            _effectType = type;
            _value = value;
            _operator = op;
        }

        public int Calculate(int stat, int value)
        {
            switch (_operator)
            {
                case '+':
                    return stat + value;
                case '*':
                    return stat * value;
                default:
                    return 0;
            }
        }
    }
}
