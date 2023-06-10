using Domain.BoardDomain.Entities;
using Domain.BoardDomain.Enums;
using Domain.PlayerDomain.Entites;
using Domain.ShipDomain.Enuns;
using static System.Console;

namespace Domain.GameDomain.Entities
{
    public class Game
    {
        public Board Board { get; set; }
        public Player Player { get; set; }
        public int StarCannonAmmo { get; set; }
        
        public bool LoadBoard(Dificulty dificulty)
        {
            Board = new Board(dificulty);
            SetStarCannonAmmon(dificulty);

            Board.BoardInitializer();

            var listOfShips = new List<ShipType>()
            {
                ShipType.StartHunt_TIE_LN,
                ShipType.Millenium_Falcon,
                ShipType.Millenium_Falcon,
                ShipType.Destroyer,
                ShipType.Destroyer,
                ShipType.Executor
            };

            foreach (var ship in listOfShips)
            {
                while (true)
                {
                    if (Board.RandomSetShip(ship)) break;
                }
            }

            return true;
        }

        public bool LoadPlayer(string Name)
        {
            Player = new Player(Name);
            return true;
        }

        public void Start()
        {
            while (true) {
                Clear();
                if (IsGameOver())
                {
                    Write("Game Over! Press any key to continue...");
                    ReadKey(true);
                    break;
                };
                
                WriteLine($"Player: {Player.Name} | Chances: {StarCannonAmmo} | Score: {Player.Score}");
                
                Board.PrintBoard();
                    
                WriteLine("Attack a cell: (Ex: A1)");
                Write(">> ");
                var attack = ReadLine();
                if (string.IsNullOrWhiteSpace(attack))
                {
                    WriteLine("Invalid coordinate! Try again...");
                    ReadKey(true);
                    continue;
                }
                var attackX = attack[0];
                var attackY = attack.Substring(1);
                
                var coordinate = ConvertToCoordinate(attackX, attackY);
                if (coordinate == null)
                {
                    WriteLine("Invalid coordinate! Try again...");
                    ReadKey(true);
                    continue;
                }
                WriteLine($"Attack: {coordinate.Column} {coordinate.Line}");
                try
                {
                    WriteLine(Attack(coordinate) ? "You hit a ship!" : "You missed!");
                    ReadKey(true);
                }
                catch (Exception e)
                {
                    WriteLine("Attack failed! Try again...");
                    ReadKey(true);
                    continue;
                }
            }
        }
        
        private Coordinate ConvertToCoordinate(char line, string column)
        {
            try
            {
                var columnConvert = Int32.Parse(column);
                var lineConvert = (Letter)Enum.Parse(typeof(Letter), line.ToString());

                return new Coordinate(lineConvert, columnConvert);
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public bool Attack(Coordinate coordinate)
        {
            if (Board.Attack(coordinate))
            {
                Player.Score += 10;
                StarCannonAmmo--;
                return true;
            };
            StarCannonAmmo--;
            return false;
        }

        public void SetStarCannonAmmon(Dificulty dificulty)
        {
            switch (dificulty)
            {
                case Dificulty.Easy:
                    StarCannonAmmo = 50;
                    break;
                case Dificulty.Medium:
                    StarCannonAmmo = 45;
                    break;
                case Dificulty.Hard:
                    StarCannonAmmo = 40;
                    break;
            }
        }

        public bool IsGameOver() 
        {
            if (StarCannonAmmo == 0)
            {
                
                WriteLine("Game Over!");
                return true;
            }
            if (Board.IsAllShipsDestroyed())
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("You Win!");
                ResetColor();
                return true;
            }
            return false;
        }
    }
}
