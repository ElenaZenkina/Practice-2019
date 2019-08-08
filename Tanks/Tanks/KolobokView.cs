using System;
using System.Drawing;

namespace Tanks
{
    class KolobokView
    {
        public Image imageKolobok = Properties.Resources.kolobok;
        public Kolobok kolobok;

        public KolobokView(Kolobok kolobok)
        {
            this.kolobok = kolobok;
        }
    }
}
