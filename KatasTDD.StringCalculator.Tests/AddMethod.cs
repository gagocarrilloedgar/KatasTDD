using Microsoft.VisualStudio.TestTools.UnitTesting;
using KatasTDD.StringCalculator.Library.Interface;
using KatasTDD.StringCalculator.Library;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class AddMethod
    {
        [TestMethod]
        public void AddMethod_ReturnsTheSummOfTwoNumbers()
        {
            //Arranges
            IStringCalculator stringCalculator = new StringCalculator();

            //Act
            var resultado = stringCalculator.Add("1,2");

            //Assert
            Assert.AreEqual(3, resultado);
        }

        [TestMethod]
        public void AddMethod_Returns0WhenTheInputIsEmpty()
        {
            //Arrange
            IStringCalculator stringCalculator = new StringCalculator();

            //Act
            var resultado = stringCalculator.Add("");

            //Assert
            Assert.AreEqual(0, resultado);

        }

        [TestMethod]
        public void AddMethod_returnsOneNumberWheThereIsJustOneInput()
        {
            //Arrange
            IStringCalculator stringCalculator = new StringCalculator();

            //Act
            var resultado = stringCalculator.Add("3");

            //Assert
            Assert.AreEqual(3, resultado);
        }

        [TestMethod]
        public void AddMethod_Returns0IsThereAreMoreThan2Numbers()
        {
            //Arrange
            IStringCalculator stringCalculator = new StringCalculator();

            //Act
            var resultado = stringCalculator.Add("3,5,6,7");

            //Assert
            Assert.AreEqual(0, resultado);

        }

        [TestMethod]
        public void AddMethod_ReturnsAcorrectResultWithDifferentDelimeters()
        {
            //Arrange
            IStringCalculator stringCalculator = new StringCalculator();

            //Act
            var resultado = stringCalculator.Add("2\n3");
            var resultado2 = stringCalculator.Add("2:3");
            //Assert
            Assert.AreEqual(5, resultado);
            Assert.AreEqual(5, resultado2);

        }
        [TestMethod]
        public void AddMethod_Returns0IfMultipleDelimtersAtTheSameTime()
        {
            //Arrange
            IStringCalculator stringCalculator = new StringCalculator();

            //Act
            var resultado = stringCalculator.Add("2,\n3");

            //Assert
            Assert.AreEqual(0, resultado);

        }

        //[TestMethod]
        //public void AddMethod_Return0IfANegativeNumberIsIntroduced()
        //{
        //    //Arrange
        //    IStringCalculator stringCalculator = new StringCalculator();

        //    //Act
        //    var resultado = stringCalculator.Add("-2,n3");

        //    //Assert
        //    Assert.AreEqual(0, resultado);

        //}

    }
}
