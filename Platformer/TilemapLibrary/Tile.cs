#region File Description
//-----------------------------------------------------------------------------
// Tile.cs
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
    /// A class that represents a single tile in a tile engine
    /// </summary>
    public class Tile
    {
        /// <summary>
        /// The name of the tile
        /// </summary>
        public string Name;

        /// <summary>
        /// The texture on the tile
        /// </summary>
        public Texture Image;

        [ContentSerializer(Optional=true)]
        public TileType TileType = TileType.Solid;

    }
}
