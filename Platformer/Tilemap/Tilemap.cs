using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Tilemap
{
    public class Tilemap
    {
        public int Width;
        public int Height;
        Texture2D[,] tiles;

        public Tilemap(int width, int height)
        {
            Width = width;
            Height = height;
            tiles = new Texture2D[width, height];
        }

        public void SetTile(Point coords, Texture2D tile)
        {
            tiles[coords.X, coords.Y] = tile;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    spriteBatch.Draw(tiles[x, y], new Rectangle(x*50, y*50, 50, 50), Color.White);
                }
            }

            spriteBatch.End();
        }
    }
}
