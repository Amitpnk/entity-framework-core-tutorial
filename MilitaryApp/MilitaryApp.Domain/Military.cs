using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryApp.Domain
{
    public class Military
    {
        public Military()
        {
            Quotes = new List<Quote>();
            MilitaryBattles = new List<MilitaryBattle>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Quote> Quotes { get; set; }
        public King King { get; set; }
        public List<MilitaryBattle> MilitaryBattles { get; set; }
        public Horse Horse { get; set; }
    }
}
