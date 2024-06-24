using System;
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
        IpCalculator ipCalculator = new();
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
            (int? decimalNumber, string? binaryNumber, string? Hexanumber) = numberSystemConv.OctalToDecimal(Oktal);
            TB_Decimal.Text = decimalNumber.ToString();
            TB_Binary.Text = binaryNumber;
            TB_Hexa.Text = Hexanumber;
        }

        private void TB_Binary_TextChanged(object sender, TextChangedEventArgs e)
        {
            string Binary = TB_Binary.Text;
            (int? decimalNumber, string? octalNumber, string? Hexanumber) = numberSystemConv.BinaryToDecimal(Binary);
            TB_Hexa.Text = Hexanumber;
            TB_Oktal.Text = octalNumber;
            TB_Decimal.Text = decimalNumber.ToString();
        }

        private void TB_Hexa_TextChanged(object sender, TextChangedEventArgs e)
        { 
            string hexaST = TB_Hexa.Text;
            (int? decimalNumber, string? binaryNumber, string? octalNumber) = numberSystemConv.HexadecimalToDecimal(hexaST);
            TB_Decimal.Text = decimalNumber.ToString();
            TB_Binary.Text = binaryNumber;
            TB_Oktal.Text = octalNumber;
        }

        private void TB_IP_TextChanged(object sender, TextChangedEventArgs e)
        {
            int dataint;
            string IP1 = TB_IP_1.Text;
            if (int.TryParse(IP1, out dataint))
            {
                TB_IPBinary_1.Text = ipCalculator.ConvertToBinary(dataint);
            }
            string IP2 = TB_IP_2.Text;
            if (int.TryParse(IP2, out dataint))
            {
                TB_IPBinary_2.Text = ipCalculator.ConvertToBinary(dataint);
            }
            string IP3 = TB_IP_3.Text;
            if (int.TryParse(IP3, out dataint))
            {
                TB_IPBinary_3.Text = ipCalculator.ConvertToBinary(dataint);
            }
            string IP4 = TB_IP_4.Text;
            if (int.TryParse(IP4, out dataint))
            {
                TB_IPBinary_4.Text = ipCalculator.ConvertToBinary(dataint);
            }
        }
        private void TB_ConvertToDecimal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Dictionary<TextBox, TextBox> textBoxes = new()
                {
                    { TB_IP_1, TB_IPBinary_1 },
                    { TB_IP_2, TB_IPBinary_2 },
                    { TB_IP_3, TB_IPBinary_3 },
                    { TB_IP_4, TB_IPBinary_4 },
                    { TB_SUBNET_1, TB_SubnetBinary_1 },
                    { TB_SUBNET_2, TB_SubnetBinary_2 },
                    { TB_SUBNET_3, TB_SubnetBinary_3 },
                    { TB_SUBNET_4, TB_SubnetBinary_4 },
                    { TB_WILDCARD_1, TB_WildcardBinary_1 },
                    { TB_WILDCARD_2, TB_WildcardBinary_2 },
                    { TB_WILDCARD_3, TB_WildcardBinary_3 },
                    { TB_WILDCARD_4, TB_WildcardBinary_4 }
                };

                foreach (var textBox in textBoxes)
                {
                    textBox.Key.Text = ipCalculator.BinaryToDecimal(textBox.Value.Text);
                }
            }
        }

        private void BTN_Standard_Sub_Click(object sender, RoutedEventArgs e)
        {
            string subnetMask = ipCalculator.GetDefaultSubnetMask(TB_IP_1.Text);
            string[] subnetOctets = subnetMask.Split('.');

            TB_SUBNET_1.Text = subnetOctets[0];
            TB_SUBNET_2.Text = subnetOctets[1];
            TB_SUBNET_3.Text = subnetOctets[2];
            TB_SUBNET_4.Text = subnetOctets[3];

            string wildcardMask = ipCalculator.CalculateWildcardMask(subnetMask);
            string[] wildcardOctets = wildcardMask.Split('.');
            
            TB_WILDCARD_1.Text = wildcardOctets[0];
            TB_WILDCARD_2.Text = wildcardOctets[1];
            TB_WILDCARD_3.Text = wildcardOctets[2];
            TB_WILDCARD_4.Text = wildcardOctets[3];
        }

        private void BTN_Check_Sub_Ip_Click(object sender, RoutedEventArgs e)
        {
            string Ip = TB_IP_1.Text +"."+ TB_IP_2.Text +"."+ TB_IP_3.Text +"."+ TB_IP_4.Text;
            string subnet = TB_SUBNET_1.Text + "." + TB_SUBNET_2.Text + "." + TB_SUBNET_3.Text + "." + TB_SUBNET_4.Text;
            bool Iptruefalse = ipCalculator.ActualIp(Ip, subnet);
            if (Iptruefalse == true)
            {
                TB_IP_Resault.Text = "This is a usable Ip and subnet";
            }
            else
            {
                TB_IP_Resault.Text = "This is not a usable Ip or subnet";
            }
        }
    }
}