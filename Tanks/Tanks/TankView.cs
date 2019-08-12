using System;
using System.Drawing;

namespace Tanks
{
    class TankView
    {
        public Image imageTank = Properties.Resources.tank;

        private readonly Size size = new Size(Properties.Resources.tank.Width, Properties.Resources.tank.Height);
        private readonly Rectangle profile = new Rectangle(0, 0, Properties.Resources.tank.Width, Properties.Resources.tank.Height);

        public TankView()
        {
        }

        public void Draw(Tank tank, Graphics field)
        {
            Rectangle scrImage = new Rectangle(tank.Location, size);
            field.DrawImage(imageTank, scrImage, profile, GraphicsUnit.Pixel);
        }
    }
}
