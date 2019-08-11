using System;
using System.Drawing;

namespace Tanks
{
    class KolobokView
    {
        private Image imageKolobok = Properties.Resources.kolobok;
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
                //pbxField.Invalidate(new Rectangle(pointPrevious, new Size(20, 20)));
                field.DrawImage(imageKolobok, new Rectangle(kolobok.Location, size), profile, GraphicsUnit.Pixel);

            }
        }
    }
}
