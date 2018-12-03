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
    public partial class beverageForm : Form
    {
        _Create ct = new _Create();
        public beverageForm()
        {
            InitializeComponent();
            Load += BeverageForm_Load;
        }

        private void BeverageForm_Load(object sender, EventArgs e)
        {
            ArrayList arr = new ArrayList();
            arr.Add(new btnSet(this, "btn1", "레몬 에이드", 200, 100, 0, 0, btn_Click));
            arr.Add(new btnSet(this, "btn2", "블루베리 에이드", 200, 100, 200, 0, btn_Click));
            arr.Add(new btnSet(this, "btn3", "자몽 에이드", 200, 100, 400, 0, btn_Click));
            arr.Add(new btnSet(this, "btn4", "청포도 에이드", 200, 100, 0, 100, btn_Click));
            arr.Add(new btnSet(this, "btn5", "스파크 워터", 200, 100, 200, 100, btn_Click));
            arr.Add(new btnSet(this, "btn6", "아사히 맥주", 200, 100, 400, 100, btn_Click));

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
