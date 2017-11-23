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

            void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
            {
                using (var hmac = new System.Security.Cryptography.HMACSHA512())
                {
                    passwordSalt = hmac.Key;
                    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                }
            }

            string pass = "1234";
            byte[] passwordHash1, passwordSalt1, passwordHash2, passwordSalt2;
            CreatePasswordHash(pass, out passwordHash1, out passwordSalt1);
            CreatePasswordHash(pass, out passwordHash2, out passwordSalt2);

            UserBO userBO = new UserBO {
                Id = 1,
                Username = "John",
                IsAdmin = false,
                PasswordHash = passwordHash1,
                PasswordSalt = passwordSalt1
            }; 

            User user = new User {
                Id = 1,
                Username = "John",
                IsAdmin = false,
                PasswordHash = passwordHash1,
                PasswordSalt = passwordSalt1
            };

            var result = conv.Convert(userBO);
            var expected = user;
            Assert.AreEqual(result.Username, expected.Username);
            Assert.AreEqual(result.Id, expected.Id);
            Assert.AreEqual(result.IsAdmin, expected.IsAdmin);
            Assert.AreEqual(result.PasswordHash, expected.PasswordHash);
            Assert.AreEqual(result.PasswordSalt, expected.PasswordSalt);
        }
    }
}

