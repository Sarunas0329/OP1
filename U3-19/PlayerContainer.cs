using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3_19
{
    internal class PlayerContainer
    {

        Player[] players;
        public int Count { get; private set; }
        private int Capacity;
        public PlayerContainer(int capacity = 1)
        {
            this.Capacity = capacity;
            this.players = new Player[capacity];
        }
        public PlayerContainer(PlayerContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public void Add(Player player)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.players[this.Count++] = player;
        }


        public Player Get(int index)
        {
            return this.players[index];
        }
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
        public void Put(Player player, int indexWhere)
        {
            EnsureCapacity(Capacity * 2);
            this.players[indexWhere] = player;
        }


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
