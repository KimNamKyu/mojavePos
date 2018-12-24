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
using mojavePos.Modules;

namespace mojavePos.Han
{
    public partial class MoneyForm : Form
    {
        Panel ch1, ch2, ch3, ch4, ch5, ch6;
        Commons comm;
        _Create ct = new _Create();
        WebAPI api;
        public MoneyForm()
        {
            InitializeComponent();
            Load += MoneyForm_Load;
        }

        private void MoneyForm_Load(object sender, EventArgs e)
        {

            ClientSize = new Size(1500, 800);
            this.BackColor = Color.Beige;
            //get_Combo();
            get_Date();
            get_button();
            moneyView();
           get_total(lv);

        }
        private void moneyView()
        {
            //uNo uName   uDate uNumber uRate uTotal  delYn regDate modDate
            ArrayList list = new ArrayList();
            list.Add(new lvSet(this, "view", 960, 700, 270, 60, list_Click));
            lv = ct.listview((lvSet)list[0]);
            Controls.Add(lv);

            lv.Columns.Add("번호", 50, HorizontalAlignment.Center);
            lv.Columns.Add("날짜", 200, HorizontalAlignment.Center);
            lv.Columns.Add("메뉴", 200, HorizontalAlignment.Center);
            lv.Columns.Add("수량", 100, HorizontalAlignment.Center);
            lv.Columns.Add("총금액", 160, HorizontalAlignment.Center);
            lv.Columns.Add("등록자", 160, HorizontalAlignment.Center);

           
           api = new WebAPI();
            api.SelectListView("http://localhost:5000/cm_init", lv);

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
        DateTimePicker dt1;
        DateTimePicker dt2;
        private ListView lv;

        private void get_Date()
        {
            ArrayList list = new ArrayList();
            dt1 = new DateTimePicker();
            dt2 = new DateTimePicker();
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
        Label label2;
        private void get_total(ListView lv)
        {
            long total=0;
            for(int i = 0; i < lv.Items.Count; i++)
            {
                ListViewItem item = lv.Items[i];
                total += Convert.ToInt64(item.SubItems[4].Text);
            }
            lbSet ls1 = new lbSet(this, "lb2", "총 금액: " + total.ToString()+"원", 600, 50, 650, 20, 30);

            label2 = new Label();
            label2 = ct.lable(ls1);
            label2.BackColor = Color.Beige;
            label2.Font = new Font(FontFamily.GenericSansSerif, 30.0F, FontStyle.Bold);
            Controls.Add(label2);
        }
        private void ok_Click(object sender, EventArgs e)
        {
            //dt1 = new DateTimePicker();
            // dt2 = new DateTimePicker();
           
            Hashtable ht = new Hashtable();
            api = new WebAPI();
            ht.Add("spName", "select_date");
            ht.Add("start", dt1.Text.Substring(0, 10));
            ht.Add("end", dt2.Text.Substring(0, 10));
            ArrayList list = api.Select("http://localhost:5000/cm_date", ht);
            api.ListView(lv, list);

            long total = 0;
            for (int i = 0; i < lv.Items.Count; i++)
            {
                ListViewItem item = lv.Items[i];
                total += Convert.ToInt64(item.SubItems[4].Text);
            }
            lbSet ls1 = new lbSet(this, "lb2", total.ToString() + "원", 600, 50, 650, 20, 30);
            //label2 = new Label();
            
            label2.Text ="총 금액: " +total.ToString()+"원";
            
            label2 = ct.lable(ls1);
            label2.BackColor = Color.Beige;
            label2.Font = new Font(FontFamily.GenericSansSerif, 30.0F, FontStyle.Bold);
            Controls.Add(label2);
            
        }

    }
}
