﻿using ConsoleProject2_ForTheTop.Managers;
using ConsoleProject2_ForTheTop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actions
{
    public class BattleEnemyAttack : BaseAction
    {
        public BattleEnemyAttack() : base(Define.ESubAction.BattleEnemyAttack)
        {

        }

        public override void Execute()
        {
            Game.Actor.CurrentEnemy.State = Define.EBattleState.Attack;

            int amount = Game.Actor.CurrentEnemy.Stat.AttackPoint;
            Game.Actor.Player.TakeDamage(amount);
        }
    }
}
