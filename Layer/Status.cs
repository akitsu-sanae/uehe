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

namespace AmCr48hGameJam2016_5.Layer
{
    class Status : asd.Layer2D
    {
        AmCr48hGameJam2016_5.Status status;

        public Status(AmCr48hGameJam2016_5.Status status)
        {
            this.status = status;

            tokuLabel.Font = Data.Font;
            tokuLabel.Text = "積んだ徳：";
            tokuLabel.Position = new asd.Vector2DF(32, 32);
            AddObject(tokuLabel);

            nenLabel.Font = Data.Font;
            nenLabel.Text = "ロケットの燃料：";
            nenLabel.Position = new asd.Vector2DF(32, 64);
            AddObject(nenLabel);
        }

        protected override void OnUpdated()
        {
            tokuLabel.Text = "積んだ徳：" + status.nToku.ToString() +  "コ";
            nenLabel.Text = "ロケットの燃料：" + status.nNen.ToString() + "回分";
        }

        private asd.TextObject2D tokuLabel = new asd.TextObject2D();
        private asd.TextObject2D nenLabel = new asd.TextObject2D();
    }
}
