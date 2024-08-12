using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Actors.Warriors
{
    public interface IDamagable
    {
        // 피격
        void TakeDamage(int damage);
        // 사망
        void Die();
    }
}
