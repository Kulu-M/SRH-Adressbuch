using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Adressbuch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            load();
        }


      
        //GLOBALE
        List<Person> listp = new List<Person>();




        public void load()
        {
            string mydocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //nn to check if folder exists, "System.IO.Directory.CreateDirectory" does that for us
            System.IO.Directory.CreateDirectory(mydocs + "/Adressbuch2");

            //same here
            File.Create(mydocs + "//Adressbuch2//Adressbuch_SaveFile.xml");
        }


            



        class Person
        { 
            public string name
            {
                get;
                set;
            }
            public string vorName
            {
                get;
                set;
            }
            public string telNr
            {
                get;
                set;
            }
        }

       

        private void b_add(object sender, RoutedEventArgs e)
        { 
            //Create new Person
            Person person = new Person();
            person.name = tb_name.Text;
            person.vorName = tb_vorname.Text;
            person.telNr = tb_nr.Text;

            if (person.name != null) {
                listp.Add(person);
                listdat.Items.Add(person.name);

                tb_name.Text = "Nachname";
                tb_vorname.Text = "Vorname";
                tb_nr.Text = "Tel.-Nr.";
            }

            else
            {
                //POPUP no name warning
            } 

        }

        private void b_delete (object sender, RoutedEventArgs e)
        {
            try
            {
                listdat.Items.Remove(listdat.SelectedItem);
                listp.RemoveAt(listdat.SelectedIndex);
            }
            catch { }
        }

        private void listdat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tb_name.Text = listp[listdat.SelectedIndex].name;
            tb_vorname.Text = listp[listdat.SelectedIndex].vorName;
            tb_nr.Text = listp[listdat.SelectedIndex].telNr;
        }

        private void b_savechanges (object sender, RoutedEventArgs e)
        {



            //Save if changes are made



        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XmlDocument xml = new XmlDocument();
            string mydocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            xml.Load(mydocs + "//Adressbuch2//Adressbuch_SaveFile.xml");


            //Delete complete content of file
            File.WriteAllText(mydocs, String.Empty);


            //PASTE everything from listp to xml file

        }


        

        
    }
}
