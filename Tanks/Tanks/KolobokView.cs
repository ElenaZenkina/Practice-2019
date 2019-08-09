using System;
using System.Drawing;

namespace Tanks
{
    class KolobokView
    {
        private Image imageKolobok = Properties.Resources.kolobok;
        private Image imageEmpty = Properties.Resources.empty;
        public Kolobok kolobok;

        private readonly Size size = new Size(20, 20);
        private readonly Rectangle profile = new Rectangle(0, 0, 20, 20);

        public KolobokView(Kolobok kolobok)
        {
            this.kolobok = kolobok;
        }

        public void Draw(Graphics field)
        {
            if (!kolobok.IsChangeCoordinate(kolobok.PreviousStep, kolobok.Location))
            {
                //field.DrawImage(Properties.Resources.empty, new Rectangle(kolobok.PreviousStep, size), profile, GraphicsUnit.Pixel);
                field.DrawImage(imageKolobok, new Rectangle(kolobok.Location, size), profile, GraphicsUnit.Pixel);
            }
        }
    }
}
