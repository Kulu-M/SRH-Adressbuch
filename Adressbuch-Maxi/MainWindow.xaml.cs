using System;
using System.Collections.Generic;
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

namespace Adressbuch_Maxi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Kontakt kontakt = new Kontakt { anrede = Anrede.Herr, vorname = "Hans", nachname = "Mueller", gebDatum = DateTime.Today};

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            cbx_anrede.ItemsSource = Enum.GetValues(typeof (Anrede));

            felderFüllen(kontakt);


      
        }


        private void felderFüllen(Kontakt kontakt)
        {
            cbx_anrede.SelectedItem = kontakt.anrede;
            tbx_nachname.Text = kontakt.nachname;
            tbx_vorname.Text = kontakt.vorname;
            dp_gebdate.SelectedDate = kontakt.gebDatum;
        }


        private void b_save (object sender, RoutedEventArgs e)
        {  
            //Speichern
            kontakt.anrede = (Anrede) cbx_anrede.SelectedItem;
            kontakt.vorname = tbx_vorname.Text;
            kontakt.nachname = tbx_nachname.Text;
            kontakt.gebDatum = (DateTime) dp_gebdate.SelectedDate;


            SpeichernLaden.writeBinary<Kontakt>("savefile.dat", kontakt);
            //SpeichernLaden.schreibeBin<Kontakt>("savefile.dat", kontakt);

            //Felder leeren:
            //felderFüllen(new Kontakt());
        }
    }
}
