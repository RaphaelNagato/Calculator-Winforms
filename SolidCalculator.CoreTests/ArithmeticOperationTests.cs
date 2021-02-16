using System;
using SolidCalculator.Commons;
using Xunit;

namespace SolidCalculator.CoreTests
{
    public class ArithmeticOperationTests : IClassFixture<InitializeRepoFixture>
    {
        private readonly InitializeRepoFixture _repoFixture;

        // inject InitializeRepoFixture into the test class
        public ArithmeticOperationTests(InitializeRepoFixture repoFixture)
        {
            _repoFixture = repoFixture;
        }

        #region AddTests

        [Theory]
        [Trait("Category", "AddTests")]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        [InlineData(10, 5, 15)]
        public void AddValidTest(double fNum, double sNum, double result)
        {
            //Arrange
            double expected = result;

            // Act
            var actual = _repoFixture.ArithmeticOperations.Add(fNum, sNum);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [Trait("Category", "AddTests")]
        [InlineData(1, null, 1)]
        [InlineData(null, 2, 2)]
        public void AddInvalidTest(double fNum, double sNum, double result)
        {
            //Arrange
            double expected = result;

            // Act
            var actual = _repoFixture.ArithmeticOperations.Add(fNum, sNum);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [Trait("Category", "AddTests")]
        [InlineData(1.011, 2.011, 3.022)]
        [InlineData(5555.55, 1000000.09, 1005555.64)]
        public void AddEdgeCasesTest(double fNum, double sNum, double result)
        {
            //Arrange
            double expected = result;

            // Act
            var actual = _repoFixture.ArithmeticOperations.Add(fNum, sNum);

            //Assert
            Assert.Equal(expected, actual, 3);
        }

        #endregion AddTests

        #region SubtractTests

        [Theory]
        [Trait("Category", "SubtractTests")]
        [InlineData(1, 1, 0)]
        [InlineData(2, 3, -1)]
        [InlineData(45, 23, 22)]
        public void SubtractValidValuesTest(double fNum, double sNum, double result)
        {
            //Arrange
            double expected = result;

            //Act
            var actual = _repoFixture.ArithmeticOperations.Subtract(fNum, sNum);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [Trait("Category", "SubtractTests")]
        [InlineData(1, null, 1)]
        [InlineData(null, 3, -3)]
        public void SubtractInvalidValuesTest(double fNum, double sNum, double result)
        {
            //Arrange
            double expected = result;

            //Act
            var actual = _repoFixture.ArithmeticOperations.Subtract(fNum, sNum);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [Trait("Category", "SubtractTests")]
        [InlineData(1.000, 1, 0)]
        [InlineData(2.54, 3.23, -0.69)]
        [InlineData(45.56, 23.89, 21.67)]
        public void SubtractEdgeCasesValuesTest(double fNum, double sNum, double result)
        {
            //Arrange
            double expected = result;

            //Act
            var actual = _repoFixture.ArithmeticOperations.Subtract(fNum, sNum);

            //Assert
            Assert.Equal(expected, actual, 2);
        }

        #endregion SubtractTests

        #region MultiplyTests

        [Fact]
        [Trait("Category", "MultiplyTests")]
        public void MultiplyValidValues()
        {
            //Arrange
            double x = 9;
            double y = 13;

            var expected = 117;

            //Act

            var actual = _repoFixture.ArithmeticOperations.Multiply(x, y);

            //Assert

            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", "MultiplyTests")]
        public void MultiplyEdgeCasesTest()
        {
            //Arrange
            double x = 9;
            double y = double.PositiveInfinity;

            var expected = double.PositiveInfinity;

            //Act

            var actual = _repoFixture.ArithmeticOperations.Multiply(x, y);

            //Assert

            Assert.Equal(expected, actual);
        }

        #endregion MultiplyTests

        #region DivisionTests

        [Theory]
        [Trait("Category", "DivisionTests")]
        [InlineData(5, 4, 1.25)]
        [InlineData(3.25, 56.7, 0.0573)]
        public void DivideValidValuesTest(double fNum, double sNum, double result)
        {
            //Arrange
            var expected = result;
            //Act
            var actual = _repoFixture.ArithmeticOperations.Divide(fNum, sNum);
            //Assert
            Assert.Equal(expected, actual, 3);
        }

        [Theory]
        [Trait("Category", "DivisionTests")]
        [InlineData(null, null)]
        [InlineData(3.25, 0)]
        [InlineData(4.675, -0)]
        public void DivideInvalidValuesTest(double fNum, double sNum)
        {
            //Assert
            Assert.Throws<ArgumentException>(() => _repoFixture.ArithmeticOperations.Divide(fNum, sNum));
        }

        [Fact]
        [Trait("Category", "DivisionTests")]
        public void DivideEdgeCasesTest()
        {
            //Arrange
            var x = 0;
            var y = double.NegativeInfinity;
            var expected = 0;
            //Act
            var actual = _repoFixture.ArithmeticOperations.Divide(x, y);

            //Assert
            Assert.Equal(expected, actual);
        }

        #endregion DivisionTests

        #region CalculateTests

        [Theory]
        [Trait("Category", "CalculateTests")]
        [InlineData(1, OperatorEnum.Add, 3, 4)]
        [InlineData(5, OperatorEnum.Subtract, 3, 2)]
        [InlineData(10, OperatorEnum.Multiply, 3, 30)]
        [InlineData(90, OperatorEnum.Divide, 3, 30)]
        public void CalculateValidValuesTest(double fNum, OperatorEnum operation, double sNum, double result)
        {
            //Arrange
            var expected = result;

            //Act
            var actual = _repoFixture.ArithmeticOperations.Calc(fNum, operation, sNum);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", "CalculateTests")]
        public void CalculateDivideInvalidValuesTest()
        {
            //Arrange
            var x = 50;
            var y = 0;
            var operation = OperatorEnum.Divide;

            //Assert
            Assert.Throws<ArgumentException>(() => _repoFixture.ArithmeticOperations.Calc(x, operation, y));
        }

        #endregion CalculateTests
    }
}