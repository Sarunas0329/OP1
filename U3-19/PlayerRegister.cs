using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace U3_19
{
    internal class PlayerRegister
    {
        private PlayerContainer AllPlayers;
        int RoundNr { get; set; }
        DateTime Date { get; set; }

        public PlayerRegister()
        {
            AllPlayers = new PlayerContainer();
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
        public int GetCount()
        {
            return AllPlayers.Count;
        }
        public Player GetPlayer(int index)
        {
            return AllPlayers.Get(index);
        }
        public int GetRound()
        {
            return RoundNr;
        }
        public DateTime GetDate()
        {
            return Date;
        }
        public bool Contains(Player player)
        {
            return AllPlayers.Contains(player);
        }


        /// <summary>
        /// Finds the sum of assists of the chosen team
        /// </summary>
        /// <param name="team">The name of the team</param>
        /// <returns>Chosen teams sum of assists</returns>
        public int FindTeamScore(string team)
        {
            int sum = 0;

            for (int i = 0; i < AllPlayers.Count; i++)
            {
                if (AllPlayers.Get(i).Team == team)
                {
                    sum += AllPlayers.Get(i).Assists;
                }
            }

            return sum;
        }

        /// <summary>
        /// Finds the maximum number of kills + assists that Jungle players have
        /// </summary>
        /// <param name="players2">A list of players information from second data file</param>
        /// <returns>Maximum number of kills + assists</returns>
        public Player FindBestJungle(PlayerRegister players2)
        {
            Player max = players2.GetPlayer(0);

            for (int i = 0; i < players2.AllPlayers.Count; i++)
            {
                if (players2.GetPlayer(i).Position.Equals("Jungle"))
                {
                    if (max.Position.Equals("Jungle"))
                    {
                        if (players2.GetPlayer(i).Kills + players2.GetPlayer(i).Assists >= max.Kills + max.Assists)
                        {
                            max = players2.GetPlayer(i);
                        }
                    }
                    else
                    {
                        max = players2.GetPlayer(i);
                    }

                }
            }
            return max;
        }

        /// <summary>
        /// Creates a list of players champions
        /// </summary>
        /// <returns>A filtered list of players champions</returns>
        public PlayerRegister FindUsedChampions(PlayerRegister players2)
        {
            int x = 0;
            int y = 0;
            PlayerRegister Filtered = new PlayerRegister();
            for (int i = 0; i < this.GetCount(); i++)
            {
                for (int j = 0; j < Filtered.AllPlayers.Count; j++)
                {
                    if (Filtered.GetPlayer(j).Champion.Contains(this.GetPlayer(i).Champion))
                    {
                        x++;
                    }
                }
                for (int j = 0; j < Filtered.AllPlayers.Count; j++)
                {
                    if (Filtered.GetPlayer(j).Champion.Contains(players2.GetPlayer(i).Champion))
                    {
                        y++;
                    }
                }
                if (x == 0)
                {
                    Filtered.AllPlayers.Add(AllPlayers.Get(i));
                }
                if(y == 0)
                {
                    Filtered.AllPlayers.Add(players2.GetPlayer(i));
                }
                y = 0;
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
            for (int i = 0; i < AllPlayers.Count; i++)
            {
                for (int j = 0; j < AllPlayers.Count; j++)
                {
                    if (AllPlayers.Get(i).Equals(players2.AllPlayers.Get(j)))
                    {
                        Player player1 = AllPlayers.Get(i);
                        Player player2 = players2.AllPlayers.Get(j);
                        int sum = player1.Assists + player1.Kills + player2.Kills +player2.Assists;
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
        public PlayerRegister FindTeamChanges(PlayerRegister players2)
        {
            PlayerRegister team = new PlayerRegister();
            int x = 0;
            for (int i = 0; i < AllPlayers.Count; i++)
            {
                Player player1 = AllPlayers.Get(i);
                for (int j = 0; j < players2.GetCount(); j++)
                {
                    Player player2 = players2.GetPlayer(j);
                    if (player1.Name.Contains(player2.Name) && player1.LastName.Contains(player2.LastName))
                    {
                        x++;
                    }

                }
                if (x == 0)
                {
                    team.AllPlayers.Add(player1);
                }
                x = 0;
            }
            return team;
        }
        public PlayerRegister FindWhoChanged(PlayerRegister players2)
        {
            PlayerRegister team = new PlayerRegister();
            int x = 0;
            for (int i = 0; i < AllPlayers.Count; i++)
            {
                Player player1 = players2.GetPlayer(i);
                for (int j = 0; j < players2.GetCount(); j++)
                {
                    Player player2 = AllPlayers.Get(j);
                    if (player1.Name.Contains(player2.Name) && player1.LastName.Contains(player2.LastName))
                    {
                        x++;
                    }

                }
                if (x == 0)
                {
                    team.AllPlayers.Add(player1);
                }
                x = 0;
            }
            return team;
        }
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.GetCount() - 1; i++)
                {
                    Player a = this.GetPlayer(i);
                    Player b = this.GetPlayer(i+1);
                    if (a.CompareTo(b) > 0)
                    {
                        AllPlayers.Put(b, i);
                        AllPlayers.Put(a, i+1);
                        flag = true;
                    }
                }
            }
        }
        public PlayerRegister SortedPlayers(PlayerRegister players)
        {
            PlayerRegister NewRegister = new PlayerRegister();

            for (int i = 0; i < this.GetCount(); i++)
            {
                Player player = this.GetPlayer(i);
                if (!NewRegister.Contains(player))
                {
                    NewRegister.Add(player);
                }
                for (int j = 0; j < players.GetCount(); j++)
                {
                    Player player1 = players.GetPlayer(j);
                    if (!NewRegister.Contains(player1))
                    {
                        NewRegister.Add(player1);
                    }
                }
            }
            return NewRegister;

        }
    }
}
