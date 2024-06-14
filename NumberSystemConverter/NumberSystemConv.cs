using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSystemConverter
{
    public class NumberSystemConv
    {
        public string? DecimalToBinary(int decimalNumber)
        {
            if (decimalNumber > 0)
            {
                return Convert.ToString(decimalNumber, 2);
            }
            return null;
        }

        public string? DecimalToOctal(int decimalNumber)
        {
            if (decimalNumber > 0)
            {
                return Convert.ToString(decimalNumber, 8);
            }
            return null;
        }

        public string? DecimalToHexadecimal(int decimalNumber)
        {
            if(decimalNumber > 0) 
            {
                return Convert.ToString(decimalNumber, 16);
            }
            return null;
        }

        public (int?, string?, string?) BinaryToDecimal(string binaryNumber)
        {
            if(binaryNumber != null && binaryNumber != "")
            {
                int decimalNumber = Convert.ToInt32(binaryNumber, 2);
                return(decimalNumber, DecimalToOctal(decimalNumber),DecimalToHexadecimal(decimalNumber));
            }
            return (null, null, null);
        }

        public (int?, string?, string?) OctalToDecimal(string octalNumber)
        {
            if(octalNumber != null && octalNumber != "")
            {
                int decimalNumber = Convert.ToInt32(octalNumber, 8);
                return(decimalNumber, DecimalToBinary(decimalNumber),DecimalToHexadecimal(decimalNumber));
            }
            return (null, null, null);
        }

        public (int?, string?, string?) HexadecimalToDecimal(string hexadecimalNumber)
        {
            if (hexadecimalNumber != null && hexadecimalNumber != "")
            {
                int decimalNumber = Convert.ToInt32(hexadecimalNumber, 16);
                return (decimalNumber, DecimalToBinary(decimalNumber), DecimalToOctal(decimalNumber));
            }
            return(null,null,null);
        }
    }
}
