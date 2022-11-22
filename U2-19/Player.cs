using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_19
{
    internal class Player
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Team { get; set; }
        public string Position { get; set; }
        public string Champion { get; set; }
        public int Kills { get; set; }
        public int Assists { get; set; }

        public Player(string name, string lastName, string team, string position, string champion, int kills, int assists)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Team = team;
            this.Position = position;
            this.Champion = champion;
            this.Kills = kills;
            this.Assists = assists;
        }
        public override string ToString()
        {
            string line;
            line = String.Format("| {0,-15} | {1,-15} | {2,-10} | {3,-10} | {4,-15} | {5,15:d} | {6,15:d} | ", Name, LastName, Team, Position, Champion, Kills, Assists);
            return line;
        }

        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   Name == player.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
