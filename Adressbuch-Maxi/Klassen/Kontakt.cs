using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbuch
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
        public string bildPath { get; set; }


        public Kontakt()
        {
            Properties.Settings.Default.last_id++;
            iD = String.Format("i{0:0000}", Properties.Settings.Default.last_id);

            nachname = "Bitte vervollständigen";
            gebDatum = new DateTime(1990, 1, 1);

            Properties.Settings.Default.Save();
        }

    }

        public enum Anrede
            {
                Frau, Herr,
            }
    


}
