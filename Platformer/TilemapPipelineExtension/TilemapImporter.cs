#region File Description
//-----------------------------------------------------------------------------
// TilemapImporter.cs
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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
#endregion

namespace TilemapPipelineExtension
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content Pipeline
    /// to import a Tilemap file from disk.  This simple class basically wraps  
    /// the XmlImporter functionality, allowing us to assign a default processor 
    /// to the .tmapextension
    /// </summary>
    [ContentImporter(".tmap", DisplayName = "Tilemap - Tilemap Library", DefaultProcessor = "TilemapProcessor")]
    public class TilemapImporter : XmlImporter
    {
    }
}
