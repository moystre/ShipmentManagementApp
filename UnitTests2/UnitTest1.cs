using BLL.BusinessObjects;
using BLL.Converters;
using DAL.Entities;
using System;
using Xunit;

namespace UnitTests2
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var conv = new UserConverter();

            UserBO userbo = new UserBO { Username = "John" };
            var result = conv.Convert(userbo);

            User user = new User { Username = "John" };
            var expected = user;

            Assert.Equal(result.Username, expected.Username);
        }
    }
}
