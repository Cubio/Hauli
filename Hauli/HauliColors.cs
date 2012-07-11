using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Hauli
{
    class HauliColors
    {
        public static List<Color> colorList;

        public HauliColors()
        {
            colorList = new List<Color>();
            colorList.Add(Color.White);
            colorList.Add(Color.LightSkyBlue);
            colorList.Add(Color.Yellow);
            colorList.Add(Color.LightGreen);
            colorList.Add(Color.Orange);
            colorList.Add(Color.Violet);
            colorList.Add(Color.DarkKhaki);
            colorList.Add(Color.Lime);
            colorList.Add(Color.Cyan);
            colorList.Add(Color.LightPink);
            colorList.Add(Color.Tomato);
            colorList.Add(Color.MediumBlue);
            colorList.Add(Color.Green);
            colorList.Add(Color.YellowGreen);
            colorList.Add(Color.Blue);
            colorList.Add(Color.Aqua);
            colorList.Add(Color.Navy);
            colorList.Add(Color.Bisque);
            colorList.Add(Color.Coral);
            colorList.Add(Color.DarkMagenta);
            colorList.Add(Color.LightGoldenrodYellow);
            colorList.Add(Color.Indigo);
            colorList.Add(Color.Olive);
            colorList.Add(Color.LemonChiffon);
            colorList.Add(Color.OrangeRed);
            colorList.Add(Color.Sienna);
            colorList.Add(Color.SeaShell);
            colorList.Add(Color.SaddleBrown);
            colorList.Add(Color.Red);
            colorList.Add(Color.HotPink);
            colorList.Add(Color.Teal);
            colorList.Add(Color.Thistle);
            colorList.Add(Color.Turquoise);
            colorList.Add(Color.Plum);
            colorList.Add(Color.Gold);

        }

        public List<Color> GetColors()
        {
            return colorList;
        }
    }
}
