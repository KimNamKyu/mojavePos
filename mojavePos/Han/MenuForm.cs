using System;
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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            Load += MenuForm_Load;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(1500, 800);
            this.BackColor = Color.BurlyWood;
        }
    }
}
