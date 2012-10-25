using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using TilemapLibrary;

namespace Platformer
{
    public class Gem
    {
        private Texture2D texture;

        private Vector2 position;

        private int layer;

        private bool collected;

        private GemType type;

        public Gem(GemType t, int l, Vector2 p)
        {
            layer = l;
            position = p;
            type = t;
            collected = false;
        }

        public void LoadContent(ContentManager content)
        {
            switch (type)
            {
                case GemType.White:
                    texture = content.Load<Texture2D>("Sprites/Gem");
                    break;
                case GemType.Gold:
                    texture = content.Load<Texture2D>("Sprites/GoldGem");
                    break;
                case GemType.Red:
                    texture = content.Load<Texture2D>("Sprites/RedGem");
                    break;
            }
        }

        public void Update(Player player)
        {
            //don't update if it's already been picked up!
            if (collected) return;

            bool collision = false;

            //check for collision with player

            //if collision
            if (collision)
            {
                collected = true;
                switch (type)
                {
                    case GemType.White:
                        //add to score
                        player.AddScore(100);
                        break;
                    case GemType.Red:
                        //add to health
                        player.AddHealth();
                        break;
                    case GemType.Gold:
                        //refill health and add 1 to max health (Zelda, anyone?)
                        player.AddToMaxHealth();
                        break;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(!collected) spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
