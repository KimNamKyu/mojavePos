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
        Panel bottom,line;
        private Graphics gr;
        Module api = new Module();
        Category_Update_delete_modal CUD;
        public MenuForm()
        {
            InitializeComponent();
            Load += MenuForm_Load;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(1500, 800);
           
            lvSet lv1 = new lvSet(this, "lv1", 400, 500, 500, 230, lv_mouseClick);
            ListView listview = ct.listview(lv1);
            listview.Font = new Font("Tahoma", 20, FontStyle.Bold);
            listview.Columns.Add("카테고리", 396, HorizontalAlignment.Center);
           
            api = new Module();
            api.selectListView("http://localhost:5000/mc_select", listview);
            Controls.Add(listview);

            lvSet lv2 = new lvSet(this, "lv2", 400, 500,1000, 230, lv2_mouseClick);
            ListView listview2 = ct.listview(lv2);
            listview2.Columns.Add("카테고리", 396, HorizontalAlignment.Center);
            api = new Module();
            api.selectListView("http://localhost:5000/mc_select", listview2);
            Controls.Add(listview2);

            pnSet pn3 = new pnSet(this,1500, 1, 0, 0);
            line = ct.panel(pn3);
            Controls.Add(line);

            pnSet pn2 = new pnSet(this, 1500, 800, 0, 0);
            bottom = ct.panel(pn2); // 패널이름 : bottom
            Controls.Add(bottom);
            bottom.Controls.Add(listview);
            bottom.Controls.Add(listview2);
            
            ArrayList arr = new ArrayList();
            arr.Add(new lbSet(this, "lb1", "Category", 250, 50, 600, 80, 35));
            arr.Add(new btnSet(this, "btn_1", "추가", 90, 50, 460, 125, btn_Click));
            arr.Add(new pictureBoxSet(this, 40, 40, 410, 120, " "));
            arr.Add(new lbSet(this, "lb2", "Menu", 200, 50, 1200, 80,35));
            arr.Add(new btnSet(this, "btn_2", "추가", 90, 50, 1060, 125, btn2_Click));
            arr.Add(new pictureBoxSet(this, 40, 40, 1010, 120, " "));
          
            for (int i = 0; i < arr.Count; i++)
            {
                if (typeof(lbSet) == arr[i].GetType())
                {
                    Label label = ct.lable((lbSet)arr[i]);
                    label.BackColor = System.Drawing.Color.Transparent;
                    bottom.Controls.Add(label);
                }
                else if (typeof(btnSet) == arr[i].GetType())
                {
                    Button button = ct.btn((btnSet)arr[i]);
                    // button.BackgroundImage = mojavePos.Properties.Resources.test2; //사진 대체해야 할것
                    bottom.Controls.Add(button);
                }
                else if (typeof(pictureBoxSet) == arr[i].GetType())
                {
                    PictureBox picuturebox = ct.picture((pictureBoxSet)arr[i]);
                    picuturebox.BackColor = Color.Green;
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
                    Me_mo.BackColor = Color.Black;
                    Me_mo.Show();
                    break;
            }

        }
        private void btn2_Click(object sender, EventArgs e)
        {

        }
        private void lv_mouseClick(object o, MouseEventArgs e)
        {
            CUD = new Category_Update_delete_modal();
            ListView lv = (ListView)o;
            ListView.SelectedListViewItemCollection slv = lv.SelectedItems;
            
           
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
        private void lv2_mouseClick(object o , EventArgs e)
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

    }
}
