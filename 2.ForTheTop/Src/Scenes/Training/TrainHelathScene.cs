﻿using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Menus;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Scenes.Training
{
    public class TrainHelathScene : BaseScene, IActable
    {

        int _actionPosX = 16;
        int _actionPosY = 16;

        int _beforeHp;

        Define.ETrainType _trainType;

        enum EState { Process, Finish }

        EState _state;

        ConsoleColor _textColor;

        public event Action OnCompleteAction;

        public TrainHelathScene() : base(Define.EScene.TrainHealth)
        {
            _trainType = Define.ETrainType.Health;

            _textColor = ConsoleColor.Green;
        }

        public override void Enter()
        {
            Console.Clear();

            _beforeHp = Game.Player.Stat.HP;
            _state = EState.Process;
        }

        public override void Exit()
        {
            
        }

        public override void Input()
        {
            
        }

        public override void Render()
        {
            Console.SetCursorPosition(0, 0);

            Util.PrintLine("[ TrainHealthScene ]\n", _textColor);

            PrintStatus();

            switch(_state)
            {
                case EState.Process:
                    {
                        PrintProcess();                       
                    }
                    break;
                case EState.Finish:
                    {
                        PrintResult();                       
                    }
                    break;
            }
        }

        #region Render
        public void PrintStatus()
        {
            // 플레이어의 상태 출력
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
            Util.Print($" HP: {Game.Player.Stat.HP,-8}", ConsoleColor.Green);
            Util.Print($"AP: {Game.Player.Stat.AttackPoint,-8}", ConsoleColor.Red);
            Util.Print($"Defense: {Game.Player.Stat.Defense,-8}", ConsoleColor.DarkCyan);
            Util.Print($"컨디션 : {Game.Player.Stat.Condition,-8}", ConsoleColor.Gray);
            Util.PrintLine($"Gold : {Game.Player.Gold}G", ConsoleColor.Yellow);
            Util.PrintLine("\n==================================================================================", ConsoleColor.Gray);
        }

        void PrintProcess()
        {
            // 훈련 진행 내용 출력
            Console.SetCursorPosition(_actionPosX, _actionPosY);
            Util.Print($"체력 단련을 진행합니다...", _textColor);
            Thread.Sleep(2500);
        }

        void PrintResult()
        {
            int amount = Game.Actions.GetTraining(_trainType).Amount;

            // 훈련 결과 출력
            Console.SetCursorPosition(_actionPosX, _actionPosY);
            for (int j = 0; j < 30; j++)
            {
                Util.Print(" ");
            }

            Console.SetCursorPosition(_actionPosX, _actionPosY);
            Util.Print($"HP가 ");
            Util.Print($"{amount} ", _textColor);
            Util.Print($"증가했습니다! ({_beforeHp} => ");
            Util.Print($"{Game.Player.Stat.HP}", _textColor);
            Util.PrintLine(")");
            Thread.Sleep(2500);
        }
        #endregion

        public override void Update()
        {
            switch (_state)
            {
                case EState.Process:
                    {
                        // Action 실행
                        Game.Actions.ExecuteTraining(_trainType);
                        _state = EState.Finish;
                    }
                    break;
                case EState.Finish:
                    {
                        // Action 완료
                        OnCompleteAction?.Invoke();
                    }
                    break;
            }
        }
    }
}
