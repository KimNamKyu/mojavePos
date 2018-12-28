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
using WindowsFormsApp;

namespace mojavePos.Han
{
    public partial class MenuForm : Form
    {
        public static string camo_no;
        _Create ct = new _Create();
        Panel bottom, line;
        private Graphics gr;
        Module api = new Module();
        Button button, 수정버튼;
        public string no;
        Category_Update_delete_modal CUD;
        ListView.SelectedListViewItemCollection slv;
        public ListView listview2;
        public MenuForm()
        {
            InitializeComponent();
            Load += MenuForm_Load;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(1500, 800);

            lvSet lv1 = new lvSet(this, "lv1", 300, 500, 570, 230, lv_mouseClick);
            ListView listview = ct.listview(lv1);
            listview.Font = new Font("Tahoma", 20, FontStyle.Bold);
            listview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listview.Columns.Add(" ", 0, HorizontalAlignment.Center);
            listview.Columns.Add(" ", 296, HorizontalAlignment.Center);
            Controls.Add(listview);
            api = new Module();
            api.selectListView("http://192.168.3.28:5000/mc_select", listview);

            lvSet lv2 = new lvSet(this, "lv2", 400, 500, 1000, 230, lv2_mouseClick);
            listview2 = ct.listview(lv2);
            listview2.Font = new Font("Tahoma", 15, FontStyle.Bold);
            listview2.Columns.Add("", 0, HorizontalAlignment.Center);
            listview2.Columns.Add("메뉴명", 200, HorizontalAlignment.Center);
            listview2.Columns.Add("가격", 100, HorizontalAlignment.Center);

            //listview2.Columns.Add("변경/삭제", 100, HorizontalAlignment.Center);

            btnSet btn1_1 = new btnSet(this, "btn_1_1", "--", 30, 30, 770, 170, btn3_Click);
            수정버튼 = ct.btn(btn1_1);
            Controls.Add(수정버튼);

            pnSet pn3 = new pnSet(this, 950, 2, 500, 218);
            line = ct.panel(pn3);
            Controls.Add(line);

            pnSet pn2 = new pnSet(this, 1500, 800, 0, 0);
            bottom = ct.panel(pn2); // 패널이름 : bottom
            Controls.Add(bottom);
            bottom.Controls.Add(listview);
            bottom.Controls.Add(listview2);
            bottom.Controls.Add(수정버튼);

            ArrayList arr = new ArrayList();
            arr.Add(new lbSet(this, "lb1", "Category", 250, 60, 600, 100, 35));
            arr.Add(new btnSet(this, "btn_1", "", 30, 30, 730, 170, btn_Click));

            arr.Add(new pictureBoxSet(this, 40, 40, 680, 165, " "));
            arr.Add(new lbSet(this, "lb2", "Menu", 200, 50, 1110, 100, 35));
            arr.Add(new btnSet(this, "btn_2", "", 30, 30, 1200, 170, btn2_Click));
            arr.Add(new pictureBoxSet(this, 40, 40, 1150, 165, " "));

            for (int i = 0; i < arr.Count; i++)
            {
                if (typeof(lbSet) == arr[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr[i]);
                    label.Font = new Font("Tahoma", 35, FontStyle.Bold);
                    label.BackColor = System.Drawing.Color.Transparent;
                    bottom.Controls.Add(label);
                }
                else if (typeof(btnSet) == arr[i].GetType())
                {
                    button = ct.btn((btnSet)arr[i]);
                    button.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    button.BackgroundImage = mojavePos.Properties.Resources.버튼;
                    bottom.Controls.Add(button);
                }
                else if (typeof(pictureBoxSet) == arr[i].GetType())
                {
                    PictureBox picuturebox = ct.picture((pictureBoxSet)arr[i]);
                    picuturebox.BackgroundImage = mojavePos.Properties.Resources.coo1;
                    bottom.Controls.Add(picuturebox);
                }

            }

            //bottom.BackColor = Color.BurlyWood;
            bottom.BackgroundImage = (Bitmap)mojavePos.Properties.Resources.ResourceManager.GetObject("배경화면1");

        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "btn_1":
                    Category_Insert_modal Me_mo = new Category_Insert_modal();
                    Me_mo.Location = new Point(100, 100);
                    Me_mo.StartPosition = FormStartPosition.Manual;
                    Me_mo.Location = new System.Drawing.Point(240, 30); //모달 처음 위치값 지정<나중에 바꾸기>
                    Me_mo.Show();
                    break;
            }

        }
        private void btn2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "btn_2":
                    Menu_Insert_modal Menu_mo = new Menu_Insert_modal();
                    Menu_mo.Location = new Point(100, 100);
                    Menu_mo.StartPosition = FormStartPosition.Manual;
                    Menu_mo.Location = new System.Drawing.Point(240, 30); //모달 처음 위치값 지정<나중에 바꾸기>

                    run2();
                    break;
            }
        }
        private void lv_mouseClick(object o, MouseEventArgs e)
        {
            수정버튼 = new Button();
            api = new Module();
            button = new Button();
            CUD = new Category_Update_delete_modal();
            ListView lv = (ListView)o;
            slv = lv.SelectedItems;
            for (int i = 0; i < slv.Count; i++)
            {
                ListViewItem item = slv[i];
                no = item.SubItems[0].Text;
               
            }
            api.selectListView_Menu("http://192.168.3.28:5000/mn_select", listview2, no);
        }
        private void btn3_Click(object o, EventArgs e)
        {
            if (MessageBox.Show("수정하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CUD.Show();
                for (int i = 0; i < slv.Count; i++)
                {
                    ListViewItem item = slv[i];

                    camo_no = item.SubItems[0].Text;
                    this.No = camo_no;
                    CUD.textbox1.Text = item.SubItems[1].Text;
                }
            }
        }
        private void lv2_mouseClick(object o, EventArgs e)
        {


        }
        public string No
        {
            get
            {
                return camo_no;
            }
            set
            {
                camo_no = value;
            }
        }
        private delegate void del11();
        public void run2()
        {
            Menu_Insert_modal ff2 = new Menu_Insert_modal();
            ff2.Show();
            string sql = no;
          
            ff2.value1 = sql;
            ff2.sss();
        }
    }
}
