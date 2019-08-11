using System;
using System.Drawing;

namespace Tanks
{
    class Bullet: Unit
    {
        public bool FromTank { get; private set; }

        public Bullet(Point location, EDirection direction, int sizeOwner, bool fromTank)
        {
            Size = 5;
            Direction = direction;
            FromTank = fromTank;
            var point = location;
            switch (Direction)
            {
                case EDirection.Left:
                    point.X = location.X - 2;
                    point.Y = location.Y + (sizeOwner / 2);
                    break;
                case EDirection.Right:
                    point.X = location.X + sizeOwner + 2;
                    point.Y = location.Y + (sizeOwner / 2);
                    break;
                case EDirection.Up:
                    point.X = location.X + (sizeOwner / 2);
                    point.Y = location.Y - 2;
                    break;
                case EDirection.Down:
                    point.X = location.X + (sizeOwner / 2);
                    point.Y = location.Y + sizeOwner + 2;
                    break;
            }
            Location = point;
        }

        public void Move()
        {
            TryMove();
            Location = NextStep;
            TryMove();
        }
    }
}
