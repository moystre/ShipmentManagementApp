using BLL.BusinessObjects;
using BLL.Converters;
using DAL.Entities;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class UserConverterTest
    {
        UserConverter converter = new UserConverter();

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
            User ent = converter.Convert((UserBO)null);

            Assert.IsNull(ent);
        }

        [Test]
        public void TestConvUserBusinessObjectToNull()
        {
            UserBO bo = converter.Convert((User)null);

            Assert.IsNull(bo);
        }

        [Test]
        public void TestConvUserToEntityId()
        {
            UserBO userBO = new UserBO { Id = 1 };
            User user = new User { Id = 1 };

            var result = converter.Convert(userBO);
            var expected = user;
            Assert.AreEqual(result.Id, expected.Id);
        }

        [Test]
        public void TestConvUserToBusinessObjectId()
        {
            UserBO userBO = new UserBO { Id = 1 };
            User user = new User { Id = 1 };

            var result = converter.Convert(user);
            var expected = userBO;
            Assert.AreEqual(result.Id, expected.Id);
        }

        [Test]
        public void TestConvUserToEntityUsername()
        {
            UserBO userBO = new UserBO { Username = "John"};
            User user = new User {Username = "John"};

            var result = converter.Convert(userBO);
            var expected = user;
            Assert.AreEqual(result.Username, expected.Username);
        }

        [Test]
        public void TestConvUserToBusinessObjectUsername()
        {
            UserBO userBO = new UserBO { Username = "John" };
            User user = new User { Username = "John" };

            var result = converter.Convert(user);
            var expected = userBO;
            Assert.AreEqual(result.Username, expected.Username);
        }

        [Test]
        public void TestConvUserToEntityPassHash()
        {
            string pass = "1234";
            byte[] passwordHash1, passwordSalt1;
            CreatePasswordHash(pass, out passwordHash1, out passwordSalt1);
            UserBO userBO = new UserBO { PasswordHash = passwordHash1};
            User user = new User { PasswordHash = passwordHash1 };

            var result = converter.Convert(userBO);
            var expected = user;
            Assert.AreEqual(result.PasswordHash, expected.PasswordHash);
        }

        [Test]
        public void TestConvUserToBusinessObjectPassHash()
        {
            string pass = "1234";
            byte[] passwordHash1, passwordSalt1;
            CreatePasswordHash(pass, out passwordHash1, out passwordSalt1);
            UserBO userBO = new UserBO { PasswordHash = passwordHash1 };
            User user = new User { PasswordHash = passwordHash1 };

            var result = converter.Convert(user);
            var expected = userBO;
            Assert.AreEqual(result.PasswordHash, expected.PasswordHash);
        }

        [Test]
        public void TestConvUserToEntityPassSalt()
        {
            string pass = "1234";
            byte[] passwordHash1, passwordSalt1;
            CreatePasswordHash(pass, out passwordHash1, out passwordSalt1);
            UserBO userBO = new UserBO { PasswordSalt = passwordSalt1 };
            User user = new User { PasswordSalt = passwordSalt1 };

            var result = converter.Convert(userBO);
            var expected = user;
            Assert.AreEqual(result.PasswordSalt, expected.PasswordSalt);
        }

        [Test]
        public void TestConvUserToBusinessObjectPassSalt()
        {
            string pass = "1234";
            byte[] passwordHash1, passwordSalt1;
            CreatePasswordHash(pass, out passwordHash1, out passwordSalt1);
            UserBO userBO = new UserBO { PasswordSalt = passwordSalt1 };
            User user = new User { PasswordSalt = passwordSalt1 };

            var result = converter.Convert(user);
            var expected = userBO;
            Assert.AreEqual(result.PasswordSalt, expected.PasswordSalt);
        }
    }
}

