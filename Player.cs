using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_2_krepsinis
{
    /// <summary>
    /// Class to describe the data of one player
    /// </summary>
    internal class Player
    {
        /// <summary>
        /// Player name and surname
        /// </summary>
        public string NameSurname { get; set; }

        /// <summary>
        /// Player age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Player height
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="nameSur">player name</param>
        /// <param name="years">player age</param>
        /// <param name="size">player height</param>
        public Player(string nameSur, int years, double size) 
        {
            NameSurname = nameSur;
            Age = years;
            Height = size;
        }

        /// <summary>
        /// Overriden Object class method
        /// </summary>
        /// <returns>Concatenated string (all class properties)</returns>
        public override string ToString() 
        {
            string line;
            line = string.Format("{0, -20}   {1, 2}    {2, 3:f2}", NameSurname, Age, Height);
            return line;
        }

        /// <summary>
        /// Covered GetHashCode method
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode() 
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Compares two objects by age
        /// </summary>
        /// <param name="play1">first object</param>
        /// <param name="play2">second object</param>
        /// <returns>true or false</returns>
        public static bool operator >(Player play1, Player play2)
        {
            return play1.Age > play2.Age;
        }

        /// <summary>
        /// Compares two objects by age
        /// </summary>
        /// <param name="play1">first object</param>
        /// <param name="play2">second object</param>
        /// <returns>true or false</returns>
        public static bool operator <(Player play1, Player play2)
        {
            return play1.Age < play2.Age;
        }
    }
}
