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
    public partial class MoneyForm : Form
    {
        Panel ch1, ch2, ch3, ch4, ch5, ch6;
        Commons comm;
        _Create ct = new _Create();
        public MoneyForm()
        {
            InitializeComponent();
            Load += MoneyForm_Load;
        }

        private void MoneyForm_Load(object sender, EventArgs e)
        {

            ClientSize = new Size(1500, 800);
            this.BackColor = Color.Beige;
            get_Combo();
            get_Date();
            get_button();
            moneyView();
        }
        private void moneyView()
        {
            //uNo uName   uDate uNumber uRate uTotal  delYn regDate modDate
            ArrayList list = new ArrayList();
            list.Add(new lvSet(this, "view", 960, 700, 270, 60, list_Click));
            ListView lv = ct.listview((lvSet)list[0]);
            Controls.Add(lv);

            lv.Columns.Add("번호", 50, HorizontalAlignment.Center);
            lv.Columns.Add("날짜", 200, HorizontalAlignment.Center);
            lv.Columns.Add("메뉴", 200, HorizontalAlignment.Center);
            lv.Columns.Add("수량", 100, HorizontalAlignment.Center);
            lv.Columns.Add("총금액", 160, HorizontalAlignment.Center);
            lv.Columns.Add("등록자", 160, HorizontalAlignment.Center);

        }

        private void list_Click(object sender, MouseEventArgs e)
        {

        }

        //1500 800 6 1400 250

        public void get_Combo()
        {
            comm = new Commons();
            ComboBox combo = new ComboBox();
            comboboxSet cb1 = new comboboxSet(this, "period", 120, 35, 650, 35);
            combo = ct.combobox(cb1);
            combo.Font = new Font("Verdana", 10.5f, FontStyle.Italic);
            combo.Text = "분기선택";
            combo.Items.Add("1분기");
            combo.Items.Add("2분기");
            combo.Items.Add("3분기");
            combo.Items.Add("4분기");


            combo.SelectedIndexChanged += Combo_SelectedIndexChanged;
            Controls.Add(combo);
        }

        private void Combo_SelectedIndexChanged(object sender, EventArgs e) // 콤보박스 이벤트 
        {
            ComboBox combo = (ComboBox)sender;

            string index = (string)combo.SelectedItem;

            if (index == "1분기")
            {
                MessageBox.Show("1분기");
            }
            else if (index == "2분기")
            {
                MessageBox.Show("2분기");
            }
            else if (index == "3분기")
            {
                MessageBox.Show("3분기");
            }
            else if (index == "4분기")
            {
                MessageBox.Show("4분기");
            }

        }

        private void get_Date()
        {
            ArrayList list = new ArrayList();
            DateTimePicker dt1 = new DateTimePicker();
            DateTimePicker dt2 = new DateTimePicker();
            DateSet dts1 = new DateSet(this, "first", 150, 50, 270, 40);
            DateSet dts2 = new DateSet(this, "second", 150, 50, 450, 40);
            dt1 = ct.datepic(dts1);
            dt2 = ct.datepic(dts2);


            lbSet ls = new lbSet(this, "lb1", " ~ ", 30, 15, 420, 40, 13);

            Label label1 = new Label();
            label1 = ct.lable(ls);
            label1.BackColor = Color.Beige;
            label1.Font = new Font(FontFamily.GenericSansSerif, 13.0F, FontStyle.Bold);
            Controls.Add(label1);
        }
        private void get_button()
        {
            comm = new Commons();
            Button btn = new Button();
            btnSet bs1 = new btnSet(this, "ok", "검색", 50, 22, 600, 40, ok_Click);
            btn = ct.btn(bs1);
            Controls.Add(btn);
        }

        private void ok_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
