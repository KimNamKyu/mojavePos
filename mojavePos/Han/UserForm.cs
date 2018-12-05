using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace mojavePos.Han
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            Load += UserForm_Load;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(1500, 800);
            this.BackColor = Color.Coral;
        }

        private void UserView()
        {
            ArrayList list = new ArrayList();
            list.Add(new lvSet(this, "", 500, 300, 50, 50, list_Click));
            
        }
        private void list_Click(object sender, MouseEventArgs e)
        {

        }
    }
}
