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
            updateTokens();
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
            int slot1_2value = 1;
            int slot2_2value = 1;
            int slot3_2value = 1;
            int slot1_3value = 1;
            int slot2_3value = 1;
            int slot3_3value = 1;

            for (int i = 0; i < dlugosc_animacji; i++)
            {
                slot3_value = slot2_value;
                slot2_value = slot1_value;

                slot3_2value = slot2_2value;
                slot2_2value = slot1_2value;

                slot3_3value = slot2_3value;
                slot2_3value = slot1_3value;

                slot1_value = random.Next(1, 6);
                slot1_2value = random.Next(1, 6);
                slot1_3value = random.Next(1, 6);
                slot1.Source = new BitmapImage(new Uri($"pack://application:,,,/Resources/slots/{slot1_value}.png"));
                slot2.Source = new BitmapImage(new Uri($"pack://application:,,,/Resources/slots/{slot2_value}.png"));
                slot3.Source = new BitmapImage(new Uri($"pack://application:,,,/Resources/slots/{slot3_value}.png"));
                slot1_2.Source = new BitmapImage(new Uri($"pack://application:,,,/Resources/slots/{slot1_2value}.png"));
                slot2_2.Source = new BitmapImage(new Uri($"pack://application:,,,/Resources/slots/{slot2_2value}.png"));
                slot3_2.Source = new BitmapImage(new Uri($"pack://application:,,,/Resources/slots/{slot3_2value}.png"));
                slot1_3.Source = new BitmapImage(new Uri($"pack://application:,,,/Resources/slots/{slot1_3value}.png"));
                slot2_3.Source = new BitmapImage(new Uri($"pack://application:,,,/Resources/slots/{slot2_3value}.png"));
                slot3_3.Source = new BitmapImage(new Uri($"pack://application:,,,/Resources/slots/{slot3_3value}.png"));
                await Task.Delay((int)animationSpeed.Value);

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
            updateTokens();

        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            animationSpeed.Value = 100;
            animationDuration.Value = 20;
        }

        public void updateTokens()
        {
            int balans = (int)wallet;
            zetony.Children.Clear();
            int lastestChipPos = -17;
            int chipCount = 0;
            int rightMargin = 0;


            int chip3 = balans / 10000;
            balans -= chip3 * 10000;

            for (int i = 0; i < chip3; i++)
            {
                Image tokenImage = new Image();
                tokenImage.Source = new BitmapImage(new Uri($"pack://application:,,,/Resources/chips/chipStack3.png"));
                Canvas.SetRight(tokenImage, rightMargin); // Przesunięcie każdego tokena o 30 pikseli
                Canvas.SetBottom(tokenImage, lastestChipPos + 17); // Ustawienie wysokości tokena
                zetony.Children.Add(tokenImage);
                lastestChipPos += 17;
                chipCount++;
                if (chipCount >= 23)
                {
                    chipCount = 0;
                    rightMargin += 70;
                    lastestChipPos = -17;
                }
            }

            int chip2 = balans / 1000;
            balans -= chip2 * 1000;

            for (int i = 0; i < chip2; i++)
            {
                Image tokenImage = new Image();
                tokenImage.Source = new BitmapImage(new Uri($"pack://application:,,,/Resources/chips/chipStack2.png"));
                Canvas.SetRight(tokenImage, rightMargin); // Przesunięcie każdego tokena o 30 pikseli
                Canvas.SetBottom(tokenImage, lastestChipPos + 17); // Ustawienie wysokości tokena
                zetony.Children.Add(tokenImage);
                lastestChipPos += 17;
                chipCount++;
                if (chipCount >= 23)
                {
                    chipCount = 0;
                    rightMargin += 70;
                    lastestChipPos = -17;
                }
            }

            int chip1 = balans / 100;
            balans -= chip1 * 100;

            for (int i = 0; i < chip1; i++)
            {
                Image tokenImage = new Image();
                tokenImage.Source = new BitmapImage(new Uri($"pack://application:,,,/Resources/chips/chipStack1.png"));
                Canvas.SetRight(tokenImage, rightMargin); // Przesunięcie każdego tokena o 30 pikseli
                Canvas.SetBottom(tokenImage, lastestChipPos + 17); // Ustawienie wysokości tokena
                zetony.Children.Add(tokenImage);
                lastestChipPos += 17;
                chipCount++;
                if (chipCount >= 23)
                {
                    chipCount = 0;
                    rightMargin += 70;
                    lastestChipPos = -17;
                }
            }

            int chip0 = balans / 10;
            balans -= chip0 * 10;

            for (int i = 0; i < chip0; i++)
            {
                Image tokenImage = new Image();
                tokenImage.Source = new BitmapImage(new Uri($"pack://application:,,,/Resources/chips/chipStack0.png"));
                Canvas.SetRight(tokenImage, rightMargin); // Przesunięcie każdego tokena o 30 pikseli
                Canvas.SetBottom(tokenImage, lastestChipPos + 17); // Ustawienie wysokości tokena
                zetony.Children.Add(tokenImage);
                lastestChipPos += 17;
                chipCount++;
                if (chipCount >= 23)
                {
                    chipCount = 0;
                    rightMargin += 70;
                    lastestChipPos = -17;
                }
            }
        }

    }
}