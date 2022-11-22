using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = InOutUtils.ReadPlayers(@"Players.csv");
            List<Player> bestJungle = TaskUtils.ReturnFilteredJungle(TaskUtils.FindJungleKA(players),players);

            InOutUtils.PrintFiles(players, @"Data.txt");

            InOutUtils.PrintJungle(bestJungle);
            Console.WriteLine();

            InOutUtils.PrintBestTeam(players);
            Console.WriteLine();

            List<Player> Champions = TaskUtils.FilterAssistPlayers(players);
            InOutUtils.PrintChampionsToCSVFile("Cempionai.csv", Champions);


        }
    }
}
