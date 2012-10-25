using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Platformer
{
    public interface ITargetable
    {
        Vector2 Position { get; }
    }
}
