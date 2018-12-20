using mojavePos.menuForm;
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
        private pastaForm form;
        private ListView lv;
        private WebAPI api;
        private Hashtable ht;
        public CountView()
        {
            InitializeComponent();
            Load += CountView_Load;
        }
        public CountView(ListView lv)
        {
            this.lv = lv;
        }

        private void CountView_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            listView();
            btn_load();
            menu_view();
        }

        public void listView()
        {
            ArrayList arr = new ArrayList();
            arr.Add(new pnSet(this,600,780,50,10));
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
                else if(typeof(lvSet) == arr[i].GetType())
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
                else if(typeof(btnSet) == arr[i].GetType())
                {
                    Button button = ct.btn((btnSet)arr[i]);
                    panel.Controls.Add(button);
                }
                else if(typeof(lbSet) == arr[i].GetType())
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

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "btn1":
                    pastaForm pf = new pastaForm(lv);
                    pf.Commons(btn.Name);
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
                    MessageBox.Show("서비스준비중입니다.","알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
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
            /*
            ArrayList arrayList = new ArrayList();

            arrayList.Add(new btnSet(this, "menu1", "파스타", 100, 100, 0, 0, menu_Click));
            arrayList.Add(new btnSet(this, "menu2", "스테이크", 100, 100, 0, 100, menu_Click));
            arrayList.Add(new btnSet(this, "menu3", "샐러드", 100, 100, 0, 200, menu_Click));
            arrayList.Add(new btnSet(this, "menu4", "디저트", 100, 100, 0, 300, menu_Click));
            arrayList.Add(new btnSet(this, "menu5", "음료", 100, 100, 0, 400, menu_Click));
            arrayList.Add(new btnSet(this, "menu6", "사이드메뉴", 100, 100, 0, 500, menu_Click));
            */

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
            /*
            pastaForm pastaForm = new pastaForm();
            pastaForm.MdiParent = this.ParentForm;
            pastaForm.WindowState = FormWindowState.Maximized;
            pastaForm.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(pastaForm);
            pastaForm.Show();
            */
        }      
       
        private void Category_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string _bNo = btn.Name;
            MessageBox.Show(_bNo);

            ht = new Hashtable();
            ht.Add("spName", "sp_Menu_Select");
            ht.Add("param", "_bNo:"+ _bNo);

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
             /*
             switch (btn.Name)
             {
                 case "menu1":
                     pastaForm pastaForm = new pastaForm(lv);
                     pastaForm.MdiParent = this.ParentForm;
                     pastaForm.WindowState = FormWindowState.Maximized;
                     pastaForm.FormBorderStyle = FormBorderStyle.None;
                     panel2.Controls.Add(pastaForm);
                     pastaForm.Show();

                     break;
                 case "menu2":
                     steakeForm steakeform = new steakeForm();
                     steakeform.MdiParent = this.ParentForm;
                     steakeform.WindowState = FormWindowState.Maximized;
                    steakeform.FormBorderStyle = FormBorderStyle.None;
                     panel2.Controls.Add(steakeform);
                     steakeform.Show();
                     break;
                 case "menu3":
                     SaladForm saladform = new SaladForm();
                     saladform.MdiParent = this.ParentForm;
                     saladform.WindowState = FormWindowState.Maximized;
                     saladform.FormBorderStyle = FormBorderStyle.None;
                     panel2.Controls.Add(saladform);
                     saladform.Show();
                     break;
                 case "menu4":
                     beverageForm beverage = new beverageForm();
                     beverage.MdiParent = this.ParentForm;
                     beverage.WindowState = FormWindowState.Maximized;
                     beverage.FormBorderStyle = FormBorderStyle.None;
                     panel2.Controls.Add(beverage);
                     beverage.Show();
                     break;
                 case "menu5":
                     dessertForm dessert = new dessertForm();
                     dessert.MdiParent = this.ParentForm;
                     dessert.WindowState = FormWindowState.Maximized;
                     dessert.FormBorderStyle = FormBorderStyle.None;
                     panel2.Controls.Add(dessert);
                     dessert.Show();
                     break;
                 case "menu6":
                     sidemenuForm sidemenu = new sidemenuForm();
                     sidemenu.MdiParent = this.ParentForm;
                     sidemenu.WindowState = FormWindowState.Maximized;
                     sidemenu.FormBorderStyle = FormBorderStyle.None;
                     panel2.Controls.Add(sidemenu);
                     sidemenu.Show();
                     break;
             }
             */
     
            private void Menu_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                //MessageBox.Show(btn.Name);
               
        }
    }
}
