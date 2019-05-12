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

			dgvDistributors.AutoResizeColumns();
			dgvDistributors.Width = dgvDistributors.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);

			this.Width = dgvDistributors.Width + 38;
			this.Height = dgvDistributors.Height + 62;

			if(dgvDistributors.ScrollBars == ScrollBars.Vertical)
			{
				dgvDistributors.Width += 20;
				this.Width += 20;
			}

			this.CenterToParent();
		}

		private void DgvDistributors_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			DialogResult result; //Holds the result of the upcoming MessageBox, confirming deletion of selected row

			result = MessageBox.Show($"You are requesting to delete the row for \"{e.Row.Cells[1].Value}\"! Are you sure you would like to delete it?", "Delete Row?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

			if(result == DialogResult.Yes) //If the user selected Yes to the deletion confirmation
			{

				e.Cancel = false; //Allow the deletion to continue
				dbHandler.DeleteDistributor(e.Row.Cells[0].Value.ToString()); //Have the row deleted from PoS.db based on the Id

				dgvDistributors.ClearSelection(); //Have nothing selected in the dgv

				int nextRowToSelect = (e.Row.Index) - 1; //We want to TRY to select the row above the one being deleted

				if (nextRowToSelect >= 0) //If the row above the deleted row exists
				{
					dgvDistributors.Rows[nextRowToSelect].Selected = true; //Then select that row
				}

				else if ((dgvDistributors.Rows.Count - 1) > 0) //If there was no row above the one deleted, but there is at least one row
				{
					dgvDistributors.Rows[1].Selected = true; //Then select that row (index 0 seems to be the header, which doesn't work)
				}
			}

			else //If Yes was NOT selected, cancel the deletion
			{
				e.Cancel = true;
			}
		}

		/// <summary>
		/// When a cell is selected, select the whole row (aesthetics)
		/// </summary>
		private void DgvDistributors_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex >= 0) //Make sure a column header isn't selected
			{
				//dgvDistributors.ClearSelection();
				dgvDistributors.Rows[e.RowIndex].Selected = true;
			}
		}

		private void DgvDistributors_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			//TODO: When a row is removed, I want to check if this gets rid of the vertical scroll bar. If the scroll bar is no longer needed, resize the control and form
			if(dgvDistributors.ScrollBars == ScrollBars.None)
			{
				dgvDistributors.Width -= 20;
				this.Width -= 20;
			}
		}
	}
}
