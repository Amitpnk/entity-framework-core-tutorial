using System;
using System.Collections.Generic;

namespace MilitaryApp.ReverseEnggData
{
    public partial class Quotes
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int MilitaryId { get; set; }

        public virtual Militaries Military { get; set; }
    }
}
