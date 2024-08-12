using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2_ForTheTop.Utils
{
    public class Define
    {
        public enum EScene { Title, Tutorial, Home, Training, Shop, Equip, Battle, Max }

        public enum EAction { Training, Shopping, Battle, Max }

        public enum EActor { Player, Enemy }

        public enum ECondition { Good, Normal, Bad }

        // 플레이어가 가능한 행동에 관한 정보 (단순 출력 용)
        public class ActionInfo
        {
            public string Name;
            public string Description;
            public ConsoleColor TextColor;

            public ActionInfo(string name, string description, ConsoleColor textColor)
            {
                Name = name;
                Description = description;
                TextColor = textColor;
            }
        }

        public static readonly ActionInfo[] actionInfo = new ActionInfo[(int)EAction.Max]
        {
            new ActionInfo("훈련하기", "플레이어를 단련시켜 능력을 강화", ConsoleColor.Yellow),
            new ActionInfo("상점이동", "전투에 도움이 되는 아이템을 구매", ConsoleColor.DarkCyan),
            new ActionInfo("전투개시", "콜로세움으로 이동하여 전투를 진행", ConsoleColor.Red)
        };
    }
}
