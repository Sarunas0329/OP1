using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_19
{
    internal class InOutUtils : Object
    {
        /// <summary>
        /// Reads the main data file of players
        /// </summary>
        /// <param name="fileName">Name of a data file</param>
        /// <returns>Player and round information to the register</returns>
        public static PlayerRegister ReadPlayers(string fileName)
        {
            PlayerRegister players = new PlayerRegister();

            string[] Lines = File.ReadAllLines(fileName);
            int round = int.Parse(Lines[0]);
            DateTime date = DateTime.Parse(Lines[1]);
            foreach (string Line in Lines.Skip(2))
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
                players.Add(player, round, date);
            }
            return players;
        }

        /// <summary>
        /// Prints champions that have assists to a CSV file
        /// </summary>
        /// <param name="fileName">Name of a data file</param>
        /// <param name="players">A register of players</param>
        /// <param name="x">A number which shows if the file has been started or not(0;1)</param>
        public static void PrintChampionsToCSVFile(string fileName, PlayerRegister players, int x)
        {
            string[] lines = new string[players.PlayerCount() + 1];
            if(x == 0)
            {
                lines[0] = String.Format("{0}", "Champion");
                for (int i = 0; i < players.PlayerCount(); i++)
                {
                    lines[i + 1] = String.Format("{0}", players.GetPlayer(i).Champion);
                }
            }
            else
            {
                for (int i = 0; i < players.PlayerCount(); i++)
                {
                    lines[i] = String.Format("{0}", players.GetPlayer(i).Champion);
                }
            }

            
            File.AppendAllLines(fileName, lines);
        }

        /// <summary>
        /// Prints the starting file to the console
        /// </summary>
        /// <param name="players">A register of players</param>
        /// <param name="filename">Name of a data file</param>
        public static void PrintFiles(PlayerRegister players, string filename)
        {
            
            string[] lines = new string[players.PlayerCount() + 4];
            lines[0] = String.Format("| {0} {1} {2:yyyy-MM-dd}", "Round", players.GetRound(), players.GetDate());
            lines[1] = String.Format("| {0,15} | {1,15} | {2,10} | {3,10} | {4,15} | {5,15} | {6,15} |", "Vardas", "Pavarde", "Komanda", "Pozicija", "Cempionas", "Sunaikinimai", "Dalyvavimai");
            lines[2] = String.Format(new string('-', 116));
            for (int i = 0; i < players.PlayerCount(); i++)
            {
                lines[i + 3] = players.GetPlayer(i).ToString();
            }
            lines[players.PlayerCount() + 3] = String.Format(new string('-', 116));

            File.AppendAllLines(filename, lines);
        }


        /// <summary>
        /// Prints the best team
        /// </summary>
        /// <param name="players">A register of players</param>
        public static void PrintBestTeam(PlayerRegister players, int sumRed, int sumBlue)
        {
            string[] bestTeam = new string[1];

            if (sumRed == sumBlue)
            {
                bestTeam = new string[2];
                bestTeam[0] = "Blue";
                bestTeam[1] = "Red";
            }
            else if (sumRed < sumBlue)
            {
                bestTeam[0] = "Blue";
            }
            else
            {
                bestTeam[0] = "Red";
            }

            if (bestTeam.Length == 1)
            {
                Console.WriteLine("Best teams: ");
                for (int j = 0; j < bestTeam.Length; j++)
                {
                    Console.WriteLine("{0} round best team: {1}",players.GetRound(), bestTeam[j]);
                }
            }
            else
            {
                Console.WriteLine("{0} round both teams ended with the same score",players.GetRound());
            }
        }

        /// <summary>
        /// Prints the best player to the console
        /// </summary>
        /// <param name="players">A register of players</param>
        /// <param name="index">The index of the best player</param>
        public static void PrintBestPlayer(PlayerRegister players, int index)
        {
            Console.WriteLine("The best player regarding kills and assists is: ");
            Console.WriteLine("| {0,15} | {1,15} | {2,10} | {3,10} | {4,15} |", "Vardas", "Pavarde", "Komanda", "Pozicija", "Cempionas");
            Console.WriteLine(new string('-', 81));
            Console.WriteLine("| {0,15} | {1,15} | {2,10} | {3,10} | {4,15} |", players.GetPlayer(index).Name, players.GetPlayer(index).LastName, players.GetPlayer(index).Team, players.GetPlayer(index).Position, players.GetPlayer(index).Champion);
            Console.WriteLine(new string('-', 81));
        }
    }
}
