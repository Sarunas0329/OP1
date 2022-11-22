using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace U1_19
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
    }
}
