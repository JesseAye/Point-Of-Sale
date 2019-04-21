namespace Point_Of_Sale
{
	partial class ManageDistributors
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dgvDistributors = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvDistributors)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvDistributors
			// 
			this.dgvDistributors.AllowUserToAddRows = false;
			this.dgvDistributors.AllowUserToResizeRows = false;
			this.dgvDistributors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvDistributors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDistributors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvDistributors.Location = new System.Drawing.Point(12, 12);
			this.dgvDistributors.MultiSelect = false;
			this.dgvDistributors.Name = "dgvDistributors";
			this.dgvDistributors.RowHeadersVisible = false;
			this.dgvDistributors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgvDistributors.Size = new System.Drawing.Size(297, 426);
			this.dgvDistributors.TabIndex = 0;
			this.dgvDistributors.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvDistributors_CellMouseClick);
			this.dgvDistributors.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DgvDistributors_RowsRemoved);
			this.dgvDistributors.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DgvDistributors_UserDeletingRow);
			// 
			// ManageDistributors
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(321, 450);
			this.Controls.Add(this.dgvDistributors);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "ManageDistributors";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Manage Distributors";
			this.Shown += new System.EventHandler(this.ManageDistributors_Shown);
			((System.ComponentModel.ISupportInitialize)(this.dgvDistributors)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvDistributors;
	}
}