using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_19
{
    internal class Program
    {
        static void Main(string[] args)
        {

            PlayerRegister players1 = InOutUtils.ReadPlayers(@"Players.csv");
            PlayerRegister players2 = InOutUtils.ReadPlayers(@"Players2.csv");
            
            if (File.Exists(@"Data.txt"))
            {
                File.Delete(@"Data.txt");
            }
            InOutUtils.PrintFiles(players1, @"Data.txt");
            InOutUtils.PrintFiles(players2, @"Data.txt");

            int index = players1.FindBestPlayerIndex(players2);
            InOutUtils.PrintBestPlayer(players2, index);


            int sumRed1 = players1.FindTeamScore("Red");
            int sumBlue1 = players1.FindTeamScore("Blue");
            int sumRed2 = players2.FindTeamScore("Red");
            int sumBlue2 = players2.FindTeamScore("Blue");
            InOutUtils.PrintBestTeam(players1, sumRed1,sumBlue1);
            InOutUtils.PrintBestTeam(players2, sumRed2, sumBlue2);
            Console.WriteLine();

            if (File.Exists(@"Cempionai.csv"))
            {
                File.Delete(@"Cempionai.csv");
            }
            PlayerRegister Champions = players1.FindUsedChampions();
            PlayerRegister Champions1 = players2.FindUsedChampions();
            InOutUtils.PrintChampionsToCSVFile("Cempionai.csv", Champions, 0);
            InOutUtils.PrintChampionsToCSVFile("Cempionai.csv", Champions1, 1);

        }
    }
}
