using System;
using System.Drawing;

namespace Tanks
{
    abstract class Unit
    {
        public Point Location { get; set; }
        public Point NextStep { get; private set; }
        public Point PreviousStep { get; private set; }
        public EDirection Direction { get; protected set; }

        public void TryMove()
        {
            PreviousStep = Location;
            var point = Location;

            switch (Direction)
            {
                case EDirection.Left:
                    point.X -= (Location.X == 0 ? 0 : Ini.Step);
                    break;
                case EDirection.Right:
                    point.X += (Location.X + Ini.kolobokSize == Ini.Width ? 0 : Ini.Step);
                    break;
                case EDirection.Up:
                    point.Y -= (Location.Y == 0 ? 0 : Ini.Step);
                    break;
                case EDirection.Down:
                    point.Y += (Location.Y + Ini.kolobokSize == Ini.Height ? 0 : Ini.Step);
                    break;
                default:
                    break;
            }
            NextStep = point;
        }

        public bool IsChangeCoordinate(Point point1, Point point2)
        {
            return (point1.X == point2.X && point1.Y == point2.Y);
        }
    }
}
