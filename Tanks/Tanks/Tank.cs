using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    public class Tank
    {
        public Point Location;
        private EDirection direction;

        public SendMessage MessageSender;

        public Tank(Point location)
        {
            this.Location = location;
            direction = EDirection.Left;
        }

        public void Move(Random rnd)
        {
            int offset = 1;
            switch (rnd.Next(0, 4))
            {
                case 0:
                    direction = EDirection.Up;
                    Location.X -= offset;
                    break;
                case 1:
                    direction = EDirection.Right;
                    Location.Y += offset;
                    break;
                case 2:
                    direction = EDirection.Down;
                    Location.X += offset;
                    break;
                default:
                    direction = EDirection.Left;
                    Location.Y -= offset;
                    break;
            }

            MessageSender("tank", Location.X, Location.Y);
        }
    }
}
