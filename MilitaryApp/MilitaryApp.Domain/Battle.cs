using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryApp.Domain
{
   public class Battle
    {
        public Battle()
        {
            MilitaryBattles = new List<MilitaryBattle>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<MilitaryBattle> MilitaryBattles { get; set; }
    }
}
