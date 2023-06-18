using Domain.BoardDomain.Entities;
using Domain.BoardDomain.Enums;
using Domain.BoardDomain.Exceptions;
using Domain.GameDomain.Entities;
using Domain.ShipDomain.Enuns;
using NUnit.Framework;

namespace UnitTests.DomainTest.GameDomainTests
{
    public class GameTests
    {
        public Game Game { get; set; }

        [SetUp]
        public void Setup()
        {
            Game = new Game();
            Game.LoadPlayer("Test");
        }

        [Test]
        public void Constructor_WhenCreateGame_ShouldBeReturnSuccess()
        {
            // Arrange
            var dificulty = Dificulty.Easy;

            // Action
            Game.Board = new Board(dificulty);

            // Assert
            Assert.IsTrue(Game.Board.Width == 10);
        }

        [Test]
        public void LoadBoard_WhenLoadBoard_ShouldHasSomeShipIntoBoard()
        {
            // Arrange
            var dificulty = Dificulty.Easy;

            // Action
            Game.LoadBoard(dificulty);
            for (int i = 0; i < Game.Board.Width; i++)
            {
                for (int j = 0; j < Game.Board.Width; j++)
                {
                    if (Game.Board.Cells[i, j] == 'S')
                    {
                        // Assert
                        Assert.IsTrue(true);
                        return;
                    }
                }
            }
        }

        [Test]
        public void Attack_WhenAttackAValidCellAndHitAShip_ShouldBeReturnTrueAndIncreseScore()
        {
            // Arrange
            var dificulty = Dificulty.Easy;
            Game.Board = new Board(dificulty);
            Game.Board.BoardInitializer();
            var cordinate = new Coordinate(Letter.B, 2);
            var direction = Axle.Vertical;
            var ship = ShipType.Millenium_Falcon;
            Game.Board.SetShip(cordinate, direction, ship);

            // Action
            var result = Game.Attack(cordinate);
             
            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(Game.Player.Score == 10);
        }
        
        [Test]
        public void Attack_WhenAttackAValidCellAndNotHitShip_ShouldBeReturnFalse()
        {
            // Arrange
            var dificulty = Dificulty.Easy;
            Game.Board = new Board(dificulty);
            Game.Board.BoardInitializer();
            Game.LoadPlayer("Test");
            var shipCooordinate = new Coordinate(Letter.B, 2);
            var attackCordinate = new Coordinate(Letter.B, 3);
            var direction = Axle.Vertical;
            var ship = ShipType.Millenium_Falcon;
            Game.Board.SetShip(shipCooordinate, direction, ship);

            // Action
            var result = Game.Attack(attackCordinate);
             
            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(Game.Player.Score == 0);
        }

        [Test]
        public void Attack_WhenAttackAValidCellAndNotHitShip_AmmoShouldBeSpent() {

            // Arrange
            var dificulty = Dificulty.Easy;
            Game.Board = new Board(dificulty);
            Game.Board.BoardInitializer();
            Game.SetStarCannonAmmon(dificulty);
            var shipCooordinate = new Coordinate(Letter.B, 2);
            var shipCooordinate1 = new Coordinate(Letter.D, 5);
            var shipCooordinate2 = new Coordinate(Letter.F, 8);
            var attackCordinate = new Coordinate(Letter.B, 3);
            var direction = Axle.Vertical;
            var ship = ShipType.Millenium_Falcon;
            Game.Board.SetShip(shipCooordinate, direction, ship);
            
            // Action
            Game.Attack(attackCordinate);
            Game.Attack(shipCooordinate1);
            Game.Attack(shipCooordinate2);
            
            // Assert
            Assert.IsTrue(Game.Player.Score == 0);
            Assert.IsTrue(Game.StarCannonAmmo == 47);
        }
        
        [Test]
        public void Attack_WhenAttackAValidCellAndHitShip_AmmoShouldBeSpent() {

            // Arrange
            var dificulty = Dificulty.Easy;
            Game.Board = new Board(dificulty);
            Game.Board.BoardInitializer();
            Game.SetStarCannonAmmon(dificulty);
            var shipCooordinate = new Coordinate(Letter.C, 2);
            var attackCordinate1 = new Coordinate(Letter.C, 2);
            var attackCordinate2 = new Coordinate(Letter.C, 3);
            var attackCordinate3 = new Coordinate(Letter.C, 4);
            var attackCordinate4 = new Coordinate(Letter.C, 5);
            var direction = Axle.Horizontal;
            var ship = ShipType.Executor;
            Game.Board.SetShip(shipCooordinate, direction, ship);
            
            // Action
            Game.Attack(attackCordinate1);
            Game.Attack(attackCordinate2);
            Game.Attack(attackCordinate3);
            Game.Attack(attackCordinate4);
            
            // Assert
            Assert.IsTrue(Game.Player.Score == 40);
            Assert.IsTrue(Game.StarCannonAmmo == 46);
        }
        
        [Test]
        public void Attack_WhenAttackAValidCellAlreadyAttacked_AmmoShouldBeThrowException() {

            // Arrange
            var dificulty = Dificulty.Easy;
            Game.Board = new Board(dificulty);
            Game.Board.BoardInitializer();
            Game.SetStarCannonAmmon(dificulty);
            var shipCooordinate = new Coordinate(Letter.C, 2);
            var attackCordinate1 = new Coordinate(Letter.C, 2);
            var attackCordinate2 = new Coordinate(Letter.C, 3);
            var attackCordinate3 = new Coordinate(Letter.C, 4);
            var attackCordinate4 = new Coordinate(Letter.C, 5);
            var direction = Axle.Horizontal;
            var ship = ShipType.Executor;
            Game.Board.SetShip(shipCooordinate, direction, ship);
            
            // Action
            Game.Attack(attackCordinate1);
            Game.Attack(attackCordinate2);
            Game.Attack(attackCordinate3);
            Game.Attack(attackCordinate4);
            
            // Assert
            Assert.Throws<CellHasBeenAttackedException>(() => Game.Attack(attackCordinate1));
        }
        
        [Test]
        public void IsGameOver_WhenPlayerNoHasAmmon_ShouldBeReturnFalse() {

            // Arrange
            var dificulty = Dificulty.Easy;
            Game.Board = new Board(dificulty);
            Game.Board.BoardInitializer();
            Game.StarCannonAmmo = 3;
            var shipCooordinate = new Coordinate(Letter.C, 2);
            var attackCordinate1 = new Coordinate(Letter.C, 2);
            var attackCordinate2 = new Coordinate(Letter.C, 3);
            var attackCordinate3 = new Coordinate(Letter.C, 4);
            var attackCordinate4 = new Coordinate(Letter.C, 5);
            var direction = Axle.Horizontal;
            var ship = ShipType.Executor;
            Game.Board.SetShip(shipCooordinate, direction, ship);
            
            // Action
            Game.Attack(attackCordinate1);
            Game.Attack(attackCordinate2);
            Game.Attack(attackCordinate3);

            // Assert
            Assert.IsTrue(Game.IsGameOver());
        }
    }
}
