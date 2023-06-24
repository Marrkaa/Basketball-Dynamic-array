using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
/*--------------------------------------------------------------------------------------------
    U1-2. Krepšinis.
Krepšinio mokykloje treniruotes lankančių sąrašas yra tekstiniame faile: būsimo krepšininko 
vardas ir pavardė, amžius ir ūgis. Pirmoje eilutėje yra krepšinio mokyklos pavadinimas. Turime 
dviejų mokyklų duomenis.
Skaičiavimai:
    Raskite, koks būsimų krepšininkų amžiaus vidurkis ir koks ūgio vidurkis kiekvienoje 
    mokykloje.
    Surašykite į atskirą rinkinį visus abiejų mokyklų sportininkus, kurių ūgis didesnis už 
    vidurkį.
    Surikiuokite rezultatų sąrašą amžiaus didėjimo tvarka.
    Pašalinkite iš rezultatų sąrašo krepšininkus, kurių amžius yra didesnis už nurodytą 
    klaviatūra.
Reikalavimai programai:
    Grafinė vartotojo sąsaja(GVS);
    Duomenų klasė(savybės, konstruktorius su parametrais, metodai CompareTo ir ToString);
    Visų veiksmų rezultatus užrašyti rezultatų faile ir parodyti ekrane(sąsajoje);
--------------------------------------------------------------------------------------------*/

namespace U1_2_krepsinis
{
    public partial class Form1 : Form
    {
        const string CFd1 = "..\\..\\players.txt";      // the name of the first data file
        const string CFd2 = "..\\..\\new_players.txt";  // the name of the second data file
        const string CFr = "..\\..\\results.txt";       // the name of the results file
        string playerAge;
        PlayersContainer PlayContainer1, PlayContainer2;

        public Form1()
        {
            InitializeComponent();
            results.Enabled = false;
            input.Enabled = false;
            input_age.Enabled = true;

            if (File.Exists(CFr))
                File.Delete(CFr);
        }

        //=========================================================================
        // GRAPHIC USER INTERFACE METHODS
        //=========================================================================

        /// <summary>
        /// Actions of the "Įvesti amžių" menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void input_age_Click(object sender, EventArgs e)
        {
            ageLabel.Text = "Amžius";
            playerAge = age.Text;
            input.Enabled = true;
            output.Text = "Amžius sėkmingai įvestas!";
        }

        /// <summary>
        /// Actions of the "Įvesti" menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void input_Click(object sender, EventArgs e)
        {
            string school1, school2;

            PlayContainer1 = ReadPlayersContainer(CFd1, out school1);
            PlayContainer2 = ReadPlayersContainer(CFd2, out school2);
            
                PrintPlayerContainer(CFr, PlayContainer1, school1);
                PrintAverage(CFr, PlayContainer1, school1 + " žaidėjų vidutinis " +
                    "amžius ir ūgis:");
                PrintPlayerContainer(CFr, PlayContainer2, school2);
                PrintAverage(CFr, PlayContainer2, school2 + " žaidėjų vidutinis " +
                    "amžius ir ūgis:");

                PlayersContainer NewPlayersContainer = new PlayersContainer();
                FormatNew(NewPlayersContainer, PlayContainer1);
                FormatNew(NewPlayersContainer, PlayContainer2);

                if (NewPlayersContainer.Count > 0)
                {
                    PrintPlayerContainer(CFr, NewPlayersContainer, "Naujai suformuotas " +
                        "žaidėjų sąrašas");
                }
                else
                {
                    using (var fr = new StreamWriter(File.Open(CFr, FileMode.Append)))
                    {
                        fr.WriteLine("Nėra žaidėjų atitinkančių sąlygą!!!");
                    }
                }

                NewPlayersContainer.Bubble();

                if (NewPlayersContainer.Count > 0)
                {
                    PrintPlayerContainer(CFr, NewPlayersContainer, "Surikiuotas " +
                    "rezultatų sąrašas");
                }
                else
                {
                    using (var fr = new StreamWriter(File.Open(CFr, FileMode.Append)))
                    {
                        fr.WriteLine("Nėra žaidėjų atitinkančių sąlygą!!!");
                    }
                }

                Remove(NewPlayersContainer, playerAge);

                if (NewPlayersContainer.Count > 0)
                {
                    PrintPlayerContainer(CFr, NewPlayersContainer, "Surikiuotas rezultatų " +
                        "sąrašas su išmestais žaidėjais");
                }
                else
                {
                    using (var fr = new StreamWriter(File.Open(CFr, FileMode.Append)))
                    {
                        fr.WriteLine("Visi naujai sudaryto sąrašo žaidėjai pašalinti!!!");
                    }
                }

                output.Clear();
                output.Text = "Duomenys sėkmingai įvesti!";

            results.Enabled = true;
        }

        /// <summary>
        /// Actions of the "Rezultatai" menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void results_Click(object sender, EventArgs e)
        {
            string frez = File.ReadAllText(CFr);
            output.Clear();
            output.Text += frez;
            output.Text += "Programa baigė darbą!";
        }

        /// <summary>
        /// Actions of the "Baigti" menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void end_Click(object sender, EventArgs e)
        {
            Close();
        }

        //===================================================================
        // USER METHODS
        //===================================================================

        /// <summary>
        /// Reads player data from a file
        /// </summary>
        /// <param name="fn">file name</param>
        /// <param name="schoolName">school name</param>
        /// <returns>container object</returns>
        static PlayersContainer ReadPlayersContainer(string fn, out string schoolName) 
        {
            PlayersContainer PlayContainer = new PlayersContainer();
            using (StreamReader reader = new StreamReader(fn)) 
            {
                string line;
                schoolName = reader.ReadLine();
                while ((line = reader.ReadLine()) != null) 
                {
                    string[] parts = line.Split(';');
                    string nameSurname = parts[0];
                    int age = int.Parse(parts[1]);
                    double height = double.Parse(parts[2]);
                    Player player = new Player(nameSurname, age, height);
                    PlayContainer.Add(player);
                }
            }
            return PlayContainer;
        }

        /// <summary>
        /// Prints player data
        /// </summary>
        /// <param name="fn">file name</param>
        /// <param name="PlayContainer">players container</param>
        /// <param name="comment">a comment</param>
        static void PrintPlayerContainer(string fn, 
            PlayersContainer PlayContainer, string comment) 
        {
            const string header = 
                        "--------------------------------------\r\n"
                      + " Nr. Pavardė ir vardas   Amžius  Ūgis \r\n"
                      + "--------------------------------------";
            using (StreamWriter fr = new StreamWriter(File.Open(fn, FileMode.Append))) 
            {
                if (PlayContainer.Count > 0)
                {
                    fr.WriteLine("\n " + comment);
                    fr.WriteLine(header);
                    for (int i = 0; i < PlayContainer.Count; i++)
                    {
                        Player player = PlayContainer.GetPlayer(i);
                        fr.WriteLine("{0, 3} {1}", i + 1, player);
                    }
                    fr.WriteLine("--------------------------------------\n"); 
                }
                else
                    fr.WriteLine("Tuščias duomenų failas!");
            }
        }

        /// <summary>
        /// Finds the average age of all players
        /// </summary>
        /// <param name="PlayContainer">players container</param>
        /// <returns>average age</returns>
        static double AverageAge(PlayersContainer PlayContainer) 
        {
            double sum = 0;
            for (int i = 0; i < PlayContainer.Count; i++) 
            {
                sum += PlayContainer.GetPlayer(i).Age;
            }
            return sum / PlayContainer.Count;
        }

        /// <summary>
        /// Finds the average height of all players
        /// </summary>
        /// <param name="PlayContainer">players container</param>
        /// <returns>average height</returns>
        static double AverageHeight(PlayersContainer PlayContainer) 
        {
            double sum = 0;
            for (int i = 0; i < PlayContainer.Count; i++)
            {
                sum += PlayContainer.GetPlayer(i).Height;
            }   
            return sum / PlayContainer.Count;
        }

        /// <summary>
        /// Prints answers about average age and height
        /// </summary>
        /// <param name="fn">file name</param>
        /// <param name="PlayContainer">players container</param>
        /// <param name="comment">a comment</param>
        static void PrintAverage(string fn, 
            PlayersContainer PlayContainer, string comment) 
        {
            using (StreamWriter fr = new StreamWriter(File.Open(fn, FileMode.Append))) 
            {
                if (PlayContainer.Count > 0 && AverageAge(PlayContainer) > 0 
                    && AverageHeight(PlayContainer) > 0)
                { 
                fr.WriteLine(comment);
                fr.WriteLine("{0, 2:f0} metai, {1, 3:f2} metrai", 
                    AverageAge(PlayContainer), AverageHeight(PlayContainer));
                }
                else
                    fr.WriteLine("Klaida duomenyse!");
            }
        }

        /// <summary>
        /// Formats a new list from two other lists
        /// </summary>
        /// <param name="NewPlayersContainer">new players container</param>
        /// <param name="PlayersCont">players container</param>
        static void FormatNew(PlayersContainer NewPlayersContainer, 
                              PlayersContainer PlayersCont) 
        {
            int index = NewPlayersContainer.Count;
            for (int i = 0; i < PlayersCont.Count; i++) 
            {
                if (PlayersCont.GetPlayer(i).Height > AverageHeight(PlayersCont))
                {
                    NewPlayersContainer.InsertPlayer(PlayersCont.GetPlayer(i), index);
                }
            }
        }

        /// <summary>
        /// Removes players which are older than the provided age
        /// </summary>
        /// <param name="PlayersCont">players container</param>
        /// <param name="age">age</param>
        static void Remove(PlayersContainer PlayersCont, string age) 
        {
            int playerAge = Convert.ToInt32(age);
            for (int i = 0; i < PlayersCont.Count; i++) 
            {
                if (PlayersCont.GetPlayer(i).Age > playerAge) 
                {
                    PlayersCont.RemovePlayer(PlayersCont.PlayerIndex
                        (PlayersCont.GetPlayer(i)));
                    i--;
                }
            }
        }

        // End USER METHODS
    }
}
