using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BursaDeValori
{
    internal class BazaDateBursa
    {
        SQLiteConnection conn;

        public BazaDateBursa()
        {
            string caleBD = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
                "bursa_de_valori.db");
            conn = new SQLiteConnection(caleBD, false); 
            conn.CreateTable<Bursa>(); 
        }
        
        public int AdaugaBursa(Bursa bursa)
        {
            return conn.Insert(bursa);
        }
        
        public int AdaugaListaBursa(List<Bursa> listaBursa)
        {
            return conn.InsertAll(listaBursa);
        }

        public int StergeToateInregistrarile()
        {
            return conn.DeleteAll<Bursa>();
        }
        
        public List<Bursa> ObtineToateInreg()
        {
            //return conn.Table<Curs>().ToList();
            return conn.Query<Bursa>("SELECT * FROM Bursa");
        }
    }
}
