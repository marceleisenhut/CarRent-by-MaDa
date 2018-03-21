using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Kennzeichen { get; set; }
        public string Marke { get; set; }
        public string Modell { get; set; }
        public int Kilometerstand { get; set; }
        public int Baujahr { get; set; }
        public int AnzahlSitze { get; set; }
        public int AnzahlTueren { get; set; }
        public int LeistungInPS { get; set; }
        public Klasse Klasse { get; set; }
        public DateTime Erstellungsdatum { get; set; }
    }

    public class Klasse
    {
        public int KlasseID { get; set; }
        public string Bezeichnung { get; set; }
        public Tagesgebuehr Ansatz { get; set; }
    }

    public class Tagesgebuehr
    {
        public int TagesgebuehrID { get; set; }
        public int AnsatzProTagInCHF { get; set; }
    }
}
