#region File Description
//-----------------------------------------------------------------------------
// Player.cs
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
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using TilemapLibrary;
#endregion

namespace Platformer
{
    /// <summary>
    /// This class represents a player's character in a platformer game
    /// </summary>
    public class Player : Actor
    {
        #region Fields


        /// <summary>
        /// Sound played when the player jumps
        /// </summary>
        SoundEffect jumpSound;


        /// <summary>
        /// Sound played when the player dies
        /// </summary>
        SoundEffect deathSound;


        /// <summary>
        /// Timer for enabling invincibility - when 0 invincibility has run out
        /// </summary>
        public float invincibleTime;

        int maxHealth;

        public int Score { get; set; }

        bool deathSoundPlaying = false;
        bool jumpSoundPlaying = false;

        //0 is move left, 1 is move right, 2 is jump
        bool[] actions = new bool[3];

        #endregion

        #region Properties

        public bool[] Actions
        {
            get { return actions; }
            set { actions = value; }
        }

        public bool MoveLeft
        {
            get { return actions[0]; }
            set { actions[0] = value; }
        }

        public bool MoveRight
        {
            get { return actions[1]; }
            set { actions[1] = value; }
        }

        public bool Jump
        {
            get { return actions[2]; }
            set { actions[2] = value; }
        }

        public bool Dead
        {
            get { return Health <= 0; }
        }

        #endregion

        #region Initialization


        /// <summary>
        /// Creates a new Player instance
        /// </summary>
        public Player()
        {
            health = 3;
            maxHealth = 3;
            invincibleTime = 0f;

            // Constants for controling horizontal movement
            MoveAcceleration = 13000.0f;
            MaxMoveSpeed = 1050.0f;
            GroundDragFactor = 0.48f;
            AirDragFactor = 0.58f;

            // Constants for controlling vertical movement
            MaxJumpTime = 0.35f;
            JumpLaunchVelocity = -3500.0f;
            GravityAcceleration = 3400.0f;
            MaxFallSpeed = 550.0f;
            JumpControlPower = 0.14f; 
        }


        /// <summary>
        /// Loads the content associated with the player.
        /// </summary>
        /// <param name="content">The content manager to use to load the player content</param>
        public override void LoadContent(ContentManager content)
        {
            jumpSound = content.Load<SoundEffect>("Sounds/PlayerJump");
            deathSound = content.Load<SoundEffect>("Sounds/PlayerKilled");
            animations = new Dictionary<string, SpriteAnimation>();
            animations["Idle"] = content.Load<SpriteAnimation>("Sprites/Player/Idle");
            animations["Run"] = content.Load<SpriteAnimation>("Sprites/Player/Run");
            animations["Jump"] = content.Load<SpriteAnimation>("Sprites/Player/Jump");
            animations["Die"] = content.Load<SpriteAnimation>("Sprites/Player/Die");
            animations["Celebrate"] = content.Load<SpriteAnimation>("Sprites/Player/Celebrate");
            animation = animations["Idle"];
        }


        #endregion

        #region Updating


        /// <summary>
        /// Updates the Player
        /// </summary>
        /// <param name="gameTime">The game's time statistics</param>
        public override void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (invincibleTime > 0) invincibleTime -= elapsed;
            else invincibleTime = 0f;

            if(Health > 0) HandleInput();
            //if (Health > 0) HandleNNInput();

            HandlePhysics(elapsed);

            if (Health <= 0)
            {
                PlayAnimation("Die");
                animation.Update(elapsed);
                if (deathSoundPlaying == false)
                {
                    deathSoundPlaying = true;
                    deathSound.Play();
                }
                
            }
            else if (onGround)
            {
                jumpSoundPlaying = false;
                if (Math.Abs(xInput) > 0.1f)
                {
                    PlayAnimation("Run");
                    animation.Update(elapsed * Math.Abs(xInput));
                }
                else
                {
                    PlayAnimation("Idle");
                }
            }
            else
            {
                PlayAnimation("Jump");
                animation.Update(elapsed);
                if (jumpSoundPlaying == false && isJumping == true)
                {
                    jumpSoundPlaying = true;
                    jumpSound.Play();
                }
            }
            
            HandleTilemapCollisions(elapsed);

            isJumping = false;
        }

        public override void TakeDamage()
        {
            if (invincibleTime == 0f && Health > 0)
            {
                Health--;
                invincibleTime = 1.0f;
            }
        }

        public void AddHealth()
        {
            if (Health < maxHealth) Health++;
        }

        public void AddToMaxHealth()
        {
            maxHealth++;
            Health = maxHealth;
        }

        public void AddScore(int s)
        {
            Score += s;
        }


        /// <summary>
        /// Poll user input and use it to move the player through the world.  
        /// We assume the player is using the first gamepad.
        /// </summary>
        public void HandleInput()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            GamePadState gamepadState = GamePad.GetState(PlayerIndex.One);

            // Pull the x-axis xInput from the thumbstick
            xInput = gamepadState.ThumbSticks.Left.X;

            // Override x-axis xInput with DPad and Keyboard
            if (gamepadState.DPad.Left == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Left))
            {
                xInput = -1;
            }
            else if (gamepadState.DPad.Right == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Right))
            {
                xInput = 1;
            }

            // Check if the player wants to jump
            isJumping = gamepadState.IsButtonDown(Buttons.A) || keyboardState.IsKeyDown(Keys.Space) || gamepadState.ThumbSticks.Left.Y > 0.5f;

            // See if the player should be facing left
            if (xInput < 0) facingLeft = false;
            else facingLeft = true;

        }

        public void HandleNNInput()
        {
            if (MoveLeft) xInput = -1;
            else if (MoveRight) xInput = 1;

            isJumping = Jump;

            if (xInput < 0) facingLeft = false;
            else facingLeft = true;

            //reset actions
            MoveLeft = false;
            MoveRight = false;
            Jump = false;
        }

        #endregion

        #region Drawing and Animation


        /// <summary>
        /// Draws the player's sprite.  This function should be called between
        /// a SpriteBatch.Begin() and SpriteBatch.End() call.  The player flashes red when
        /// temporarily invincible after taking damage.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to render the player's sprite with</param>
        new public void Draw(SpriteBatch spriteBatch)
        {
            float val = (float)Math.Abs(Math.Cos(10*invincibleTime));
            Color color = new Color(1f, val, val);
            spriteBatch.Draw(animation.Image, position, animation.Frame, color, 0f, Origin, 1f, (facingLeft ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 0f);
        }


        #endregion
    }
}
