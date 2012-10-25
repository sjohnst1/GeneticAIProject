using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TilemapLibrary
{
    public class SpriteAnimation
    {
        [ContentSerializer]
        Texture2D texture;

        [ContentSerializer]
        Rectangle[] frames;

        public bool Looping;

        public float FrameDelay;

        [ContentSerializerIgnore]
        public Rectangle Frame
        {
            get { return frames[frame]; }
        }

        [ContentSerializerIgnore]
        public Texture2D Image
        {
            get { return texture; }
        }


        float time = 0f;
        int frame = 0;

        public SpriteAnimation() { }

        

        public void Update(float elapsedTime)
        {
            time += elapsedTime;
            if (Looping)
            {
                frame = (int)(Math.Floor(time / FrameDelay)) % frames.Length;
            }
            else
            {
                frame = Math.Min((int)Math.Floor(time / FrameDelay), frames.Length - 1);
            }
        }

        public void Reset()
        {
            frame = 0;
            time = 0.0f;
        }
    }
}
