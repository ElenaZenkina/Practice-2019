using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Common;

namespace Model
{
    public class Game
    {
        public event EventGameOver OnGameOver;
        public event EventAddScore OnAddScore;
        public event EventUpdateView OnUpdateView;

        private List<Point> walls;
        private List<Point> apples;
        private List<Tank> tanks;
        private List<Bullet> bullets;
        private Kolobok kolobok;

        private Random rnd = new Random();

        public Game()
        {
        }

        public void Move()
        {
            MoveTanks();
            MoveKolobok();
            MoveBullets();

            OnUpdateView?.Invoke(UpdateStat());
        }

        private void MoveBullets()
        {
            if (bullets == null) { return; }

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Move();
                bullets[i].Location = bullets[i].NextStep;

                if (bullets[i].FromTank && !IsNotKolobok(bullets[i].NextStep, IniGraphic.bulletSize))
                {
                    OnGameOver?.Invoke();
                }

                if (IsOutBullet(bullets[i].NextStep, IniGraphic.bulletSize) || !IsNotWall(bullets[i].NextStep, IniGraphic.bulletSize))
                {
                    bullets.RemoveAt(i);
                    i--;
                    continue;
                }

                if (!bullets[i].FromTank && tanks != null)
                {
                    for (int j = 0; j < tanks.Count; j++)
                    {
                        if (IsCross(bullets[i].NextStep, IniGraphic.bulletSize, tanks[j].Location, IniGraphic.tankSize))
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

                if (IsNotWall(tanks[i].NextStep, IniGraphic.tankSize))
                {
                    tanks[i].Location = tanks[i].NextStep;
                }

                for (int j = 0; j < tanks.Count; j++)
                {
                    if (i == j) { continue; }
                    if (IsCross(tanks[i].Location, IniGraphic.tankSize, tanks[j].Location, IniGraphic.tankSize))
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
            if (IsNotWall(kolobok.NextStep, IniGraphic.kolobokSize))
            {
                kolobok.Location = kolobok.NextStep;
            }

            if (!IsNotTank(kolobok.Location, IniGraphic.kolobokSize))
            {
                OnGameOver?.Invoke();
            }

            if (IsEatApple(kolobok.Location, IniGraphic.kolobokSize, out Point appleEating))
            {
                apples.Add(CreateOneApple());
                OnAddScore?.Invoke();
            }
        }

        public void TurnKolobok(EDirection direction)
        {
            kolobok.Turn(direction);
        }

        public void FireKolobok()
        {
            bullets.Add(new Bullet(kolobok.Location, kolobok.Direction, IniGraphic.kolobokSize, false));
        }

        private void FireTank(Tank tank)
        {
            if (rnd.Next(0, 100) == 1)
            {
                bullets.Add(new Bullet(tank.Location, tank.Direction, IniGraphic.tankSize, true));
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

        public void NewGame()
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
                point.X = rnd.Next(0, (Ini.Width / IniGraphic.tankSize)) * IniGraphic.tankSize;
                point.Y = rnd.Next(0, (Ini.Height / IniGraphic.tankSize)) * IniGraphic.tankSize;
            } while (!IsNotWall(point, IniGraphic.wallSize) || !IsNotApple(point, IniGraphic.appleSize) || !IsNotTank(point, IniGraphic.tankSize));
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
                point.X = rnd.Next(0, (Ini.Width - IniGraphic.tankSize));
                point.Y = rnd.Next(0, (Ini.Height - IniGraphic.tankSize));
            } while (!IsNotWall(point, IniGraphic.tankSize) || !IsNotApple(point, IniGraphic.tankSize) || !IsNotTank(point, IniGraphic.tankSize));

            return new Tank(point);
        }

        private void CreateMaze()
        {
            walls = IniGraphic.Maze;
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
                point.X = rnd.Next(0, (Ini.Width - IniGraphic.appleSize));
                point.Y = rnd.Next(0, (Ini.Height - IniGraphic.appleSize));
            } while (!IsNotWall(point, IniGraphic.appleSize) || !IsNotApple(point, IniGraphic.appleSize) || !IsNotKolobok(point, IniGraphic.appleSize));

            return point;
        }

#endregion

        #region Пересечения объектов

        private bool IsNotTank(Point point, int size)
        {
            if (tanks == null) { return true; }

            for (int i = 0; i < tanks.Count; i++)
            {
                if (IsCross(point, size, tanks[i].Location, IniGraphic.tankSize)) { return false; }
            }

            return true;
        }

        private bool IsNotWall(Point point, int size)
        {
            if (walls == null) { return true; }

            for (int i = 0; i < walls.Count; i++)
            {
                if (IsCross(point, size, walls[i], IniGraphic.wallSize)) { return false; }
            }

            return true;
        }

        private bool IsNotApple(Point point, int size)
        {
            if (apples == null) { return true; }

            for (int i = 0; i < apples.Count; i++)
            {
                if (IsCross(point, size, apples[i], IniGraphic.appleSize)) { return false; }
            }

            return true;
        }


        private bool IsNotKolobok(Point point, int size)
        {
            if (kolobok == null) { return true; }

            return (!IsCross(point, size, kolobok.Location, IniGraphic.kolobokSize));
        }

        private bool IsEatApple(Point point, int size, out Point appleEating)
        {
            appleEating = new Point();
            if (apples == null) { return false; }

            for (int i = 0; i < apples.Count; i++)
            {
                if (IsCross(point, size, apples[i], IniGraphic.appleSize))
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
            return (point.X <= 0 || point.Y <= 0 || point.X + size >= Ini.Width || point.Y + size >= Ini.Height);
        }

        #endregion
    }
}
