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
    class PlayerHuman : Player
    {
        public PlayerHuman(asd.MapObject2D map, asd.Vector2DF position, Status status) : base(map, position, status)
        {
            this.Src = Data.rect(Data.GraphType.Player1);
        }

        private void ChangeGraph()
        {
            counter %= 16;
            if (counter == 0)
                this.Src = Data.rect(Data.GraphType.Player1);
            if (counter == 4)
                this.Src = Data.rect(Data.GraphType.Player2);
            if (counter == 8)
                this.Src = Data.rect(Data.GraphType.Player3);
            if (counter == 12)
                this.Src = Data.rect(Data.GraphType.Player4);

            this.TurnLR = this.dir == Direction.Left;
        }

        protected override void Move()
        {
            this.speed.X = 0;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Hold)
            {
                if (this.IsOnGround)
                {
                    this.speed.X = -4;
                    this.counter++;
                }
                else
                {
                    this.speed.X = -5;
                }
                this.dir = Direction.Left;
            }
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Hold)
            {
                if (this.IsOnGround)
                {
                    this.speed.X = 4;
                    this.counter++;
                }
                else
                {
                    this.speed.X = 5;
                }
                this.dir = Direction.Right;
            }

            this.speed.Y += 0.4F;

            
            if (this.speed.Y > 12.0F)
                this.speed.Y = 12.0F;

        }
        protected override void OnUpdate()
        {
            ChangeGraph();
            base.OnUpdate();

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push && this.IsOnGround)
            {
                this.speed.Y = -9.0F;
                this.IsOnGround = false;
            }

        }

        enum Direction
        {
            Left,
            Right
        }

        private Direction dir = Direction.Left;
        private int counter = 0;

    }
}
