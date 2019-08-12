using System;
using System.Drawing;

namespace Tanks
{
    class Bullet
    {
        public Point Location { get; set; }
        public Point NextStep { get; private set; }
        public Point PreviousStep { get; private set; }
        public EDirection Direction { get; protected set; }
        public int Size { get; protected set; }
        public bool FromTank { get; private set; }

        private const int step = 3;

        public Bullet(Point location, EDirection direction, int sizeOwner, bool fromTank)
        {
            Size = 5;
            Direction = direction;
            FromTank = fromTank;
            var point = location;
            switch (Direction)
            {
                case EDirection.Left:
                    point.X = location.X - step;
                    point.Y = location.Y + (sizeOwner / 2);
                    break;
                case EDirection.Right:
                    point.X = location.X + sizeOwner + step;
                    point.Y = location.Y + (sizeOwner / 2);
                    break;
                case EDirection.Up:
                    point.X = location.X + (sizeOwner / 2);
                    point.Y = location.Y - step;
                    break;
                case EDirection.Down:
                    point.X = location.X + (sizeOwner / 2);
                    point.Y = location.Y + sizeOwner + step;
                    break;
            }
            Location = point;
        }

        public void Move()
        {
            PreviousStep = Location;
            var point = Location;

            switch (Direction)
            {
                case EDirection.Left:
                    point.X -= (Location.X <= 0 ? 0 : step);
                    break;
                case EDirection.Right:
                    point.X += (Location.X + Size >= Ini.Width ? 0 : step);
                    break;
                case EDirection.Up:
                    point.Y -= (Location.Y <= 0 ? 0 : step);
                    break;
                case EDirection.Down:
                    point.Y += (Location.Y + Size >= Ini.Height ? 0 : step);
                    break;
                default:
                    break;
            }
            NextStep = point;
        }
    }
}
