#region File Description
//-----------------------------------------------------------------------------
// TilemapContent.cs
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
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using TilemapLibrary;

#endregion

namespace TilemapPipelineExtension
{
    /// <summary>
    /// A content pipeline class corresponding to a tilemap
    /// </summary>
    [ContentSerializerRuntimeType("TilemapLibrary.Tilemap, TilemapLibrary")]
    public class TilemapContent
    {
        #region Fields

        /// <summary>
        /// The name of the tilemap
        /// </summary>
        public string Name;

        /// <summary>
        /// The width of the tilemap, in tiles
        /// </summary>
        public int Width;

        /// <summary>
        /// The height of the tilemap, in tiles
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
        /// A list of all tiles used in this tilemap
        /// </summary>
        public List<TileContent> TilePalette;
        
        /// <summary>
        /// A collection of tilemap layer content 
        /// </summary>
        public List<TilemapLayerContent> Layers;

        [ContentSerializer(Optional=true)]
        public PlayerStart PlayerStart;

        [ContentSerializer(Optional=true)]
        public List<EnemyStart> EnemyLocations;

        [ContentSerializer(Optional=true)]
        public List<GemLocation> Gems;

        #endregion

        #region Initialization

        public TilemapContent(){}

        #endregion
    }
}
