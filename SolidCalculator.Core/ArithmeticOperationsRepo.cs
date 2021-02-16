using System;
using SolidCalculator.Commons;

namespace SolidCalculator.Core
{
    public class ArithmeticOperationsRepo : IArithmeticOperationsRepo
    {
        /// <summary>
        /// Performs addition operation between first and second number
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns>double : result</returns>
        public double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        /// <summary>
        /// Performs subtraction operation between inputs
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns>double : result</returns>
        public double Subtract(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }

        /// <summary>
        /// Performs multiplication operation between inputs
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns>double: result</returns>
        public double Multiply(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }

        /// <summary>
        /// Performs the division operation between inputs
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns>double: result</returns>
        /// <exception cref="ArgumentException">throws exception if divisor (second input) is zero </exception>
        public double Divide(double firstNumber, double secondNumber)
        {
            if (secondNumber == 0)
            {
                throw new ArgumentException("Error");
            }

            return firstNumber / secondNumber;
        }

        /// <summary>
        /// maps the operation enum to the operation methods
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="sign"></param>
        /// <param name="secondNumber"></param>
        /// <returns>returns result from the specified operation method</returns>
        /// <exception cref="NotImplementedException">throws exception for operation enum that cannot be mapped</exception>
        public double Calc(double firstNumber, OperatorEnum sign, double secondNumber)
        {
            return sign switch
            {
                OperatorEnum.Multiply => Multiply(firstNumber, secondNumber),
                OperatorEnum.Divide => Divide(firstNumber, secondNumber),
                OperatorEnum.Subtract => Subtract(firstNumber, secondNumber),
                OperatorEnum.Add => Add(firstNumber, secondNumber),
                _ => throw new NotImplementedException("There is no implementation for this operator")
            };
        }
    }
}