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
    public partial class sidemenuForm : Form
    {
        _Create ct = new _Create();
        public sidemenuForm()
        {
            InitializeComponent();
            Load += SidemenuForm_Load;
        }

        private void SidemenuForm_Load(object sender, EventArgs e)
        {
            ArrayList arr = new ArrayList();
            arr.Add(new btnSet(this, "btn1", "프라이즈 칼라마리", 200, 100, 0, 0, btn_Click));
            arr.Add(new btnSet(this, "btn2", "트러플 프렌치 프라이즈", 200, 100, 200, 0, btn_Click));
            arr.Add(new btnSet(this, "btn3", "쿼리 아란치미", 200, 100, 400, 0, btn_Click));
            arr.Add(new btnSet(this, "btn4", "오늘의 스프", 200, 100, 0, 100, btn_Click));
            arr.Add(new btnSet(this, "btn5", "감바스 알아히요", 200, 100, 200, 100, btn_Click));

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
