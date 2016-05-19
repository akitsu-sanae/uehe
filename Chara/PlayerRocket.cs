﻿/*=============================================================================
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
    class PlayerRocket : Player
    {
        public PlayerRocket(asd.MapObject2D map, asd.Vector2DF position, Status status) : base(map, position, status)
        {
            this.Src = Data.rect(Data.GraphType.PlayerRocket);
            this.speed.Y = -20.0F;
        }
        protected override void Move()
        {
            this.speed.Y += 0.2F;
        }
    }
}
