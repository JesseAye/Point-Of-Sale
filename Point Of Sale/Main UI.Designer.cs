namespace Point_Of_Sale
{
    partial class MainUI
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
			this.menuStripMainUI = new System.Windows.Forms.MenuStrip();
			this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.manageDistributorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.addDistributorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStripMainUI.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStripMainUI
			// 
			this.menuStripMainUI.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maintenanceToolStripMenuItem});
			this.menuStripMainUI.Location = new System.Drawing.Point(0, 0);
			this.menuStripMainUI.Name = "menuStripMainUI";
			this.menuStripMainUI.Size = new System.Drawing.Size(800, 24);
			this.menuStripMainUI.TabIndex = 0;
			this.menuStripMainUI.Text = "menuStrip1";
			// 
			// maintenanceToolStripMenuItem
			// 
			this.maintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageDistributorsToolStripMenuItem,
            this.toolStripSeparator1,
            this.addDistributorToolStripMenuItem});
			this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
			this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
			this.maintenanceToolStripMenuItem.Text = "Maintenance";
			// 
			// manageDistributorsToolStripMenuItem
			// 
			this.manageDistributorsToolStripMenuItem.Name = "manageDistributorsToolStripMenuItem";
			this.manageDistributorsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.manageDistributorsToolStripMenuItem.Text = "Manage Distributors";
			this.manageDistributorsToolStripMenuItem.Click += new System.EventHandler(this.ManageDistributorsToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
			// 
			// addDistributorToolStripMenuItem
			// 
			this.addDistributorToolStripMenuItem.Name = "addDistributorToolStripMenuItem";
			this.addDistributorToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.addDistributorToolStripMenuItem.Text = "Add Distributor";
			this.addDistributorToolStripMenuItem.Click += new System.EventHandler(this.AddDistributorToolStripMenuItem_Click);
			// 
			// MainUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.menuStripMainUI);
			this.MainMenuStrip = this.menuStripMainUI;
			this.Name = "MainUI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Point of Sale";
			this.menuStripMainUI.ResumeLayout(false);
			this.menuStripMainUI.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMainUI;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDistributorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addDistributorToolStripMenuItem;
    }
}

