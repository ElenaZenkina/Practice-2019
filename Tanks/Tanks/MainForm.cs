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

        private readonly Size size = new Size(20, 20);
        private readonly Rectangle profile = new Rectangle(0, 0, 20, 20);

        public MainForm()
        {
            Ini.Init();

            InitializeComponent();
            pbxField.Size = new Size(Ini.Width, Ini.Height);
            // Ini.Speed - количество пикселей в секунду
            timer1.Interval = 1000 / Ini.Speed;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            packman = new PackmanController(this);
            StartGame();
        }

        private void StartGame()
        {
            score = 0;

            timer1.Enabled = true;
            timer1.Start();
            btnNewGame.Enabled = false;
            lblStarted.Text = "Игра началась...";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Go();
        }

        private void Go()
        {
            packman.Move();
            using (Graphics field = pbxField.CreateGraphics())
            {
                field.Clear(Color.Gray);

                packman.kolobokView.Draw(field);
                for (int i = 0; i < packman.game.tanks.Count; i++)
                {
                    packman.tankView.Draw(packman.game.tanks[i], field);
                }
                for (int i = 0; i < packman.game.bullets.Count; i++)
                {
                    field.DrawImage(Properties.Resources.bullet, new Rectangle(packman.game.bullets[i].Location, new Size(5, 5)), new Rectangle(0, 0, 5, 5), GraphicsUnit.Pixel);
                }
                for (int i = 0; i < packman.game.walls.Count; i++)
                {
                    Rectangle scrImage = new Rectangle(packman.game.walls[i], size);
                    field.DrawImage(Properties.Resources.wall, scrImage, profile, GraphicsUnit.Pixel);
                }
                for (int i = 0; i < packman.game.apples.Count; i++)
                {
                    Rectangle scrImage = new Rectangle(packman.game.apples[i], size);
                    field.DrawImage(Properties.Resources.apple, scrImage, profile, GraphicsUnit.Pixel);
                }
            }
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
