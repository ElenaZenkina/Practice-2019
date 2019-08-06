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
    public partial class mainForm : Form
    {
        private PackmanController controller;

        public mainForm()
        {
            PackmanController controller = new PackmanController();

            InitializeComponent();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            //Model model = new Model();
            Ini.Init();

            var a = Ini.speed;

        }
    }
}
