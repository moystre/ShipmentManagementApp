using BLL.BusinessObjects;
using BLL.Converters;
using DAL.Entities;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class UserConverterTest
    {
        [Test]
        public void TestMethod1()
        {
            var conv = new UserConverter();

            UserBO userbo = new UserBO {Username= "John" }; 
            var result = conv.Convert(userbo);

            User user = new User {Username="John" };
            var expected = user;

            Assert.AreEqual(result.Username, expected.Username);
        }
    }
}

