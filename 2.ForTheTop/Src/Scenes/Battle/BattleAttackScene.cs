using ConsoleProject2_ForTheTop.Actors;
using ConsoleProject2_ForTheTop.Actors.Stats;
using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Menus;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public class BattleAttackScene : BaseScene
    {
        int _playerPosX = 3;
        int _playerPosY = 12;

        int _enemyPosX = 59;
        int _enemyPosY = 4;

        int _infoPosY = 18;

        int _enemyMaxHp;
        int _playerMaxHp;

        Define.ESubAction _actionType;
        ConsoleColor _textColor;

        enum EState { Process, Finish }
        EState _state;

        public BattleAttackScene() : base(Define.EScene.BattleAttack)
        {
            _actionType = Define.ESubAction.BattleAttack;
            _textColor = ConsoleColor.Red;
        }

        public override void Enter()
        {
            _enemyMaxHp = Game.Actor.CurrentEnemy.Stat.MaxHP / 10;
            _playerMaxHp = Game.Actor.Player.Stat.MaxHP / 10;

            _state = EState.Process;
        }

        public override void Render()
        {
            Console.SetCursorPosition(0, 0);

            Util.PrintLine("[ BattleAttack ]\n", Define.homeMenu[(int)Define.EAction.Battle].TextColor);

            PrintActors();

            switch (_state)
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
        void PrintActors()
        {
            // Actor들의 정보를 출력

            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);

            // Actor들의 현재 체력
            int enemyHp = Game.Actor.CurrentEnemy.Stat.HP / 10; 
            int playerHp = Game.Actor.Player.Stat.HP / 10;

            // Enemy Info
            int lineCount = 0;
            Enemy enemy = Game.Actor.CurrentEnemy;
            Console.SetCursorPosition(_enemyPosX, _enemyPosY + lineCount++);
            Util.Print($"{enemy.Name}", ConsoleColor.Red);

            Console.SetCursorPosition(_enemyPosX, _enemyPosY + lineCount++);
            for (int i = 0; i < _enemyMaxHp; i++)
            {
                if (i < enemyHp)
                    Util.Print("■", ConsoleColor.DarkRed);
                else
                    Util.Print("□");
            }

            Console.SetCursorPosition(_enemyPosX, _enemyPosY + lineCount++);
            Util.Print("HP ", ConsoleColor.DarkRed);
            Util.Print($": {enemy.Stat.HP, -3}");

            Console.SetCursorPosition(_enemyPosX, _enemyPosY + lineCount++);
            Util.Print("AP ", ConsoleColor.Red);
            Util.Print($": {enemy.Stat.AttackPoint, -3}");

            Console.SetCursorPosition(_enemyPosX, _enemyPosY + lineCount);
            Util.Print("Defense ", ConsoleColor.DarkCyan);
            Util.Print($": {enemy.Stat.Defense, -3}");

            // Player Info
            lineCount = 0;
            Player player = Game.Actor.Player;
            Console.SetCursorPosition(_playerPosX, _playerPosY + lineCount++);
            Util.Print($"{player.Name}", ConsoleColor.Green);

            Console.SetCursorPosition(_playerPosX, _playerPosY + lineCount++);
            for (int i = 0; i < _playerMaxHp; i++)
            {
                if (i < playerHp)
                    Util.Print("■", ConsoleColor.DarkRed);
                else
                    Util.Print("□");
            }

            Console.SetCursorPosition(_playerPosX, _playerPosY + lineCount++);
            Util.Print("HP ", ConsoleColor.DarkRed);
            Util.Print($": {player.Stat.HP, -3}");

            Console.SetCursorPosition(_playerPosX, _playerPosY + lineCount++);
            Util.Print("AP ", ConsoleColor.Red);
            Util.Print($": {player.Stat.AttackPoint, -3}");

            Console.SetCursorPosition(_playerPosX, _playerPosY + lineCount);
            Util.Print("Defense ", ConsoleColor.DarkCyan);
            Util.Print($": {player.Stat.Defense, -3}");

            Console.SetCursorPosition(0, _infoPosY);
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
        }

        // 공격 진행 메세지 출력
        void PrintProcess()
        {
            Util.Print("                                                                  ");                      
            Util.PrintLine("\n");

            Warrior attacker = Game.Actor.Player; 

            Util.Print($"   {attacker.Name}", ConsoleColor.Green);
            Util.Print("의 ");
            Util.PrintLine("공격!", _textColor);
            Util.PrintLine("");
            Util.PrintLine("\n");
            Util.PrintLine("==================================================================================", ConsoleColor.Gray);
            Thread.Sleep(1500);
        }

        // 공격 결과 메세지 출력
        void PrintResult()
        {
            Util.PrintLine("\n");

            Warrior attacker = Game.Actor.Player; 
            Warrior enemy = Game.Actor.CurrentEnemy;
            int damage = attacker.Stat.AttackPoint;

            Util.Print($"   {enemy.Name}", ConsoleColor.Red);
            Util.Print("는(은) ");
            Util.Print($"{damage}", _textColor);
            Util.PrintLine("의 데미지를 입었다!");
            Util.PrintLine("");
            Util.PrintLine("\n");
            Util.PrintLine("==================================================================================", ConsoleColor.Gray);
            Thread.Sleep(2500);
        }
        #endregion

        public override void Input()
        {
            
        }

        public override void Update()
        {
            switch (_state)
            {
                case EState.Process:
                    {
                        Game.Actions.ExecuteAction(_actionType);
                        _state = EState.Finish;
                    }
                    break;
                case EState.Finish:
                    {
                        if (Game.Actor.CurrentEnemy.IsAlive)
                        {
                            // enemy의 공격 턴으로 이행
                            Game.Scene.ChangeScene(Define.EScene.BattleEnemyAttack);
                        }
                        else
                        {
                            // enemy가 사망했으므로 되돌아간다.
                            Game.Scene.ChangeScene(Define.EScene.Battle);
                        }
                    }
                    break;
            }
        }

        public override void Exit()
        {

        }
    }
}
