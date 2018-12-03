using System;
using System.Collections;
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
    public partial class SaladForm : Form
    {
        _Create ct = new _Create();
        public SaladForm()
        {
            InitializeComponent();
            Load += SaladForm_Load;
        }

        private void SaladForm_Load(object sender, EventArgs e)
        {
            ArrayList arr = new ArrayList();
            arr.Add(new btnSet(this, "btn1", "리코타 샐러드", 200, 100, 0, 0, btn_Click));
            arr.Add(new btnSet(this, "btn2", "치킨 시저 샐러드", 200, 100, 200, 0, btn_Click));
            arr.Add(new btnSet(this, "btn3", "단호박 샐러드", 200, 100, 400, 0, btn_Click));

            for( int i = 0; i<arr.Count; i++)
            {
                ct.btn((btnSet)arr[i]);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
