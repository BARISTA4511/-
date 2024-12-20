using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using computerTech;

namespace computerTechTests
{
    [TestClass]
    public class AutorizationTests
    {
        private Autorization autorization;

        [TestInitialize]
        public void Setup()
        {
            autorization = new Autorization();
        }

        [TestMethod]
        public void CheckCapcha_ValidCapcha_ReturnsTrue()
        {
            // Arrange
            autorization.currentCapcha = "1234";
            string inputCapcha = "1234";

            // Act
            bool result = autorization.CheckCapcha(inputCapcha);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckCapcha_InvalidCapcha_ReturnsFalse()
        {
            // Arrange
            autorization.currentCapcha = "1234";
            string inputCapcha = "abcd";

            // Act
            bool result = autorization.CheckCapcha(inputCapcha);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ClearInputFields_ClearsAllFields()
        {
            // Arrange
            autorization.textBoxLogin.Text = "user";
            autorization.textBoxPasswd.Text = "password";
            autorization.textBoxCapcha.Text = "1234";

            // Act
            autorization.ClearInputFields();

            // Assert
            Assert.AreEqual(string.Empty, autorization.textBoxLogin.Text);
            Assert.AreEqual(string.Empty, autorization.textBoxPasswd.Text);
            Assert.AreEqual(string.Empty, autorization.textBoxCapcha.Text);
        }

        [TestMethod]
        public void AuthenticateUser_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            string login = "login1";
            string password = "pass1";
            int userTypeId;
            int userId;

            // Act
            bool result = autorization.AuthenticateUser(login, password, out userTypeId, out userId);

            // Assert
            Assert.IsTrue(result);
            Assert.AreNotEqual(-1, userTypeId);
            Assert.AreNotEqual(-1, userId);
        }

        [TestMethod]
        public void AuthenticateUser_InvalidCredentials_ReturnsFalse()
        {
            // Arrange
            string login = "invalidUser ";
            string password = "invalidPassword";
            int userTypeId;
            int userId;

            // Act
            bool result = autorization.AuthenticateUser(login, password, out userTypeId, out userId);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(-1, userTypeId);
            Assert.AreEqual(-1, userId);
        }
    }
}