#region File Description
//-----------------------------------------------------------------------------
// Camera.cs
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
using TilemapLibrary;
#endregion

namespace Platformer
{
    /// <summary>
    /// This class represents the veiwpoint from wich the world of the platformer
    /// game can be veiwed.  It provides a custom effect to transform the rendered
    /// world to match that viewpoint.  It is tied to a single Tilemap instance.
    /// </summary>
    public class Camera
    {
        #region Fields and Members

        /// <summary>
        /// A vector to the center of the viewport
        /// </summary>
        Vector2 center;

        /// <summary>
        /// The bounding region the camera is allowed to occupy
        /// </summary>
        Rectangle bounds;

        /// <summary>
        /// The target of this camera (typically a player)
        /// </summary>
        public ITargetable Target;

        /// <summary>
        /// The position of the camera in the world
        /// </summary>
        public Vector2 Position
        {
            get { return Target.Position; }
        }

        /// <summary>
        /// The effect that will shift the world to correspond
        /// to this camera's position.
        /// </summary>
        public BasicEffect Effect
        {
            get { return effect; }
        }
        BasicEffect effect;


        #endregion

        #region Initializaiton


        /// <summary>
        /// Creates a new camera instance, tied to a particular tilemap
        /// </summary>
        /// <param name="graphicsDevice">The GraphicsDevice</param>
        /// <param name="tilemap">The Tilemap this camera is tied to</param>
        public Camera(GraphicsDevice graphicsDevice, Tilemap tilemap)
        {
            Viewport viewport = graphicsDevice.Viewport;

            effect = new BasicEffect(graphicsDevice)
            {
                TextureEnabled = true,
                VertexColorEnabled = true,
                World = Matrix.Identity,
                View = Matrix.Identity,
                Projection = Matrix.CreateOrthographicOffCenter(0, viewport.Width, viewport.Height, 0, 0, 1)
            };

            center = new Vector2(viewport.Width / 2, viewport.Height / 2);

            bounds = new Rectangle(
                viewport.Width / 2,
                viewport.Height / 2,
                tilemap.Width * tilemap.TileWidth - viewport.Width,
                tilemap.Height * tilemap.TileHeight - viewport.Height
            );
        }


        #endregion

        #region Updating


        /// <summary>
        /// Moves the camera to remain focused on its target, and clamps to 
        /// its bounding region.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            Vector3 pos = new Vector3(Target.Position, 0);
            pos.X = MathHelper.Clamp(pos.X, bounds.Left, bounds.Right);
            pos.Y = MathHelper.Clamp(pos.Y, bounds.Top, bounds.Bottom);

            effect.View = Matrix.CreateTranslation(new Vector3(center, 0) - pos);
        }

        #endregion
    }
}
