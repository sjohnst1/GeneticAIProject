using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

namespace TilemapPipelineExtension
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content Pipeline
    /// to apply custom processing to content data, converting an object of
    /// type TInput to TOutput. The input and output types may be the same if
    /// the processor wishes to alter data without changing its type.
    ///
    /// This should be part of a Content Pipeline Extension Library project.
    ///
    /// TODO: change the ContentProcessor attribute to specify the correct
    /// display name for this processor.
    /// </summary>
    [ContentProcessor(DisplayName = "SpriteAnimation Processor")]
    public class SpriteAnimationProcessor : ContentProcessor<Texture2DContent, SpriteAnimationContent>
    {
        int frameCount = 10;
        bool looping = false;
        float frameDelay = 0.23f;

        [DefaultValue(10)]
        [DisplayName("Frame Count")]
        [Description("How many frames are in this animation")]
        public int FrameCount
        {
            get { return frameCount; }
            set { frameCount = value; }
        }

        [DefaultValue(false)]
        [Description("Whether this animation should loop")]
        public bool Looping
        {
            get { return looping; }
            set { looping = value; }
        }

        [DefaultValue(0.23f)]
        [DisplayName("Frame Delay")]
        [Description("Amount of time to display each frame")]
        public float FrameDelay
        {
            get { return frameDelay; }
            set { frameDelay = value; }
        }

        public override SpriteAnimationContent Process(Texture2DContent input, ContentProcessorContext context)
        {
            SpriteAnimationContent output = new SpriteAnimationContent();
            int frameWidth = input.Mipmaps[0].Width / frameCount;
            int frameHeight = input.Mipmaps[0].Height;
            output.Frames = new Rectangle[frameCount];
            for (int i = 0; i < frameCount; i++)
            {
                output.Frames[i] = new Rectangle(i * frameWidth, 0, frameWidth, frameHeight);
            }

            output.Texture = (Texture2DContent)context.Convert<Texture2DContent, TextureContent>(input, "TextureProcessor");

            return output;
        }
    }
}