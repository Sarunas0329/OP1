using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_19
{
    internal class PlayerRegister
    {
        private List<Player> AllPlayers;
        int RoundNr { get; set; }
        DateTime Date { get; set; }

        public PlayerRegister()
        {
            AllPlayers = new List<Player>();
        }
        public PlayerRegister(List<Player> players)
        {
            AllPlayers = new List<Player>();
            foreach (Player player in players)
            {
                this.AllPlayers.Add(player);

            }
        }

        public void Add(Player player, int RoundNr, DateTime Date)
        {
            AllPlayers.Add(player);
            this.RoundNr = RoundNr;
            this.Date = Date;
        }
        public void Add(Player player)
        {
            AllPlayers.Add(player);
        }

        public int PlayerCount()
        {
            return this.AllPlayers.Count;
        }
        public Player GetPlayer(int index)
        {
            return AllPlayers[index];
        }
        public int GetRound()
        {
            return RoundNr;
        }
        public DateTime GetDate()
        {
            return Date;
        }

        /// <summary>
        /// Finds the sum of assists of the chosen team
        /// </summary>
        /// <param name="team">The name of the team</param>
        /// <returns>Chosen teams sum of assists</returns>
        public int FindTeamScore(string team)
        {
            int sum = 0;

            for (int i = 0; i < AllPlayers.Count(); i++)
            {
                if (AllPlayers[i].Team == team)
                {
                    sum += AllPlayers[i].Assists;
                }
            }

            return sum;
        }
        /// <summary>
        /// Creates a list of players champions
        /// </summary>
        /// <returns>A filtered list of players champions</returns>
        public PlayerRegister FindUsedChampions()
        {
            int x = 0;
            PlayerRegister Filtered = new PlayerRegister();
            foreach (Player player in AllPlayers)
            {
                for (int i = 0; i < Filtered.PlayerCount(); i++)
                {
                    if (Filtered.AllPlayers[i].Champion.Contains(player.Champion))
                    {
                        x++;
                    }
                }
                if (x == 0)
                {
                    Filtered.Add(player);
                }
                x = 0;
            }
            return Filtered;
        }

        /// <summary>
        /// Finds the index of the best player by kills and assists
        /// </summary>
        /// <param name="players2">Second register of players</param>
        /// <returns>The index of the best player</returns>
        public int FindBestPlayerIndex(PlayerRegister players2)
        {
            int max = 0;
            int index = 0;
            for (int i = 0; i < PlayerCount(); i++)
            {
                for (int j = 0; j < PlayerCount(); j++)
                {
                    if (AllPlayers[i].Equals(players2.GetPlayer(j)))
                    {
                        int sum = AllPlayers[i].Assists + AllPlayers[i].Kills + players2.GetPlayer(j).Kills + players2.GetPlayer(j).Assists;
                        if (sum > max)
                        {
                            max = sum;
                            index = j;

                        }
                    }
                }
            }
            return index;
        }
    }
}
