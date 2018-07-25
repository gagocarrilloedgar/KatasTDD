using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KatasTDD.StringCalculator.V2.Library;
using KatasTDD.StringCalculator.V2.Library.Interface;

namespace KatasTDD.StringCalculator.V2.Tests
{
    [TestClass]
    public class StringCalculatorTest
    {
        [TestMethod]
        public void Add_Returns0_IfInputIsEmpty()
        {
            //Arrage
            IStringCalculatorService stringCalculator = new StringCalculatorService();

            //Act
            var actual = stringCalculator.Add("");
            var result = 0;

            //Assert

            Assert.AreEqual(result, actual);

        }

        [TestMethod]
        public void Add_ReturnsTheNumber_IfTheInputIsANumber()
        {
            //Arrage
            IStringCalculatorService stringCalculator = new StringCalculatorService();

            //Act
            var actual = stringCalculator.Add("1");
            var result = 1;

            //Assert

            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void Add_ReturnsTheSum_TwoInputsSeparatedByComa()
        {
            //Arrage
            IStringCalculatorService stringCalculator = new StringCalculatorService();

            //Act
            var actual = stringCalculator.Add("1,2");
            var result = 3;

            //Assert

            Assert.AreEqual(result, actual);
        }
        [TestMethod]
        public void Add_ReturnsTheSum_TreeInputsSeparatedByComa()
        {
            //Arrage
            IStringCalculatorService stringCalculator = new StringCalculatorService();

            //Act
            var actual = stringCalculator.Add("1,2,4");
            var result = 7;

            //Assert

            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void Add_ReturnsSum_AcceptTwoDeilimeters()
        {
            //Arrage
            IStringCalculatorService stringCalculator = new StringCalculatorService();

            //Act
            var actual = stringCalculator.Add("1,2\n4");
            var result = 7;

            //Assert

            Assert.AreEqual(result, actual);

        }

        [TestMethod]
        public void Add_ReturnsSum_AcceptTreeDelimeters()
        {
            //Arrage
            IStringCalculatorService stringCalculator = new StringCalculatorService();

            //Act
            var actual = stringCalculator.Add("1,2\n4;4");
            var result = 11;

            //Assert

            Assert.AreEqual(result, actual);

        }

        [TestMethod]
        public void Add_ReturnsSumm_ByChangingTheDelimeter()
        {
            //Arrage
            IStringCalculatorService stringCalculator = new StringCalculatorService();

            //Act
            var actual = stringCalculator.Add("//;1;2\n4\n4");
            var result = 11;

            //Assert

            Assert.AreEqual(result, actual);

        }

        [TestMethod]
        public void GetFilteredNumbers_ReturnsAnStringFiltered()
        {
            //Arrage
            IFilterString stringCalculator = new StringCalculatorService();

            //Act
            var actual = stringCalculator.GetFilteredNumbers("//;1;2\n4\n4");
            var result = "1;2\n4\n4";

            //Assert

            Assert.AreEqual(result, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_ExpectedException_IfTherAreSomeNegativeNumber()
        {
            //Arrage
            IStringCalculatorService stringCalculator = new StringCalculatorService();

            //Act
            stringCalculator.Add("-2,4");

        }

        [TestMethod]
        public void Add_NumbersAbove1000AreNotBeingConseidereds()
        {
            //Arrage
            IStringCalculatorService stringCalculator = new StringCalculatorService();

            //Act
            var actual = stringCalculator.Add("1,1001;6");
            var result = 7;

            //Assert

            Assert.AreEqual(result, actual);

        }

        [TestMethod]
        public void Add_CorrectOperation_WhenMultipleDelimeters()
        {
            //Arrage
            IStringCalculatorService stringCalculator = new StringCalculatorService();

            //Act
            var actual = stringCalculator.Add("1 2;6,4\n2*0");
            var result = 15;

            //Assert

            Assert.AreEqual(result, actual);

        }

        [TestMethod]
        public void Add_CorrectOperation_WhenLongDelimeters()
        {
            //Arrage
            IStringCalculatorService stringCalculator = new StringCalculatorService();

            //Act
            var actual = stringCalculator.Add("1**3");
            var result = 4;

            //Assert

            Assert.AreEqual(result, actual);

        }

    }
}
