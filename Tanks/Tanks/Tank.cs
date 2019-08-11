using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class Tank: Unit
    {
        public EDirection PreviousDirection { get; set; }
        public Tank(Point location)
        {
            Location = location;
            Direction = EDirection.Left;
            Size = Ini.tankSize;
        }

        public void Turn(Random rnd)
        {
            PreviousDirection = Direction;
            switch (rnd.Next(0, 4))
            {
                case 0:
                    Direction = EDirection.Up;
                    break;
                case 1:
                    Direction = EDirection.Right;
                    break;
                case 2:
                    Direction = EDirection.Down;
                    break;
                default:
                    Direction = EDirection.Left;
                    break;
            }
        }

        public void Turn180()
        {
            switch (Direction)
            {
                case EDirection.Up:
                    Direction = EDirection.Down;
                    break;
                case EDirection.Right:
                    Direction = EDirection.Left;
                    break;
                case EDirection.Down:
                    Direction = EDirection.Up;
                    break;
                case EDirection.Left:
                    Direction = EDirection.Right;
                    break;
            }
        }

        public void Move(Random rnd)
        {
            TryMove();
            Turn(rnd);
        }

    }
}
