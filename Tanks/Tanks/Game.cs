using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class Game
    {
        private const int appleSize = 20;
        private const int wallSize = 20;
        private const int tankSize = 20;

        public int FieldWidth { get; private set; }
        public int FieldHeight { get; private set; }

        public List<Point> walls { get; private set; }
        public List<Point> apples { get; private set; }
        public List<Tank> tanks;
        public Kolobok kolobok;

        private Random rnd = new Random();

        public Game()
        {
            Ini.Init();
            FieldWidth = Ini.Width;
            FieldHeight = Ini.Height;

            NewGame();
        }

        public void Move()
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                tanks[i].Move(rnd);
                //kolobok.Move();
            }
        }

        private void NewGame()
        {
            CreateMaze();
            CreateApples();
            CreateTanks();
            CreateKolobok();
        }

#region Новая игра

        private void CreateKolobok()
        {
            kolobok = new Kolobok();
            Point point = new Point();
            do
            {
                point.X = rnd.Next(0, (FieldWidth / tankSize)) * tankSize;
                point.Y = rnd.Next(0, (FieldHeight / tankSize)) * tankSize;
            } while (!IsNotWall(point, wallSize) || !IsNotApple(point, appleSize) || !IsNotTank(point, tankSize));
            kolobok.location = point;
        }

        private void CreateTanks()
        {
            tanks = new List<Tank>();
            for (int i = 0; i < Ini.Tanks; i++)
            {
                tanks.Add(CreateOneTank());
            }
        }

        private Tank CreateOneTank()
        {
            Point point = new Point();
            do
            {
                point.X = rnd.Next(0, (FieldWidth - tankSize));
                point.Y = rnd.Next(0, (FieldHeight - tankSize));
            } while (!IsNotWall(point, tankSize) || !IsNotApple(point, tankSize) || !IsNotTank(point, tankSize));

            return new Tank(point);
        }

        private void CreateMaze()
        {
            walls = new List<Point>();
            walls.Add(new Point(60, 40));
            walls.Add(new Point(80, 40));
            walls.Add(new Point(100, 40));
            walls.Add(new Point(120, 40));
            walls.Add(new Point(140, 40));
            walls.Add(new Point(160, 40));
            walls.Add(new Point(180, 40));
            walls.Add(new Point(200, 40));
            walls.Add(new Point(220, 40));
            walls.Add(new Point(240, 40));
            walls.Add(new Point(260, 40));
            walls.Add(new Point(280, 40));
            walls.Add(new Point(300, 40));

            walls.Add(new Point(100, 100));
            walls.Add(new Point(100, 120));
            walls.Add(new Point(100, 140));
            walls.Add(new Point(100, 160));
            walls.Add(new Point(100, 180));
            walls.Add(new Point(100, 200));
            walls.Add(new Point(100, 220));
            walls.Add(new Point(100, 240));

            walls.Add(new Point(300, 100));
            walls.Add(new Point(300, 120));
            walls.Add(new Point(300, 140));
            walls.Add(new Point(300, 160));
            walls.Add(new Point(300, 180));
            walls.Add(new Point(300, 200));
            walls.Add(new Point(300, 220));
            walls.Add(new Point(300, 240));
        }

        private void CreateApples()
        {
            apples = new List<Point>();
            for (int i = 0; i < Ini.Apples; i++)
            {
                apples.Add(CreateOneApple());
            }
        }

        private Point CreateOneApple()
        {
            Point point = new Point();
            do
            {
                point.X = rnd.Next(0, (FieldWidth - appleSize));
                point.Y = rnd.Next(0, (FieldHeight - appleSize));
            } while (!IsNotWall(point, appleSize) || !IsNotApple(point, appleSize));

            return point;
        }

#endregion

        #region Пересечения объектов

        private bool IsNotTank(Point point, int size)
        {
            if (tanks == null) { return true; }

            for (int i = 0; i < tanks.Count; i++)
            {
                if (IsCross(point, size, tanks[i].Location, tankSize)) { return false; }
            }

            return true;
        }

        private bool IsNotWall(Point point, int size)
        {
            if (walls == null) { return true; }

            for (int i = 0; i < walls.Count; i++)
            {
                if (IsCross(point, size, walls[i], wallSize)) { return false; }
            }

            return true;
        }

        private bool IsNotApple(Point point, int size)
        {
            if (apples == null) { return true; }

            for (int i = 0; i < apples.Count; i++)
            {
                if (IsCross(point, size, apples[i], appleSize)) { return false; }
            }

            return true;
        }

        private bool IsCross(Point point1, int size1, Point point2, int size2)
        {
            return !(point1.X + size1 <= point2.X || point1.X >= point2.X + size2 || 
                     point1.Y + size1 <= point2.Y || point1.Y >= point2.Y + size2);
        }

#endregion
    }
}
