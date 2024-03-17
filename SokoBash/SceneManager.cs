using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokoBash
{
    internal class SceneManager
    {
        private LevelManager levelManager;

        public SceneManager(string dir)
        {
            levelManager = new LevelManager(dir);
        }

        public void ShowTitleScreen()
        {
            string TitleScreenText =
            "  ██████      ██████    ██      ██    ██████  \r\n██      ██  ██      ██  ██    ██    ██      ██\r\n██          ██      ██  ██  ██      ██  ██████\r\n  ██████    ██      ██  ████        ██  ██  ██\r\n        ██  ██      ██  ██  ██      ██  ██████\r\n██      ██  ██      ██  ██    ██    ██        \r\n  ██████      ██████    ██      ██    ██████  \r\n                                              \r\n▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\r\n                                              \r\n████████      ██████      ██████    ██      ██\r\n██      ██  ██      ██  ██      ██  ██      ██\r\n██      ██  ██      ██  ██          ██      ██\r\n████████    ██████████    ██████    ██████████\r\n██      ██  ██      ██          ██  ██      ██\r\n██      ██  ██      ██  ██      ██  ██      ██\r\n████████    ██      ██    ██████    ██      ██\r\n                                              \r\n                                              \r\n                                              \r\n-----------[ PRESS ENTER TO PLAY! ]-----------\r\n                                              \r\n                                              \r\n              J. Schwärzler 2023               ";
            //Console.WindowHeight = 24;
            //Console.BufferHeight = 24;
            //Console.WindowWidth = 46;
            Console.CursorVisible = false;
            Console.Clear();
            Console.Write(TitleScreenText);
        }

        public int ShowLevelSelect()
        {
            bool success = false;
            while (!success)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the level select!");
                Console.Write("Enter Level Index: ");
                try
                {
                    int inputIndex = Int32.Parse(Console.ReadLine());
                    return inputIndex;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Not a valid number!");
                    Console.WriteLine("...press any key to retry");
                    Console.ReadKey();
                }
                catch (System.NullReferenceException)
                {
                    Console.WriteLine($"Invalid Index. That level does not exist!");
                    Console.WriteLine("...press any key to retry");
                    Console.ReadKey();

                }
            }
            return 0;
        }

        public void ShowLevels(int startingLevelIndex)
        {
            int beatCount = startingLevelIndex;
            do
            {
                levelManager.LoadLevel(beatCount);
                levelManager.StartLoadedLevel();
                beatCount++;

            } while (beatCount < levelManager.LevelFileQueueLength);
        }

        public void ShowCredits()
        {
            //Console.WindowHeight = 17;
            //Console.BufferHeight = 17;
            //Console.WindowWidth = 24;
            Console.CursorVisible = false;
            Console.Clear();
            string text = "      -- SokoBash --\r\n\r\nEin Spiel gemacht als\r\nProjektarbeit der Robert\r\nBosch Schule.\r\n\r\nAutor:\r\n--- Jonas Schwärzler\r\n\r\nKlasse:\r\n--- 2BKI2\r\n\r\nBetreuer:\r\n--- Herr Geng\r\n\r\n\r\nDanke fürs Spielen!";
            Console.Write(text);
            while (true) { }
        }
        

        // Implement Level Select
    }
}
