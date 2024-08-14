using ConsoleProject2_ForTheTop.Actors;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Managers
{
    public class ActorManager
    {
        Player _player;
        List<Enemy> _enemies;

        public Player Player { get { return _player; } }
        public List<Enemy> Enemies {  get { return _enemies; } }
        public Enemy CurrentEnemy { get { return _enemies[Game.CurrentEnemyIdx]; } }

        public ActorManager()
        {
            _enemies = new List<Enemy>(Define.ENEMY_COUNT);
        }

        public void AddActor(Actor actor, Define.EActor type)
        {
            switch (type)
            {
                case Define.EActor.Player:
                    {
                        if (actor is Player)
                        {
                            _player = (Player)actor;
                        }
                    }
                    break;
                case Define.EActor.Enemy:
                    {
                        if (_enemies.Count >= Define.ENEMY_COUNT)
                            return;                            
                        
                        if (actor is Enemy)
                        {
                            _enemies.Add((Enemy)actor);
                        }
                    }
                    break;
            }
        }
    }
}
