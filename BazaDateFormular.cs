using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BursaDeValori
{
    internal class BazaDateFormular
    {
        SQLiteConnection conn;

        public BazaDateFormular()
        {
            string caleBD = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
                "formular.db");
            conn = new SQLiteConnection(caleBD, false);
            conn.CreateTable<Formular>();
        }

        public int AdaugaRaspuns(Formular formular)
        {
            return conn.Insert(formular);
        }
    }
}
