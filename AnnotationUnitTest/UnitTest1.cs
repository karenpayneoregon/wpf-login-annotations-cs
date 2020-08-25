﻿using System;
using AnnotationUnitTest.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationLibrary;
using ValidationLibrary.CommonRules;
using ValidationLibrary.ExtensionMethods;

namespace AnnotationUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Validate a file extension is one of the default extensions png,jpg,jpeg,gif
        /// </summary>
        [TestMethod]
        public void FileExtensionsExample()
        {
            FileItem fileItem = new FileItem() {Name = "test.jpg"};

            EntityValidationResult validationResult = ValidationHelper.ValidateEntity(fileItem);
            Assert.IsFalse(validationResult.HasError);

            fileItem.Name = "test.xsd";
            validationResult = ValidationHelper.ValidateEntity(fileItem);
            Assert.IsTrue(validationResult.HasError);
        }
        /// <summary>
        /// Validate no phone number
        /// </summary>
        [TestMethod]
        public void PersonPhoneExample()
        {
            Person  person = new Person() {FirstName = "Bob", LastName = "Jones", SSN = "201518161" };

            EntityValidationResult validationResult = ValidationHelper.ValidateEntity(person);
            Assert.IsTrue(validationResult.HasError);
            Assert.IsTrue(validationResult.ErrorMessageList().Contains("Phone is required"));
        }
        /// <summary>
        /// Validate missing first name
        /// </summary>
        [TestMethod]
        public void PersonFirstNameMissingExample()
        {
            Person person = new Person()
            {
                FirstName = "Jimmy Bob",
                LastName = "Jones",
                Phone = "(305) 444-9999",
                SSN = "201518161"
            };

            EntityValidationResult validationResult = 
                ValidationHelper.ValidateEntity(person);

            Assert.IsFalse(validationResult.HasError);
            var test = validationResult.Errors;
            person.FirstName = "";
            validationResult = ValidationHelper.ValidateEntity(person);

            Assert.IsTrue(validationResult.Errors.Count == 1 && 
                          validationResult.ErrorMessageList().Contains("First Name"));

        }
        /// <summary>
        /// Here there is a bad SSN, see remarks in <seealso cref="SocialSecurityAttribute"/>
        /// </summary>
        [TestMethod]
        public void PersonSocialSecurityExample()
        {
            Person person = new Person()
            {
                FirstName = "Jimmy Bob",
                LastName = "Jones",
                Phone = "(305) 444-9999",
                SSN = "078-05-1120"
            };

            EntityValidationResult validationResult = 
                ValidationHelper.ValidateEntity(person);

            Console.WriteLine(validationResult.ErrorMessageList());
            Assert.IsTrue(validationResult.HasError);
          

        }
    }
}
