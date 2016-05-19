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
    class Cloud : asd.TextureObject2D
    {
        public Cloud(asd.Vector2DF pos)
        {
            this.Texture = Data.Image;
            this.Src = Data.rect(Data.GraphType.Cloud);
            this.Position = pos;
        }

        protected override void OnUpdate()
        {
        }
    }
}
