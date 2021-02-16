using System;
using System.Globalization;

namespace SolidCalculator.Commons
{
    public class Utilities
    {
        /// <summary>
        /// Parses string input to an operation listed in OperatorEnum
        /// </summary>
        /// <param name="val"></param>
        /// <returns>OperatorEnum</returns>
        public static OperatorEnum TryParseToOperator(string val)
        {
            return val switch
            {
                "x" => OperatorEnum.Multiply,
                "/" => OperatorEnum.Divide,
                "+" => OperatorEnum.Add,
                "-" => OperatorEnum.Subtract,
                _ => throw new ArgumentException("cannot parse  value to an operator")
            };
        }

        /// <summary>
        /// Parses input of type double to string
        /// </summary>
        /// <param name="val"></param>
        /// <returns>string</returns>
        public static string ParseToString(double val)
        {
            return val.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Parses string to double
        /// </summary>
        /// <param name="val"></param>
        /// <returns>double</returns>
        public static double ParseToDouble(string val)
        {
            if (double.TryParse(val, out double result))
            {
                return result;
            }
            throw new FormatException("cannot parse value to double");
        }
    }
}