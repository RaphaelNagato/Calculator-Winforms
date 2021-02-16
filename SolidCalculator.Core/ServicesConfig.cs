namespace SolidCalculator.Core
{
    /// <summary>
    /// Global config for dependency injections
    /// </summary>
    public class ServicesConfig
    {
        public static IArithmeticOperationsRepo OperationsRepo;

        public static void Initialize()
        {
            OperationsRepo = new ArithmeticOperationsRepo();
        }
    }
}