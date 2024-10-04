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

namespace Cursusgeld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool LEAP;
        string YEAR;
        bool NUMERIEK;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void numeriekButton_Click(object sender, RoutedEventArgs e)
        {
       
        foreach (Char ch in yearTextBox.Text)
        {
            if (Char.IsDigit(ch))
            {
                YEAR += $"{ch}";
                NUMERIEK = true; 
            }
            else
            {
                numTextBox.Text = "Geef een correct jaartal!";
                leapYearTextBox.Text = "Is geen schrikkeljaar";
                calcButton.IsEnabled = false;
                NUMERIEK = false;
                break;
            }
        }
        if (NUMERIEK) 
            { 
                calcButton.IsEnabled = true;
                numTextBox.Text = "Is numeriek";
                if ((int.Parse(yearTextBox.Text) % 4 == 0) && (int.Parse($"{yearTextBox.Text[0]}{yearTextBox.Text[1]}00") % 400 == 0))
                {
                    leapYearTextBox.Text = "Is schrikkeljaar";
                    LEAP = true;
                }
                else
                {
                    leapYearTextBox.Text = "Is geen schrikkeljaar";
                    LEAP = false;
                }
            } 
        }

        private void calcButton_Click(object sender, RoutedEventArgs e)
        {
            double cost = double.Parse(hoursTextBox.Text) * 1.5;
            if (LEAP)
            {
                cost += 1.5;
            }
            enrolTextBox.Text = Math.Round(cost,2).ToString();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}