namespace TaxCalculator.Tests.Web
{
    using System;

    using NUnit.Framework;
    using TaxCalculator.Web.Validation;

    public class RequestValidatorTests
    {
        [Test]
        [TestCase(100, 99, 101, default(int), true, null )]
        [TestCase('b', 'a', 'c', default(char), true, null )]
        [TestCase("B", "A", "C", "", true, null )]
        [TestCase(100, 100, 100, default(int), true, null)]
        [TestCase(99, 100, 1000, default(int), false, "Provided value, must be greather than 100 and less than 1000")]
        public void TestCorrectValidation<T>(object valueToValidate, object min, object max, T t, bool expectedSuccess, string expectedErrorMessage)
            where T : IComparable<T>
        {
            var subject = new RequestValidator();

            subject.InRange<T>(valueToValidate, min, max);

            var validationResult = subject.Validate();

            Assert.AreEqual(expectedSuccess, validationResult.IsSuccess);
            Assert.AreEqual(expectedErrorMessage, validationResult.ErrorMessage);
        }
    }
}
