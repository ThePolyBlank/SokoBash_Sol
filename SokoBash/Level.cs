using SokoBash.Elements;
using SokoBash.Tiles;
using SokoBash.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokoBash
{
    internal class Level
    {
        private Tile[,] levelTiles;
        public List<Vector> tileSwitchPositions;
        public int Width { get { return levelTiles.GetLength(0); } }
        public int Height { get { return levelTiles.GetLength(1); } }
        
        public Level(Tile[,] _levelTiles)
        {
            this.levelTiles = _levelTiles;
            tileSwitchPositions = new List<Vector>();
            for (int i = 0; i < levelTiles.GetLength(1); i++)
            {
                for (int j = 0; j < levelTiles.GetLength(0); j++)
                {
                    if (this.levelTiles[j,i] is TileSwitch)
                    {
                        tileSwitchPositions.Add(new Vector(j, i));
                    }
                } 
            }
        }

        public bool IsSolved()
        {
            foreach (Vector switchTilePos in tileSwitchPositions)
            {
                if (GetTile(switchTilePos) is TileSwitch)
                {
                    Tile switchTile = GetTile(switchTilePos);
                    if (!switchTile.IsSatisfied)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        private int FlooredMod(int x, int m)
        {
            return (x % m + m) % m;
        }
        public Vector WrapPosition(Vector vec)
        {
            Vector output;
            output.x = FlooredMod(vec.x,Width);
            output.y = FlooredMod(vec.y,Height);
            return output;
        }

        public bool IsInBounds(Vector vec)
        {
            try
            {
                Tile checkedTile = levelTiles[vec.x, vec.y];
                return true;
            } catch
            {
                return false;
            }
        }

        // TODO MAKE THESE FUNCTIONS USE EACH OTHER
        public void SetTileContent(Vector position, Element element)
        {
            Vector actualPosition = WrapPosition(position);
            this.levelTiles[actualPosition.x, actualPosition.y].Content = element; 
        }
        public Tile GetTile(Vector position)
        {
            Vector actualPosition = WrapPosition(position);
            return levelTiles[actualPosition.x, actualPosition.y];
            
        }
        public Element GetTileContent(Vector position)
        {
            Vector actualPosition = WrapPosition(position);
            return this.levelTiles[actualPosition.x,actualPosition.y].Content;
        }

        public List<Vector> GetPlayerPositions()
        {
            List<Vector> players = new List<Vector>();
            for (int i = 0; i < levelTiles.GetLength(1); i++)
            {
                for (int j = 0; j < levelTiles.GetLength(0); j++)
                {
                    if(levelTiles[j, i].Content.GetType() == typeof(Elements.Player) )
                    {
                        players.Add(new Vector(j, i));
                    }
                }
            }
            return players;
        }

        public void MovePlayers(Vector direction)
        {
            List<Vector> playerPositions = GetPlayerPositions();
            foreach (Vector playerPosition in playerPositions)
            {
                PushElement(playerPosition, direction);
            }
        }

        public void PushElement(Vector location, Vector direction)
        {
            if (direction != VectorMethods.GetVector(Direction.Neutral))
            {
                location = WrapPosition(location);
                Element pusherElement = GetTile(location).Content;
                pusherElement.TryPush(this, location, direction);
            }
        }

        public void Print()
        {
            ConsoleRenderer.Render(levelTiles);
        }
    }
}
