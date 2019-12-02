using System;
using Fract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFraction.UnitTests
{
    [TestClass]
    public class FractionTests
    {
        [TestMethod]
        public void Add_AddTwoFractions_ReturnsFraction()
        {
            
            //Arrange
            string input = "1/2 + 1/2";
            string expectedResult = "1";
            //Act
            string operationResult = Operation.Compute(input).ToString();

            //Assert
            Assert.AreEqual(operationResult, expectedResult);
        }

        [TestMethod]
        public void Subtract_SubtractTwoFractions_ReturnsFraction()
        {
            //Arrange
            string input = "1/3 - 1/2";
            string expectedResult = "-1/6";

            //Act
            string operationResult = Operation.Compute(input).ToString();

            //Assert
            Assert.AreEqual(operationResult, expectedResult);
        }

        [TestMethod]
        public void Multiply_MultiplyTwoFractions_ReturnsFraction()
        {
            //Arrange
            string input = "1/4 * 2/11";
            string expectedResult = "1/22";

            //Act
            string operationResult = Operation.Compute(input).ToString();

            //Assert
            Assert.AreEqual(operationResult, expectedResult);
        }

        [TestMethod]
        public void Divide_DivideTwoFractions_ReturnsFraction()
        {
            //Arrange
            string input = "1/4 / 3/15";
            string expectedResult = "1_1/4";

            //Act
            string operationResult = Operation.Compute(input).ToString();

            //Assert
            Assert.AreEqual(operationResult, expectedResult);
        }

    }
}
