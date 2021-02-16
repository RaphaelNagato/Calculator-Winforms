using SolidCalculator.Core;

namespace SolidCalculator.CoreTests
{
    /// <summary>
    /// A class to be used in Xunit IClassFixture interface for sharing context between tests
    /// </summary>
    public class InitializeRepoFixture
    {
        public IArithmeticOperationsRepo ArithmeticOperations { get; }

        public InitializeRepoFixture()
        {
            ServicesConfig.Initialize();
            ArithmeticOperations = ServicesConfig.OperationsRepo;  // passes in an instance of the ArithmeticOperationRepo
        }
    }
}