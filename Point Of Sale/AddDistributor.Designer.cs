namespace Point_Of_Sale
{
    partial class AddDistributor
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
			this.lblDistributorName = new System.Windows.Forms.Label();
			this.tbDistName = new System.Windows.Forms.TextBox();
			this.tbContactName = new System.Windows.Forms.TextBox();
			this.tbContactNum = new System.Windows.Forms.TextBox();
			this.lblContactNumber = new System.Windows.Forms.Label();
			this.lblContactName = new System.Windows.Forms.Label();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblDistributorName
			// 
			this.lblDistributorName.AutoSize = true;
			this.lblDistributorName.Location = new System.Drawing.Point(12, 13);
			this.lblDistributorName.Name = "lblDistributorName";
			this.lblDistributorName.Size = new System.Drawing.Size(85, 13);
			this.lblDistributorName.TabIndex = 0;
			this.lblDistributorName.Text = "Distributor Name";
			// 
			// tbDistName
			// 
			this.tbDistName.Location = new System.Drawing.Point(103, 10);
			this.tbDistName.Name = "tbDistName";
			this.tbDistName.Size = new System.Drawing.Size(100, 20);
			this.tbDistName.TabIndex = 0;
			// 
			// tbContactName
			// 
			this.tbContactName.Location = new System.Drawing.Point(103, 36);
			this.tbContactName.Name = "tbContactName";
			this.tbContactName.Size = new System.Drawing.Size(100, 20);
			this.tbContactName.TabIndex = 1;
			// 
			// tbContactNum
			// 
			this.tbContactNum.Location = new System.Drawing.Point(103, 62);
			this.tbContactNum.Name = "tbContactNum";
			this.tbContactNum.Size = new System.Drawing.Size(100, 20);
			this.tbContactNum.TabIndex = 2;
			// 
			// lblContactNumber
			// 
			this.lblContactNumber.AutoSize = true;
			this.lblContactNumber.Location = new System.Drawing.Point(12, 65);
			this.lblContactNumber.Name = "lblContactNumber";
			this.lblContactNumber.Size = new System.Drawing.Size(84, 13);
			this.lblContactNumber.TabIndex = 4;
			this.lblContactNumber.Text = "Contact Number";
			// 
			// lblContactName
			// 
			this.lblContactName.AutoSize = true;
			this.lblContactName.Location = new System.Drawing.Point(12, 39);
			this.lblContactName.Name = "lblContactName";
			this.lblContactName.Size = new System.Drawing.Size(75, 13);
			this.lblContactName.TabIndex = 5;
			this.lblContactName.Text = "Contact Name";
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(128, 88);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 3;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(12, 88);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// AddDistributor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(215, 123);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lblContactName);
			this.Controls.Add(this.lblContactNumber);
			this.Controls.Add(this.tbContactNum);
			this.Controls.Add(this.tbContactName);
			this.Controls.Add(this.tbDistName);
			this.Controls.Add(this.lblDistributorName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "AddDistributor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Distributor";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDistributorName;
        private System.Windows.Forms.TextBox tbDistName;
        private System.Windows.Forms.TextBox tbContactName;
        private System.Windows.Forms.TextBox tbContactNum;
        private System.Windows.Forms.Label lblContactNumber;
        private System.Windows.Forms.Label lblContactName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
    }
}