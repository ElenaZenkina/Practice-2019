using System;
using System.Drawing;

namespace Tanks
{
    class KolobokView
    {
        private Image imageKolobok = Properties.Resources.kolobok;
        public Kolobok kolobok;

        private readonly Size size = new Size(Properties.Resources.kolobok.Width, Properties.Resources.kolobok.Height);
        private readonly Rectangle profile = new Rectangle(0, 0, Properties.Resources.kolobok.Width, Properties.Resources.kolobok.Height);

        public KolobokView(Kolobok kolobok)
        {
            this.kolobok = kolobok;
        }

        public void Draw(Graphics field)
        {
            field.DrawImage(imageKolobok, new Rectangle(kolobok.Location, size), profile, GraphicsUnit.Pixel);
        }
    }
}
