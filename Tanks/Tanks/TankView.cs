using System;
using System.Drawing;

namespace Tanks
{
    public class TankView
    {
        public Image imageTank = Properties.Resources.tank;

        private readonly Size size = new Size(Properties.Resources.tank.Width, Properties.Resources.tank.Height);
        private readonly Rectangle profile = new Rectangle(0, 0, Properties.Resources.tank.Width, Properties.Resources.tank.Height);

        public TankView()
        {
        }

        public void Draw(Point location, Graphics field)
        {
            field.DrawImage(imageTank, new Rectangle(location, size), profile, GraphicsUnit.Pixel);
        }
    }
}
