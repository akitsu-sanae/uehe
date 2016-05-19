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
    class Game : asd.Layer2D
    {
        private AmCr48hGameJam2016_5.Status status;

        public Game(AmCr48hGameJam2016_5.Status status)
        {
            this.status = status;

            player = new Chara.PlayerHuman(map, new asd.Vector2DF(32 * 4, (Data.Height - 3) * 32), status);
            AddObject(player);

            camera.Src = new asd.RectI(new asd.Vector2DI(), asd.Engine.WindowSize);
            camera.Dst = new asd.RectI(new asd.Vector2DI(), asd.Engine.WindowSize);
            AddObject(camera);

            LoadMap();

        }
        private void LoadMap()
        {
            var bitmap = new System.Drawing.Bitmap("Resources/stage.bmp");
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var color = bitmap.GetPixel(x, y);
                    if (color.R == 0 && color.G == 0 && color.B == 0)
                        continue;

                    if (color.R > 0)
                    {
                        var chip = new asd.Chip2D();
                        chip.Texture = Data.Image;
                        chip.Position = new asd.Vector2DF(x * 32, y * 32);
                        map.AddChip(chip);
                        chip.Src = Data.rect(Data.GraphType.Block);
                    }
                    else if (color.G > 0)
                    {
                        AddObject(new Chara.TokuItem(player, status, new asd.Vector2DF(x * 32, y * 32)));
                    }
                    else if (color.B > 0)
                    {
                        var cloud = new Chara.Cloud(new asd.Vector2DF(x * 32, y * 32));
                        this.clouds.Add(cloud);
                        AddObject(cloud);
                    }
                }
            }
            AddObject(map);
        }

        private void ChangePlayer()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.A) == asd.KeyState.Push && player is Chara.PlayerHuman && status.nNen > 0)
            {
                var p = new Chara.PlayerRocket(map, player.Position, status);
                AddObject(p);
                player.Dispose();
                player = p;
                status.nNen--;
            }
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.A) == asd.KeyState.Release && player is Chara.PlayerRocket)
            {
                var p = new Chara.PlayerHuman(map, player.Position, status);
                AddObject(p);
                player.Dispose();
                player = p;
            }


            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.S) == asd.KeyState.Push && player is Chara.PlayerHuman)
            {
                var p = new Chara.PlayerMonk(map, player.Position, status, clouds);
                AddObject(p);
                player.Dispose();
                player = p;
            }
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.S) == asd.KeyState.Release && player is Chara.PlayerMonk)
            {
                var p = new Chara.PlayerHuman(map, player.Position, status);
                AddObject(p);
                player.Dispose();
                player = p;
            }
        }

        protected override void OnUpdated()
        {
            // update camera
            var SrcY = (int)player.Position.Y - asd.Engine.WindowSize.Y / 2;
            if (SrcY + asd.Engine.WindowSize.Y > Data.Height * 32)
                SrcY = Data.Height * 32 - asd.Engine.WindowSize.Y;
            if (SrcY < 0)
                SrcY = 0;
            camera.Src = new asd.RectI(
                0,
                SrcY,
                asd.Engine.WindowSize.X, asd.Engine.WindowSize.Y);

            ChangePlayer();

            foreach(var obj in Objects)
            {
                if (!(obj is Chara.TokuItem))
                    continue;
                (obj as Chara.TokuItem).setPlayer(player);
            }
        }

        public bool IsClear()
        {
            return player.Position.Y <= asd.Engine.WindowSize.Y / 2;
        }

        private asd.MapObject2D map = new asd.MapObject2D();
        private asd.CameraObject2D camera = new asd.CameraObject2D();
        private List<Chara.Cloud> clouds = new List<Chara.Cloud>();
        private Chara.Player player;
    }
}
