using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_2_krepsinis
{
    /// <summary>
    /// Players container class
    /// </summary>
    internal class PlayersContainer
    {
        private Player[] Players;   // players array
        public int Count { get; private set; }      // players count
        public int Capacity { get; private set; }   // players array capacity

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="capacity">capacity</param>
        public PlayersContainer(int capacity = 16)
        {
            Count = 0;
            Capacity = capacity;
            Players = new Player[capacity];
        }

        /// <summary>
        /// Increases the array capacity if needed
        /// </summary>
        /// <param name="diffCapacity">different capacity</param>
        public void IncreaseCapacity(int diffCapacity)
        {
            if (diffCapacity > Capacity)
            {
                Player[] Temp = new Player[diffCapacity];
                for (int i = 0; i < Count; i++)
                {
                    Temp[i] = Players[i];
                }
                Players = Temp;
                Capacity = diffCapacity;
            }
        }

        /// <summary>
        /// Returns a player with the given index
        /// </summary>
        /// <param name="index">given index</param>
        /// <returns>player</returns>
        public Player GetPlayer(int index)
        {
            return Players[index];
        }

        /// <summary>
        /// Adds a player to the end an array
        /// </summary>
        /// <param name="player">player object</param>
        public void Add(Player player)
        {
            if (Count == Capacity)
            {
                IncreaseCapacity(Capacity * 2);
            }
            Players[Count++] = player;
        }

        /// <summary>
        /// Adds a player at the given place
        /// </summary>
        /// <param name="player">player object</param>
        /// <param name="index">index</param>
        public void Put(Player player, int index)
        {
            if (-1 < index && index < Count)
            {
                Players[index] = player;
            }
        }

        /// <summary>
        /// Inserts a player at the given place
        /// </summary>
        /// <param name="player">player object</param>
        /// <param name="index">index</param>
        public void InsertPlayer(Player player, int index)
        {
            if (-1 < index && index <= Count)
            {
                if (Capacity == Count)
                    IncreaseCapacity(Capacity * 2);
                for (int i = Count; i > index; i--)
                {
                    Players[i] = Players[i - 1];
                }
                Players[index] = player;
                Count++;
            }
        }

        /// <summary>
        /// Searches for the needed player in an array
        /// </summary>
        /// <param name="player">player object</param>
        /// <returns>player index</returns>
        public int PlayerIndex(Player player)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Players[i].Equals(player))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Removes a player from the array at the given index
        /// </summary>
        /// <param name="index">index</param>
        public void RemovePlayer(int index)
        {
            if (-1 < index && index < Count)
            {
                for (int i = index; i < Count - 1; i++)
                {
                    Players[i] = Players[i + 1];
                }
                Count--;
            }
        }

        /// <summary>
        /// Bubble sorting method which sorts the 
        /// elements of an array by their age (ascending)
        /// </summary>
        public void Bubble()
        {
            int i = 0;
            bool bk = true;
            while (bk)
            {
                bk = false;
                for (int j = Count - 1; j > i; j--)
                    if (Players[j] < Players[j - 1])
                    {
                        bk = true;
                        Player play = Players[j];
                        Players[j] = Players[j - 1];
                        Players[j - 1] = play;
                    }
                i++;
            }
        }
    }
}
