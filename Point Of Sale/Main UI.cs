using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Point_Of_Sale
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
        }

        private void AddDistributorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDistributor AddDistWindow = new AddDistributor();
            AddDistWindow.ShowDialog();
        }

		private void ManageDistributorsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ManageDistributors ManageDistributorsWindow = new ManageDistributors();
			ManageDistributorsWindow.ShowDialog();
		}
	}
}
