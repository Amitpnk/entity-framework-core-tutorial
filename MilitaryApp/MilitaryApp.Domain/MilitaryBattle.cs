using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryApp.Domain
{
   public class MilitaryBattle
    {
        public int MilitaryId { get; set; }
        public int BattleId { get; set; }
        public Military Military { get; set; }
        public Battle Battle { get; set; }

    }
}
