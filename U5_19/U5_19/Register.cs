using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace U5_19
{
    internal class Register
    {
        private Container AllPlayers;
        int RoundNr { get; set; }
        DateTime Date { get; set; }

        /// <summary>
        /// Creates an empty register
        /// </summary>
        public Register()
        {
            AllPlayers = new Container();
        }

        /// <summary>
        /// Adds a player, round and date to the register
        /// </summary>
        /// <param name="player">Information about a player</param>
        /// <param name="RoundNr">Round number</param>
        /// <param name="Date">Date of the round</param>
        public void Add(Player player, int RoundNr, DateTime Date)
        {
            AllPlayers.Add(player);
            this.RoundNr = RoundNr;
            this.Date = Date;
        }

        /// <summary>
        /// Adds a player to the register
        /// </summary>
        /// <param name="player">Information about a player</param>
        public void Add(Player player)
        {
            AllPlayers.Add(player);
        }

        /// <summary>
        /// Returns the count of players
        /// </summary>
        /// <returns>Count of players</returns>
        public int GetCount()
        {
            return AllPlayers.Count;
        }

        /// <summary>
        /// Returns a player at a set location
        /// </summary>
        /// <param name="index">The location of the player</param>
        /// <returns>A player</returns>
        public Player GetPlayer(int index)
        {
            return AllPlayers.Get(index);
        }

        /// <summary>
        /// Returns the number of the round
        /// </summary>
        /// <returns>Round number</returns>
        public int GetRound()
        {
            return RoundNr;
        }

        /// <summary>
        /// Returns the date of the round
        /// </summary>
        /// <returns>The date</returns>
        public DateTime GetDate()
        {
            return Date;
        }
        public bool Empty()
        {
            int x = 0;
            for (int i = 0; i < GetCount(); i++)
            {
                if (GetPlayer(i) != null)
                {
                    x++;
                }
            }
            return x == 0;
        }

        /// <summary>
        /// Finds the best League of Legends player
        /// </summary>
        /// <param name="best">Information about the best player</param>
        /// <returns>The best LOL player</returns>
        public Player FindBestLOLPLayer(Player best)
        {
            double bestKDA;
            if (best == null)
            {
                bestKDA = 0;
            }
            else
            {
                LOLPlayer lOLPlayer = (LOLPlayer)best;
                if(lOLPlayer.Deaths == 0)
                {
                    bestKDA = lOLPlayer.Kills + lOLPlayer.Assists;
                }
                else
                {
                    bestKDA = (double)(lOLPlayer.Kills + lOLPlayer.Assists) / (double)lOLPlayer.Deaths;
                } 
            }
            for (int i = 0; i < GetCount(); i++)
            {
                Player player1 = GetPlayer(i);
                if (player1 is LOLPlayer)
                {
                    double KDA = 0;
                    LOLPlayer player = (LOLPlayer)player1;
                    if(player.Deaths == 0)
                    {
                        KDA = player.Kills + player.Assists;
                    }
                    else
                    {
                        KDA = (double)(player.Kills + player.Assists) / (double)player.Deaths;
                    }
                    
                    if(KDA > bestKDA)
                    {
                        bestKDA = KDA;
                        best = player1;
                    }
                }
            }
            return best;
        }

        /// <summary>
        /// Finds the best CS player
        /// </summary>
        /// <param name="best">Information about the best player</param>
        /// <returns>The best CS player</returns>
        public Player FindBestCSPLayer(Player best)
        {
            double bestKD;
            if (best == null)
            {
                bestKD = 0;
            }
            else
            {
                CSPlayer Csplayer = (CSPlayer)best;
                if (Csplayer.Deaths == 0)
                {
                    bestKD = Csplayer.Kills;
                }
                else
                {
                    bestKD = (double)Csplayer.Kills / (double)Csplayer.Deaths;
                }
            }
            for (int i = 0; i < GetCount(); i++)
            {
                Player player1 = GetPlayer(i);
                if (player1 is CSPlayer)
                {
                    double KDA = 0;
                    CSPlayer player = (CSPlayer)player1;
                    if (player.Deaths == 0)
                    {
                        KDA = player.Kills;
                    }
                    else
                    {
                        KDA = (double)player.Kills / (double)player.Deaths;
                    }

                    if (KDA > bestKD)
                    {
                        bestKD = KDA;
                        best = player1;
                    }
                }
            }
            return best;
        }

        /// <summary>
        /// Creates a list of players champions
        /// </summary>
        /// <param name="Filtered">A register of champions</param>
        /// <returns>A list of champions</returns>
        public Register CreateUsedChampionsList(Register Filtered)
        {
            int x = 0;
            if(Filtered == null)
            {
                Filtered = new Register();
            }
            for (int i = 0; i < this.GetCount(); i++)
            {
                if (GetPlayer(i) is LOLPlayer)
                {
                    for (int j = 0; j < Filtered.AllPlayers.Count; j++)
                    {

                        LOLPlayer player1 = (LOLPlayer)Filtered.GetPlayer(j);
                        LOLPlayer player2 = (LOLPlayer)GetPlayer(i);
                        if (player1.Champion.Contains(player2.Champion))
                        {
                            x++;
                        }

                    }
                    if (x == 0)
                    {
                        Filtered.Add(GetPlayer(i));
                    }
                }
                x = 0;
            }
            return Filtered;
        }

        /// <summary>
        /// Creates a list of players
        /// </summary>
        /// <param name="List">A register of players</param>
        /// <returns>A register of players</returns>
        public Register CreatePlayerList(Register List)
        {
            int x = 0;
            if (List == null)
            {
                List = new Register();
            }
            for (int i = 0; i < this.GetCount(); i++)
            {
                for (int j = 0; j < List.AllPlayers.Count; j++)
                {

                    Player player1 = List.GetPlayer(j);
                    Player player2 = GetPlayer(i);
                    if (player1.Name.Contains(player2.Name))
                    {
                        if (player2.LastName.Contains(player1.LastName))
                        {
                            x++;
                        }
                    }

                }
                if (x == 0)
                {
                    List.Add(GetPlayer(i));
                }
                x = 0;
            }
            return List;
        }

        /// <summary>
        /// Creates a list of teams
        /// </summary>
        /// <param name="List">A register of teams</param>
        /// <returns>A register of teams</returns>
        public Register CreateTeamList(Register List)
        {
            int x = 0;
            if (List == null)
            {
                List = new Register();
            }
            for (int i = 0; i < this.GetCount(); i++)
            {
                for (int j = 0; j < List.AllPlayers.Count; j++)
                {

                    Player player1 = List.GetPlayer(j);
                    Player player2 = GetPlayer(i);
                    if (player1.Team.Contains(player2.Team))
                    {
                        x++;
                    }

                }
                if (x == 0)
                {
                    List.Add(GetPlayer(i));
                }
                x = 0;
            }
            return List;
        }

        /// <summary>
        /// Sorts a register
        /// </summary>
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.GetCount() - 1; i++)
                {
                    Player a = this.GetPlayer(i);
                    Player b = this.GetPlayer(i + 1);
                    if (a.CompareTo(b) > 0)
                    {
                        AllPlayers.Put(b, i);
                        AllPlayers.Put(a, i + 1);
                        flag = true;
                    }
                }
            }
        }
    }
}
