using System;
using System.Collections.Generic;

namespace Nodo1.Models
{
    public partial class Block
    {
        public int Id { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public int? IdTicket { get; set; }
    }
}
