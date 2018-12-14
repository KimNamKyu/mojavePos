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

namespace mojavePos.CHUN
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
            Load += Test_Load;
        }

        _Create ct = new _Create();

        private void Test_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(750, 450);

            pnSet pn1 = new pnSet(this, 750, 150, 0, 0);
            Panel 패널 = ct.panel(pn1);
            패널.BackColor = Color.FromArgb(200, 100, 100);
            Controls.Add(패널);

            ArrayList arr = new ArrayList();
            arr.Add(new btnSet(this, "button", "카테고리추가", 250, 40, 260, 40, btn_Click));
            arr.Add(new btnSet(this, "button2", "메뉴추가", 250, 40, 260, 100, btn2_Click));
          
            for (int i = 0; i < arr.Count; i++)
            {
                if (typeof(btnSet) == arr[i].GetType())
                {
                    Button button = ct.btn((btnSet)arr[i]);
                    패널.Controls.Add(button);
                }
            }

            aa();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Menu_modal MenuM = new Menu_modal();
            MenuM.Show();
        }
        private void btn2_Click(object sender, EventArgs e)
        {

        }
        private void aa()
        {

            lbSet lb1 = new lbSet(this, "label1", "", 100, 50, 100, 40, 10);
            Label 라벨 = ct.lable(lb1);
            라벨.BackColor = Color.FromArgb(255, 255, 255);
            Controls.Add(라벨);

            pnSet pn2 = new pnSet(this, 750, 300, 0, 150);
            Panel 패널2 = ct.panel(pn2);
            패널2.BackColor = Color.FromArgb(0, 0, 255);
            Controls.Add(패널2);
            패널2.Controls.Add(라벨);

        }
    }
}



/*
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp
{

    public partial class Form1 : Form
    {
        private SqlConnection conn;
        private string no;
        //private string name;
        //private string age;

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Click += btn1;
            button2.Click += btn2;
            listView1.MouseClick += lv1; //왜 첫번째 컬럼 선택했을때 실행되는지
            listView1.FullRowSelect = true;
            button3.Click += btn3;
            button4.Click += btn4;

            conn = new SqlConnection();

            string host = "(localdb)\\ProjectsV13";
            string user = "root";
            string password = "1234";
            string db = "test2";

            conn.ConnectionString = string.Format("server={0};uid={1};password={2};database={3}", host, user, password, db);
            //SqlConnection conn = new SqlConnection(connStr);

        }

        private void btn1(object s, EventArgs e)
        {
            R("sp_select", 6);
        }


        private void btn2(object s, EventArgs e)
        {
            //MessageBox.Show(no);

            CUD("sp_delete");
            R("sp_select", 6);
        }

        private void btn3(object sender, EventArgs e)
        {
           // string name = textBox1.Text;
           // string age = textBox2.Text;
            CUD("sp_insert");
            R("sp_select", 6);
        }
        private void btn4(object s, EventArgs e)
        {
           // string name = textBox1.Text;
           // string age = textBox2.Text;
            CUD("sp_update");
            R("sp_select", 6);
        }
        private void lv1(object s, EventArgs e)
        {
            //MessageBox.Show("선택되었다");
            ListView lv = (ListView)s;
            ListView.SelectedListViewItemCollection slv = lv.SelectedItems;
            for (int i = 0; i < slv.Count; i++)
            {
                ListViewItem item = slv[i];
                //MessageBox.Show(item.SubItems[0].Text);
                no = item.SubItems[0].Text;

                textBox1.Text = item.SubItems[1].Text;
                textBox2.Text = item.SubItems[2].Text;
            }
        }

        private void R(string sql, int ColNum) //read 메서드
        {
            try
            {
                conn.Open();
                //MessageBox.Show("서버오픈");
                SqlCommand comm = new SqlCommand();
                comm.CommandText = sql;
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = comm.ExecuteReader();
                listView1.Items.Clear();
                while (sdr.Read())
                {
                    string[] arr = new string[ColNum];
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        //result += string.Format("{0} : {1}wt", sdr.GetName(i), sdr.GetValue(i));
                        arr[i] = sdr.GetValue(i).ToString();
                    }
                    //result += "\n";
                    listView1.Items.Add(new ListViewItem(arr));
                }
                // MessageBox.Show(result);
                sdr.Close();
                conn.Close();
            }
            catch
            {
                conn.Close();
                MessageBox.Show("서버다운");
            }
        }

        private void CUD(string sql) //insert update delecte 메서드
        {
            string name = textBox1.Text;
            string age = textBox2.Text;
           
            try
            {

                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = sql;
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;

                if(sql == "sp_delete")
                {
                    comm.Parameters.AddWithValue("@no", no);
                }
                else if(sql == "sp_insert")
                {
                    comm.Parameters.AddWithValue("@name", name);
                    comm.Parameters.AddWithValue("@age", age);

                }
                else if(sql == "sp_update")
                {
                    comm.Parameters.AddWithValue("@no", no);
                    comm.Parameters.AddWithValue("@name", name);
                    comm.Parameters.AddWithValue("@age", age);
                }

                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
            }

        }
    }
}

 */
