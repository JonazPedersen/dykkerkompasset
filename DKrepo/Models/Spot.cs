using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKrepo
{
    public class Spot
    {
        public int ID { get; set; }

        public string Navn { get; set; }

        public string Long { get; set; }

        public string Lati { get; set; }

        public string Videre { get; set; }

        public string Beskrivelse { get; set; }

        public string DybteBund { get; set; }

        public string Billede { get; set; }

        public string DybteTop { get; set; }

        public int PosType { get; set; }

        public int Type { get; set; }

        public string Afstand { get; set; }

        public int Skibe { get; set; }

        public int Aaben { get; set; }

        public int VisPos { get; set; }
    }

}
