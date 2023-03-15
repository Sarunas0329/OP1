using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_19
{
    internal class Container
    {
        private Player[] players;
        public int Count { get; private set; }
        private int Capacity;

        /// <summary>
        /// Creates an empty container
        /// </summary>
        /// <param name="capacity">Capacity of the container</param>
        public Container(int capacity = 1)
        {
            this.Capacity = capacity;
            this.players = new Player[capacity];

        }

        /// <summary>
        /// Adds a player to the container
        /// </summary>
        /// <param name="player">Information about a player</param>
        public void Add(Player player)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.players[this.Count++] = player;
        }

        /// <summary>
        /// Returns a player by index
        /// </summary>
        /// <param name="index">An index of which to return a player</param>
        /// <returns>A player by an index</returns>
        public Player Get(int index)
        {
            return this.players[index];
        }

        /// <summary>
        /// Finds if this container contains a player
        /// </summary>
        /// <param name="player">Information about a player</param>
        /// <returns>True or false if it contains the player</returns>
        public bool Contains(Player player)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.players[i].Equals(player))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Puts a player to an index location
        /// </summary>
        /// <param name="player">Information about a player</param>
        /// <param name="indexWhere">The location where to put a player</param>
        public void Put(Player player, int indexWhere)
        {
            this.players[indexWhere] = player;
        }

        /// <summary>
        /// Ensures if the capacity of the container is enough
        /// </summary>
        /// <param name="minimumCapacity">The minimum capacity of a container</param>
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Player[] temp = new Player[minimumCapacity];
                for (int i = 0; i < Count; i++)
                {
                    temp[i] = players[i];
                }
                this.Capacity = minimumCapacity;
                this.players = temp;
            }
        }
    }
}
