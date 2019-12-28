using NUnit.Framework;
using PhoneBookTestApp;
using Moq;

namespace PhoneBookTestAppTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class PhoneBookTest
    {
        [Test]
        public void add_find_Person()
        {
            var person = new Person()
            {
                name = "TestName",
                phoneNumber = "TestNumber",
                address = "TestAddress"
            };

            var phoneBook = new Mock<IPhoneBook>();
            phoneBook.Setup(x => x.addPerson(new Person()));
            phoneBook.Setup(x => x.findPerson(person.name)).Returns(person);

            phoneBook.Object.addPerson(person);

            var result = phoneBook.Object.findPerson(person.name);

            Assert.AreEqual(result.name, person.name);
        }
    }

    // ReSharper restore InconsistentNaming
}