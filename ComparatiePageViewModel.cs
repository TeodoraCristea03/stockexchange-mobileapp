using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BursaDeValori
{
    public class ComparatiePageViewModel
    {
        public Bursa Companie1 { get; set; }    
        public Bursa Companie2 { get; set; }
        public List<Bursa> ListaBursa { get; set; }

        public ComparatiePageViewModel()
        {
            ListaBursa = new BazaDateBursa().ObtineToateInreg();
        }
    }
}
