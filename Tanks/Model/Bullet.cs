using System;
using System.Drawing;
using Common;

namespace Model
{
    public class Bullet : Unit
    {
        public bool FromTank { get; private set; }

        private const int bulletSpeed = 2;
        private const int offset = 2;

        public Bullet(Point location, EDirection direction, int sizeOwner, bool fromTank)
        {
            Size = 5;
            Direction = direction;
            FromTank = fromTank;
            var point = location;
            switch (Direction)
            {
                case EDirection.Left:
                    point.X = location.X - offset;
                    point.Y = location.Y + (sizeOwner / 2);
                    break;
                case EDirection.Right:
                    point.X = location.X + sizeOwner + offset;
                    point.Y = location.Y + (sizeOwner / 2);
                    break;
                case EDirection.Up:
                    point.X = location.X + (sizeOwner / 2);
                    point.Y = location.Y - offset;
                    break;
                case EDirection.Down:
                    point.X = location.X + (sizeOwner / 2);
                    point.Y = location.Y + sizeOwner + offset;
                    break;
            }
            Location = point;
        }

        public void Move()
        {
            TryMove(bulletSpeed);
        }
    }
}
