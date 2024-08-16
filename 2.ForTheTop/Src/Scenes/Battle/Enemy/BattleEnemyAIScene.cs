using ConsoleProject2_ForTheTop.Actors;
using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;

namespace ConsoleProject2_ForTheTop.Scenes
{
    public class BattleEnemyAIScene : BaseScene
    {
        int _playerPosX = 3;
        int _playerPosY = 12;

        int _enemyPosX = 45;
        int _enemyPosY = 4;

        int _infoPosY = 18;

        int _enemyMaxHp;
        int _playerMaxHp;

        int _actionIndex;
        ConsoleColor _textColor;

        public BattleEnemyAIScene() : base(Define.EScene.BattleEnemyAI)
        {
            _textColor = ConsoleColor.Red;
        }

        public override void Enter()
        {
            _enemyMaxHp = Game.Actor.CurrentEnemy.Stat.MaxHP / 10;
            _playerMaxHp = Game.Actor.Player.Stat.MaxHP / 10;

            Game.Actor.CurrentEnemy.State = Define.EBattleState.Idle;

            _actionIndex = 0;
        }

        public override void Render()
        {
            Console.SetCursorPosition(0, 0);

            Util.PrintLine("[ BattleEnemyAI ]\n", Define.homeMenu[(int)Define.EAction.Battle].TextColor);

            PrintActors();
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

            Util.Print("                                                                  ");
            Util.PrintLine("\n");

            Util.PrintLine("                                                              ");
            Util.PrintLine("                                                              ");
            Util.PrintLine("\n");
            Util.PrintLine("==================================================================================", ConsoleColor.Gray);
        }
        #endregion

        public override void Input()
        {

        }

        public override void Update()
        {
            // enemy 행동 랜덤 선택
            Random rand = new Random();
            _actionIndex = rand.Next(0, 3);

            // 공격
            if (_actionIndex < 2)
            {
                Game.Scene.ChangeScene(Define.EScene.BattleEnemyAttack);
            }
            // 방어
            else
            {
                Game.Scene.ChangeScene(Define.EScene.BattleEnemyDefense);
            }
        }

        public override void Exit()
        {

        }
    }
}
