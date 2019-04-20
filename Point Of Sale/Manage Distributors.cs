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
	public partial class ManageDistributors : Form
	{
		DataTable dataTable;
		public ManageDistributors()
		{
			InitializeComponent();
		}

		private void ManageDistributors_Shown(object sender, EventArgs e)
		{
			dataTable = dbHandler.ReadDistributors();
			dgvDistributors.DataSource = dataTable;
		}

		private void DgvDistributors_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			DialogResult result; //Holds the result of the upcoming MessageBox, confirming deletion of selected row

			result = MessageBox.Show($"You are requesting to delete the row for \"{e.Row.Cells[1].Value}\"! Are you sure you would like to delete it?", "Delete Row?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

			if(result == DialogResult.Yes) //If the user selected Yes to the deletion confirmation
			{
				e.Cancel = false;
				dbHandler.DeleteDistributor(e.Row.Cells[0].Value.ToString());
			}

			else //If Yes was NOT selected, cancel the deletion
			{
				e.Cancel = true;
			}
		}
	}
}
