﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mojavePos.Han
{
    public partial class MoneyForm : Form
    {
        public MoneyForm()
        {
            InitializeComponent();
            Load += MoneyForm_Load;
        }

        private void MoneyForm_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(1500, 800);
            this.BackColor = Color.Beige;
        }
    }
}
