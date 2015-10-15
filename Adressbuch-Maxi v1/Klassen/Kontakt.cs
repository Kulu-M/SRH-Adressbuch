using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbuch_Maxi
{
    [Serializable]
    public class Kontakt
    {
        public string iD { get; set; }
        public string nachname { get; set; }
        public string vorname { get; set; }
        public DateTime gebDatum { get; set; }
        public string straße { get; set; }
        public int plz { get; set; }
        public string ort { get; set; }
        public string telnr { get; set; }
        public string email { get; set; }
        public Anrede anrede { get; set; }
        

    }

        public enum Anrede
            {
                Frau, Herr,
            }
    


}
