using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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
            catch (Exception)
            {
                if(fs!=null)
                    fs.Close();
            }
        }

        internal static T readBinary<T>(string datei, T zuLaden)
        {

            T output;
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                FileStream fs = new FileStream(datei, FileMode.OpenOrCreate);
                output = (T)bf.Deserialize(fs);
                fs.Close();
            }
            catch (Exception)
            {
                    
                output = default(T);
            }
            return output;
        }        
    }
}
