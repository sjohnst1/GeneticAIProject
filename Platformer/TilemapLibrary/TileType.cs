#region File Description
//-----------------------------------------------------------------------------
// TileType.cs
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
#endregion

namespace TilemapLibrary
{
    /// <summary>
    /// This enumeration represents possible types of tiles
    /// to be used in a platformer game.  Add your custom tile
    /// types to the end of the eunumeration.
    /// </summary>
    public enum TileType
    {
        Solid,
        Breakable,
        Damaging,
        Spikes,
        Platform,
        Dissolvable,
    }
}
