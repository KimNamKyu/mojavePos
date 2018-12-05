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
    public partial class ManagerForm : Form
    {
        _Create ct = new _Create();
        Panel bottom;


        public ManagerForm()
        {
            InitializeComponent();
            Load += MemberForm_Load;
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(1500, 900);
            this.IsMdiContainer = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Head();
        }
        private void Head()
        {
            pnSet pn1 = new pnSet(this, 1500, 100, 0, 0);
            Panel head = ct.panel(pn1);
            Controls.Add(head);
            pnSet pn2 = new pnSet(this, 1500, 800, 0, 100);
            bottom = ct.panel(pn2);
            Controls.Add(bottom);
            head.BackColor = Color.Black;
            bottom.BackColor = Color.Brown;

            ArrayList btn_list = new ArrayList();
            btn_list.Add(new btnSet(this, "menu", "메뉴관리", 375, 100, 0, 0, Main_Click));
            btn_list.Add(new btnSet(this, "money", "매출관리", 375, 100, 375, 0, Main_Click));
            btn_list.Add(new btnSet(this, "user", "회원관리", 375, 100, 750, 0, Main_Click));
            btn_list.Add(new btnSet(this, "exit", "종료", 375, 100, 1125, 0, Main_Click));
            
            for(int i=0; i < btn_list.Count; i++)
            {
                Button button = ct.btn((btnSet)btn_list[i]);
                head.Controls.Add(button);
            }


        }
        private void Main_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Name)
            {
                case "menu":
                    MenuForm menu = new MenuForm();
                    menu.MdiParent = this;
                    menu.WindowState = FormWindowState.Maximized;
                    menu.FormBorderStyle = FormBorderStyle.None;
                    bottom.Controls.Add(menu);
                    menu.Show();
                    break;
                case "money":
                    MoneyForm  money= new MoneyForm();
                    money.MdiParent = this;
                    money.WindowState = FormWindowState.Maximized;
                    money.FormBorderStyle = FormBorderStyle.None;
                    bottom.Controls.Add(money);
                    money.Show();
                    break;
                case "user":
                    UserForm user = new UserForm();
                    user.MdiParent = this;
                    user.WindowState = FormWindowState.Maximized;
                    user.FormBorderStyle = FormBorderStyle.None;
                    bottom.Controls.Add(user);
                    user.Show();
                    break;
                case "exit":
                    this.Close();
                    break;
            }
        }

    }
}
