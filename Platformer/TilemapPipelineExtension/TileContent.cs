#region File Description
//-----------------------------------------------------------------------------
// TileContenet.cs
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
    /// A content pipeline class representing a single tile and its data
    /// </summary>
    [ContentSerializerRuntimeType("TilemapLibrary.Tile, TilemapLibrary")]
    public class TileContent
    {
        # region Fields

        /// <summary>
        /// The name of the tile
        /// </summary>
        public string Name;

        /// <summary>
        /// The image representing this tile
        /// Since images can't be embedded in a serialized
        /// XNA class, we use an external reference to point
        /// to our texture.
        /// </summary>
        public ExternalReference<TextureContent> Image;

        /// <summary>
        /// Constructs a new TileContent instance
        /// </summary>
        public TileContent() { }
        
        /// <summary>
        /// Constructs a new tile instance and initalizes the
        /// Texture external reference
        /// </summary>
        /// <param name="filename">The filename of the texture</param>
        public TileContent(string filename)
        {
            Image = new ExternalReference<TextureContent>(filename);
        }


        [ContentSerializer(Optional = true)]
        public TileType TileType = TileType.Solid;


        #endregion
    }
}
