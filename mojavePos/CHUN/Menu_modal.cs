using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mojavePos.CHUN
{
    public partial class Menu_modal : Form
    {
        _Create ct = new _Create();
        SqlConnection conn;
        TextBox textbox1;
        private string no;

        public Menu_modal()
        {
            InitializeComponent();
            Load += Menu_modal_Load;
        }

        private void Menu_modal_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();

            string host = "(localdb)\\ProjectsV13";
            string user = "root";
            string password = "1234";
            string db = "test2";

            conn.ConnectionString = string.Format("server={0};uid={1};password={2};database={3}", host, user, password, db);


            ClientSize = new Size(300, 50);
            pnSet pn = new pnSet(this, 300, 50, 0, 0);
            Panel panel = ct.panel(pn);
            Controls.Add(panel);
           

            //arr.Add(new tbSet(this, "tb1", 200, 50, 0, 0));
            tbSet tb = new tbSet(this, "tb1", 200, 50, 0, 0);
            textbox1 = ct.txtbox(tb);
            panel.Controls.Add(textbox1);
           
            ArrayList arr = new ArrayList();
            arr.Add(new btnSet(this, "btn1", "추가",50, 50, 200, 0, btn_click));
            arr.Add(new btnSet(this, "btn2", "취소", 50, 50, 250, 0, btn_click));
           

            for (int i = 0; i < arr.Count; i++)
            {
                if (typeof(btnSet) == arr[i].GetType())
                {
                    Button button = ct.btn((btnSet)arr[i]);
                    panel.Controls.Add(button);
                }
                else if (typeof(tbSet) == arr[i].GetType())
                {
                    TextBox textbox = ct.txtbox((tbSet)arr[i]);
                    panel.Controls.Add(textbox);
                }
            }
        }

        private void btn_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "btn1":
                   
                    CUD("sp_insert");
                   

                    break;
                case "btn2":
                    this.Close();
                    break;
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
               
                while (sdr.Read())
                {
                    string[] arr = new string[ColNum];
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        //result += string.Format("{0} : {1}wt", sdr.GetName(i), sdr.GetValue(i));
                        arr[i] = sdr.GetValue(i).ToString();
                    }
                    //result += "\n";
                    //listView1.Items.Add(new ListViewItem(arr));
                   
                    
                    
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
            string name = textbox1.Text; //파스타입력

            try
            {

                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = sql;
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;

                if (sql == "sp_delete")
                {
                    comm.Parameters.AddWithValue("@no", no);
                }
                else if (sql == "sp_insert")
                {
                    comm.Parameters.AddWithValue("@name", name);
                    MessageBox.Show("실행완료");
                }
                else if (sql == "sp_update")
                {
                    comm.Parameters.AddWithValue("@no", no);
                    comm.Parameters.AddWithValue("@name", name);
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
