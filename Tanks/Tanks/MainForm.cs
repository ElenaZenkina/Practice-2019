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

        public MainForm()
        {
            packman = new PackmanController();
            packman.LoadIni();

            InitializeComponent();

            pbxField.Size = new Size(Ini.Width, Ini.Height);
            timer1.Interval = 500;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Setting();

            timer1.Enabled = true;
            timer1.Start();
            //MessageBox.Show("OK");
        }

        private void Setting()
        {
            Graphics field = pbxField.CreateGraphics();

            for (int i = 0; i < packman.game.walls.Count; i++)
            {
                field.DrawImage(Properties.Resources.wall, packman.game.walls[i]);
            }

            for (int i = 0; i < packman.game.apples.Count; i++)
            {
                field.DrawImage(Properties.Resources.apple, packman.game.apples[i]);
            }

            for (int i = 0; i < packman.game.tanks.Count; i++)
            {
                field.DrawImage(Properties.Resources.tank, packman.game.tanks[i].Location);
            }

            field.DrawImage(packman.kolobokView.imageKolobok, packman.kolobokView.kolobok.Location.X,
                packman.kolobokView.kolobok.Location.Y, new Rectangle(0, 0, 20, 20), GraphicsUnit.Pixel);

            /*Image img = Image.FromFile("fire.png");
            Graphics gr = pictureBox1.CreateGraphics();
            y = y + 2;
            if (OnFire == true)
            {
                gr.DrawImage(img, 370, y, 70, 70);
            }
            //Invalidate();
            pictureBox1.Invalidate();*/
            


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            packman.StartGame();

            Graphics field = pbxField.CreateGraphics();

            pbxField.Invalidate(new Rectangle(packman.kolobokView.kolobok.Location, new Size(20, 20)));

            field.DrawImage(packman.kolobokView.imageKolobok, packman.kolobokView.kolobok.Location.X,
                packman.kolobokView.kolobok.Location.Y, new Rectangle(0, 0, 20, 20), GraphicsUnit.Inch);


            //pbxField.Invalidate(new Rectangle())

            /*Image img = Properties.Resources.kolobok;
            Graphics gr = pbxField.CreateGraphics();
            y--;
            if (y % 2 == 0)
            {
                gr.DrawImage(img, 200, y);
            }
            pbxField.Invalidate();*/

        }

        private void UpdateStats()
        {

        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            //Setting();
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
            }
        }
    }
}
