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
	public partial class AddItemsByDistributor : Form
	{
		public AddItemsByDistributor()
		{
			InitializeComponent();
		}

		private void AddItemsByDistributor_Shown(object sender, EventArgs e)
		{
			dgvDistributors.DataSource = dbHandler.ReadDistributorNames();
			//dgvDistributorItems.DataSource = dbHandler.ReadItemsByDistributor(Int32.TryParse(dgvDistributors.SelectedCells.ToString()));
		}
	}
}
