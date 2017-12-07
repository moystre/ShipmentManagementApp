using BLL.BusinessObjects;
using BLL.Converters;
using DAL.Entities;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class UserConverterTest
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        [Test]
        public void TestConvUserEntityToNull()
        {
            var converter = new UserConverter();
            User ent = converter.Convert((UserBO)null);

            Assert.IsNull(ent);
        }

        [Test]
        public void TestConvUserBusinessObjectToNull()
        {
            var converter = new UserConverter();
            UserBO bo = converter.Convert((User)null);

            Assert.IsNull(bo);
        }

        [Test]
        public void TestConvUserToEntityId()
        {
            var conv = new UserConverter();

            
            UserBO userBO = new UserBO { Id = 1 };
            User user = new User { Id = 1 };

            var result = conv.Convert(userBO);
            var expected = user;
            Assert.AreEqual(result.Id, expected.Id);
        }

        [Test]
        public void TestConvUserToBusinessObjectId()
        {
            var conv = new UserConverter();


            UserBO userBO = new UserBO { Id = 1 };
            User user = new User { Id = 1 };

            var result = conv.Convert(user);
            var expected = userBO;
            Assert.AreEqual(result.Id, expected.Id);
        }

        [Test]
        public void TestConvUserToEntityUsername()
        {
            var conv = new UserConverter();


            UserBO userBO = new UserBO { Username = "John"};
            User user = new User {Username = "John"};

            var result = conv.Convert(userBO);
            var expected = user;
            Assert.AreEqual(result.Username, expected.Username);
        }

        [Test]
        public void TestConvUserToBusinessObjectUsername()
        {
            var conv = new UserConverter();


            UserBO userBO = new UserBO { Username = "John" };
            User user = new User { Username = "John" };

            var result = conv.Convert(user);
            var expected = userBO;
            Assert.AreEqual(result.Username, expected.Username);
        }

        [Test]
        public void TestConvUserToEntityPassHash()
        {
            var conv = new UserConverter();

            string pass = "1234";
            byte[] passwordHash1, passwordSalt1;
            CreatePasswordHash(pass, out passwordHash1, out passwordSalt1);
            UserBO userBO = new UserBO { PasswordHash = passwordHash1};
            User user = new User { PasswordHash = passwordHash1 };

            var result = conv.Convert(userBO);
            var expected = user;
            Assert.AreEqual(result.PasswordHash, expected.PasswordHash);
        }

        [Test]
        public void TestConvUserToBusinessObjectPassHash()
        {
            var conv = new UserConverter();

            string pass = "1234";
            byte[] passwordHash1, passwordSalt1;
            CreatePasswordHash(pass, out passwordHash1, out passwordSalt1);
            UserBO userBO = new UserBO { PasswordHash = passwordHash1 };
            User user = new User { PasswordHash = passwordHash1 };

            var result = conv.Convert(user);
            var expected = userBO;
            Assert.AreEqual(result.PasswordHash, expected.PasswordHash);
        }

        [Test]
        public void TestConvUserToEntityPassSalt()
        {
            var conv = new UserConverter();

            string pass = "1234";
            byte[] passwordHash1, passwordSalt1;
            CreatePasswordHash(pass, out passwordHash1, out passwordSalt1);
            UserBO userBO = new UserBO { PasswordSalt = passwordSalt1 };
            User user = new User { PasswordSalt = passwordSalt1 };

            var result = conv.Convert(userBO);
            var expected = user;
            Assert.AreEqual(result.PasswordSalt, expected.PasswordSalt);
        }

        [Test]
        public void TestConvUserToBusinessObjectPassSalt()
        {
            var conv = new UserConverter();

            string pass = "1234";
            byte[] passwordHash1, passwordSalt1;
            CreatePasswordHash(pass, out passwordHash1, out passwordSalt1);
            UserBO userBO = new UserBO { PasswordSalt = passwordSalt1 };
            User user = new User { PasswordSalt = passwordSalt1 };

            var result = conv.Convert(user);
            var expected = userBO;
            Assert.AreEqual(result.PasswordSalt, expected.PasswordSalt);
        }
    }
}

