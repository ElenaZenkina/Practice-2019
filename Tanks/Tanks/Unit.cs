using System;
using System.Drawing;

namespace Tanks
{
    abstract class Unit
    {
        public Point Location { get; set; }
        public EDirection Direction { get; protected set; }

        public bool IsMoving(int offset)
        {
            var point = Location;
            switch (Direction)
            {
                case EDirection.Left:
                    point.X -= (Location.X == 0 ? 0 : offset);
                    break;
                case EDirection.Right:
                    point.X += (Location.X + Ini.kolobokSize == Ini.Width ? 0 : offset);
                    break;
                case EDirection.Up:
                    point.Y -= (Location.Y == 0 ? 0 : offset);
                    break;
                case EDirection.Down:
                    point.Y += (Location.Y + Ini.kolobokSize == Ini.Height ? 0 : offset);
                    break;
                default:
                    break;
            }

            if (!IsChangeCoordinate(point, Location))
            {
                Location = point;
                return true;
            }

            return false;
        }

        private bool IsChangeCoordinate(Point point1, Point point2)
        {
            return (point1.X == point2.X && point1.Y == point2.Y);
        }
    }
}
