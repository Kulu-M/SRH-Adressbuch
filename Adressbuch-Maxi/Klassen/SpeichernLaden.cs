using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Adressbuch_Maxi;

namespace Adressbuch_Maxi
{
    class SpeichernLaden
    {
   

    public static void writeBinary<T>(string datei, T zuSpeichern)
    {
        FileStream fs = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            fs = new FileStream(datei, FileMode.Create);
            bf.Serialize(fs, zuSpeichern);
            fs.Close();
        }
        catch (Exception e)
        {
            if(fs!=null)
                fs.Close();
        }
    }

        internal static void schreibeBin<T>(string v, T kontakt)
        {
            throw new NotImplementedException();
        }
    }

}
