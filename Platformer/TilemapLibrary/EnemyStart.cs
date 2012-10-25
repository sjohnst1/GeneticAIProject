﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TilemapLibrary
{
    public enum MonsterType
    {
        MonsterA,
        MonsterB,
        MonsterC,
        MonsterD
    }
    public struct EnemyStart
    {
        public Vector2 Position { get; set; }
        public int Layer { get; set; }
        public MonsterType MonsterType { get; set; }
    }
}
