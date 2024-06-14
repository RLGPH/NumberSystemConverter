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

namespace NumberSystemConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        NumberSystemConv numberSystemConv = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TB_Decimal_TextChanged(object sender, TextChangedEventArgs e)
        {
            string DecimalST = TB_Decimal.Text;
            int Decimal;
            if(int .TryParse(DecimalST, out Decimal))
            {
                
                TB_Oktal.Text = numberSystemConv.DecimalToOctal(Decimal);
                TB_Hexa.Text = numberSystemConv.DecimalToHexadecimal(Decimal);
                TB_Binary.Text = numberSystemConv.DecimalToBinary(Decimal);
            }
            else
            {
                TB_Oktal.Text = null; 
                TB_Hexa.Text = null;
                TB_Binary.Text = null;
            }
        }

        private void TB_Oktal_TextChanged(object sender, TextChangedEventArgs e)
        {
            string Oktal = TB_Oktal.Text;
            (int? decimalNumber, string binaryNumber, string Hexanumber) = numberSystemConv.OctalToDecimal(Oktal);
            TB_Decimal.Text = decimalNumber.ToString();
            TB_Binary.Text = binaryNumber;
            TB_Hexa.Text = Hexanumber;
        }

        private void TB_Binary_TextChanged(object sender, TextChangedEventArgs e)
        {
            string Binary = TB_Binary.Text;

        }

        private void TB_Hexa_TextChanged(object sender, TextChangedEventArgs e)
        { 
            string hexaST = TB_Hexa.Text;
            (int? decimalNumber, string binaryNumber, string octalNumber) = numberSystemConv.HexadecimalToDecimal(hexaST);
            TB_Decimal.Text = decimalNumber.ToString();
            TB_Binary.Text = binaryNumber;
            TB_Oktal.Text = octalNumber;
        }
    }
}