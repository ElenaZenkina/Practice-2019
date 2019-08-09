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

        public void AddData(List<string> stats)
        {
            dgvStat.Rows.Clear();

            for (int i = 0; i < stats.Count; i++)
            {
                var rows = stats[i].Split(',');
                dgvStat.Rows.Add(rows[0], rows[1], rows[2]);
            }
            

        }
    }
}
