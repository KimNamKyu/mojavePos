using mojavePos.CHUN;
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
        private Graphics gr;
        MenuForm menu;

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

            /*-------------메뉴박스------------------*/

            pnSet pn2 = new pnSet(this, 1500, 800, 0, 100);
            bottom = ct.panel(pn2); // 패널이름 : bottom
            Controls.Add(bottom);
         
            ArrayList arr = new ArrayList();

            arr.Add(new lbSet(this, "lb1", "Category", 200, 35, 350, 80, 25));
            arr.Add(new btnSet(this, "btn_1", "//사진으로 대체", 30, 30, 460, 125, btn_Click));
            arr.Add(new pictureBoxSet(this, 40, 40, 410, 120, " "));
            arr.Add(new lbSet(this, "lb2", "Menu", 200, 35, 1000, 80, 25));
            arr.Add(new btnSet(this, "btn_2", "//사진으로 대체", 30, 30, 1060, 125, btn2_Click));
            arr.Add(new pictureBoxSet(this, 40, 40, 1010, 120, " "));

            for (int i = 0; i < arr.Count; i++)
            {
                if (typeof(lbSet) == arr[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr[i]);
                    bottom.Controls.Add(label);
                }
                else if (typeof(btnSet) == arr[i].GetType())
                {
                    Button button = ct.btn((btnSet)arr[i]);
                    bottom.Controls.Add(button);
                }
                else if (typeof(pictureBoxSet) == arr[i].GetType())
                {
                    PictureBox picuturebox = ct.picture((pictureBoxSet)arr[i]);
                    picuturebox.BackColor = Color.Green;
                    bottom.Controls.Add(picuturebox);
                    
                }
            }
            /*-----------*/
            gr = this.CreateGraphics();
            Pen pen1 = new Pen(Color.Black, 1);
            pen1.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            Point First = new Point(300, 300);
            Point Second = new Point(1200, 300);
            /*-----------*/

            head.BackColor = Color.Black;
            bottom.BackColor = Color.BurlyWood;
            /*----------------------------*/
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
                    FORM_03 F3 = new FORM_03();
                    F3.Show(); // exit하면 MANAGERFORM이 꺼져야하는 기능 추가해야 함
                    break;
            }
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch(btn.Name)
            {
                case "btn_1":
                    Menu_modal Me_mo = new Menu_modal();
                    Me_mo.Location = new Point(100, 100);
                    Me_mo.StartPosition = FormStartPosition.Manual;
                    Me_mo.Location = new System.Drawing.Point(240, 30); //모달 처음 위치값 지정<나중에 바꾸기>
                    Me_mo.BackColor = Color.Black;
                    Me_mo.Show();
                    break;
            }

        }
        private void btn2_Click(object sender, EventArgs e)
        {

        }
    }
}
