using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TilemapLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Platformer
{
    public class Enemy : Actor
    {
        private MonsterType monsterType;

        private float idleTime = 0f;
        private float walkTime = 0f;
        private float speed = 0f;

        public Enemy(MonsterType m, int l, Vector2 pos) : base()
        {
            monsterType = m;
            position = pos;
            LayerIndex = l;
        }

        public override void LoadContent(ContentManager content)
        {
            string a = "Sprites/";
            switch (monsterType)
            {
                case MonsterType.MonsterA:
                    a += "EnemyA/";
                    speed = 0.2f;
                    break;
                case MonsterType.MonsterB:
                    a += "EnemyB/";
                    speed = 0.5f;
                    break;
                case MonsterType.MonsterC:
                    a += "EnemyC/";
                    speed = 0.8f;
                    break;
                case MonsterType.MonsterD:
                    a += "EnemyD/";
                    speed = 1f;
                    break;
            }

            animations = new Dictionary<string, SpriteAnimation>(2);
            animations["Idle"] = content.Load<SpriteAnimation>(a+"Idle");
            animations["Run"] = content.Load<SpriteAnimation>(a+"Run");

            facingLeft = false;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public void Update(GameTime gameTime, Player player)
        {
            if (Health == 0) return;

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Think(elapsed, player);
            HandlePhysics(elapsed);

            //handle collisions with player

            //collision from top, squished by player, kill

            //collision from other sides, damage player
        }

        public void Think(float elapsed, Player player)
        {
            switch (monsterType)
            {
                case MonsterType.MonsterA:

                    //idle for 1 seconds
                    if (idleTime < 1)
                    {
                        xInput = 0;
                        idleTime += elapsed;
                    }
                    //wander in a random direction for 2 seconds
                    else if (walkTime < 2)
                    {
                        if (walkTime == 0)
                        {
                            Random r = new Random();
                            int x = r.Next(1, 2);
                            if (x == 1) speed = -speed;
                        }
                        xInput = speed;
                        walkTime += elapsed;
                    }
                    //start over
                    else
                    {
                        idleTime = 0f;
                        walkTime = 0f;
                    }
                    break;

                case MonsterType.MonsterB:
                    //just walks
                    xInput = speed;
                    break;

                case MonsterType.MonsterC:
                    //idles until player gets close, then chases
                    break;

                case MonsterType.MonsterD:

                    break;
            }
        }

        public override void TakeDamage()
        {
            if (Health > 0) Health--;
        }

    }
}
