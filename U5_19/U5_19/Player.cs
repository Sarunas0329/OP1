using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_19
{
    public abstract class Player
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Team { get; set; }

        public Player(string name, string lastName, string team)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Team = team;
        }

        public override string ToString()
        {
            string line;
            line = String.Format("| {0,-15} | {1,-15} | {2, -17} | ", Name, LastName, Team);
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

        public int CompareTo(Player other)
        {
            int x = this.LastName.CompareTo(other.LastName);
            if (x == 0)
            {
                x = this.Name.CompareTo(other.Name);
            }
            return x;
        }
    }
}
