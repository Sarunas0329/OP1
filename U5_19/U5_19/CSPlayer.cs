using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_19
{
    internal class CSPlayer : Player
    {
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public string Favorite { get; set; }

        public CSPlayer(string name, string lastName, string team, int kills, int deaths, string favorite) : base(name,lastName,team)
        {
            this.Kills = kills;
            this.Deaths = deaths;
            this.Favorite = favorite;
        }
        public override string ToString()
        {
            string line;
            line = String.Format("| {0,-15} | {1,-15} | {2,-17} | {3,-10} | {4,-15} | {5,10} | {6,-12} | {7,10} | {8,-22} | ", Name, LastName, Team, "No Data", "No Data", Kills, "No Data",Deaths, Favorite);
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
