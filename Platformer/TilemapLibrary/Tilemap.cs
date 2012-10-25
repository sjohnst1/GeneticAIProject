#region File Description
//-----------------------------------------------------------------------------
// Tilemap.cs
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
    /// A class that represents a single tilemap
    /// </summary>
    public class Tilemap
    {

        #region Fields


        /// <summary>
        /// The tilemap's name
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
        /// The palette of tiles used in this tilemap
        /// </summary>
        public List<Tile> TilePalette;

        /// <summary>
        /// A collection of layers
        /// </summary>
        public List<TilemapLayer> Layers;

        /// <summary>
        /// Player's starting position and layer
        /// </summary>
        public PlayerStart PlayerStart;

        /// <summary>
        /// List of enemy locations, layers, and types
        /// </summary>
        [ContentSerializer(Optional = true)]
        public List<EnemyStart> EnemyLocations;

        /// <summary>
        /// List of gem locations, layers, and types
        /// </summary>
        [ContentSerializer(Optional = true)]
        public List<GemLocation> Gems;


        #endregion

        #region Initialization

        /// <summary>
        /// Parameterless constructor needed by the content pipeline
        /// </summary>
        public Tilemap() 
        {
        }

        /// <summary>
        /// Creates a new instance of a tilemap
        /// </summary>
        /// <param name="name">The tilemap's name</param>
        /// <param name="layers">The number of layers in the tilemap</param>
        /// <param name="width">The width of the tilemap, in tiles</param>
        /// <param name="height">The height of the tilemap, in tiles</param>
        /// <param name="tileWidth">The height of the map's in pixels</param>
        /// <param name="tileHeight">The height of the map's tiles, in pixels</param>
        public Tilemap(string name, int layers, int width, int height, int tileWidth, int tileHeight)
        {
            Name = name;
            Width = width;
            Height = height;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            TilePalette = new List<Tile>(16);
            Layers = new List<TilemapLayer>(layers);
            for (int i = 0; i < layers; i++)
            {
                Layers.Add(new TilemapLayer("Layer " + i, width, height, tileWidth, tileHeight));

            }
        }

        #endregion

        #region Drawing 

        /// <summary>
        /// Renders the tilemap
        /// </summary>
        /// <param name="spriteBatch">The spritebatch to use to render the tilemap</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(TilemapLayer layer in Layers)
            {
                layer.Draw(spriteBatch, TilePalette);
            }
        }

        #endregion


        /// <summary>
        /// Returns the tile found at x,y in the layer at layerIndex in the tilemap
        /// </summary>
        /// <param name="layerIndex">The index of the layer to find the tile in</param>
        /// <param name="x">The x position of the tile</param>
        /// <param name="y">The y position of the tile</param>
        /// <returns>The tile, or null if it doesn't exist</returns>
        public Tile GetTile(int layerIndex, int x, int y)
        {
            if(layerIndex < 0 || layerIndex >= Layers.Count || x < 0 || x >= Width || y < 0 || y >= Height) return null;
            TilemapLayer layer = Layers[layerIndex];
            int tileIndex = layer.TileData[x + y * layer.Width];
            if(tileIndex == -1) return null;
            return TilePalette[tileIndex];
        }

        public bool IsFallenOffScreen(int layerIndex, int x, int y)
        {
            int tileIndex = x + y * Width;
            if (tileIndex >= Height * Width) return true;
            return false;
        }

        public bool IsRightSide(int layerIndex, int x, int y)
        {
            int tileIndex = x + y * Width;
            
            int max = Height * Width;
            for (int i = 1; i < max; i++)
            {
                if (tileIndex > (i * Width - 3) && tileIndex < (i * Width)) return true;
            }
            return false;
        }
    }
}
