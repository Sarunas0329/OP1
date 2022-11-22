using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3_19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string FILE_NAME = "Data.txt";
            const string CHAMPION_FILE = "Cempionai.csv";
            const string PLAYERCHANGE_FILE = "Pasikeitimai.csv";

            File.Delete(FILE_NAME);
            File.Delete(CHAMPION_FILE);
            File.Delete(PLAYERCHANGE_FILE);

            PlayerRegister players1 = InOutUtils.ReadPlayers(@"Players.csv");
            PlayerRegister players2 = InOutUtils.ReadPlayers(@"Players2.csv");                     

            Player bestJunglePlayer = players1.FindBestJungle(players2);
            InOutUtils.PrintBestJunglePlayer(bestJunglePlayer);
            Console.WriteLine();

            InOutUtils.PrintFiles(players1, FILE_NAME);
            InOutUtils.PrintFiles(players2, FILE_NAME);

            int index = players1.FindBestPlayerIndex(players2);
            InOutUtils.PrintBestPlayer(players2, index);

            PlayerRegister teamChanges = players1.FindTeamChanges(players2);
            PlayerRegister whoChanged = players1.FindWhoChanged(players2);
            PlayerRegister sortedTeam = whoChanged.SortedPlayers(teamChanges);
            sortedTeam.Sort();
            InOutUtils.PrintPlayersToCSVFile(PLAYERCHANGE_FILE, sortedTeam);

            int sumRed1 = players1.FindTeamScore("Red");
            int sumBlue1 = players1.FindTeamScore("Blue");
            int sumRed2 = players2.FindTeamScore("Red");
            int sumBlue2 = players2.FindTeamScore("Blue");
            InOutUtils.PrintBestTeam(players1, sumRed1, sumBlue1);
            InOutUtils.PrintBestTeam(players2, sumRed2, sumBlue2);
            Console.WriteLine();
            
            PlayerRegister Champions = players1.FindUsedChampions(players2);
            InOutUtils.PrintChampionsToCSVFile(CHAMPION_FILE, Champions);


        }
    }
}
