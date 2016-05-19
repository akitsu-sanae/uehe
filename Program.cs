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
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var result = System.Windows.Forms.MessageBox.Show(
                "ふるすくりーんにする？",
                "上へ・・・",
                System.Windows.Forms.MessageBoxButtons.YesNo);
            var option = new asd.EngineOption();
            option.IsFullScreen = result == System.Windows.Forms.DialogResult.Yes;

            asd.Engine.Initialize("上へ・・・", 640, 480, option);

            Data.Initialize();

            asd.Engine.ChangeScene(new Scene.Title());

            while (asd.Engine.DoEvents() && !Data.IsGameEnd)
            {
                asd.Engine.Update();
            }
            asd.Engine.Terminate();
        }
    }
}
