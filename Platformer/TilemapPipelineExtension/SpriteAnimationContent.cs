using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace TilemapPipelineExtension
{
    [ContentSerializerRuntimeType("TilemapLibrary.SpriteAnimation, TilemapLibrary")]
    public class SpriteAnimationContent
    {
        public Texture2DContent Texture;

        public Rectangle[] Frames;

        public bool Looping;

        public float FrameDelay;
    }
}
