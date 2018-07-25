using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KatasTDD.StringCalculator.V2.Library.Interface;
using Moq;
using KatasTDD.StringCalculator.V2.Library;

namespace KatasTDD.StringCalculator.V2.Tests
{
    /// <summary>
    /// Descripción resumida de StringCalculatorConsoleTest
    /// </summary>
    [TestClass]
    public class StringCalculatorConsoleTest
    {
        #region Properties & Variables

        private const string resultIs = "Result is: ";
        private Mock<ILogger> loggerMock;
        private IStringCalculatorConsoleService stringCalculatorConsoleService;
        string input = "", output = "";

        #endregion

        [TestInitialize]
        public void SetUp()
        {
            loggerMock = new Mock<ILogger>();
            stringCalculatorConsoleService = new StringCalculatorConsoleService
                (
                    loggerMock.Object,
                    new StringCalculatorService()
                    );

        }

        [TestMethod]
        public void Main_EmptyArgs_OutputsZero()
        {
            //Arrange --> TestInitialize

            //Act
            output = "0";
            Main(input);

            //Assert
            VerifyOutputedConsole(ResultIs(output));

        }

        [TestMethod]
        public void Main_OneValue_OutputsTheValue()
        {
            input = "1";
            output = input;

            Main(input);

            VerifyOutputedConsole(ResultIs(output));
        }

        [TestMethod]
        public void Main_MultipleValues_OutputsTheSum()
        {
            input = "1,2,3,4";
            output = "10";

            Main(input);

            VerifyOutputedConsole(ResultIs(output));
            
        }

        private string ResultIs(string expected)
        {
            return resultIs + expected;
        }

        private void VerifyOutputedConsole(string OutputLine)
        {
            loggerMock.Verify(console => console.Write(OutputLine));
        }

        private void Main(string result)
        {
            stringCalculatorConsoleService.Main(new string[] {result});
        }
    }
}
