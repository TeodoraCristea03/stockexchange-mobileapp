using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BursaDeValori
{
    public class Formular
    {
        public Formular(string nume, string prenume, string datanastere, string extracomp, double notaapp)
        {
            Nume = nume;
            Prenume = prenume;
            DataNastere = datanastere;
            ExtraComp = extracomp;
            NotaApp = notaapp;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string DataNastere { get; set; }
        public string ExtraComp { get; set; }
        public double NotaApp { get; set; }
    }
}
