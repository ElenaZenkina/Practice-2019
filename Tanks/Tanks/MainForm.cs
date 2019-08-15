using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Common;


namespace Tanks
{
    public partial class MainForm : Form
    {
        private PackmanController packman;
        private StatForm formStat;
        private int score = 0;

        private KolobokView kolobokView;
        private TankView tankView;

        public MainForm()
        {
            InitializeComponent();

            formStat = new StatForm();
            formStat.Show();

            packman = new PackmanController();
            Setting();
        }

        private void Setting()
        {
            Ini.Init();
            pbxField.Size = new Size(Ini.Width, Ini.Height);
            // Ini.Speed - количество пикселей в секунду
            timer1.Interval = 1000 / Ini.Speed;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            packman.StartGame(UpdateScore, UpdateView, GameOver);
            kolobokView = new KolobokView();
            tankView = new TankView();

            score = 0;
            timer1.Enabled = true;
            timer1.Start();
            btnNewGame.Enabled = false;
            lblStarted.Text = "Игра началась...";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            packman.Move();
        }

        public void UpdateScore()
        {
            score++;
            lblScore.Text = score.ToString();
        }

        public void GameOver()
        {
            timer1.Stop();
            timer1.Enabled = false;

            lblStarted.Text = "Игра закончена";
            btnNewGame.Enabled = true;
        }

        public void UpdateView(List<string> objects)
        {
            formStat.AddData(objects);

            Size size;
            Bitmap image = new Bitmap(Ini.Width, Ini.Height);
            Graphics field = Graphics.FromImage(image);

            size = new Size(Properties.Resources.wall.Width, Properties.Resources.wall.Height);
            var walls = objects.FindAll(s => s.StartsWith("wall"));
            for (int i = 0; i < walls.Count; i++)
            {
                field.DrawImage(Properties.Resources.wall, new Rectangle(StringToPoint(walls[i]), size), new Rectangle(new Point(0, 0), size), GraphicsUnit.Pixel);
            }

            size = new Size(Properties.Resources.apple.Width, Properties.Resources.apple.Height);
            var apples = objects.FindAll(s => s.StartsWith("apple"));
            for (int i = 0; i < apples.Count; i++)
            {
                field.DrawImage(Properties.Resources.apple, new Rectangle(StringToPoint(apples[i]), size), new Rectangle(new Point(0, 0), size), GraphicsUnit.Pixel);
            }

            size = new Size(Properties.Resources.bullet.Width, Properties.Resources.bullet.Height);
            var bullets = objects.FindAll(s => s.StartsWith("bullet"));
            for (int i = 0; i < bullets.Count; i++)
            {
                field.DrawImage(Properties.Resources.bullet, new Rectangle(StringToPoint(bullets[i]), size), new Rectangle(new Point(0, 0), size), GraphicsUnit.Pixel);
            }

            var kolobok = objects.Find(s => s.StartsWith("kolobok"));
            kolobokView.Draw(StringToPoint(kolobok), field);

            var tanks = objects.FindAll(s => s.StartsWith("tank"));
            for (int i = 0; i < tanks.Count; i++)
            {
                tankView.Draw(StringToPoint(tanks[i]), field);
            }

            pbxField.Image = image;
        }

        private Point StringToPoint(string str)
        {
            var pos = str.Split(',');
            int x = 0;
            Int32.TryParse(pos[1], out x);
            int y = 0;
            Int32.TryParse(pos[2], out y);

            return new Point(x, y);
        }

        private void AllControls_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    packman.TurnKolobok(EDirection.Up);
                    break;
                case Keys.Down:
                    packman.TurnKolobok(EDirection.Down);
                    break;
                case Keys.Left:
                    packman.TurnKolobok(EDirection.Left);
                    break;
                case Keys.Right:
                    packman.TurnKolobok(EDirection.Right);
                    break;
                case Keys.Space:
                    packman.FireKolobok();
                    break;
            }
        }
    }
}
