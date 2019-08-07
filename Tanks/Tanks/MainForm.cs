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

            field.DrawImage(Properties.Resources.kolobok, packman.game.kolobok.location);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            packman.StartGame();
        }

        private void UpdateStats()
        {

        }

        private void SendMessages(string name, int x, int y)
        {
            string s = name + ": " + x + ", " + y;
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            Setting();
        }

    }
}
