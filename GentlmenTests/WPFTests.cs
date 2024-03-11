using NUnit.Framework;
using OOO_Gentlmen;
using System;
using System.Threading;

namespace GentlmenTests
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class WPFTests
    {
        private MainWindow mainWindow;
        string _validLogin = "LupinRV@gmail.com", _validPassword = "roma2001";
        string _invalidLogin = "000", _invalidPassword = "asdf";

        [SetUp]
        public void Setup()
        {
            mainWindow = new MainWindow();
        }

        [Test]
        public void Login_ValidCredentials_ReturnsTrue()
        {
            // Act
            bool result = mainWindow.Login(_validLogin, _validPassword);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Login_InvalidLogin_ReturnsFalse()
        {
            // Act
            bool result = mainWindow.Login(_invalidLogin, _validPassword);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Login_InvalidPassword_ReturnsFalse()
        {
            // Act
            bool result = mainWindow.Login(_validLogin, _invalidPassword);

            // Assert
            Assert.IsFalse(result);
        }
    }
   
}