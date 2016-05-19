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
    class Game : asd.Scene
    {

        private void InitBackgroundLayer()
        {
            var rect = new asd.RectangleShape();
            rect.DrawingArea = new asd.RectF(0, 0, 640, 480);
            var background = new asd.GeometryObject2D();
            background.Shape = rect;
            background.Color = new asd.Color(90, 150, 240, 255);
            backgroundLayer.AddObject(background);
            this.AddLayer(backgroundLayer);
        }

        public Game()
        {
            InitBackgroundLayer();
            gameLayer = new Layer.Game(status);
            this.AddLayer(gameLayer);
            statusLayer = new Layer.Status(status);
            this.AddLayer(statusLayer);

            stopWatch.Start();
        }

        protected override void OnUpdated()
        {
            if (gameLayer.IsClear())
            {
                stopWatch.Stop();
                asd.Engine.ChangeSceneWithTransition(
                    new Scene.Clear(stopWatch.ElapsedMilliseconds, status.nToku),
                    new asd.TransitionFade(1.0F, 1.0F));
            }
        }

        private System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
        private asd.Layer2D backgroundLayer = new asd.Layer2D();
        private Layer.Game gameLayer;
        private Layer.Status statusLayer;
        private Status status = new Status();
    }
}
