using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_19
{
    internal class InOutUtils
    {
        /// <summary>
        /// Reads the main data file of players
        /// </summary>
        /// <param name="fileName">Name of a data file</param>
        /// <returns>A list of players</returns>
        public static List<Player> ReadPlayers(string fileName)
        {
            List<Player> players = new List<Player>();
            string[] Lines = File.ReadAllLines(fileName);
            foreach(string Line in Lines)
            {
                string[] Values = Line.Split(' ');
                string name = Values[0];
                string lastName = Values[1];
                string team = Values[2];
                string position = Values[3];
                string champion = Values[4];
                int kills = int.Parse(Values[5]);
                int assists = int.Parse(Values[6]);

                Player player = new Player(name, lastName, team, position, champion, kills, assists);
                players.Add(player);
            }
            return players;
        }

        /// <summary>
        /// Prints champions that have assists to a CSV file
        /// </summary>
        /// <param name="fileName">Name of a data file</param>
        /// <param name="players">A list of players information</param>
        public static void PrintChampionsToCSVFile(string fileName, List<Player> players)
        {
            string[] lines = new string[players.Count + 1];
            lines[0] = String.Format("{0}", "Champion");
            for (int i = 0; i < players.Count; i++)
            {
                lines[i + 1] = String.Format("{0}", players[i].Champion);
            }
            File.WriteAllLines(fileName, lines);
        }
        

        /// <summary>
        /// Prints the starting file to the console
        /// </summary>
        /// <param name="players">A list of players information</param>
        public static void PrintFiles(List<Player> players, string filename)
        {
            string[] lines = new string[players.Count+3];
            lines[0]= String.Format("| {0,15} | {1,15} | {2,10} | {3,10} | {4,15} | {5,15} | {6,15} |", "Vardas" , "Pavarde", "Komanda", "Pozicija", "Cempionas", "Sunaikinimai", "Dalyvavimai");
            lines[1] = String.Format(new string('-', 116));
            for (int i = 0; i < players.Count; i++)
            {
                lines[i+2] = String.Format("| {0,-15} | {1,-15} | {2,-10} | {3,-10} | {4,-15} | {5,15:d} | {6,15:d} | ", players[i].Name, players[i].LastName, players[i].Team, players[i].Position, players[i].Champion, players[i].Kills, players[i].Assists);
            }
            lines[players.Count+1] = String.Format(new string('-', 116));

            File.WriteAllLines(filename, lines);
        }
       
        /// <summary>
        /// Prints the best Jungle players to the console
        /// </summary>
        /// <param name="bestJungle">A list of the best Jungle players</param>
        public static void PrintJungle(List<Player> bestJungle)
        {
            if (bestJungle.Count == 1)
            {
                Console.WriteLine("Aktyviausias Jungle zaidejas: ");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Aktyviausi Jungle zaidejai: ");
                Console.WriteLine();
            }
            for (int i = 0; i < bestJungle.Count; i++)
            {
                Console.WriteLine("{0} {1}", bestJungle[i].Name, bestJungle[i].LastName);
            }
        }

        /// <summary>
        /// Prints the best team
        /// </summary>
        /// <param name="players">List of players information</param>
        public static void PrintBestTeam( List<Player> players)
        {
            string[] bestTeam = new string[1];
            int sumRed = TaskUtils.FindRedTeamScore(players);
            int sumBlue = TaskUtils.FindBlueTeamScore(players);

            if (sumRed == sumBlue)
            {
                bestTeam = new string[2];
                bestTeam[0] = "Blue";
                bestTeam[1] = "Red";
            }
            else if (sumRed > sumBlue)
            {
                bestTeam[0] = "Blue";
            }
            else
            {
                bestTeam[0] = "Red";
            }

            if (bestTeam.Length == 1)
            {
                Console.WriteLine("Geriausia komanda: ");
                for (int j = 0; j < bestTeam.Length; j++)
                {
                    Console.WriteLine("{0}", bestTeam[j]);
                }
            }
            else
            {
                Console.WriteLine("Abieju komandu rezultatas buvo vienodas");
            }
        }
    }
}
