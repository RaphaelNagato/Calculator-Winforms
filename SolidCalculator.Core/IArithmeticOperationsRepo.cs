using SolidCalculator.Commons;

namespace SolidCalculator.Core
{
    public interface IArithmeticOperationsRepo
    {
        /// <summary>
        /// Implements Addition operation between the two inputs
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns>double</returns>
        double Add(double firstNumber, double secondNumber);

        /// <summary>
        /// Implements Subtract or minus operation between the two inputs
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns>double</returns>
        double Subtract(double firstNumber, double secondNumber);

        /// <summary>
        /// Implements Multiply operation between two inputs
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns>double</returns>
        double Multiply(double firstNumber, double secondNumber);

        /// <summary>
        /// Implements Division operation between two inputs, the second input is the divisor
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns>double</returns>
        double Divide(double firstNumber, double secondNumber);

        /// <summary>
        /// maps the OperatorEnum to the methods performing the operation
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="sign"></param>
        /// <param name="secondNumber"></param>
        /// <returns>double</returns>
        double Calc(double firstNumber, OperatorEnum sign, double secondNumber);
    }
}