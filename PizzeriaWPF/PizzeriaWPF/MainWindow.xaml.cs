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
using System.Windows.Navigation;
using System.Globalization;

namespace PizzeriaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pizza pizza = new Pizza(); 
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void nowapizza_Click(object sender, RoutedEventArgs e)
        {
            GridPizza.Visibility = Visibility.Visible;
            GridDostawa.Visibility = Visibility.Hidden;
            GridSos.Visibility = Visibility.Hidden;
            GridSkladnik.Visibility = Visibility.Hidden;
            dostawa.IsEnabled = false;
            dodajskladniki.IsEnabled = false;
            opis.Text = String.Empty;
        }

        private void dodajpizze_Click(object sender, RoutedEventArgs e)
        {
           pizza.UstawNazwe(nazwapizzy.Text);
           if (pizza.CzyNazwa())
                {
                    pizza.UstawNazwe(nazwapizzy.Text);
                    nazwapizzy.Clear();
                    GridPizza.Visibility = Visibility.Hidden;
                    GridSkladnik.Visibility = Visibility.Visible;
                dodajskladniki.IsEnabled = true;             
                }
            else
            {
                MessageBox.Show("Nieprawidłowa nazwa.");
            }
            
        }

        private void dodajskladnik_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nazwaskladnika.Text.Length != 0 && iloscskladnika.Text.Length != 0 && Convert.ToDouble(cenaskladnika.Text) <= 0);
                {
                    for (int i = 0; i < Convert.ToInt16(iloscskladnika.Text); i++)
                    {
                        pizza.DodajSkladnik(nazwaskladnika.Text, Convert.ToDouble(cenaskladnika.Text));
                    }
                    nazwaskladnika.Clear();
                    iloscskladnika.Clear();
                    cenaskladnika.Clear();
                    GridSos.Visibility = Visibility.Visible;
                    GridPizza.Visibility = Visibility.Hidden;
                    GridSkladnik.Visibility = Visibility.Hidden;
                    GridDostawa.Visibility = Visibility.Hidden;
               
                }
            }
            catch
            {
                MessageBox.Show("Niepoprawne dane.");
            }
            
        }

        private void dodajsos_Click(object sender, RoutedEventArgs e)
        {        
                    pizza.DodajSos(nazwasosu.Text);
                    GridSos.Visibility = Visibility.Hidden;
                    opis.Text = pizza.ToString();
            dostawa.IsEnabled = true;

        }
        private void dostawa_Click(object sender, RoutedEventArgs e)
        {   
            if(pizza.CzyPoprawnaPizza())
            {
                GridDostawa.Visibility = Visibility.Visible;
                
              
            }
            else
            {
                MessageBox.Show("Coś jest nie tak");
            }
        }

        private void dodajskladniki_Click(object sender, RoutedEventArgs e)
        {
            GridSkladnik.Visibility = Visibility.Visible;
            
        }

        private void sprawdz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime data = DateTime.ParseExact(godzina.Text, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                                      
                if (combobox.SelectedIndex == 0)
                {
                    NaMiejscu zamowienie = new NaMiejscu();              
                    zamowienie.UstawCzasDostawy(data);
                    if(zamowienie.PoprawnyCzas())
                    {
                        MessageBox.Show("Zapisano zamówienie");
                    }              
                    else
                    {
                        MessageBox.Show("Zamówienie niemożliwe");
                    }
                }
                if (combobox.SelectedIndex == 1)
                {
                    NaWynos zamowienie = new NaWynos();
                    zamowienie.UstawCzasDostawy(data);
                    if (zamowienie.PoprawnyCzas())
                    {
                        MessageBox.Show("Zapisano zamówienie");
                    }
                    else
                    {
                        MessageBox.Show("Zamówienie niemożliwe");
                    }
                }


            }
            catch
            {
                MessageBox.Show("Niepoprawna godzina");
            }
            
        }
    }
}
