using Domain.BoardDomain.Entities;
using Domain.BoardDomain.Enums;
using Domain.BoardDomain.Exceptions;
using Domain.ShipDomain.Enuns;
using NUnit.Framework;

namespace UnitTests.DomainTest.BoardDomainTests
{
    public class BoardTests
    {
        [Test]
        public void BoardInitializer_WhenTheBoardWasInitialized_ShouldContainsTheCels()
        {
            var board = new Board(Dificulty.Easy);

            board.BoardInitializer();
            
            Assert.AreEqual(board.Cells[9, 9], '~');
        }

        [Test]
        public void SetShip_WhenTheCoordinationIsOffTheBoard_ShouldBeThrowsException()
        {
            // Arrange
            var board = new Board(Dificulty.Medium);
            var starPoint = new Coordinate(Letter.K, 23);
            var direction = Axle.Horizontal;
            var ship = ShipType.Executor;

            board.BoardInitializer();
            
            // Action and Assert
            Assert.Throws<CordenationIsOffTheBoarException>(
                () => board.SetShip(starPoint, direction, ship));
        }

        [Test]
        public void SetShip_WhenTheShipAlreadyExistsInThisCoordenate_ShouldBeThrowsExeption()
        {
            // Arrange
            var starPoint = new Coordinate(Letter.B, 11);
            var board = new Board(Dificulty.Medium);
            var direction = Axle.Vertical;
            var ship = ShipType.Executor;

            board.BoardInitializer();
            board.SetShip(starPoint, direction, ship);

            var ship2 = ShipType.Millenium_Falcon;

            // Action and Assert
            Assert.Throws<ShipAlreadyExistsInTheBoardException>(
                () => board.SetShip(starPoint, direction, ship2));
        }

        [Test]
        public void SetShip_WhenTheShipIsNotExistsAndCordenationIsValid_ShouldBeReturnTrue()
        {
            // Arrage
            var starPoint = new Coordinate(Letter.B, 11);
            var board = new Board(Dificulty.Medium);
            var direction = Axle.Vertical;
            var ship = ShipType.Executor;

            board.BoardInitializer();

            // Action
            var result = board.SetShip(starPoint, direction, ship);
            Assert.IsTrue(result);
        }

        [Test]
        public void Attack_WhenAttackCoordinateIsOffTheBoard_ShouldThrowException()
        {
            // Arrange
            var board = new Board(Dificulty.Easy);
            var attackCoordinate = new Coordinate(Letter.B, 11);

            board.BoardInitializer();

            // Action and Assert
            Assert.Throws<CordenationIsOffTheBoarException>(
                () => board.Attack(attackCoordinate));
        }

        [Test]
        public void Attack_WhenAttackCoordinateNotContainsShip_ShouldReturnFalse()
        {
            // Arrange
            var board = new Board(Dificulty.Easy);
            var attackCoordinate = new Coordinate(Letter.B, 2);

            board.BoardInitializer();

            // Action
            var result = board.Attack(attackCoordinate);

            // Assert
            Assert.IsFalse(result);
            Assert.True(board.Cells[1,2] == '@');
        }

        [Test]
        public void Attack_WhenAttackCoordinateContainsShip_ShouldReturnTrue()
        {
            // Arrange
            var board = new Board(Dificulty.Easy);
            var attackCoordinate = new Coordinate(Letter.B, 2);
            var starPoint = new Coordinate(Letter.B, 2);
            var direction = Axle.Vertical;
            var ship = ShipType.Executor;

            board.BoardInitializer();
            board.SetShip(starPoint, direction, ship);

            // Action
            var result = board.Attack(attackCoordinate);

            // Assert
            Assert.IsTrue(result);
            Assert.True(board.Cells[1,2] == 'X');
        }

        [Test]
        public void Attack_WhenAttackCellHasBeenAttacked_ShouldThrowException() {
            // Arrange
            var board = new Board(Dificulty.Easy);
            var attackCoordinate = new Coordinate(Letter.B, 2);
            var starPoint = new Coordinate(Letter.B, 2);
            var direction = Axle.Vertical;
            var ship = ShipType.Executor;

            board.BoardInitializer();
            board.SetShip(starPoint, direction, ship);
            board.Attack(attackCoordinate);

            // Action and Assert
            Assert.Throws<CellHasBeenAttackedException>(
                () => board.Attack(attackCoordinate));
        }

        [Test]
        public void IsAllShipsDestroyed_WhenBoardHasShipInTheBoard_SholdBeReTrue()
        {
            // Arrange
            var board = new Board(Dificulty.Easy);
            var starPoint = new Coordinate(Letter.B, 2);
            var direction = Axle.Vertical;
            var ship = ShipType.Executor;

            board.BoardInitializer();
            board.SetShip(starPoint, direction, ship);

            // Action
            var result = board.IsAllShipsDestroyed();

            Assert.IsFalse(result);
        }

        [Test]
        public void IsAllShipsDestroyed_WhenBoardNoHasShipInTheBoard_ShouldBeReturnFalse()
        {
            // Arrange
            var board = new Board(Dificulty.Easy);
            var starPoint = new Coordinate(Letter.B, 2);
            var direction = Axle.Vertical;
            var ship = ShipType.Executor;

            board.BoardInitializer();

            // Action
            var result = board.IsAllShipsDestroyed();

            Assert.IsTrue(result);
        }
    }
}
