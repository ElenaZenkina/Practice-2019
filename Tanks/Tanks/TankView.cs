using System;
using System.Drawing;

namespace Tanks
{
    class TankView
    {
        public Image imageTank = Properties.Resources.tank;
        //public Tank tank;

        private readonly Size size = new Size(20, 20);
        private readonly Rectangle profile = new Rectangle(0, 0, 20, 20);

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
