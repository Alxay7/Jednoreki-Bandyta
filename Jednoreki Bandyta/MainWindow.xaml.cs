using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Jednoreki_Bandyta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int dlugosc_animacji = 20;
        int mnoznik = 1;
        int wallet = 1000;
        int canSpin = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        public async void Spin(object sender, RoutedEventArgs e)
        {
            if (canSpin == 0 || multiplayer.Text == "" || (!int.TryParse(multiplayer.Text, out _)))
            {
                return;
            }
            mnoznik = int.Parse(multiplayer.Text);
            canSpin = 0;
            dlugosc_animacji = (int)animationDuration.Value;
            wallet -= 5 * mnoznik;
            balance.Content = $"${wallet}";

            Random random = new Random();
            int slot1_value = 1;
            int slot2_value = 1;
            int slot3_value = 1;
            for (int i = 0; i < dlugosc_animacji; i++)
            {
                slot1_value = random.Next(1, 6);
                slot2_value = random.Next(1, 6);
                slot3_value = random.Next(1, 6);
                slot1.Source = new BitmapImage(new Uri($"pack://application:,,,/Resources/slots/{slot1_value}.png"));
                slot2.Source = new BitmapImage(new Uri($"pack://application:,,,/Resources/slots/{slot2_value}.png"));
                slot3.Source = new BitmapImage(new Uri($"pack://application:,,,/Resources/slots/{slot3_value}.png"));
                await Task.Delay(100);

            }
            // Zmienna pomocnicza do zliczania wiśni (ułatwia sprawdzanie "ANY TWO" i "ANY ONE")
            int cherryCount = 0;
            if (slot1_value == 1) cherryCount++;
            if (slot2_value == 1) cherryCount++;
            if (slot3_value == 1) cherryCount++;

            // Zmienne pomocnicze sprawdzające, czy dany slot to jakikolwiek BAR (wartość 5 lub 6)
            bool isBar1 = (slot1_value == 5 || slot1_value == 6);
            bool isBar2 = (slot2_value == 5 || slot2_value == 6);
            bool isBar3 = (slot3_value == 5 || slot3_value == 6);

            //WYGRANA: 10000
                if (slot1_value == 3 && slot2_value == 3 && slot3_value == 3) // 3x seven
                {
                    wallet += 10000 * mnoznik;
                    balance.Content = $"${wallet}";
            }

            // WYGRANA: 300
            if ((slot1_value == 1 && slot2_value == 1 && slot3_value == 1) || // 3x Wiśnia
                (slot1_value == 4 && slot2_value == 4 && slot3_value == 4))   // 3x Dzwonek
            {
                wallet += 300 * mnoznik;
                balance.Content = $"${wallet}";
            }

            // WYGRANA: 60
            else if ((slot1_value == 1 && slot2_value == 4 && slot3_value == 4) || // Wiśnia, Dzwonek, Dzwonek
                     (slot1_value == 6 && slot2_value == 6 && slot3_value == 6))   // 3x Multi BAR (zakładam, że nr 6 to duży BAR z tabeli)
            {
                wallet += 60 * mnoznik;
                balance.Content = $"${wallet}";
            }

            // WYGRANA: 30
            else if ((slot1_value == 1 && slot2_value == 1 && slot3_value == 4) || // Wiśnia, Wiśnia, Dzwonek
                     (slot1_value == 5 && slot2_value == 5 && slot3_value == 5))   // 3x Single BAR
            {
                wallet += 30 * mnoznik;
                balance.Content = $"${wallet}";
            }

            // WYGRANA: 20
            else if ((slot1_value == 2 && slot2_value == 2 && slot3_value == 2) || // 3x Winogrona
                     (slot1_value == 1 && slot2_value == 4))                       // Wiśnia, Dzwonek, ? (Trzeci slot może być dowolny)
            {
                wallet += 20 * mnoznik;
                balance.Content = $"${wallet}";
            }

            // WYGRANA: 15
            else if (cherryCount == 2 ||              // DOWOLNE 2 Wiśnie
                     (isBar1 && isBar2 && isBar3))    // DOWOLNE 3 symbole BAR (wymieszane 5 i 6)
            {
                wallet += 15 * mnoznik;
                balance.Content = $"${wallet}";
            }

            // WYGRANA: 6
            else if (cherryCount == 1) // DOWOLNA 1 Wiśnia
            {
                wallet += 6 * mnoznik;
                balance.Content = $"${wallet}";
            }
            canSpin = 1;

        } 
    }
}