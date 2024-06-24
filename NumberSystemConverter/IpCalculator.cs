using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSystemConverter
{
    class IpCalculator
    {
        public string ConvertToBinary(int data)
        {
            // Check if data is within the byte range (0-255)
            if (data > 255)
            {
                return("exceeds 255");
            }

            string binary = Convert.ToString(data, 2).PadLeft(8, '0');
            return(binary);
        }
        public string BinaryToDecimal(string binaryNumber)
        {
            if (binaryNumber != null && binaryNumber != "")
            {
                int decimalint = Convert.ToInt32(binaryNumber, 2);
                string decimalst = decimalint.ToString();
                return (decimalst);
            }
            else 
            {
                return ("0");
            }
        }
        public string GetDefaultSubnetMask(string ipFirstAddress)
        {
            int firstOctet;
            if (int.TryParse(ipFirstAddress, out firstOctet))
            {
                if (firstOctet >= 1 && firstOctet <= 126)
                {
                    return "255.0.0.0"; // Class A
                }
                else if (firstOctet >= 128 && firstOctet <= 191)
                {
                    return "255.255.0.0"; // Class B
                }
                else if (firstOctet >= 192 && firstOctet <= 223)
                {
                    return "255.255.255.0"; // Class C
                }
                else
                {
                    return "0.0.0.0";
                }
            }
            return "255.255.255.255";
        }

        public string CalculateWildcardMask(string subnetMask)
        {
            string[] subnetOctets = subnetMask.Split('.');
            StringBuilder wildcardMask = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                int wildcardOctet = 255 - int.Parse(subnetOctets[i]);
                wildcardMask.Append(wildcardOctet.ToString());
                if (i < 3)
                {
                    wildcardMask.Append(".");
                }
            }
            return wildcardMask.ToString();
        }

        public bool ActualIp(string IP, string sub)
        {
            string[] IpOctets = IP.Split('.');

            int firstOctet;
            if (int.TryParse(IpOctets[0], out firstOctet))
            {
                if (firstOctet >= 1 && firstOctet <= 126)
                {
                    if(sub == "255.0.0.0")
                    {
                        return true; // Class A
                    }
                }
                else if (firstOctet >= 128 && firstOctet <= 191)
                {
                    if(sub == "255.255.0.0")
                    {
                        return true; // Class B
                    }
                }
                else if (firstOctet >= 192 && firstOctet <= 223)
                {
                    if(sub == "255.255.255.0")
                    {
                        return true; // Class C
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
