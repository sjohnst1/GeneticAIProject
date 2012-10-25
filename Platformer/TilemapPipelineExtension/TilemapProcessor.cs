#region File Description
//-----------------------------------------------------------------------------
// TilemapProcessor.cs
//
// CIS 580 - Game Programming Fundamentals
// Computing and Information Science, Kansas State Univeristy
// Copyright (C) Nathan Bean.  Released under the Microsoft Permissive License
//-----------------------------------------------------------------------------
#endregion

#region Using statements
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using TilemapPipelineExtension;
using TilemapLibrary;
#endregion

namespace TilemapPipelineExtension
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content Pipeline
    /// to apply custom processing to tilemap content data.  It loads the 
    /// individual tile images as external references.
    /// </summary>
    [ContentProcessor(DisplayName = "Tilemap  - Tilemap Library")]
    public class TilemapProcessor : ContentProcessor<TilemapContent, TilemapContent>
    {
        public override TilemapContent Process(TilemapContent input, ContentProcessorContext context)
        {
            // Build the tile images for all tiles in the tile palette
            foreach (TileContent tile in input.TilePalette)
            {
                tile.Image = context.BuildAsset<TextureContent, TextureContent>(tile.Image, "TextureProcessor");
            }
            return input;
        }
    }
}