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
    public partial class steakeForm : Form
    {
        _Create ct = new _Create();
        public steakeForm()
        {
            InitializeComponent();
            Load += SteakeForm_Load;
        }

        private void SteakeForm_Load(object sender, EventArgs e)
        {
            ArrayList arr = new ArrayList();

            arr.Add(new btnSet(this, "btn1", "안심 스테이크", 200, 100, 0, 0, btn_Click));
            arr.Add(new btnSet(this, "btn2", "치즈 매쉬 립아이 스테이크", 200, 100, 200, 0, btn_Click));
            arr.Add(new btnSet(this, "btn3", "티본 스테이크", 200, 100, 400, 0, btn_Click));

            for(int i = 0; i<arr.Count; i++)
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
