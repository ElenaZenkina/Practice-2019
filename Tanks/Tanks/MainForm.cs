using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class MainForm : Form
    {
        private PackmanController packman;
        private int score = 0;
        private bool onDraw = false;

        private readonly Size size = new Size(20, 20);
        private readonly Rectangle profile = new Rectangle(0, 0, 20, 20);

        public MainForm()
        {
            packman = new PackmanController(this);
            InitializeComponent();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            packman.LoadIni();
            //pbxField.Invalidate(new Rectangle(0, 0, Ini.Width, Ini.Height));
            pbxField.Size = new Size(Ini.Width, Ini.Height);

            Setting();

            score = 0;
            // Ini.Speed - количество пикселей в секунду
            timer1.Interval = 1000 / Ini.Speed;
            timer1.Enabled = true;
            timer1.Start();
            btnNewGame.Enabled = false;
            lblStarted.Text = "Игра началась...";
        }

        private void Setting()
        {
            Rectangle scrImage;
            using (Graphics field = pbxField.CreateGraphics())
            {
                for (int i = 0; i < packman.game.walls.Count; i++)
                {
                    scrImage = new Rectangle(packman.game.walls[i], size);
                    field.DrawImage(Properties.Resources.wall, scrImage, profile, GraphicsUnit.Pixel);
                }

                for (int i = 0; i < packman.game.apples.Count; i++)
                {
                    scrImage = new Rectangle(packman.game.apples[i], size);
                    field.DrawImage(Properties.Resources.apple, scrImage, profile, GraphicsUnit.Pixel);
                }

                for (int i = 0; i < packman.game.tanks.Count; i++)
                {
                    packman.tankView.Draw(packman.game.tanks[i], field);
                }

                packman.kolobokView.Draw(field);
                //pbxField.Invalidate(new Rectangle(packman.kolobokView.kolobok.Location, new Size(20, 20)));
                //field.DrawImage(Properties.Resources.kolobok, new Rectangle(packman.kolobokView.kolobok.Location, size), profile, GraphicsUnit.Pixel);
            }


            /*Image img = Image.FromFile("fire.png");
            Graphics gr = pictureBox1.CreateGraphics();
            y = y + 2;
            if (OnFire == true)
            {
                gr.DrawImage(img, 370, y, 70, 70);
            }
            pictureBox1.Invalidate();*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            packman.StartGame();
            Point pointPrevious = packman.kolobokView.kolobok.PreviousStep;
            Point pointCurrent = packman.kolobokView.kolobok.Location;

            using (Graphics field = pbxField.CreateGraphics())
            {
                //pbxField.Invalidate(new Rectangle(pointPrevious, new Size(20, 20)));
                /*if (onDraw)
                {
                    field.DrawImage(Properties.Resources.kolobok, new Rectangle(pointCurrent, size), profile, GraphicsUnit.Pixel);
                }
                else
                {
                    pbxField.Invalidate(new Rectangle(pointPrevious, new Size(20, 20)));
                }

                onDraw = !onDraw;*/
                packman.kolobokView.Draw(field);
                for (int i = 0; i < packman.game.tanks.Count; i++)
                {
                    packman.tankView.Draw(packman.game.tanks[i], field);
                }
                for (int i = 0; i < packman.game.bullets.Count; i++)
                {
                    field.DrawImage(Properties.Resources.bullet, new Rectangle(packman.game.bullets[i].Location, new Size(5, 5)), new Rectangle(0, 0, 5, 5), GraphicsUnit.Pixel);
                }
            }

        }

        public void UpdateScore(Point appleEating, Point appleNew)
        {
            score++;
            lblScore.Text = score.ToString();

            using (Graphics field = pbxField.CreateGraphics())
            {
                pbxField.Invalidate(new Rectangle(appleEating, new Size(20, 20)));
                field.DrawImage(Properties.Resources.apple, new Rectangle(appleNew, size), profile, GraphicsUnit.Pixel);
            }
        }

        public void GameOver()
        {
            timer1.Stop();
            timer1.Enabled = false;

            lblStarted.Text = "Игра закончена";
            btnNewGame.Enabled = true;
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
