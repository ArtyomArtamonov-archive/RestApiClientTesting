using System;
using Newtonsoft.Json;
using NUnit.Framework;
using RestApiClient;

namespace IntegrationTests
{
    [TestFixture]
    public class GetTests
    {
        private TestingRestApi _testingClass;

        [SetUp]
        public void Setup()
        {
            _testingClass = new TestingRestApi("https://test.dmzem.xyz/");
        }

        [TestCase("15", "15")]
        [TestCase("-15", "-5")]
        [TestCase("-15.0", "-5.0")]
        public void ShouldGetResultOfAddition(string a, string b)
        {
            var response = _testingClass.Run("addition", a, b);


            Assert.DoesNotThrow(() => HandleResponse(response));
        }

        [TestCase("a", "b")]
        [TestCase("true", "false")]
        public void ShouldThrowWhenTryingToAdd(string a, string b)
        {
            var response = _testingClass.Run("addition", a, b);

            Assert.That(() => HandleResponse(response), Throws.Exception);
        }

        [TestCase("15", "15")]
        [TestCase("-15", "-5")]
        [TestCase("-15.0", "-5.0")]
        public void ShouldGetResultOfSubtraction(string a, string b)
        {
            var response = _testingClass.Run("subtraction", a, b);


            Assert.DoesNotThrow(() => HandleResponse(response));
        }

        [TestCase("15", "15")]
        [TestCase("-15", "-5")]
        [TestCase("-15.0", "-5.0")]
        public void ShouldGetResultOfDivision(string a, string b)
        {
            var response = _testingClass.Run("division", a, b);


            Assert.DoesNotThrow(() => HandleResponse(response));
        }


        private void HandleResponse(string response)
        {
            dynamic json = JsonConvert.DeserializeObject(response);

            if (json.success == false)
            {
                throw new ArgumentException();
            }
        }
    }
}
