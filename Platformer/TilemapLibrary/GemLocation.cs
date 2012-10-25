using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TilemapLibrary
{
    public enum GemType
    {
        White,
        Red,
        Gold
    }
    public struct GemLocation
    {
        public Vector2 Position { get; set; }
        public int Layer { get; set; }
        public GemType GemType { get; set; }
    }
}
