using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_19
{
    internal class TaskUtils
    {

        /// <summary>
        /// Finds the maximum number of kills + assists that Jungle players have
        /// </summary>
        /// <param name="players">A list of players information</param>
        /// <returns>Maximum number of kills + assists</returns>
        public static Player FindJungleKA(List<Player> players)
        {
            List<Player> bestJungle = new List<Player>();
            Player max = players[0];

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Position.Equals("Jungle"))
                {
                    if(max.Position.Equals("Jungle"))
                    {
                        if (players[i].Kills + players[i].Assists >= max.Kills+max.Assists)
                            {
                                max = players[i];
                            }
                    }
                    else
                    {
                        max = players[i];
                    }
                    
                }
            }

            return max;
        }

        /// <summary>
        /// Creates a list of Jungle players who have the maximum ammount of kills + assists
        /// </summary>
        /// <param name="max">Maximum number of kills + assists</param>
        /// <param name="players">A list of players information</param>
        /// <returns>A new list of the best Jungle players</returns>
        public static List<Player> ReturnFilteredJungle(Player max, List<Player> players)
        {
            List<Player> bestJungle = new List<Player>();

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Position.Equals("Jungle"))
                {
                    if (players[i].Kills + players[i].Assists == max.Kills + max.Assists)
                    {
                        bestJungle.Add(players[i]);
                    }
                }
            }

            return bestJungle;
        }

        /// <summary>
        /// Finds the sum of assists of the red team
        /// </summary>
        /// <param name="players">A list of players information</param>
        /// <returns>Red teams sum of assists</returns>
        public static int FindRedTeamScore(List<Player> players)
        {
            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                if (players[i].Team == "Red")
                {
                    sum += players[i].Assists;
                }
            }

            return sum;
        }

        /// <summary>
        /// Finds the sum of assists of the blue team
        /// </summary>
        /// <param name="players">A list of players information</param>
        /// <returns>Blue teams sum of assists</returns>
        public static int FindBlueTeamScore(List<Player> players)
        {
            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                if (players[i].Team == "Blue")
                {
                    sum += players[i].Assists;
                }
            }

            return sum;
        }

        /// <summary>
        /// Creates a list of players that have assists
        /// </summary>
        /// <param name="players">A list of players information</param>
        /// <returns>A filtered list of players who have assists</returns>
        public static List<Player> FilterAssistPlayers(List<Player> players)
        {
            int x = 0;
            List<Player> Filtered = new List<Player>();
            foreach (Player player in players)
            {
                if(player.Assists > 0)
                {
                    for(int i = 0;i<Filtered.Count;i++)
                    {
                        if (Filtered[i].Champion.Contains(player.Champion))
                        {
                            x++;
                        }
                    }
                    if(x == 0)
                    {
                        Filtered.Add(player);
                    }
                    x = 0;
                    
                }
            }    

            return Filtered;
        }
    }
}
