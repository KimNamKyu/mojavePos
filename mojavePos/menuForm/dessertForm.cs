using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mojavePos.menuForm
{
    public partial class dessertForm : Form
    {
        _Create ct = new _Create();
        public dessertForm()
        {
            InitializeComponent();
            Load += DessertForm_Load;
        }

        private void DessertForm_Load(object sender, EventArgs e)
        {
            btnSet btn = new btnSet(this, "btn1", "클래식 티라미슈", 200, 100, 0, 0, btn_Click);
            Button button = ct.btn(btn);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
