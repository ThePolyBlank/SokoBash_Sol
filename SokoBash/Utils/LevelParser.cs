using SokoBash.Elements;
using SokoBash.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SokoBash.Utils
{
    internal static class LevelParser
    {
        static readonly Dictionary<char, Type> elementDictionary = new Dictionary<char, Type>();
        static readonly Dictionary<char, Type> tileDictionary = new Dictionary<char, Type>();

        static LevelParser()
        {
            // ELEMENTS -------------
                // regular symbols
                    elementDictionary.Add('#', typeof(Elements.Wall));
                    elementDictionary.Add(' ', typeof(Elements.Air));
                    elementDictionary.Add('@', typeof(Elements.Player));
                    elementDictionary.Add('X', typeof(Elements.Box));
                    elementDictionary.Add('^', typeof(Elements.Air));
                    elementDictionary.Add('`', typeof(Elements.Air));


            // poweruser symbols
            elementDictionary.Add('a', typeof(Elements.Player));
                    elementDictionary.Add('â', typeof(Elements.Player));
                    elementDictionary.Add('à', typeof(Elements.Player));
                    elementDictionary.Add('A', typeof(Elements.Player));
                    elementDictionary.Add('Â', typeof(Elements.Player));
                    elementDictionary.Add('À', typeof(Elements.Player));

                    elementDictionary.Add('o', typeof(Elements.Box));
                    elementDictionary.Add('ô', typeof(Elements.Box));
                    elementDictionary.Add('ò', typeof(Elements.Box));
                    elementDictionary.Add('O', typeof(Elements.Box));
                    elementDictionary.Add('Ô', typeof(Elements.Box));
                    elementDictionary.Add('Ò', typeof(Elements.Box));

            // TILES -------------
                // Box Switch
                    tileDictionary.Add('^', typeof(Elements.Box));

                    // poweruser symbols
                        tileDictionary.Add('ô', typeof(Elements.Box));
                        tileDictionary.Add('Ô', typeof(Elements.Box));
                        tileDictionary.Add('â', typeof(Elements.Box));
                        tileDictionary.Add('Â', typeof(Elements.Box));


            // Player Switch
            tileDictionary.Add('`', typeof(Elements.Player));

                    // poweruser symbols
                        tileDictionary.Add('ò', typeof(Elements.Player));
                        tileDictionary.Add('à', typeof(Elements.Player));
                        tileDictionary.Add('Ò', typeof(Elements.Player));
                        tileDictionary.Add('À', typeof(Elements.Player));
        }

        public static Vector GetDimensions(List<string> lines)
        {

            Vector dimensions = new Vector();
            //Determine level dimensions
            dimensions.y = lines.Count;
            // get length of flongest line (Field Width)
            dimensions.x = 0;
            foreach (string line in lines)
            {
                if (dimensions.x < line.Length)
                {
                    dimensions.x = line.Length;
                }
            }
            return dimensions;
        }

        public static List<string> ToLineList(string text)
        {
           
            string[] levelLinesArray = text.ReplaceLineEndings("\n").Split("\n");
            List<string> levelLines = new List<string>(levelLinesArray);
            return levelLines;
        }

        public static List<string> TrimLineList(List<string> lines)
        {
            List<string> linesNew = lines;
            Regex blankLineRegex = new Regex(@"^\s+$");
            // remove visually empty lines (not always desired)
            for (int i = linesNew.Count - 1; i >= 0; i--)
            {
                if (blankLineRegex.IsMatch(linesNew[i]))
                {
                    linesNew.RemoveAt(i);
                }
            }

            // trim end whitespace of each line
            for (int i = 0; i < linesNew.Count; i++)
            {
                linesNew[i] = linesNew[i].TrimEnd('\r');
                linesNew[i] = linesNew[i].TrimEnd(' ');
            }
            return linesNew;
        }

        public static void OutputLineList(List<string> lines)
        {
            foreach (string line in lines)
            {
                foreach (char c in line)
                {
                    Console.Write(c.ToString().Replace(' ', '-'));
                }
                Console.WriteLine();
            }
        }

        public static Element GetElementFromChar(char c)
        {
            if (elementDictionary.ContainsKey(c))
            {
                Type elementType = elementDictionary[c];
                return (Element)Activator.CreateInstance(elementType);
            }
            else
            {
                return new Elements.Air();
            }
        }

        public static Tile GetTileFromChar(char c)
        {
            Element tileContent = GetElementFromChar(c);
            if (tileDictionary.ContainsKey(c))
            {
                Type switchType = tileDictionary[c];
                Element watchedElement = (Element)Activator.CreateInstance(switchType);
                return new TileSwitch(tileContent, watchedElement);
            }
            else
            {
                return new Tile(tileContent);
            }
        }


        public static Level Parse(string file)
        {
            //Read and Parse File
            string levelText = File.ReadAllText(file);
            levelText = levelText.Replace("\t", "    ");

            List<string> levelLines = ToLineList(levelText);

            levelLines = TrimLineList(levelLines);
            Vector levelDimensions = GetDimensions(levelLines);

            Tile[,] newTiles = new Tile[levelDimensions.x,levelDimensions.y];
            for (int i = 0; i < levelDimensions.y; i++)
            {
                string currentLine = levelLines[i];
                currentLine = currentLine.PadRight(levelDimensions.x);

                for (int j = 0; j < levelDimensions.x; j++)
                {
                    char currentChar = currentLine[j];
                    Vector tilePos = new Vector(i, j);
                    newTiles[j, i] = GetTileFromChar(currentChar);
                }
            }
            Level newLevel = new Level(newTiles);
            return newLevel;
        }
    }
}
