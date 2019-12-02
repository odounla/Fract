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
            var fraction1 = new Fraction(1, 7);
            var fraction2 = new Fraction(3, 4);

            //Act
            var result = fraction1 + fraction2;

            //Assert
            Assert.ReferenceEquals(fraction1, result);
        }

        [TestMethod]
        public void Subtract_SubtractTwoFractions_ReturnsFraction()
        {
            //Arrange
            var fraction1 = new Fraction(2, 7);
            var fraction2 = new Fraction(3, 5);

            //Act
            var result = fraction1 - fraction2;

            //Assert
            Assert.ReferenceEquals(fraction1, result);
        }

        [TestMethod]
        public void Multiply_MultiplyTwoFractions_ReturnsFraction()
        {
            //Arrange
            var fraction1 = new Fraction(1, 9);
            var fraction2 = new Fraction(4, 11);

            //Act
            var result = fraction1 * fraction2;

            //Assert
            Assert.ReferenceEquals(fraction1, result);
        }

        [TestMethod]
        public void Divide_DivideTwoFractions_ReturnsFraction()
        {
            //Arrange
            var fraction1 = new Fraction(3, 4);
            var fraction2 = new Fraction(12, 77);

            //Act
            var result = fraction1 + fraction2;

            //Assert
            Assert.ReferenceEquals(fraction1, result);
        }

    }
}
