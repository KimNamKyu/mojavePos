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
    public partial class MainPos : Form
    {
        _Create ct= new _Create();
        private Panel pn4;
        private Commons comm;
        private Hashtable ht;
        private WebAPI api;
        private string tNo;
      

        public MainPos()
        {
            InitializeComponent();
            Load += MainPos_Load;
            //this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainPos_Load(object sender, EventArgs e)
        {
            comm = new Commons();
            this.IsMdiContainer = true;
            this.ClientSize = new Size(1500, 900);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            Mainup_Load();
            btn_Load();
        }

        //메인Pos 상단바 UI
        private void Mainup_Load()
        {
            ArrayList arr = new ArrayList();

            arr.Add(new pnSet(this, 300, 100, 0, 0));
            arr.Add(new pnSet(this, 900, 100, 300, 0));
            arr.Add(new pnSet(this, 300, 100, 1200, 0));
            
            Panel pnl = new Panel();
            pnl = ct.panel((pnSet)arr[0]);
            pnl.BackColor = Color.Blue;
            Controls.Add(pnl);

            PictureBox mojave = new PictureBox();
            mojave.Image = (Bitmap)mojavePos.Properties.Resources.ResourceManager.GetObject("mojave");
            mojave.SizeMode = PictureBoxSizeMode.StretchImage;
            mojave.Size = new Size(300, 100);
            mojave.Location = new Point(0, 0);
            pnl.Controls.Add(mojave);

            Panel pnl2 = new Panel();
            pnl2 = ct.panel((pnSet)arr[1]);
            pnl2.BackColor = Color.Gainsboro;
            Controls.Add(pnl2);

            Panel pnl3 = new Panel();
            pnl3 = ct.panel((pnSet)arr[2]);
            pnl3.BackColor = Color.Silver;
            pnl3.Click += Pnl3_Click;
            Controls.Add(pnl3);
            
            arr.Add(new lbSet(this, "라벨1", "MojavePos System", 400, 70, 300, 20, 40));
            arr.Add(new lbSet(this, "라벨2", "종료", 150, 50, 100, 20, 35));
            
            Label label1 = ct.lable((lbSet)arr[3]);
            pnl2.Controls.Add(label1);

            Label label2 = ct.lable((lbSet)arr[4]);
            pnl3.Controls.Add(label2);

            arr.Add(new pnSet(this, 1500, 800, 0, 100));
            pn4 = new Panel();
            pn4.Name = "contents";
            pn4 = ct.panel((pnSet)arr[5]);
            pn4.BackColor = Color.Beige;
            Controls.Add(pn4);

        }
        //종료버튼 클릭시 이벤트
        private void Pnl3_Click(object sender, EventArgs e)
        {
            Dispose();
            FORM_03 f3 = new FORM_03();
            f3.Show();
        }
        //버튼 UI
        private void btn_Load()
        {
            ArrayList array = new ArrayList();

            array.Add(new pnSet(this, 5, 310, 620, 40));
            array.Add(new pnSet(this, 5, 310, 620, 450));
            
            for (int i = 0; i < array.Count; i++)
            {
                if (typeof(pnSet) == array[i].GetType())
                {
                    Panel panel = ct.panel((pnSet)array[i]);
                    panel.BackColor = Color.Silver;
                    pn4.Controls.Add(panel);
                }
            }
            api = new WebAPI();
            ht = new Hashtable();
            ht.Add("spName", "sp_Table_Select");
            ht.Add("param", "");
            ArrayList list = api.Select("http://localhost:5000/select", ht);
            if (list != null)
            {
                ArrayList arrayList = api.Button3(pn4, list, btn_Click);
                for (int i = 0; i < arrayList.Count; i++)
                {
                    Button button = ct.btn((btnSet)arrayList[i]);
                    pn4.Controls.Add(button);
                }
            }
        }
        
        private ArrayList list;
        //버튼 이벤트
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //MessageBox.Show(btn.Name);
            //MessageBox.Show(btn.Text);
            tNo = btn.Text;
            ht = new Hashtable();
            ht.Add("spName", "sp_Order_Select");
            ht.Add("param", "_tNo:" + tNo);
            list = api.Select("http://localhost:5000/select", ht);
            
            CountView cv = new CountView(tNo, list);
            cv.MdiParent = this;
            cv.WindowState = FormWindowState.Maximized;
            cv.FormBorderStyle = FormBorderStyle.None;
            pn4.Controls.Add(cv);
            cv.Show();
        }
    }
}
