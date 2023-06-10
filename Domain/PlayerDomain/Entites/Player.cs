using System.Text.RegularExpressions;
using Domain.PlayerDomain.Execptions;

namespace Domain.PlayerDomain.Entites
{
    public class Player
    {
        public string Name { get; set; } = string.Empty;
        public int Score { get; set; }

        public Player(string name)
        {
            if (name.Length <= 0 || name.Length > 20)
                throw new InvalidNameLengthException();

            if (Regex.IsMatch(name, @"^[a-zA-Z0-9]+$") == false)
                throw new InvalidCharactersNameException();

            Name = name;
            Score = 0;
        }
    }
}
