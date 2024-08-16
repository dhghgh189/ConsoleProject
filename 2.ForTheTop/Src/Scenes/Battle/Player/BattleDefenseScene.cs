using ConsoleProject2_ForTheTop.Actors;
using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public class BattleDefenseScene : BaseScene
    {
        int _playerPosX = 3;
        int _playerPosY = 12;

        int _enemyPosX = 45;
        int _enemyPosY = 4;

        int _infoPosY = 18;

        int _enemyMaxHp;
        int _playerMaxHp;

        Define.ESubAction _actionType;
        ConsoleColor _textColor;

        public BattleDefenseScene() : base(Define.EScene.BattleAttack)
        {
            _actionType = Define.ESubAction.BattleDefense;
            _textColor = ConsoleColor.DarkCyan;
        }

        public override void Enter()
        {
            _enemyMaxHp = Game.Actor.CurrentEnemy.Stat.MaxHP / 10;
            _playerMaxHp = Game.Actor.Player.Stat.MaxHP / 10;
        }

        public override void Render()
        {
            Console.SetCursorPosition(0, 0);

            Util.PrintLine("[ BattleDefense ]\n", Define.homeMenu[(int)Define.EAction.Battle].TextColor);

            PrintActors();

            PrintInfoMsg();
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
            Util.Print($": {enemy.Stat.HP,-3}");

            Console.SetCursorPosition(_enemyPosX, _enemyPosY + lineCount++);
            Util.Print("AP ", ConsoleColor.Red);
            Util.Print($": {enemy.Stat.AttackPoint,-3}");

            Console.SetCursorPosition(_enemyPosX, _enemyPosY + lineCount);
            Util.Print("Defense ", ConsoleColor.DarkCyan);
            Util.Print($": {enemy.Stat.Defense,-3}");

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
            Util.Print($": {player.Stat.HP,-3}");

            Console.SetCursorPosition(_playerPosX, _playerPosY + lineCount++);
            Util.Print("AP ", ConsoleColor.Red);
            Util.Print($": {player.Stat.AttackPoint}+{player.AdditionalStat.AttackPoint,-3}");

            Console.SetCursorPosition(_playerPosX, _playerPosY + lineCount);
            Util.Print("Defense ", ConsoleColor.DarkCyan);
            Util.Print($": {player.Stat.Defense}+{player.AdditionalStat.Defense,-3}");

            Console.SetCursorPosition(0, _infoPosY);
            Util.PrintLine("==================================================================================\n", ConsoleColor.Gray);
        }

        // 방어 진행 메세지 출력
        void PrintInfoMsg()
        {
            Util.Print("                                                                  ");
            Util.PrintLine("\n");

            Warrior defender = Game.Actor.Player;

            Util.Print($"   {defender.Name}", ConsoleColor.Green);
            Util.Print("는(은) ");
            Util.Print("방어", _textColor);
            Util.PrintLine("태세를 갖췄다!");
            Util.PrintLine("");
            Util.PrintLine("\n");
            Util.PrintLine("==================================================================================", ConsoleColor.Gray);
            Thread.Sleep(2000);
        }
        #endregion

        public override void Input()
        {

        }

        public override void Update()
        {
            Game.Actions.ExecuteAction(_actionType);
            Game.Scene.ChangeScene(Define.EScene.BattleEnemyAI);
        }

        public override void Exit()
        {

        }
    }
}
