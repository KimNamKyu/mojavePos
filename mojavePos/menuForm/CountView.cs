
using mojavePos.Modal;
using mojavePos.Modules;
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

namespace mojavePos
{

    public partial class CountView : Form
    {
        _Create ct = new _Create();
        Panel panel2;
        private Panel panel;
        private ListView lv;
        private WebAPI api;
        private string _bNo;
        private Hashtable ht;
        private string _tNo;

        public CountView()
        {
            InitializeComponent();
            Load += CountView_Load;
        }


        private void CountView_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            listView();
            btn_load();
            menu_view();

        }

        private void listView()
        {
            ArrayList arr = new ArrayList();
            arr.Add(new pnSet(this, 600, 780, 50, 10));
            arr.Add(new lvSet(this, "", 500, 300, 50, 20, list_Click));
            arr.Add(new lbSet(this, "lb1", "판매액", 150, 30, 100, 360, 20));
            arr.Add(new lbSet(this, "lb1", "할인", 150, 30, 110, 410, 20));
            arr.Add(new lbSet(this, "lb1", "총금액", 150, 30, 100, 460, 20));
            arr.Add(new lbSet(this, "lb2", "", 150, 30, 350, 360, 20));
            arr.Add(new lbSet(this, "lb2", "", 150, 30, 350, 410, 20));
            arr.Add(new lbSet(this, "lb2", "", 150, 30, 350, 460, 20));
            arr.Add(new btnSet(this, "btn1", "할인쿠폰", 230, 100, 50, 560, btn_Click));
            arr.Add(new btnSet(this, "btn2", "현금결제", 230, 100, 320, 560, btn_Click));
            arr.Add(new btnSet(this, "btn3", "주문", 230, 100, 50, 670, btn_Click));
            arr.Add(new btnSet(this, "btn4", "카드결제", 230, 100, 320, 670, btn_Click));

            for (int i = 0; i < arr.Count; i++)
            {
                if (typeof(pnSet) == arr[i].GetType())
                {
                    panel = ct.panel((pnSet)arr[i]);
                    panel.BackColor = Color.Gainsboro;
                    Controls.Add(panel);
                }
                else if (typeof(lvSet) == arr[i].GetType())
                {
                    lv = ct.listview((lvSet)arr[i]);
                    lv.BackColor = Color.WhiteSmoke;
                    panel.Controls.Add(lv);
                    lv.Columns.Add("No", 40, HorizontalAlignment.Center);
                    lv.Columns.Add("메뉴명", 160, HorizontalAlignment.Center);
                    lv.Columns.Add("단가", 100, HorizontalAlignment.Center);
                    lv.Columns.Add("수량", 100, HorizontalAlignment.Center);
                    lv.Columns.Add("금액", 100, HorizontalAlignment.Center);
                }
                else if (typeof(btnSet) == arr[i].GetType())
                {
                    Button button = ct.btn((btnSet)arr[i]);
                    panel.Controls.Add(button);
                }
                else if (typeof(lbSet) == arr[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr[i]);
                    if (label.Name == "lb2") label.BackColor = Color.White;
                    panel.Controls.Add(label);
                }
            }
        }

        private void list_Click(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            lv.FullRowSelect = true;
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;
            ListViewItem item = itemGroup[0];
        }

        private void btn_load()
        {
            ArrayList arr2 = new ArrayList();

            for (int i = 0; i < arr2.Count; i++)
            {
                ct.btn((btnSet)arr2[i]);
            }
        }
        
        private void menu_view()
        {
            pnSet pn1 = new pnSet(this, 100, 780, 750, 10);
            Panel panel = ct.panel(pn1);
            panel.BackColor = Color.Gainsboro;
            Controls.Add(panel);
            pnSet pn2 = new pnSet(this, 600, 780, 850, 10);
            panel2 = ct.panel(pn2);
            panel2.BackColor = Color.Gainsboro;
            Controls.Add(panel2);

            api = new WebAPI();
            ht = new Hashtable();
            ht.Add("spName", "sp_MenuCategory_Select");
            ht.Add("param", "");
            ArrayList list = api.Select("http://localhost:5000/select", ht);
            if (list != null)
            {
                ArrayList arrayList = api.Button(this, list, Category_Click);
                for (int i = 0; i < arrayList.Count; i++)
                {
                    Button button = ct.btn((btnSet)arrayList[i]);
                    panel.Controls.Add(button);
                }
            }

        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            _tNo = "3";
            switch (btn.Name)
            {
                case "btn1":
                    api = new WebAPI();
                    ht = new Hashtable();
                    ht.Add("spName", "sp_Order_Select");
                    ht.Add("tNo","tNo:" + _tNo);
                    ArrayList list = api.Select("http://localhost:5000/select", ht);
                    if (list != null)
                    {
                        api.ListView(lv, list);
                    }
                  
                    break;
                case "btn2":
                    Cash cash = new Cash();
                    cash.StartPosition = FormStartPosition.CenterParent;
                    cash.Show();
                    break;
                case "btn3":
                    this.Visible = false;
                    break;
                case "btn4":
                    MessageBox.Show("서비스준비중입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void Category_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            _bNo = btn.Name;
            //MessageBox.Show(_bNo);

            ht = new Hashtable();
            ht.Add("spName", "sp_Menu_Select");
            ht.Add("param", "_bNo:" + _bNo);

            panel2.Controls.Clear();
            ArrayList list = api.Select("http://localhost:5000/select", ht);
            if (list != null)
            {
                ArrayList arrayList = api.Button2(panel2, list, Menu_Click);
                for (int i = 0; i < arrayList.Count; i++)
                {
                    Button button = ct.btn((btnSet)arrayList[i]);
                    panel2.Controls.Add(button);
                }

            }

        }

        private void Menu_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Common("1");
        }
        private void Common(string type)
        {
            _tNo = "3";

            api = new WebAPI();
            ht = new Hashtable();
            switch (type)
            {
                case "Select":
                    ht.Add("spName", "sp_Menu_Select");
                    ht.Add("param", "_tNo:" + _tNo);
                    ArrayList list = api.Select("http://localhost:5000/select", ht);
                    api.ListView(lv, list);
                    break;
                case "1":
                    ht.Add("mNo", _bNo);
                    ht.Add("tNo", _tNo);
                    api.Post("http://localhost:5000/insert", ht);
                    Common("select");
                    break;
                case "2":
                    ht.Add("mNo", _bNo);
                    ht.Add("tNo", _tNo);
                    api.Post("http://localhost:5000/insert", ht);
                    break;
                case "3":
                    ht.Add("mNo", _bNo);
                    ht.Add("tNo", _tNo);
                    api.Post("http://localhost:5000/insert", ht);
                    break;
                case "4":
                    ht.Add("mNo", _bNo);
                    ht.Add("tNo", _tNo);
                    api.Post("http://localhost:5000/insert", ht);
                    break;
                case "5":
                    ht.Add("mNo", _bNo);
                    ht.Add("tNo", _tNo);
                    api.Post("http://localhost:5000/insert", ht);
                    break;
                case "6":
                    ht.Add("mNo", _bNo);
                    ht.Add("tNo", _tNo);
                    api.Post("http://localhost:5000/insert", ht);
                    break;
                default:
                    break;
            }
        }
    }
}
