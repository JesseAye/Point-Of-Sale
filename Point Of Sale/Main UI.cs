﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddDistributorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDistributor AddDistWindow = new AddDistributor();
            AddDistWindow.ShowDialog();
        }
    }
}