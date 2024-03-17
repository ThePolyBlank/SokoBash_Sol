using SokoBash.Elements;
using SokoBash.Tiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace SokoBash.Utils
{
    internal static class ConsoleRenderer
    {
        public static void Render(Tile[,] levelTiles)
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            ConsoleChar[] consoleChars = GetConsoleChars(levelTiles);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            StringBuilder stringBatch = new StringBuilder();
            foreach (ConsoleChar conChar in consoleChars)
            {
                // if consolecolour is null, choose the last known console color
                ConsoleColor nextForegroundColor = conChar.ForegroundColour ?? Console.ForegroundColor;
                ConsoleColor nextBackgroundColor = conChar.BackgroundColour ?? Console.BackgroundColor;
                char currentChar = conChar.character;

                if (Console.ForegroundColor != nextForegroundColor)
                {
                    if (stringBatch.ToString() != "")
                    {
                        Console.Write(stringBatch.ToString());
                    }
                    stringBatch.Clear();
                    Console.ForegroundColor = nextForegroundColor;
                }

                if (Console.BackgroundColor != nextBackgroundColor)
                {
                    if (stringBatch.ToString() != "")
                    {
                        Console.Write(stringBatch.ToString());
                    }
                    stringBatch.Clear();
                    Console.BackgroundColor = nextBackgroundColor;
                }
                stringBatch.Append(conChar.character);
            }
            Console.Write(stringBatch.ToString());
        }

        private static ConsoleChar[] GetConsoleChars(Tile[,] levelTiles)
        {
            int charsPerLine = levelTiles.GetLength(0) + 1; // 1+ because of the newline
            int charAmmount = charsPerLine * levelTiles.GetLength(1);
            ConsoleChar[] consoleChars = new ConsoleChar[charAmmount];
            int charsIndex = 0;
            for (int i = 0; i < levelTiles.GetLength(1); i++)
            {
                consoleChars[(i + 1) * charsPerLine - 1] = new ConsoleChar('\n');
                for (int j = 0; j < levelTiles.GetLength(0); j++)
                {
                    charsIndex = i * charsPerLine + j;
                    char outputChar = levelTiles[j, i].Content.ToChar();


                    if (levelTiles[j, i].GetType() == typeof(Tiles.TileSwitch))
                    {

                        TileSwitch currentSwitch = levelTiles[j, i] as TileSwitch;
                        if (currentSwitch.Content is Air)
                        {
                            outputChar = currentSwitch.satisfactoryElement.ToChar();
                            consoleChars[charsIndex] = new ConsoleChar(outputChar, ConsoleColor.Black, ConsoleColor.DarkGray);
                        }
                        else if (currentSwitch.IsSatisfied)
                        {
                            consoleChars[charsIndex] = new ConsoleChar(outputChar, ConsoleColor.White, ConsoleColor.Green);
                        }
                        else
                        {
                            consoleChars[charsIndex] = new ConsoleChar(outputChar, ConsoleColor.White, ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        consoleChars[charsIndex] = new ConsoleChar(outputChar, ConsoleColor.White, ConsoleColor.Black);
                    }
                }
            }
            return consoleChars;
        }
    }
}
