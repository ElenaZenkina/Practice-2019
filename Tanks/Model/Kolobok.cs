using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Common;

namespace Model
{
    public class Kolobok : Unit
    {
        private int kolobokSpeed = 1;

        public Kolobok()
        {
            Direction = EDirection.Left;
            Size = IniGraphic.kolobokSize;
        }

        public void Turn(EDirection direction)
        {
            Direction = direction;
        }

        public void Move()
        {
            TryMove(kolobokSpeed);
        }

    }
}
