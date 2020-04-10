using System;
using System.Collections.Generic;

namespace MilitaryApp.ReverseEnggData
{
    public partial class Kings
    {
        public Kings()
        {
            Militaries = new HashSet<Militaries>();
        }

        public int Id { get; set; }
        public string KingName { get; set; }

        public virtual ICollection<Militaries> Militaries { get; set; }
    }
}
