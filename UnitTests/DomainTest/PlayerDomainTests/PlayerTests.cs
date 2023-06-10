using Domain.PlayerDomain.Entites;
using Domain.PlayerDomain.Execptions;
using NUnit.Framework;

namespace UnitTests.DomainTest.PlayerDomainTests
{
    public class PlayerTests
    {
        [Test]
        public void Constructor_WhenCreatePlayer_ShouldBeReturnSuccess()
        {
            // Arrange
            var name = "Test123";

            // Action
            var player = new Player(name);

            // Assert
            Assert.IsTrue(player.Name == name);
        }

        [Test]
        public void Constructor_WhenCreatePlayerWithInvalidNameLength_ShouldBeThrowsException()
        {
            // Arrange
            var name = "Test123456789012345678901234567890";

            // Action and Assert
            Assert.Throws<InvalidNameLengthException>(
                () => new Player(name));
        }

        [Test]
        public void Constructor_WhenCreatePlayerWithInvalidCharacters_ShouldBeThrowsException()
        {
            // Arrange
            var name = "Test123@";

            // Action and Assert
            Assert.Throws<InvalidCharactersNameException>(
                () => new Player(name));
        }
    }
}
