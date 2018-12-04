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

        public CountView()
        {
            InitializeComponent();
            Load += CountView_Load;
        }

        private void CountView_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackColor = Color.Gainsboro;
            listView();
            btn_load();
            menu_view();
        }

        private void listView()
        {
            ArrayList arr = new ArrayList();
            arr.Add(new lvSet(this, "", 500, 300, 50, 50, list_Click));
            ListView lv = ct.listview((lvSet)arr[0]);
            Controls.Add(lv);

            lv.Columns.Add("No",40,HorizontalAlignment.Center);
            lv.Columns.Add("메뉴명", 160, HorizontalAlignment.Center);
            lv.Columns.Add("단가", 100, HorizontalAlignment.Center);
            lv.Columns.Add("수량", 100, HorizontalAlignment.Center);
            lv.Columns.Add("금액", 100, HorizontalAlignment.Center);

            ListView lv2 = new ListView();
            lv2.View = View.Details;
            lv2.GridLines = true;
            lv2.Alignment = ListViewAlignment.Left;
            lv2.Size = new Size(500, 200);
            lv2.Location = new Point(50, 380);
            Controls.Add(lv2);

            lv2.Columns.Add("총금액", 100, HorizontalAlignment.Center);
            lv2.Columns.Add("메뉴명", 100, HorizontalAlignment.Center);
            lv2.Columns.Add("단가", 100, HorizontalAlignment.Center);
        }

        private void list_Click(object sender, MouseEventArgs e)
        {
            
        }

        private void btn_load()
        {
            ArrayList arr2 = new ArrayList();
            arr2.Add(new btnSet(this, "btn1", "할인쿠폰", 230, 100, 50, 630, btn_Click));
            arr2.Add(new btnSet(this, "btn2", "현금결제", 230, 100, 320, 630, btn_Click));
            arr2.Add(new btnSet(this, "btn3", "주문", 230, 100, 50, 750, btn_Click));
            arr2.Add(new btnSet(this, "btn3", "카드결제", 230, 100, 320, 750, btn_Click));
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
                    
                    break;
                case "btn2":
                    Cash cash = new Cash();
                    cash.StartPosition = FormStartPosition.CenterParent;
                    cash.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private void menu_view()
        {
            pnSet pn1 = new pnSet(this, 100, 800, 700, 50);
            Panel panel = ct.panel(pn1);
            Controls.Add(panel);
            pnSet pn2 = new pnSet(this, 600, 800, 800, 50);
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
                    pastaForm PastaFrom = new pastaForm();
                    PastaFrom.MdiParent = this;
                    PastaFrom.WindowState = FormWindowState.Maximized;
                    PastaFrom.FormBorderStyle = FormBorderStyle.None;
                    panel2.Controls.Add(PastaFrom);
                    PastaFrom.Show();
                    break;
                case "menu2":
                    steakeForm steakeform = new steakeForm();
                    steakeform.MdiParent = this;
                    steakeform.WindowState = FormWindowState.Maximized;
                    steakeform.FormBorderStyle = FormBorderStyle.None;
                    panel2.Controls.Add(steakeform);
                    steakeform.Show();
                    break;
                case "menu3":
                    SaladForm saladform = new SaladForm();
                    saladform.MdiParent = this;
                    saladform.WindowState = FormWindowState.Maximized;
                    saladform.FormBorderStyle = FormBorderStyle.None;
                    panel2.Controls.Add(saladform);
                    saladform.Show();
                    break;
                case "menu4":
                    beverageForm beverage = new beverageForm();
                    beverage.MdiParent = this;
                    beverage.WindowState = FormWindowState.Maximized;
                    beverage.FormBorderStyle = FormBorderStyle.None;
                    panel2.Controls.Add(beverage);
                    beverage.Show();
                    break;
                case "menu5":
                    dessertForm dessert = new dessertForm();
                    dessert.MdiParent = this;
                    dessert.WindowState = FormWindowState.Maximized;
                    dessert.FormBorderStyle = FormBorderStyle.None;
                    panel2.Controls.Add(dessert);
                    dessert.Show();
                    break;
                case "menu6":
                    sidemenuForm sidemenu = new sidemenuForm();
                    sidemenu.MdiParent = this;
                    sidemenu.WindowState = FormWindowState.Maximized;
                    sidemenu.FormBorderStyle = FormBorderStyle.None;
                    panel2.Controls.Add(sidemenu);
                    sidemenu.Show();
                    break;
            }
            
        }
    }
}
