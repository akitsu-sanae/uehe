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
    class TokuItem : asd.TextureObject2D
    {
        private Chara.Player player;
        private Status status;

        public TokuItem(Player player, Status status, asd.Vector2DF pos)
        {
            this.player = player;
            this.status = status;
            this.Texture = Data.Image;
            this.Src = Data.rect(Data.GraphType.Toku);
            this.Position = pos;
        }

        public void setPlayer(Player player)
        {
            this.player = player;
        }

        protected override void OnUpdate()
        {
            if (player == null)
                return;
            if (!(player is PlayerHuman))
                return;
            if ((player.Position - Position).SquaredLength < 16*16)
            {
                status.nToku++;
                Dispose();
            }
        }
    }
}
