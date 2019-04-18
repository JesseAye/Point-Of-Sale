using System;
using System.Configuration;
using System.Data.Common;
using System.Windows.Forms;

namespace Point_Of_Sale
{
	public partial class AddDistributor : Form
    {
        public AddDistributor()
        {
            InitializeComponent();
        }

        // TODO: Connect to the DB, insert row with form text boxes
        /// <summary>
        /// Access DB, insert row with form text boxes
        /// </summary>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
			if(dbHandler.InsertDistributor(tbDistName.Text, tbContactName.Text, tbContactNum.Text)) // If the entry was successfully inserted into PoS.db
			{
				Close();
			}
        }

        /// <summary>
        /// Close form without any changes to db
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
