/*=============================================================================
  Copyright (c) 2016 Akitsu Sanae
  https://github.com/akitsu-sanae/uehe
  Distributed under the Boost Software License, Version 1.0. (See accompanying
  file LICENSE_1_0.txt or copy at http://www.boost.org/LICENSE_1_0.txt)
=============================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmCr48hGameJam2016_5.Chara
{
    abstract class Player : asd.TextureObject2D
    {
        public Player(asd.MapObject2D map, asd.Vector2DF position, Status status)
        {
            this.Position = position;
            this.map = map;
            this.Texture = Data.Image;
            this.status = status;
        }

        protected abstract void Move();
        
        private void Hit()
        {
            if (Position.X + speed.X < 0 || Position.X + speed.X > asd.Engine.WindowSize.X - 16)
                speed.X = 0.0F;


            foreach (var chip in map.Chips)
            {
                {
                    var lhs = chip.Src;
                    var tokuRect = Data.rect(Data.GraphType.Toku);
                    if (lhs.X == tokuRect.X && lhs.Y == tokuRect.Y)
                        continue;
                }

                var xDiff = Math.Abs(Position.X + speed.X - chip.Position.X);
                if (xDiff > 24)
                    continue;
                var yDiff = Math.Abs(Position.Y + speed.Y - chip.Position.Y);
                if (yDiff > 16)
                    continue;
                if (Position.X < chip.Position.X)
                    Position = new asd.Vector2DF(chip.Position.X - 24 , Position.Y);
                else
                    Position = new asd.Vector2DF(chip.Position.X + 24, Position.Y);
                this.speed.X = 0;
            }

            foreach (var chip in map.Chips)
            {
                {
                    var lhs = chip.Src;
                    var tokuRect = Data.rect(Data.GraphType.Toku);
                    if (lhs.X == tokuRect.X && lhs.Y == tokuRect.Y)
                        continue;
                }

                var xDiff = Math.Abs(Position.X - chip.Position.X);
                if (xDiff > 16)
                    continue;

                var yDiff = Math.Abs(Position.Y + speed.Y - chip.Position.Y);
                if (yDiff > 24)
                    continue;

                if (Position.Y < chip.Position.Y)
                    Position = new asd.Vector2DF(Position.X, chip.Position.Y - 24);
                else
                    Position = new asd.Vector2DF(Position.X, chip.Position.Y + 24);

                this.speed.Y = 0;
                IsOnGround = true;
            }
        }
        protected override void OnUpdate()
        {
            Move();
            Hit();
            this.Position += this.speed;
        }
        protected asd.MapObject2D map;
        private Status status;
        protected asd.Vector2DF speed = new asd.Vector2DF();
        protected bool IsOnGround = false;
    }
}
