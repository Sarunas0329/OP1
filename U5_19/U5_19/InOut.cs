using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace U5_19
{
    internal class InOut
    {
        /// <summary>
        /// Reads the main data file of players
        /// </summary>
        /// <param name="fileName">Name of a data file</param>
        /// <returns>Player and round information to the register</returns>
        public static Register ReadPlayers(string fileName)
        {
            Register players = new Register();

            string[] Lines = File.ReadAllLines(fileName);
            int round = int.Parse(Lines[0]);
            DateTime date = DateTime.Parse(Lines[1]);
            foreach (string Line in Lines.Skip(2))
            {
                string[] Values = Line.Split(' ');
                string name = Values[0];
                string lastName = Values[1];
                string team = Values[2];

                string position = "";
                string champion = "";
                string favorite = "";
                int kills = 0;
                int assists = 0;
                int deaths = 0;

                if (Values.Length > 6)
                {
                    position = Values[3];
                    champion = Values[4];
                    kills = int.Parse(Values[5]);
                    
                    deaths = int.Parse(Values[6]);
                    assists = int.Parse(Values[7]);
                }
                else
                {
                    kills = int.Parse(Values[3]);
                    deaths = int.Parse(Values[4]);
                    favorite = Values[5];
                }
                switch(Values.Length > 6)
                {
                    case true:
                        LOLPlayer LOLplayer = new LOLPlayer(name, lastName, team, position, champion, kills, deaths, assists);
                        players.Add(LOLplayer, round, date);
                        break;
                    case false:
                        CSPlayer CSplayer = new CSPlayer(name, lastName, team,kills,deaths,favorite);
                        players.Add(CSplayer, round, date);
                        break;
                }
            }
            return players;
        }

        /// <summary>
        /// Prints champions to a CSV file
        /// </summary>
        /// <param name="fileName">Name of a data file</param>
        /// <param name="players">A register of players</param>
        public static void PrintChampionsToCSVFile(string fileName, Register players)
        {
            string[] lines = new string[players.GetCount() + 1];

            for (int i = 0; i < players.GetCount(); i++)
            {
                LOLPlayer player = (LOLPlayer)players.GetPlayer(i);
                lines[i] = String.Format("{0}", player.Champion);
            }

            File.AppendAllLines(fileName, lines);
        }

        /// <summary>
        /// Prints all players to a new CSV file
        /// </summary>
        /// <param name="fileName">Name of a data file</param>
        /// <param name="players">A register of players</param>
        public static void PrintPlayersToCSVFile(string fileName, Register players)
        {
            string[] lines = new string[players.GetCount() + 1];

            for (int i = 0; i < players.GetCount(); i++)
            {
                lines[i] = String.Format("{0},{1}", players.GetPlayer(i).Name, players.GetPlayer(i).LastName);
            }

            File.AppendAllLines(fileName, lines);
        }

        /// <summary>
        /// Prints all teams to a new CSV file
        /// </summary>
        /// <param name="fileName">Name of a data file</param>
        /// <param name="players">A register of players</param>
        public static void PrintTeamsToCSVFile(string fileName, Register players)
        {
            string[] lines = new string[players.GetCount()];

            for (int i = 0; i < players.GetCount(); i++)
            {
                lines[i] = String.Format("{0}", players.GetPlayer(i).Team);
            }

            File.AppendAllLines(fileName, lines);
        }

        /// <summary>
        /// Prints the starting file to the console
        /// </summary>
        /// <param name="players">A register of players</param>
        /// <param name="filename">Name of a data file</param>
        public static void PrintFiles(Register players, string filename)
        {

            string[] lines = new string[players.GetCount() + 4];
            lines[0] = String.Format("| {0} {1} {2:yyyy-MM-dd} |", "Round", players.GetRound(), players.GetDate());
            lines[1] = String.Format("| {0,-15} | {1,-15} | {2,-17} | {3,-10} | {4,-15} | {5,-10} | {6,-12} | {7,-10} | {8,-22} | ", "Vardas", "Pavarde", "Komanda", "Pozicija", "Cempionas", "Nuzudymai", "Dalyvavimai" , "Mirtys", "Megstamiausias ginklas");
            lines[2] = String.Format(new string('-', 154));
            for (int i = 0; i < players.GetCount(); i++)
            {
                lines[i + 3] = players.GetPlayer(i).ToString();
            }
            lines[players.GetCount() + 3] = String.Format(new string('-', 154));

            File.AppendAllLines(filename, lines);
        }
    }
}
