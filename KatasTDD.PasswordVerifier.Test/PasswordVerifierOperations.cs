using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KatasTDD.PasswordVerifier.Library.Interface;
using KatasTDD.PasswordVerifier.Library.Services;

namespace KatasTDD.PasswordVerifier.Test
{
    [TestClass]
    public class PasswordVerifierOperations
    {
        #region Properties
        private IPasswordVerfierServices passwordVerifierServices;
        #endregion

        [TestInitialize]
        public void Setup()
        {
            passwordVerifierServices = new PasswordVerifierServices();
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PasswordShorterThan8_ReturnsFalse()
        {
            //Arrange --> Setup()

            Verify("hola");

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void PasswordNull_ThrowsNullReferenceExcption()
        {
            Verify(null);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PasswordWithoutCaptialLetter_ThrowsException()
        {
            Verify("holamundo");

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PasswordNotConainsANumber_ThrowsException()
        {
            Verify("holamundo");

        }

        [TestMethod]
        public void Verify_AtLEast3AreCorrect_ReturnsTrue()
        {
            var expected = Verify("Holamundo8");
            var actual = true;

            Assert.AreEqual(expected, actual);

        }

        #region ExtraMethods
        private bool Verify(string password)
        {   
            //Act
            var expected = passwordVerifierServices.Verify(password);

            return expected;
        }

        #endregion


    }
}





