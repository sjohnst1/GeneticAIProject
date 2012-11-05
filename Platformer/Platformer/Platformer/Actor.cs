#region File Description
//-----------------------------------------------------------------------------
// Actor.cs
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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using TilemapLibrary;
#endregion

namespace Platformer
{
    public abstract class Actor: ITargetable
    {
        #region Constants

        // Constants for controling horizontal movement
        protected float MoveAcceleration = 13000.0f;
        protected float MaxMoveSpeed = 1050.0f;
        protected float GroundDragFactor = 0.48f;
        protected float AirDragFactor = 0.58f;

        // Constants for controlling vertical movement
        protected float MaxJumpTime = 0.35f;
        protected float JumpLaunchVelocity = -3500.0f;
        protected float GravityAcceleration = 3400.0f;
        protected float MaxFallSpeed = 550.0f;
        protected float JumpControlPower = 0.14f; 

        #endregion

        #region Fields

        /// <summary>
        /// Boolean indicating if the actor is facing to the left
        /// </summary>
        protected bool facingLeft;

        /// <summary>
        /// Boolean indicating if the actor is standing on a solid surface
        /// </summary>
        protected bool onGround;

        /// <summary>
        /// Actor's xInput in the x-axis
        /// </summary>
        protected float xInput;

        /// <summary>
        /// The bottom bound of the actor from the previous frame
        /// </summary>
        protected float previousBottom;

        /// <summary>
        /// Boolean variable indicating if the actor is holding down the jump button
        /// </summary>
        protected bool isJumping;

        /// <summary>
        /// Boolean variable indicating if the actor was 
        /// holding down the jump button in the previous frame
        /// </summary>
        protected bool wasJumping;
        
        /// <summary>
        /// Counter indicating how long the actor has been in the ascent of thier jump.
        /// </summary>
        protected float jumpTime;

        /// <summary>
        /// Dictionary containing the actor's animations 
        /// </summary>
        protected Dictionary<string, SpriteAnimation> animations;

        /// <summary>
        /// Reference to the current animation
        /// </summary>
        protected SpriteAnimation animation;

        public bool Win
        {
            get;
            set;
        }

        #endregion

        #region Members

        /// <summary>
        /// The actor's position in the world
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        protected Vector2 position;


        /// <summary>
        /// The actor's current velocity
        /// </summary>
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        protected Vector2 velocity;


        /// <summary>
        /// The player's current health
        /// </summary>
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        protected int health;

        /// <summary>
        /// The image to use to represent the Actor
        /// </summary>
        public Texture2D Image
        {
            get { return animation.Image; }
        }


        /// <summary>
        /// The origin vector for the actor's image (typically at his feet)
        /// </summary>
        public Vector2 Origin
        {
            get {
                return new Vector2(animation.Frame.Width / 2, animation.Frame.Height); 
            }
        }
        

        /// <summary>
        /// The bounding rectangle for the actor's onscreen representation
        /// </summary>
        public Rectangle Bounds
        {
            get 
            {
                Vector2 offset = Position - Origin; 
                int padding = (int)(animation.Frame.Width * 0.2f);
                return new Rectangle((int)offset.X + padding, (int)offset.Y, animation.Frame.Width - 2 * padding, animation.Frame.Height); 
            }
        }

        /// <summary>
        /// The Tilemap where the actor currently exists
        /// </summary>
        public Tilemap Tilemap;


        /// <summary>
        /// The index of the TilemapLayer the actor is currently interacting with
        /// </summary>
        public int LayerIndex;


        #endregion

        #region Initialization


        /// <summary>
        /// Creates a new Actor instance
        /// </summary>
        public Actor()
        {
            health = 1;
            Win = false;
        }


        /// <summary>
        /// Loads the content associated with the actor.
        /// </summary>
        /// <param name="content">The content manager to use to load the actor content</param>
        public abstract void  LoadContent(ContentManager content);


        #endregion

        #region Updating


        /// <summary>
        /// Updates the Actor
        /// </summary>
        /// <param name="gameTime">The game's time statistics</param>
        public abstract void Update(GameTime gameTime);


        #endregion

        #region Drawing and Animation


        /// <summary>
        /// Draws the actor's sprite.  This function should be called between
        /// a SpriteBatch.Begin() and SpriteBatch.End() call.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to render the actor's sprite with</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(animation.Image, position, animation.Frame, Color.White, 0f, Origin, 1f, (facingLeft ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 0f);
        }


        protected void PlayAnimation(string name)
        {
            SpriteAnimation animation = animations[name];

            // Stop if we're already playing the animation
            if (this.animation == animation) return;

            // Start new animation
            this.animation = animation;
            this.animation.Reset();
        }

        #endregion

        #region Platformer Physics and Collisions

        public abstract void TakeDamage();

        /// <summary>
        /// This function applys platformer physics to the actor character
        /// </summary>
        /// <param name="elapsed">The elapsed time, in fractions of a second</param>
        protected void HandlePhysics(float elapsed)
        {
            Vector2 oldPosition = position;

            // Calculate horizontal velocity
            velocity.X += xInput * MoveAcceleration * elapsed;

            // Apply drag
            if(onGround)
                velocity.X *= GroundDragFactor;
            else
                velocity.X *= AirDragFactor;

            // Prevent the actor from exceeding his top speed
            velocity.X = MathHelper.Clamp(velocity.X, -MaxMoveSpeed, MaxMoveSpeed);

            // Calculate vertical velocity
            velocity.Y = MathHelper.Clamp(velocity.Y + GravityAcceleration * elapsed, -MaxFallSpeed, MaxFallSpeed);
            
            // Apply the jump function for when jumping
            DoJump(elapsed);

            // Apply velocity
            position += velocity * elapsed;
            position.X = (float)Math.Round(position.X);
            position.Y = (float)Math.Round(position.Y);
        }


        /// <summary>
        /// This function applies a "Power" jump function to allow
        /// the actor more direct control over the arc of a jump.  
        /// While not physically accurate, it better conforms to
        /// actor expectations.  The velocity is only altered during
        /// the ascent of the jump.
        /// </summary>
        /// <param name="elapsedTime">The time elapsed, in fractions of a second</param>
        protected void DoJump(float elapsedTime)
        {
            // Begin or continue a jump
            if (isJumping)
            {
                if ((!wasJumping && onGround) || jumpTime > 0.0f)
                {
                    jumpTime += elapsedTime;
                }

                // If we are in the ascent of the jump
                if (0.0f < jumpTime && jumpTime < MaxJumpTime)
                {
                    // Override velocity with power curve that gives actors more control over the top of the jump
                    velocity.Y = JumpLaunchVelocity * (1.0f - (float)Math.Pow(jumpTime / MaxJumpTime, JumpControlPower));
                }
                else
                {
                    // reached the apex, now falling
                    jumpTime = 0.0f;
                }
            }
            else
            {
                jumpTime = 0.0f;
            }
            wasJumping = isJumping;
        }



        /// <summary>
        /// This method handles collisions between the actor and the tilemap.  It 
        /// also determines if the actor is on the ground.
        /// </summary>
        /// <param name="elapsed">The elapsed time, in fractions of a second</param>
        protected void HandleTilemapCollisions(float elapsed)
        {

            Rectangle bounds = Bounds;
            int leftTile = (int)Math.Floor((float)bounds.Left / Tilemap.TileWidth);
            int rightTile = (int)Math.Ceiling((float)bounds.Right / Tilemap.TileWidth) - 1;
            int topTile = (int)Math.Floor((float)bounds.Top / Tilemap.TileHeight);
            int bottomTile = (int)Math.Ceiling((float)bounds.Bottom / Tilemap.TileHeight) - 1;
            
            onGround = false;

            // Check the tile directly beneath us to establish ground level
            int xpos = (int)(position.X / Tilemap.TileWidth);
            int ypos = (int)(position.Y / Tilemap.TileHeight);
            Tile tile = Tilemap.GetTile(LayerIndex, xpos, ypos);

            if (tile != null)
            {
                // Determine collision depth (with direction) and magnitude.
                Rectangle tileBounds = new Rectangle(xpos * Tilemap.TileWidth, ypos * Tilemap.TileHeight, Tilemap.TileWidth, Tilemap.TileHeight);
                Vector2 depth = RectangleExtensions.GetIntersectionDepth(bounds, tileBounds);
                if (depth != Vector2.Zero)
                {
                    float absDepthX = Math.Abs(depth.X);
                    float absDepthY = Math.Abs(depth.Y);

                    // Resolve collision with spikes by decreasing health and launching upwards
                    if (tile.TileType == TileType.Spikes && health > 0)
                    {
                        TakeDamage();
                        velocity.Y = JumpLaunchVelocity;
                    }

                    // Resolve the collision along the shallow axis.
                    if (absDepthY < absDepthX || tile.TileType == TileType.Platform)
                    {
                        // If we crossed the top of a tile, we are on the ground.
                        if (previousBottom <= tileBounds.Top)
                            onGround = true;

                        // Ignore platforms, unless we are on the ground.
                        if (tile.TileType != TileType.Platform || onGround)
                        {
                            // Resolve the collision along the Y axis.
                            Position = new Vector2(Position.X, Position.Y + depth.Y);

                            // Perform further collisions with the new bounds.
                            bounds = Bounds;
                        }
                    }
                    else if (tile.TileType != TileType.Platform) // Ignore platforms.
                    {
                        // Resolve the collision along the X axis.
                        Position = new Vector2(Position.X + depth.X, Position.Y);

                        // Perform further collisions with the new bounds.
                        bounds = Bounds;
                    }
                }
            }

            else
            {
                if(Tilemap.IsFallenOffScreen(LayerIndex, xpos, ypos)) Health = 0;
                else if (Tilemap.IsRightSide(LayerIndex, xpos, ypos)) Win = true; ; //set win condition
            }

            // For each other potentially colliding tile,
            for (int y = topTile; y <= bottomTile; ++y)
            {
                for (int x = leftTile; x <= rightTile; ++x)
                {
                    // If this tile exists,
                    tile = Tilemap.GetTile(LayerIndex, x, y);
                    if (tile != null)
                    {
                        // Determine collision depth (with direction) and magnitude.
                        Rectangle tileBounds = new Rectangle(x * Tilemap.TileWidth, y * Tilemap.TileHeight, Tilemap.TileWidth, Tilemap.TileHeight);
                        Vector2 depth = RectangleExtensions.GetIntersectionDepth(bounds, tileBounds);
                        if (depth != Vector2.Zero)
                        {
                            float absDepthX = Math.Abs(depth.X);
                            float absDepthY = Math.Abs(depth.Y);
                            
                            // Resolve the collision along the shallow axis.
                            if (absDepthY < absDepthX || tile.TileType == TileType.Platform)
                            {
                                // If we crossed the top of a tile, we are on the ground.
                                if (previousBottom <= tileBounds.Top)
                                    onGround = true;

                                // Ignore platforms, unless we are on the ground.
                                if (tile.TileType != TileType.Platform || onGround)
                                {
                                    // Resolve the collision along the Y axis.
                                    Position = new Vector2(Position.X, Position.Y + depth.Y);

                                    // Perform further collisions with the new bounds.
                                    bounds = Bounds;
                                }
                            }
                            else if (tile.TileType != TileType.Platform) // Ignore platforms.
                            {
                                // Resolve the collision along the X axis.
                                Position = new Vector2(Position.X + depth.X, Position.Y);

                                // Perform further collisions with the new bounds.
                                bounds = Bounds;
                            }
                        }
                    }
                }
            }

            // Save the new bounds bottom
            previousBottom = bounds.Bottom;
        }


        #endregion

    }
}
