using Domain.BoardDomain.Enums;

namespace Domain.BoardDomain.Entities
{
    public class Coordinate
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Coordinate(Letter line, int column)
        {
            Line = (int)line;
            Column = column;
        }
    }
}
