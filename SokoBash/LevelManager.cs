using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using SokoBash.Utils;
using SokoBash.Elements;
using System.Xml.Linq;
using SokoBash.Tiles;

namespace SokoBash
{
    internal class LevelManager
    {
        private Level loadedLevel;
        private readonly String[] levelFileQueue;
        private int SelectedLevelIndex; // index of the loadedLevel in respect to levelFileQueue

        public int LevelFileQueueLength
        {
            get { return levelFileQueue.Length; }
        }
        

        public LevelManager(string directory)
        {
            this.levelFileQueue = Directory.GetFiles(directory);
        }
        private bool IsValidLevelIndex(int level)
        {
            return (level < this.levelFileQueue.Length && level >= 0);
        }

        private string RetrieveLevelPathFromQueue(int index)
        {
            if (IsValidLevelIndex(index))
            {
                this.SelectedLevelIndex = index;
                return this.levelFileQueue[this.SelectedLevelIndex];
            }
            return null;
        }

        private bool SetLoadedLevel( string levelFile)
        {
            if (levelFile != null && File.Exists(levelFile))
            {
                Console.Clear();
                Console.CursorVisible = false;
                this.loadedLevel = LevelParser.Parse(levelFile);
                //Console.WriteLine($"Loaded Level {levelFile}");
                return true;
            }
            return false;
        }

        public bool LoadLevel(int index)
        {
            string levelPath = RetrieveLevelPathFromQueue(index);
            return SetLoadedLevel(levelPath);
        }

        public void VictoryJingle()
        {
            loadedLevel.Print();
            Console.Beep(55 * 12, 100);
            Console.Beep(43 * 12, 100);
            Thread.Sleep(500);
        }

        public void StartLoadedLevel()
        {
            loadedLevel.Print(); //initial print
            while (!loadedLevel.IsSolved())
            {

                ConsoleKey key = Console.ReadKey(intercept: true).Key;
                if (key == ConsoleKey.R)
                {
                    // Level Reset
                    LoadLevel(SelectedLevelIndex);
                } else
                {
                    Vector movementDirection = VectorMethods.ConsoleKeyToVector(key);
                    loadedLevel.MovePlayers(movementDirection);
                }
                loadedLevel.Print();
                Console.ResetColor();
            }
            // level has been beaten!
            VictoryJingle();
        }
    }
}
