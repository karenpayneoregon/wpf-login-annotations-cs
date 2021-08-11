using System;
using System.Diagnostics;
using LoginCoreUnitTest.Base;
using LoginCoreUnitTest.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationCoreLibrary;
using ValidationCoreLibrary.ExtensionMethods;

namespace LoginCoreUnitTest
{
    [TestClass]
    public partial class MainTest : TestBase
    {
        [TestMethod]
        [TestTraits(Trait.ValidLogin)]
        public void ValidLoginTest()
        {
            CustomerLogin customerLogin = new ()
            {
                UserName = "paynek", 
                Password = "@SomeLongPassword1",
                PasswordConfirmation = "@SomeLongPassword1"
            };
            
            EntityValidationResult validationResult = ValidationHelper.ValidateEntity(customerLogin);
            
            Assert.IsFalse(validationResult.HasError);


        }
        [TestMethod]
        [TestTraits(Trait.InvalidLogin)]
        public void InValidLoginUserNameTest()
        {
            CustomerLogin customerLogin = new ()
            {
                UserName = "abc",
                Password = "@SomeLongPassword1",
                PasswordConfirmation = "@SomeLongPassword1"
            };

            EntityValidationResult validationResult = ValidationHelper.ValidateEntity(customerLogin);

            Assert.IsTrue(validationResult.HasError);

            string message = "The field User Name must be a string with a minimum length of 6 and a maximum length of 10.";
            Assert.IsTrue(validationResult.ErrorMessageList().Contains(message));

        }
        [TestMethod]
        [TestTraits(Trait.InvalidLogin)]
        public void InValidLoginPasswordTest()
        {
            CustomerLogin customerLogin = new()
            {
                UserName = "paynek",
                Password = "SomeLongPassword",
                PasswordConfirmation = "SomeLongPassword"
            };

            EntityValidationResult validationResult = ValidationHelper.ValidateEntity(customerLogin);

            Assert.IsTrue(validationResult.HasError);

            string message = "Must include a number and symbol in Password";
            Assert.IsTrue(validationResult.ErrorMessageList().Contains(message));
            
        }
        [TestMethod]
        [TestTraits(Trait.InvalidLogin)]
        public void InValidLoginMismatchedPasswordsTest()
        {
            CustomerLogin customerLogin = new()
            {
                UserName = "paynek",
                Password = "@SomeLongPassword",
                PasswordConfirmation = "@SomeLongPassword1"
            };

            EntityValidationResult validationResult = ValidationHelper.ValidateEntity(customerLogin);

            Assert.IsTrue(validationResult.HasError);

            string message = "Passwords do not match , please try again";
            Assert.IsTrue(validationResult.ErrorMessageList().Contains(message));
            Debug.WriteLine(validationResult.ErrorMessageList());

        }
        [TestMethod]
        [TestTraits(Trait.InvalidLogin)]
        public void InValidLoginBadUserName_MismatchedPasswords_Test()
        {
            
            CustomerLogin customerLogin = new()
            {
                UserName = "abc",
                Password = "@SomeLongPassword",
                PasswordConfirmation = "@SomeLongPassword1"
            };

            EntityValidationResult validationResult = ValidationHelper.ValidateEntity(customerLogin);

            Assert.IsTrue(validationResult.HasError);

            //string message = "Passwords do not match , please try again";
            //Assert.IsTrue(validationResult.ErrorMessageList().Contains(message));
            Debug.WriteLine(validationResult.ErrorMessageList());

        }
    }
}
