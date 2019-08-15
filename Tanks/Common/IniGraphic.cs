using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Common
{
    public static class IniGraphic
    {
        public static int appleSize = 20;
        public static int wallSize = 20;
        public static int tankSize = 20;
        public static int kolobokSize = 20;
        public static int bulletSize = 5;

        public static List<Point> Maze = new List<Point>()
        {
            new Point(60, 40),
            new Point(80, 40),
            new Point(100, 40),
            new Point(120, 40),
            new Point(140, 40),
            new Point(160, 40),
            new Point(180, 40),
            new Point(200, 40),
            new Point(220, 40),
            new Point(240, 40),
            new Point(260, 40),
            new Point(280, 40),
            new Point(300, 40),

            new Point(100, 100),
            new Point(100, 120),
            new Point(100, 140),
            new Point(100, 160),
            new Point(100, 180),
            new Point(100, 200),
            new Point(100, 220),
            new Point(100, 240),

            new Point(300, 100),
            new Point(300, 120),
            new Point(300, 140),
            new Point(300, 160),
            new Point(300, 180),
            new Point(300, 200),
            new Point(300, 220),
            new Point(300, 240)
        };

        /// <summary>
        /// Количество пикселей при перемещение объекта за один кадр
        /// </summary>
        public static int Step = 1;
    }
}
