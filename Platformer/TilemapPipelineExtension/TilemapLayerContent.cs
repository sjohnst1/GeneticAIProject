#region File Description
//-----------------------------------------------------------------------------
// TilemapLayerContent.cs
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
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

#endregion

namespace TilemapPipelineExtension
{
    /// <summary>
    /// The TilemapLayerContent is the pipeline version
    /// of the TilemapLayer.  It contains the layout
    /// of tiles in a single layer.
    /// </summary>
    [ContentSerializerRuntimeType("TilemapLibrary.TilemapLayer, TilemapLibrary")]
    public class TilemapLayerContent
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

        /// Determines if the layer should be rendered or not
        /// </summary>
        [ContentSerializer(Optional = true)]
        public bool Visible = true;

        /// <summary>
        /// The color that should be applied to this layer
        /// </summary>
        [ContentSerializer(Optional = true)]
        public Color Color = Color.White;

        /// <summary>
        /// The actual tile data for this layer, stored as a an array
        /// </summary>
        public int[] TileData;

        #endregion
    }
}
