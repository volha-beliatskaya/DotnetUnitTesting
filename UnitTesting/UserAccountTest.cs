using DotnetUnitTesting;
using NUnit.Framework;

namespace UnitTesting
{
    class UserAccountTest
    {
        [Test]
        public void VerifyThatUserAccountCanBeCreated()
        {
            //Act
            UserAccount userAccount = new UserAccount("Bill", "Korner", "12.12.1991");


            //Assert
            Assert.That(userAccount.Name, Is.EqualTo("Bill"));
            Assert.That(userAccount.Surname, Is.EqualTo("Korner"));
            Assert.That(userAccount.DateOfBirth, Is.EqualTo("12.12.1991"));
        }
    }
}
