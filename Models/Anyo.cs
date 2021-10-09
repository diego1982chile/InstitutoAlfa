using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstitutoAlfa.Models
{
    public class Anyo
    {
        public int id { get; set; }
        public int anyo { get; set; }

        public Anyo(int id, int anyo)
        {
            this.id = id;
            this.anyo = anyo;
        }
    }
}