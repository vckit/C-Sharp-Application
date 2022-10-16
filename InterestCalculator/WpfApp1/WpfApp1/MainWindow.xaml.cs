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
using System.Xml.Schema;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txbStartCapital_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789,".IndexOf(e.Text) < 0;
        }

        private void txbPrecent_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789,".IndexOf(e.Text) < 0;
        }

        private void txbCountYear_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }
        public void Price(TextBox textBox)
        {
            int l, n;
            n = textBox.Text.IndexOf(",");

            if (n > 0 && textBox.Text.Length > n + 3)
            {
                textBox.Text = textBox.Text.Substring(0, n + 3);
                l = textBox.Text.Length;
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double startCount = Convert.ToDouble(txbStartCapital.Text);
                double rate = Convert.ToDouble(txbPrecent.Text);
                int years = Convert.ToInt32(txbCountYear.Text);

                rate = rate / 100;
                int periods = 0;

                switch (cmbSelectedProcess.SelectedIndex)
                {
                    case 0:
                        double dayRate = rate / 365;
                        periods = years * 365;
                        startCount = startCount * Math.Pow((1 + dayRate), periods);
                        txbDone.Text = Convert.ToString(Math.Round(startCount, 2));
                        break;
                    case 1:
                        double monthRate = rate / 12;
                        periods = years * 12;
                        startCount = startCount * Math.Pow((1 + monthRate), periods);
                        txbDone.Text = Convert.ToString(Math.Round(startCount, 2));
                        break;
                    case 2:
                        double quarteRate = rate / 4;
                        periods = years * 4;
                        startCount = startCount * Math.Pow((1 + quarteRate), periods);
                        txbDone.Text = Convert.ToString(Math.Round(startCount, 2));
                        break;
                    case 3:
                        double halfyearRate = rate / 2;
                        periods = years * 2;
                        startCount = startCount * Math.Pow((1 + halfyearRate), periods);
                        txbDone.Text = Convert.ToString(Math.Round(startCount, 2));
                        break;
                    case 4:
                        double yearRate = rate;
                        periods = years;
                        startCount = startCount * Math.Pow((1 + yearRate), periods);
                        txbDone.Text = Convert.ToString(Math.Round(startCount, 2));
                        break;
                    default:
                        cmbSelectedProcess.Text = "Процесс не выбран";
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Введите значния!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private void txbStartCapital_TextChanged(object sender, TextChangedEventArgs e)
        {
            Price(txbStartCapital);
        }

        private void txbPrecent_TextChanged(object sender, TextChangedEventArgs e)
        {
            Price(txbPrecent);
        }
    }
}
