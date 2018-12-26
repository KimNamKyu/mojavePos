using mojavePos.menuForm;
using mojavePos.Modal;
using mojavePos;
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
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json.Linq;

namespace mojavePos.Han
{
    public partial class RankForm : Form
    {
        Commons comm;
        _Create ct = new _Create();
        Chart chart;
        ChartArea chartArea1;
        Legend legend1;
        Series series1;
        Hashtable ht;
        TextBox tb;
        string start = "";
        string end = "";
        string[] arr;
        Panel pasta, steake, salad, dessert, beverage, side;
        ArrayList list = new ArrayList();
        
        public RankForm()
        {
            InitializeComponent();
            Load += RankForm_Load;
        }
       

        private void RankForm_Load(object sender, EventArgs e)
        {
            //get_panel();
            get_Combo();
            get_text();
            get_panel();

        }
        public void get_panel()
        {
            ArrayList panel = new ArrayList();
            comm = new Commons();

            pnSet pn1 = new pnSet(this, 433, 350, 100, 70);
            pasta = ct.panel(pn1);
            pasta.BackColor = Color.Azure;
            pasta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Controls.Add(pasta);
            panel.Add(pasta);

            pnSet pn2 = new pnSet(this, 433, 350, 533, 70);
            steake = ct.panel(pn2);
            steake.BackColor = Color.Black;
            steake.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Controls.Add(steake);
            panel.Add(steake);

            pnSet pn3 = new pnSet(this, 433, 350, 966, 70);
            salad = ct.panel(pn3);
            salad.BackColor = Color.Aqua;
            salad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Controls.Add(salad);
            panel.Add(salad);

            pnSet pn4 = new pnSet(this, 433, 350, 100, 420);
            beverage = ct.panel(pn4);
            beverage.BackColor = Color.BurlyWood;
            beverage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Controls.Add(beverage);
            panel.Add(beverage);

            pnSet pn5 = new pnSet(this, 433, 350, 533, 420);
            side = ct.panel(pn5);
            side.BackColor = Color.DarkMagenta;
            side.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Controls.Add(side);
            panel.Add(side);

            pnSet pn6 = new pnSet(this, 433, 350, 966, 420);
            dessert = ct.panel(pn6);
            dessert.BackColor = Color.MidnightBlue;
            dessert.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Controls.Add(dessert);
            panel.Add(dessert);


            for (int i = 0; i < 6; i++)
            {
                ht = new Hashtable();
                ht.Add("areaname", "ChartArea1");
                ht.Add("legname", "Legend1");
                ht.Add("seriname", "Series1");
                ht.Add("chartname", "chartname");
                ht.Add("text", panel[i]);
                
                chart = comm.getChart(ht, (Panel)panel[i]);
                switch (i)
                {
                    
                    case 0:
                        chart.Titles.Add("파스타");
                        chart.Series["Series1"].Points.AddXY("1", "60");
                        chart.Series["Series1"].Points.AddXY("2", "60");
                        break;
                    case 1:
                        chart.Titles.Add("스테이크");
                        chart.Series["Series1"].Points.AddXY("2", "60");
                        chart.Series["Series1"].Points.AddXY("3", "60");
                        break;
                    case 2:
                        chart.Titles.Add("샐러드");
                        //chart.Series["Series1"].Points.AddXY(arr[1], arr[2]);
                        chart.Series["Series1"].Points.AddXY("2", "60");
                        chart.Series["Series1"].Points.AddXY("3", "60");
                        break;
                    case 3:
                        chart.Titles.Add("음료");
                        break;
                    case 4:
                        chart.Titles.Add("사이드");
                        break;
                    case 5:
                        chart.Titles.Add("디저트");
                        break;
                }


            }

        }
        public void get_Combo()
        {
            comm = new Commons();
            ComboBox combo = new ComboBox();
            comboboxSet cb1 = new comboboxSet(this, "month", 120, 35, 780, 35);
            combo = ct.combobox(cb1);
            combo.Font = new Font("Verdana", 10.5f, FontStyle.Italic);
            combo.Text = "분기선택";
            combo.Items.Add("1분기");
            combo.Items.Add("2분기");
            combo.Items.Add("3분기");
            combo.Items.Add("4분기");
            combo.SelectedIndexChanged += Combo_SelectedIndexChanged;
            Controls.Add(combo);

        }
        private void Combo_SelectedIndexChanged(object sender, EventArgs e) // 콤보박스 이벤트 
        {
            ComboBox combo = (ComboBox)sender;

            WebAPI api = new WebAPI();
            string index = (string)combo.SelectedItem;

            if (index == "1분기")
            {
                if (tb.Text != "")
                {                    
                    api.Post2("http://localhost:5000/insert_CM");
                    start = tb.Text + "-1-1";
                    end = tb.Text + "-3-31";
                }
            }
            else if (index == "2분기")
            {
                if (tb.Text != "")
                {
                    start = tb.Text + "-4-1";
                    end = tb.Text + "-6-30";
                }
            }
            else if (index == "3분기")
            {
                if (tb.Text != "")
                {
                    start = tb.Text + "-7-1";
                    end = tb.Text + "-9-30";
                }

            }
            else if (index == "4분기")
            {
                if (tb.Text != "")
                {
                    start = tb.Text + "-10-1";
                    end = tb.Text + "-12-31";
                }
            }

            
            Hashtable pcd = new Hashtable();
            pcd.Add("spName", "sel_Rank");
            pcd.Add("start", start);
            pcd.Add("end", end);
            list = api.Select("http://localhost:5000/sel_date", pcd);
            arr = api.Chart(list);
            foreach(Hashtable ht in list)
            {
                ht["m_bNo"].ToString();
                ht["c_Menu"].ToString();
                ht["sum(cm.c_Count)"].ToString();
            }

        }


        private void get_text()
        {
            comm = new Commons();
            tb = new TextBox();
            tbSet tbs = new tbSet(this, "year", 120, 24, 650, 35);
            tb = ct.txtbox(tbs);
            tb.KeyPress += Tb_KeyPress;
            tb.MaxLength = 4;
            tb.TextAlign = HorizontalAlignment.Center;
            tb.MouseClick += Tb_MouseClick;
            tb.Text = "연도";
            tb.ForeColor = Color.Gray;
        }


        private void Tb_MouseClick(object sender, MouseEventArgs e)
        {
            bool init = true;
            TextBox tb = (TextBox)sender;

            if (init)
            {
                tb.Text = "";
                init = false;
            }
        }

        private void Tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.ForeColor = Color.Black;
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '-'))
            {
                e.Handled = true;
            }
        }
    }
}
