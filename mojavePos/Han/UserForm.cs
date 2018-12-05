using mojavePos.menuForm;
using mojavePos.Modal;
using mojavePos;
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
namespace mojavePos.Han
{
    public partial class UserForm : Form
    {
        _Create ct = new _Create();
        public UserForm()
        {
            InitializeComponent();
            Load += UserForm_Load;
        }
        
        private void UserForm_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(1500, 800);
            this.BackColor = Color.Coral;

            UserView();
            get_Date();

        }

        private void UserView()
        {
            //uNo uName   uDate uNumber uRate uTotal  delYn regDate modDate
            ArrayList list = new ArrayList();
            list.Add(new lvSet(this, "", 960, 700, 270, 60, list_Click));
            ListView lv = ct.listview((lvSet)list[0]);
            Controls.Add(lv);

            lv.Columns.Add("번호", 50, HorizontalAlignment.Center);
            lv.Columns.Add("이름", 100, HorizontalAlignment.Center);
            lv.Columns.Add("생년월일", 150, HorizontalAlignment.Center);
            lv.Columns.Add("휴대폰번호", 160, HorizontalAlignment.Center);
            lv.Columns.Add("등급", 100, HorizontalAlignment.Center);
            lv.Columns.Add("누적금액", 100, HorizontalAlignment.Center);
            lv.Columns.Add("등록날짜", 150, HorizontalAlignment.Center);
            lv.Columns.Add("수정된 날짜", 150, HorizontalAlignment.Center);

        }
        private void get_Date()
        {
            ArrayList list = new ArrayList();
            list.Add(new DateSet(this, "first", 150, 50, 270, 40));
            list.Add(new DateSet(this, "second", 150, 50, 450, 40));
            for (int i = 0; i < list.Count; i++)
            {
                ct.datepic((DateSet)list[i]);
            }
            list.Add(new lbSet(this, "lb1", " ~ ", 30,30 , 250, 50, 20));
            Label label1 = ct.lable((lbSet)list[2]);
            Controls.Add(label1);

        }
        private void list_Click(object sender, MouseEventArgs e)
        {

        }
    }
}
