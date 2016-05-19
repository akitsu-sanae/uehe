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

namespace AmCr48hGameJam2016_5
{
    static class Data
    {
        public static bool IsGameEnd = false;
        public static System.Random Random = new Random();

        public static asd.Texture2D Image;
        public static asd.Font BigFont;
        public static asd.Font Font;

        public static void Initialize()
        {
            Image = asd.Engine.Graphics.CreateTexture2D("Resources/image.png");

            BigFont = asd.Engine.Graphics.CreateDynamicFont(
                "Resources/MAKINAS.otf",
                64, new asd.Color(255, 255, 255, 255),
                0, new asd.Color(255, 255, 255, 255));

            Font = asd.Engine.Graphics.CreateDynamicFont(
                "Resources/MAKINAS.otf",
                32, new asd.Color(255, 255, 255, 255),
                0, new asd.Color(255, 255, 255, 255));
        }

        public enum GraphType
        {
            Player1,
            Player2,
            Player3,
            Player4,

            PlayerMonk,
            PlayerRocket,
            
            SignBoard,
            Block,
            Cloud,

            Toku,

            Invalid
        }

        public static asd.RectF rect(GraphType type)
        {
            var l = 32;
            switch (type)
            {
                case GraphType.Player1:
                    return new asd.RectF(0, 0, l, l);
                case GraphType.Player2:
                    return new asd.RectF(l, 0, l, l);
                case GraphType.Player3:
                    return new asd.RectF(2 * l, 0, l, l);
                case GraphType.Player4:
                    return new asd.RectF(3 * l, 0, l, l);
                case GraphType.PlayerMonk:
                    return new asd.RectF(0, l, l, l);
                case GraphType.PlayerRocket:
                    return new asd.RectF(l, l, 2 * l, 2 * l);

                case GraphType.SignBoard:
                    return new asd.RectF(0, 6 * l, l, l);
                case GraphType.Block:
                    return new asd.RectF(l, 6 * l, l, l);
                case GraphType.Cloud:
                    return new asd.RectF(3 * l, 6 * l, 2 * l, l);
                case GraphType.Toku:
                    return new asd.RectF(l, 7 * l, l, l);
                default:
                    return new asd.RectF(2 * l, 6 * l, l, l);
            }
        }

        public static bool isEqual(GraphType type, asd.RectF rect)
        {
            var lhs = Data.rect(type);
            return lhs.X == rect.X && lhs.Y == rect.Y;
        }

        public static void Terminate()
        {

        }

        public const int Width = 20;
        public const int Height = 320;
    }
}
