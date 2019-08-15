using System;
using System.Drawing;

namespace Tanks
{
    public class KolobokView
    {
        private Image imageKolobok = Properties.Resources.kolobok;

        private readonly Size size = new Size(Properties.Resources.kolobok.Width, Properties.Resources.kolobok.Height);
        private readonly Rectangle profile = new Rectangle(0, 0, Properties.Resources.kolobok.Width, Properties.Resources.kolobok.Height);

        public KolobokView()
        {
        }

        public void Draw(Point location, Graphics field)
        {
            field.DrawImage(imageKolobok, new Rectangle(location, size), profile, GraphicsUnit.Pixel);
        }
    }
}
