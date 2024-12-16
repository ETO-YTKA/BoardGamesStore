using BoardGamesStore.pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class RegistrationPageTests
    {
        [TestMethod]
        public void EmptyRegField()
        {
            var regPage = new RegistrationPage();

            bool result = regPage.IsFieldsValid("", "", "", "", "", "");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidRegField()
        {
            var regPage = new RegistrationPage();
            bool result = regPage.IsFieldsValid("login", "firstName", "lastName", "password", "password", "patronymic");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void differentPasswords()
        {
            var regPage = new RegistrationPage();
            bool result = regPage.IsFieldsValid("login", "firstName", "lastName", "password", "password1", "patronymic");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void emptyPatronymic()
        {
            var regPage = new RegistrationPage();
            bool result = regPage.IsFieldsValid("login", "firstName", "lastName", "password", "password", "");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void emptyLogin()
        {
            var regPage = new RegistrationPage();
            bool result = regPage.IsFieldsValid("", "firstName", "lastName", "password", "password", "patronymic");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShortPasword()
        {
            var regPage = new RegistrationPage();
            bool result = regPage.IsFieldsValid("login", "firstName", "lastName", "123", "123", "patronymic");
            Assert.IsFalse(result);
        }
    }
}
