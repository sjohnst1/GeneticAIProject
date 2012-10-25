#region File Description
//-----------------------------------------------------------------------------
// TilemapLayer.cs
//
// CIS 580 - Game Programming Fundamentals
// Computing and Information Science, Kansas State Univeristy
// Copyright (C) Nathan Bean.  Released under the Microsoft Permissive License
//-----------------------------------------------------------------------------
#endregion

#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

#endregion

namespace TilemapLibrary
{
    /// <summary>
    /// This class represents a single layer in a tilemap
    /// </summary>
    public class TilemapLayer
    {
        #region Fields

        /// <summary>
        /// The layer's name
        /// </summary>
        public string Name;

        /// <summary>
        /// The width of the tilemap, in tiles
        /// </summary>
        public int Width;

        /// <summary>
        /// The Height of the tilemap, in tiles
        /// </summary>
        public int Height;

        /// <summary>
        /// The width of a tile, in pixels
        /// </summary>
        public int TileWidth;

        /// <summary>
        /// The height of a tile, in pixels
        /// </summary>
        public int TileHeight;

        /// <summary>
        /// Determines if the layer should be rendered or not
        /// </summary>
        [ContentSerializer(Optional=true)]
        public bool Visible = true;

        /// <summary>
        /// The color that should be applied to this layer
        /// </summary>
        [ContentSerializer(Optional=true)]
        public Color Color = Color.White;

        /// <summary>
        /// The actual data holding the tiles, as an array of tile indices
        /// We use a one-dimensional array as the serializers cannot
        /// handle two-dimensional arrays
        /// </summary>
        public int[] TileData;

        #endregion

        #region Intialization

        /// <summary>
        /// Parameterless constructor for the Content Pipeline
        /// </summary>
        TilemapLayer() { }

		
        /// <summary>
        /// Creates a new instance of a tilemap
        /// </summary>
        /// <param name="name">The tilemap's name</param>
        /// <param name="width">The width of the tilemap, in tiles</param>
        /// <param name="height">The height of the tilemap, in tiles</param>
        /// <param name="tileHeight">The height of the map's tiles, in pixels</param>
        /// <param name="tileWidth">The height of the map's in pixels</param>
        public TilemapLayer(string name, int width, int height, int tileWidth, int tileHeight)
        {
            Name = name;
            Width = width;
            Height = height;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            TileData = new int[width * height];

            // Initalize array to "empty" tile index
            for (int i = 0; i < width * height; i++) TileData[i] = -1;
        }

        #endregion

        #region Drawing

        /// <summary>
        /// Renders the tilemap layer
        /// </summary>
        /// <param name="spriteBatch">The spritebatch to use to render the tilemap layer</param>
        public void Draw(SpriteBatch spriteBatch, List<Tile> tilePalette)
        {
            if (Visible)
            {
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        if (TileData[x + y * Width] != -1)
                            spriteBatch.Draw((Texture2D)tilePalette[TileData[x + y * Width]].Image, new Rectangle(x * TileWidth, y * TileHeight, TileWidth, TileHeight), Color);
                    }
                }
            }
        }

        #endregion
    }
}
