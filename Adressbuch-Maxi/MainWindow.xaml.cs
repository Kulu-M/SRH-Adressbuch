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
using Microsoft.Win32;


namespace Adressbuch
{
    public partial class MainWindow : Window
    {

        private List<Kontakt> kontakte = new List<Kontakt>();


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
            lBx_kontakte.SelectedIndex = kontakte.Count - 1;
        }


        private void b_del_Click(object sender, RoutedEventArgs e)
        {
            if (lBx_kontakte.SelectedItem == null)
            {
                return;
            }

            kontakte.Remove((Kontakt) lBx_kontakte.SelectedItem);
            lBx_kontakte.ItemsSource = null;
            lBx_kontakte.ItemsSource = kontakte;

        }


       


        private void b_save(object sender, RoutedEventArgs e)
        {
            maskRead(lBx_kontakte.SelectedItem as Kontakt);

            SpeichernLaden.writeBinary<List<Kontakt>>("savefile.dat", kontakte);

            lBx_kontakte.ItemsSource = null;
            lBx_kontakte.ItemsSource = kontakte;
        }


        private void lBx_kontakte_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lBx_kontakte.SelectedItems == null)
                return;

            felderFüllen(lBx_kontakte.SelectedItem as Kontakt);
        }
        
       
        private void felderFüllen(Kontakt kontakt)
        {
            try
            {
                cbx_anrede.SelectedItem = kontakt.anrede;
                tbx_nachname.Text = kontakt.nachname;
                tbx_vorname.Text = kontakt.vorname;
                dp_gebdate.SelectedDate = kontakt.gebDatum;
            }
            catch (Exception)
            {
                cbx_anrede.SelectedItem = "";
            }
            

            try
            {
                img_Bild.Source = new BitmapImage(new Uri(kontakt.bildPath, UriKind.Absolute));
            }
            catch (Exception)
            {
                var path = Environment.CurrentDirectory + @"\Pics\2.jpg";
                img_Bild.Source = new BitmapImage(new Uri(path, UriKind.Absolute));
            }
            
        }

        private void img_bild_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lBx_kontakte.SelectedItem == null)
            {
                MessageBox.Show("Bitte einen Kontakt auswählen!", "Hinweis", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "Image Dateien(.jpg)|*.jpg;*.gif;*.png";

            if (objOpenFileDialog.ShowDialog() == true)
            {
                img_Bild.Source = new BitmapImage(new Uri(
                    objOpenFileDialog.FileName));
                (lBx_kontakte.SelectedItem as Kontakt).
                    bildPath = objOpenFileDialog.FileName;
            }
        }


        //MASKE AUSLESEN UND ALS "kontakt" ZURÜCKGEBEN
        private Kontakt maskRead(Kontakt kontakt)
        {
            //Speichern
            kontakt.anrede = (Anrede)cbx_anrede.SelectedItem;
            kontakt.vorname = tbx_vorname.Text;
            kontakt.nachname = tbx_nachname.Text;
            kontakt.gebDatum = (DateTime)dp_gebdate.SelectedDate;
            return kontakt;
        }


        private void Tb_filter_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_filter.Text != "Filtern...")
            {
                var filter =
                    (from k in kontakte
                        where k.nachname.StartsWith(tb_filter.Text, StringComparison.InvariantCultureIgnoreCase)
                        select k).ToList();

                lBx_kontakte.ItemsSource = null;
                lBx_kontakte.ItemsSource = filter;
            }
        }
    }
}



























////ATM 10 LEERE KONTAKTE GENERIEREN
//private void generateKontakts(int anz)
//{
//    for (int i = 0; i < anz; i++)
//    {
//        kontakte.Add(new Kontakt());
//    }
//}




//}


////IN FILE SPEICHERN
//private void b_save(object sender, RoutedEventArgs e)
//{
//    //kontakt = maskRead(kontakt);


//}



////LADEN UND FELDER FÜLLEN
//private void b_load(object sender, RoutedEventArgs e)
//{
//    //SpeichernLaden.readBinary<Kontakt>("savefile.dat", kontakt);

//    //tb_id.Text = kontakt.iD;
//    //cbx_anrede.SelectedItem = kontakt.anrede;
//    //tbx_nachname.Text = kontakt.nachname;
//    //tbx_vorname.Text = kontakt.vorname;
//    //dp_gebdate.SelectedDate = kontakt.gebDatum;
//}

