using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class Kolobok : Unit
    {
        public Kolobok()
        {
            Direction = EDirection.Left;
        }

        public void Turn(EDirection direction)
        {
            Direction = direction;
        }

        public void Move()
        {
            TryMove();
        }

    }
}
