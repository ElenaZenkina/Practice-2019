using System;
using System.Drawing;
using Common;

namespace Model
{
    public abstract class Unit
    {
        public Point Location { get; set; }
        public Point NextStep { get; private set; }
        public Point PreviousStep { get; private set; }
        public EDirection Direction { get; protected set; }
        public int Size { get; protected set; }


        /// <summary>
        /// Движение вперед
        /// </summary>
        /// <param name="speed">во сколько раз скорость больше, чем изначально установленная для движущегося объекта
        /// (скорость пули больше скорости колобка и танка) </param>
        public void TryMove(int speed)
        {
            PreviousStep = Location;
            var point = Location;

            switch (Direction)
            {
                case EDirection.Left:
                    point.X -= (Location.X <= 0 ? 0 : IniGraphic.Step * speed);
                    break;
                case EDirection.Right:
                    point.X += (Location.X + Size >= Ini.Width ? 0 : IniGraphic.Step * speed);
                    break;
                case EDirection.Up:
                    point.Y -= (Location.Y <= 0 ? 0 : IniGraphic.Step * speed);
                    break;
                case EDirection.Down:
                    point.Y += (Location.Y + Size >= Ini.Height ? 0 : IniGraphic.Step * speed);
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
