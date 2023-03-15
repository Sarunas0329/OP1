using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace U5_19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string KOMANDOS = "Komandos.csv";
            const string VISI = "Visi.csv";
            const string CEMPIONAI = "Cempionai.csv";
            const string DATA = "Data.txt";
            File.Delete(DATA);
            File.Delete(CEMPIONAI);
            File.Delete(VISI);
            File.Delete(KOMANDOS);

            Register register1 = InOut.ReadPlayers(@"Players1.csv");
            Register register2 = InOut.ReadPlayers(@"Players2.csv");
            Register register3 = InOut.ReadPlayers(@"Players3.csv");

            Player bestLOLPLayer = register1.FindBestLOLPLayer(null);
            bestLOLPLayer = register2.FindBestLOLPLayer(bestLOLPLayer);
            bestLOLPLayer = register3.FindBestLOLPLayer(bestLOLPLayer);
            if (bestLOLPLayer != null)
            {
                Console.WriteLine("Best LOL player: ");
                Console.WriteLine((new string('-', 57)));
                Console.WriteLine("| {0,-15} | {1,-15} | {2, -17} | ", bestLOLPLayer.Name, bestLOLPLayer.LastName, bestLOLPLayer.Team);
                Console.WriteLine((new string('-', 57)));
            }
            else
            {
                Console.WriteLine("Nerasta zaidejo");
            }

            Player bestCSPLayer = register1.FindBestCSPLayer(null);
            bestCSPLayer = register2.FindBestCSPLayer(bestCSPLayer);
            bestCSPLayer = register3.FindBestCSPLayer(bestCSPLayer);
            if (bestCSPLayer != null)
            {

                Console.WriteLine("Best CS player: ");
                Console.WriteLine((new string('-', 57)));
                Console.WriteLine("| {0,-15} | {1,-15} | {2, -17} | ", bestCSPLayer.Name, bestCSPLayer.LastName, bestCSPLayer.Team);
                Console.WriteLine((new string('-', 57)));
            }

            InOut.PrintFiles(register1, DATA);
            InOut.PrintFiles(register2, DATA);
            InOut.PrintFiles(register3, DATA);

            Register TeamList = register1.CreateTeamList(null);
            TeamList = register2.CreateTeamList(TeamList);
            TeamList = register3.CreateTeamList(TeamList);
            if (!TeamList.Empty())
            {
                InOut.PrintTeamsToCSVFile(KOMANDOS, TeamList);
            }
            else
            {
                Console.WriteLine("Nera komandu");
            }

            Register PlayerList = register1.CreatePlayerList(null);
            PlayerList = register2.CreatePlayerList(PlayerList);
            PlayerList = register3.CreatePlayerList(PlayerList);
            if (!PlayerList.Empty())
            {
                PlayerList.Sort();
                InOut.PrintPlayersToCSVFile(VISI, PlayerList);
            }
            else
            {
                Console.WriteLine("Nera zaideju");
            }

            Register ChampionsList = register1.CreateUsedChampionsList(null);
            ChampionsList = register2.CreateUsedChampionsList(ChampionsList);
            ChampionsList = register3.CreateUsedChampionsList(ChampionsList);
            if (!ChampionsList.Empty())
            {
                InOut.PrintChampionsToCSVFile(CEMPIONAI, ChampionsList);
            }
            else
            {
                Console.WriteLine("Nera cempionu");
            }
        }
    }
}
