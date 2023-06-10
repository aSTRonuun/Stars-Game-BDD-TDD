using Domain.BoardDomain.Enums;
using Domain.BoardDomain.Exceptions;
using Domain.ShipDomain.Enuns;

namespace Domain.BoardDomain.Entities
{
    public class Board
    {
        public int Width;
        public char[,] Cells;

        public Board(Dificulty dificulty)
        {
            Width = (int)dificulty;
            Cells = new char[Width, Width];
        }

        public void BoardInitializer()
        {
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    Cells[i, j] = '~';
                }
            }
        }

        public void PrintBoard() {

            var columns  = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                                        'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T' };

            var rows = new List<string> { " 0 ", "  1  ", " 2 ", "  3  ", " 4 ", "  5  ", " 6 ", "  7  ", " 8 ", " 9 ",
                                            " 10 ", " 11 ", " 12 ", " 13 ", " 14 ", " 15 ", " 16 ", " 17 ", " 18 ", " 19 " };

            Console.WriteLine("   " + rows.Take(Width).Aggregate((a, b) => a + " " + b));
            for (var i = 0; i < Width; i++)
            {
                Console.Write(columns[i] + "   ");
                for (var j = 0; j < Width; j++)
                {
                    if (Cells[i, j] == 'S')
                    {
                        Console.Write('~' + "    ");
                    }
                    else if (Cells[i, j] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Cells[i, j] + "    ");
                        Console.ResetColor();
                    }
                    else if (Cells[i, j] == '@')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(Cells[i, j] + "    ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(Cells[i, j] + "    ");
                    }
                }
                Console.WriteLine();
            }
        }

        public bool SetShip(Coordinate startPoint, Axle axle, ShipType ship)
        {   
            if (startPoint.Line > Width || startPoint.Column > Width)
            {
                throw new CordenationIsOffTheBoarException();
            }

            if (axle == Axle.Vertical)
            {
                if (startPoint.Line + (int)ship > Width)
                {
                    throw new CordenationIsOffTheBoarException();
                }
                for (var i = startPoint.Line; i <= startPoint.Line + ((int)ship - 1); i++)
                {
                    if (Cells[i, startPoint.Column] == 'S')
                    {
                        throw new ShipAlreadyExistsInTheBoardException();
                    }
                }
                for (var i = startPoint.Line; i <= startPoint.Line + ((int)ship - 1); i++)
                {
                    Cells[i, startPoint.Column] = 'S';
                }
                return true;
            }
            if (axle == Axle.Horizontal)
            {
                if (startPoint.Column + (int)ship > Width)
                {
                    throw new CordenationIsOffTheBoarException();
                }
                for (var i = startPoint.Column; i <= startPoint.Column + ((int)ship - 1); i++)
                {
                    if (Cells[startPoint.Line, i] == 'S')
                    {
                        throw new ShipAlreadyExistsInTheBoardException();
                    }
                }
                for (var i = startPoint.Column; i <= startPoint.Column + ((int)ship - 1); i++)
                {
                    Cells[startPoint.Line, i] = 'S';
                }

                return true;
            }

            return true; 
        }

        public bool Attack(Coordinate coordinate) 
        {
            if (coordinate.Line > Width || coordinate.Column > Width)
            {
                throw new CordenationIsOffTheBoarException();
            }
            if (Cells[coordinate.Line, coordinate.Column] == 'X')
            {
                throw new CellHasBeenAttackedException();
            }
            if (Cells[coordinate.Line, coordinate.Column] == '~')
            {
                Cells[coordinate.Line, coordinate.Column] = '@';
                return false;
            }
            if (Cells[ coordinate.Line, coordinate.Column] == 'S')
            {
                Cells[ coordinate.Line, coordinate.Column] = 'X';
                return true;
            }
            return false;
        }

        public bool RandomSetShip(ShipType ship)
        {
            var random = new Random();
            var axle = (Axle)random.Next(0, 2);
            var column = random.Next(0, Width);
            var line = (Letter)random.Next(0, Width);
            var startPoint = new Coordinate(line, column);

            try
            {
                SetShip(startPoint, axle, ship);
                return true;
            }
            catch (CordenationIsOffTheBoarException)
            {
                return false;
            }
            catch (ShipAlreadyExistsInTheBoardException)
            {
                return false;
            }
        }

        public bool IsAllShipsDestroyed()
        {
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    if (Cells[i, j] == 'S')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}


