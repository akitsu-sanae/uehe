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
    class Title : asd.Scene
    {
        public Title()
        {
            var rect = new asd.RectangleShape();
            rect.DrawingArea = new asd.RectF(0, 0, 640, 480);
            background.Shape = rect;
            background.Color = new asd.Color(90, 150, 240, 255);
            mainLayer.AddObject(background);

            gameTitleLabel.Font = Data.BigFont;
            gameTitleLabel.Text = "上へ・・・";
            gameTitleLabel.Position = new asd.Vector2DF(180, 160);
            mainLayer.AddObject(gameTitleLabel);

            startLabel.Font = Data.Font;
            startLabel.Text = "Game Start";
            startLabel.Position = new asd.Vector2DF(200, 300);
            mainLayer.AddObject(startLabel);

            quitLabel.Font = Data.Font;
            quitLabel.Text = "Quit";
            quitLabel.Position = new asd.Vector2DF(200, 364);
            mainLayer.AddObject(quitLabel);

            cursorLabel.Font = Data.Font;
            cursorLabel.Text = "→";
            cursorLabel.Position = new asd.Vector2DF(160, startLabel.Position.Y);
            mainLayer.AddObject(cursorLabel);

            this.AddLayer(mainLayer);

            for (int i = 0; i < 10; i++)
            {
                var pos = new asd.Vector2DF(Data.Random.Next(640), Data.Random.Next(480));
                var cloud = new Chara.Cloud(pos);
                backLayer.AddObject(cloud);
            }
            this.AddLayer(backLayer);


        }

        protected override void OnUpdated()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Push)
                cursor = Cursor.GameStart;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.KeyState.Push)
                cursor = Cursor.Quit;

            switch (cursor)
            {
                case Cursor.GameStart:
                    cursorLabel.Position = new asd.Vector2DF(160, startLabel.Position.Y);
                    break;
                case Cursor.Quit:
                    cursorLabel.Position = new asd.Vector2DF(160, quitLabel.Position.Y);
                    break;
            }

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
            {
                switch (cursor) {
                    case Cursor.GameStart:
                        asd.Engine.ChangeSceneWithTransition(new Scene.Game(), new asd.TransitionFade(1.0f, 1.0f));
                        break;
                    case Cursor.Quit:
                        Data.IsGameEnd = true;
                        break;
                }
            }
        }
        private asd.GeometryObject2D background = new asd.GeometryObject2D();
        private asd.Layer2D mainLayer = new asd.Layer2D();
        private asd.Layer2D backLayer = new asd.Layer2D();

        enum Cursor
        {
            GameStart,
            Quit
        }
        Cursor cursor = Cursor.GameStart;
        private asd.TextObject2D cursorLabel = new asd.TextObject2D();
        private asd.TextObject2D gameTitleLabel = new asd.TextObject2D();
        private asd.TextObject2D startLabel = new asd.TextObject2D();
        private asd.TextObject2D quitLabel = new asd.TextObject2D();
    }
}
