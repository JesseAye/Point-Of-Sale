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
		public ManageDistributors()
		{
			InitializeComponent();
		}

		private void ManageDistributors_Shown(object sender, EventArgs e)
		{
			dbHandler.ReadDistributors();
		}
	}
}
