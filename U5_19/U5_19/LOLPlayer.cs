using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_19
{
    internal class LOLPlayer : Player
    {
        public string Position { get; set; }
        public string Champion { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }

        public LOLPlayer(string name, string lastName, string team, string position, string champion, int kills, int deaths, int assists) : base(name, lastName,team)
        {
            this.Position = position;
            this.Champion = champion;
            this.Kills = kills;
            this.Deaths = deaths;
            this.Assists = assists;
        }

        public override string ToString()
        {
            string line;
            line = String.Format("| {0,-15} | {1,-15} | {2,-17} | {3,-10} | {4,-15} | {5,10} | {6,12} | {7,10} | {8,-22} | ", Name, LastName, Team, Position, Champion, Kills, Assists, Deaths, "No Data");
            return line;
        }
        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   Name == player.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public int CompareTo(LOLPlayer other)
        {
            int x = this.Team.CompareTo(other.Team);
            if (x == 0)
            {
                x = this.LastName.CompareTo(other.LastName);
                if (x == 0)
                {
                    x = this.Name.CompareTo(other.Name);
                }
            }
            return x;
        }
    }
}
