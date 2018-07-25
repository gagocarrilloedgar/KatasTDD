using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KatasTDD.StringCalculator.V2.Library;
using Moq;
using KatasTDD.StringCalculator.V2.Library.Interface;

namespace KatasTDD.StringCalculator.V2.Tests
{
    /// <summary>
    /// Descripción resumida de UnitTest1
    /// </summary>
    [TestClass]
    public class StringCalculatorOutputTest
    {
        #region Poperties
        private Mock<ILogger> loggerMock;
        private Mock<IWebService> webServiceMock;
        private IStringCalculatorService stringCalculatorService;
        #endregion

        [TestInitialize]
        public void SetUp()
        {
            loggerMock = new Mock<ILogger>();
            webServiceMock = new Mock<IWebService>();
            stringCalculatorService = new StringCalculatorService
            {
                Logger = loggerMock.Object,
                WebService = webServiceMock.Object
            };
        }

        [TestMethod]
        public void Add_EmptyValue_OutputsZero()
        {
            //Act
            stringCalculatorService.Add("");
            var expected = "0";

            //Assert
            VerifyOutputLine(expected);

        }

        [TestMethod]
        public void Add_SingleValue_OutputsValue()
        {

            //Act
            stringCalculatorService.Add("1");
            var expected = "1";

            //Assert
            VerifyOutputLine(expected);

        }

        [TestMethod]
        public void Add_MultipleValues_OutputsSum()
        {
            //Act
            stringCalculatorService.Add("1,4,3,5");
            var expected = "13";

            //Assert
            VerifyOutputLine(expected);


        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_NegativeNumbers_ThrowMessage()
        {
            stringCalculatorService.Add("-1 4 5 ");

            var expected = "Error NegativesAreNotAllow";

            VerifyOutputLine(expected);

        }

        [TestMethod]
        public void Add_CallingLoggerThrowExecption_CallWebService()
        {
            try
            {
                stringCalculatorService.Add(" ");
            }
            catch (NullReferenceException ex)
            {

                webServiceMock.Verify(webservice => webservice.RegisterExecption(ex.Message));
            }
            
        }

        private void VerifyOutputLine(string expected)
        {
            loggerMock.Verify(logger => logger.Write(expected));
        }




    }


}
