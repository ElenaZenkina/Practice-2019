using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class Kolobok
    {
        public Point location;
        public EDirection direction;

        public void Move(int offset)
        {
            switch (direction)
            {
                case EDirection.Left:
                    location.X -= offset;
                    break;
                case EDirection.Right:
                    location.X += offset;
                    break;
                case EDirection.Up:
                    location.Y -= offset;
                    break;
                case EDirection.Down:
                    location.Y += offset;
                    break;
                default:
                    break;
            }

        }
    }
}
