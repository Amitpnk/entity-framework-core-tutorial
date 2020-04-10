using System;
using System.Collections.Generic;

namespace MilitaryApp.ReverseEnggData
{
    public partial class Militaries
    {
        public Militaries()
        {
            Quotes = new HashSet<Quotes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? KingId { get; set; }

        public virtual Kings King { get; set; }
        public virtual ICollection<Quotes> Quotes { get; set; }
    }
}
