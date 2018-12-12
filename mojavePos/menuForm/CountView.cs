using mojavePos.menuForm;
using mojavePos.Modal;
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
                    ListView lv = ct.listview((lvSet)arr[i]);
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
                    Coupon cp = new Coupon();
                    cp.StartPosition = FormStartPosition.CenterParent;
                    cp.Show();
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
            this.Visible = true;
            pnSet pn1 = new pnSet(this, 100, 780, 750, 10);
            Panel panel = ct.panel(pn1);
            panel.BackColor = Color.Gainsboro;
            Controls.Add(panel);
            pnSet pn2 = new pnSet(this, 600, 780, 850, 10);
            panel2 = ct.panel(pn2);
            panel2.BackColor = Color.Gainsboro;
            Controls.Add(panel2);

            ArrayList arrayList = new ArrayList();
            arrayList.Add(new btnSet(this, "menu1", "파스타", 100, 100, 0, 0, menu_Click));
            arrayList.Add(new btnSet(this, "menu2", "스테이크", 100, 100, 0, 100, menu_Click));
            arrayList.Add(new btnSet(this, "menu3", "샐러드", 100, 100, 0, 200, menu_Click));
            arrayList.Add(new btnSet(this, "menu4", "음료", 100, 100, 0, 300, menu_Click));
            arrayList.Add(new btnSet(this, "menu5", "디저트", 100, 100, 0, 400, menu_Click));
            arrayList.Add(new btnSet(this, "menu6", "사이드메뉴", 100, 100, 0, 500, menu_Click));

            for( int i = 0; i < arrayList.Count; i++)
            {
                Button button = ct.btn((btnSet)arrayList[i]);
                panel.Controls.Add(button);
            }
        }
       
       
       
        private void menu_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            switch (btn.Name)
            {
                case "menu1":
                    pastaForm pastaForm = new pastaForm();
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
        }       
    }
}
