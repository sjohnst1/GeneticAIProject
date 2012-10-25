using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

// TODO: replace these with the processor input and output types.
using TInput = System.String;
using TOutput = System.String;

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
    [ContentProcessor(DisplayName = "Animation Strip - Tilemap Library")]
    public class AnimationStripProcessor : ContentProcessor<Texture2DContent, SpriteAnimationContent>
    {
        [DefaultValue(10)]
        [DisplayName("Frame Count")]
        [Description("The number of frames in the animation")]
        public int FrameCount
        {
            get { return FrameCount; }
            set { frameCount = value; }
        }
        int frameCount = 10;


        [DefaultValue(false)]
        [Description("Indicates if the animation should play continously or stop")]
        public bool Looping
        {
            get { return looping; }
            set { looping = value; }
        }
        bool looping = false;

        
        [DefaultValue(16)]
        [DisplayName("Frames Per Second")]
        [Description("The speed at which the animation should play")]
        public int FramesPerSecond
        {
            get { return framesPerSecond; }
            set { framesPerSecond = value; }
        }
        int framesPerSecond = 16;


        [DefaultValue(false)]
        [Description("Indicates if the animation proceeds from left to right (false), or right to left (true)")]
        public bool Inverted
        {
            get { return inverted; }
            set { inverted = value; }
        }
        bool inverted = false;


        public Color ColorKey
        {
            get { return colorKey; }
            set { colorKey = value; }
        }
        Color colorKey;

        public override SpriteAnimationContent Process(Texture2DContent input, ContentProcessorContext context)
        {
            SpriteAnimationContent output = new SpriteAnimationContent();

            output.Texture = (Texture2DContent)context.Convert<TextureContent, TextureContent>(input, "TextureProcessor");

            int frameWidth = input.Mipmaps[0].Width / frameCount;
            int frameHeight = input.Mipmaps[0].Height;

            output.Frames = new Rectangle[frameCount];
            for (int i = 0; i < frameCount; i++)
            {
                if (inverted)
                {
                    output.Frames[i] = new Rectangle((frameCount - i - 1) * frameWidth, 0, frameWidth, frameHeight);
                }
                else
                {
                    output.Frames[i] = new Rectangle(i * frameWidth, 0, frameWidth, frameHeight);
                }
            }
            
            output.Looping = looping;

            output.FrameDelay = 1.0f / framesPerSecond;

            return output;
        }
    }
}