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
    public partial class StatForm : Form
    {
        public StatForm()
        {
            InitializeComponent();
        }

        public void AddData(string name, int x, int y)
        {
            dgvStat.Rows.Add(name, x, y);
            //dgvStat.Rows.Clear;
        }
    }
}
