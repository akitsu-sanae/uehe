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

namespace AmCr48hGameJam2016_5.Scene
{
    class Clear : asd.Scene
    {
        public Clear(long time, int toku)
        {
            var layer = new asd.Layer2D();

            var rect = new asd.RectangleShape();
            rect.DrawingArea = new asd.RectF(0, 0, 640, 480);
            var background = new asd.GeometryObject2D();
            background.Shape = rect;
            background.Color = new asd.Color(90, 150, 240, 255);
            layer.AddObject(background);

            for (int i = 0; i < 10; i++)
            {
                var pos = new asd.Vector2DF(Data.Random.Next(640), Data.Random.Next(480));
                var cloud = new Chara.Cloud(pos);
                layer.AddObject(cloud);
            }
            
            var tile_rect = new asd.RectangleShape();
            tile_rect.DrawingArea = new asd.RectF(120 - 32, 120 - 32, 640 - (120-32)*2, 480 - (120-32)*2);
            var tile = new asd.GeometryObject2D();
            tile.Shape = tile_rect;
            tile.Color = new asd.Color(90, 100, 180, 255);
            layer.AddObject(tile);

            var font = Data.Font;
            var clearLabel = new asd.TextObject2D();
            clearLabel.Font = font;
            clearLabel.Position = new asd.Vector2DF(120, 120);
            clearLabel.Text = "げーむくりあ!!!!!!!";
            layer.AddObject(clearLabel);

            var timeLabel = new asd.TextObject2D();
            timeLabel.Font = font;
            timeLabel.Position = new asd.Vector2DF(120, 120 + 32);
            timeLabel.Text = (time/1000).ToString() + "秒かかったよ!!!";
            layer.AddObject(timeLabel);

            var tokuLabel = new asd.TextObject2D();
            tokuLabel.Font = font;
            tokuLabel.Position = new asd.Vector2DF(120, 120 + 32 + 32);
            tokuLabel.Text = toku.ToString() + "コの徳を獲得!!!!";
            layer.AddObject(tokuLabel);

            var zLabel = new asd.TextObject2D();
            zLabel.Font = font;
            zLabel.Position = new asd.Vector2DF(120, 120 + 32 * 3);
            zLabel.Text = "Zキーでタイトル画面へ";
            layer.AddObject(zLabel);

            AddLayer(layer);
        }

        protected override void OnUpdated()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
            {
                asd.Engine.ChangeSceneWithTransition(new Scene.Title(),
                    new asd.TransitionFade(1.0F, 1.0F));
            }
        }
    }
}
