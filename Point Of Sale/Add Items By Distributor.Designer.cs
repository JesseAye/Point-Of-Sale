namespace Point_Of_Sale
{
	partial class AddItemsByDistributor
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
			this.dgvDistributorItems = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvDistributors)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvDistributorItems)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvDistributors
			// 
			this.dgvDistributors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDistributors.Location = new System.Drawing.Point(13, 13);
			this.dgvDistributors.Name = "dgvDistributors";
			this.dgvDistributors.RowHeadersVisible = false;
			this.dgvDistributors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgvDistributors.Size = new System.Drawing.Size(136, 236);
			this.dgvDistributors.TabIndex = 0;
			// 
			// dgvDistributorItems
			// 
			this.dgvDistributorItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDistributorItems.Location = new System.Drawing.Point(156, 13);
			this.dgvDistributorItems.Name = "dgvDistributorItems";
			this.dgvDistributorItems.RowHeadersVisible = false;
			this.dgvDistributorItems.Size = new System.Drawing.Size(323, 236);
			this.dgvDistributorItems.TabIndex = 1;
			// 
			// AddItemsByDistributor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.dgvDistributorItems);
			this.Controls.Add(this.dgvDistributors);
			this.Name = "AddItemsByDistributor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Items By Distributor";
			this.Shown += new System.EventHandler(this.AddItemsByDistributor_Shown);
			((System.ComponentModel.ISupportInitialize)(this.dgvDistributors)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvDistributorItems)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvDistributors;
		private System.Windows.Forms.DataGridView dgvDistributorItems;
	}
}