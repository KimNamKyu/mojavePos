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
    public partial class MenuView : Form
    {
        _Create ct = new _Create();
        private Panel panel2;

        public MenuView()
        {
            InitializeComponent();
            Load += MenuView_Load;
        }

        private void MenuView_Load(object sender, EventArgs e)
        {
           
        }
        private void menu_view()
        {
            this.Visible = true;
            pnSet pn1 = new pnSet(this, 100, 800, 0, 10);
            Panel panel = ct.panel(pn1);
            Controls.Add(panel);
            pnSet pn2 = new pnSet(this, 600, 800, 0, 10);
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

            for (int i = 0; i < arrayList.Count; i++)
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
                    MainPos mp = new MainPos();
                    pastaForm PastaFrom = new pastaForm();
                    PastaFrom.MdiParent = mp;
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
