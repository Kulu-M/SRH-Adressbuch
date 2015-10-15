using System;
using System.Collections.Generic;
using System.ComponentModel;
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


namespace Adressbuch
{
    public partial class MainWindow : Window
    {

        List<Kontakt> kontakte = new List<Kontakt>();
        //Kontakt kontakt;
        


        //MAIN
        public MainWindow()
        {
            InitializeComponent();
        }



        //ON STARTUP
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {

            kontakte = SpeichernLaden.readBinary<List<Kontakt>>("savefile.dat");
            if (kontakte == null)
            {
                kontakte = new List<Kontakt>();
            }
            


            lBx_kontakte.ItemsSource = kontakte;

            cbx_anrede.ItemsSource = Enum.GetValues(typeof (Anrede));

            //felderFüllen(kontakt);
            //generateKontakts(10);
        }


        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            SpeichernLaden.writeBinary<List<Kontakt>>("savefile.dat", kontakte);
        }

        private void b_add_Click(object sender, RoutedEventArgs e)
        {
            var kon = new Kontakt();
            kontakte.Add(kon);
            lBx_kontakte.ItemsSource = null;
            lBx_kontakte.ItemsSource = kontakte;
        }


        private void b_del_Click(object sender, RoutedEventArgs e)
        {
            if (lBx_kontakte.SelectedItem == null)
            {
                return;
            }

            kontakte.Remove((Kontakt)lBx_kontakte.SelectedItem);
            lBx_kontakte.ItemsSource = null;
            lBx_kontakte.ItemsSource = kontakte;

        }

























        //ATM 10 LEERE KONTAKTE GENERIEREN
        private void generateKontakts(int anz)
        {
            for (int i = 0; i < anz; i++)
            {
                kontakte.Add(new Kontakt());
            }
        }


        //
        private void felderFüllen(Kontakt kontakt)
        {
            tb_id.Text = kontakt.iD;
            cbx_anrede.SelectedItem = kontakt.anrede;
            tbx_nachname.Text = kontakt.nachname;
            tbx_vorname.Text = kontakt.vorname;
            dp_gebdate.SelectedDate = kontakt.gebDatum;

        }


        //IN FILE SPEICHERN
        private void b_save(object sender, RoutedEventArgs e)
        {
            //kontakt = maskRead(kontakt);


        }


        //MASKE AUSLESEN UND ALS "kontakt" ZURÜCKGEBEN
        private Kontakt maskRead(Kontakt kontakt)
        {
            //Speichern
            kontakt.iD = tb_id.Text;
            kontakt.anrede = (Anrede)cbx_anrede.SelectedItem;
            kontakt.vorname = tbx_vorname.Text;
            kontakt.nachname = tbx_nachname.Text;
            kontakt.gebDatum = (DateTime)dp_gebdate.SelectedDate;
            return kontakt;
        }


        //LADEN UND FELDER FÜLLEN
        private void b_load(object sender, RoutedEventArgs e)
        {
            //SpeichernLaden.readBinary<Kontakt>("savefile.dat", kontakt);

            //tb_id.Text = kontakt.iD;
            //cbx_anrede.SelectedItem = kontakt.anrede;
            //tbx_nachname.Text = kontakt.nachname;
            //tbx_vorname.Text = kontakt.vorname;
            //dp_gebdate.SelectedDate = kontakt.gebDatum;
        }

        
    }
}
