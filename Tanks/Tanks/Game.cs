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
        private const int kolobokSize = 20;
        private const int bulletSize = 5;

        private SendScore sendScore;
        private SendGameOver sendGameOver;

        public List<Point> walls { get; private set; }
        public List<Point> apples { get; private set; }
        public List<Tank> tanks;
        public List<Bullet> bullets;
        public Kolobok kolobok;

        private Random rnd = new Random();

        public Game(SendScore sendScore, SendGameOver sendGameOver)
        {
            this.sendScore = sendScore;
            this.sendGameOver = sendGameOver;
            Ini.Init();
            NewGame();
        }

        public void Move(SendStat sendStat)
        {
            MoveTanks();
            MoveKolobok();
            MoveBullets();

            sendStat(UpdateStat());
        }

        private void MoveBullets()
        {
            if (bullets == null) { return; }

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Move();
                bullets[i].Location = bullets[i].NextStep;

                if (bullets[i].FromTank && !IsNotKolobok(bullets[i].NextStep, bulletSize))
                {
                    sendGameOver();
                }

                if (IsOutBullet(bullets[i].NextStep, bulletSize) || !IsNotWall(bullets[i].NextStep, bulletSize))
                {
                    bullets.RemoveAt(i);
                    i--;
                    continue;
                }

                if (!bullets[i].FromTank && tanks != null)
                {
                    for (int j = 0; j < tanks.Count; j++)
                    {
                        if (IsCross(bullets[i].NextStep, bulletSize, tanks[j].Location, tankSize))
                        {
                            bullets.RemoveAt(i);
                            tanks.RemoveAt(j);
                            i--;
                            break;
                        }
                    }
                }

            }
        }

        private void MoveTanks()
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                FireTank(tanks[i]);

                tanks[i].Move(rnd);

                if (IsNotWall(tanks[i].NextStep, tankSize))
                {
                    tanks[i].Location = tanks[i].NextStep;
                }

                for (int j = 0; j < tanks.Count; j++)
                {
                    if (i == j) { continue; }
                    if (IsCross(tanks[i].Location, tankSize, tanks[j].Location, tankSize))
                    {
                        tanks[i].Turn180();
                        tanks[i].Move(rnd);
                        tanks[j].Turn180();
                    }
                }
            }
        }

        private void MoveKolobok()
        {
            kolobok.Move();
            if (IsNotWall(kolobok.NextStep, kolobokSize))
            {
                kolobok.Location = kolobok.NextStep;
            }

            if (!IsNotTank(kolobok.Location, kolobokSize))
            {
                sendGameOver();
            }

            if (IsEatApple(kolobok.Location, kolobokSize, out Point appleEating))
            {
                apples.Add(CreateOneApple());
                sendScore(appleEating, apples[Ini.Apples - 1]);
            }
        }

        public void FireKolobok()
        {
            bullets.Add(new Bullet(kolobok.Location, kolobok.Direction, bulletSize, false));
        }

        private void FireTank(Tank tank)
        {
            if (rnd.Next(0, 100) == 1)
            {
                bullets.Add(new Bullet(tank.Location, tank.Direction, bulletSize, true));
            }
        }


        private List<string> UpdateStat()
        {
            var stats = new List<string>();
            stats.Add("kolobok" + "," + kolobok.Location.X + "," + kolobok.Location.Y);

            for (int i = 0; i < tanks.Count; i++)
            {
                stats.Add("tank" + "," + tanks[i].Location.X + "," + tanks[i].Location.Y);
            }

            for (int i = 0; i < bullets.Count; i++)
            {
                stats.Add("bullet" + "," + bullets[i].Location.X + "," + bullets[i].Location.Y);
            }

            for (int i = 0; i < apples.Count; i++)
            {
                stats.Add("apple" + "," + apples[i].X + "," + apples[i].Y);
            }

            for (int i = 0; i < walls.Count; i++)
            {
                stats.Add("wall" + "," + walls[i].X + "," + walls[i].Y);
            }

            return stats;
        }

        #region Новая игра

        private void NewGame()
        {
            CreateMaze();
            CreateApples();
            CreateTanks();
            CreateKolobok();
            bullets = new List<Bullet>();
        }

        private void CreateKolobok()
        {
            kolobok = new Kolobok();
            Point point = new Point();
            do
            {
                point.X = rnd.Next(0, (Ini.Width / tankSize)) * tankSize;
                point.Y = rnd.Next(0, (Ini.Height / tankSize)) * tankSize;
            } while (!IsNotWall(point, wallSize) || !IsNotApple(point, appleSize) || !IsNotTank(point, tankSize));
            kolobok.Location = point;
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
                point.X = rnd.Next(0, (Ini.Width - tankSize));
                point.Y = rnd.Next(0, (Ini.Height - tankSize));
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
                point.X = rnd.Next(0, (Ini.Width - appleSize));
                point.Y = rnd.Next(0, (Ini.Height - appleSize));
            } while (!IsNotWall(point, appleSize) || !IsNotApple(point, appleSize) || !IsNotKolobok(point, appleSize));

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


        private bool IsNotKolobok(Point point, int size)
        {
            if (kolobok == null) { return true; }

            return (!IsCross(point, size, kolobok.Location, kolobokSize));
        }

        private bool IsEatApple(Point point, int size, out Point appleEating)
        {
            appleEating = new Point();
            if (apples == null) { return false; }

            for (int i = 0; i < apples.Count; i++)
            {
                if (IsCross(point, size, apples[i], appleSize))
                {
                    appleEating = apples[i];
                    apples.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        private bool IsCross(Point point1, int size1, Point point2, int size2)
        {
            return !(point1.X + size1 <= point2.X || point1.X >= point2.X + size2 || 
                     point1.Y + size1 <= point2.Y || point1.Y >= point2.Y + size2);
        }

        private bool IsOutBullet(Point point, int size)
        {
            return (point.X == 0 || point.Y == 0 || point.X + size >= Ini.Width || point.Y + size >= Ini.Height);
        }

        #endregion
    }
}
