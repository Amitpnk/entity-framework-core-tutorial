using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryApp.Domain
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Military Military { get; set; }
        public int MilitaryId { get; set; }
    }
}
