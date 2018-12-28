using mojavePos.Han;
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

namespace mojavePos.CHUN
{
    public partial class Menu_update_delete_modal : Form
    {
        _Create ct = new _Create();
        public TextBox textbox1, textbox2;
        private string mc_No;
        MenuForm mf;

        public Menu_update_delete_modal()
        {
            InitializeComponent();
            Load += Menu_update_delete_modal_Load;
        }

        private void Menu_update_delete_modal_Load(object sender, EventArgs e)
        {

            ClientSize = new Size(350, 100);
            pnSet pn = new pnSet(this, 350, 100, 0, 0);
            Panel panel = ct.panel(pn);
            Controls.Add(panel);

            tbSet tb = new tbSet(this, "tb1", 200, 50, 0, 0);
            textbox1 = ct.txtbox(tb);
            panel.Controls.Add(textbox1);

            tbSet tb2 = new tbSet(this, "tb2", 200, 50, 0, 50);
            textbox2 = ct.txtbox(tb2);
            panel.Controls.Add(textbox2);

            ArrayList arr = new ArrayList();
            arr.Add(new btnSet(this, "btn1", "수정", 50, 50, 200, 0, btn_click));
            arr.Add(new btnSet(this, "btn2", "삭제", 50, 50, 250, 0, btn_click));
            arr.Add(new btnSet(this, "btn3", "취소", 50, 50, 300, 0, btn_click));


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
            Hashtable ht = new Hashtable();
            Module api = new Module();
            mf = new MenuForm();
            switch (btn.Name)
            {
                case "btn1":
                    api = new Module();
                    ht.Add("m_Sort", mf.No1);
                    ht.Add("m_Name", textbox1.Text);
                    ht.Add("m_Price", textbox2.Text);
                    ht.Add("m_bNo",mf.No);
                    api.insert_Category("http://192.168.3.20:5000/mn_update", ht);
                    MessageBox.Show("수정하셨습니다.");
                    this.Close();
                    //Close();
                    break;
                case "btn2":
                    api = new Module();
                    //MessageBox.Show(mf.No , mf.No1);
                    ht.Add("m_bNo", mf.No);
                    ht.Add("m_Sort", mf.No1);
                    api.insert_Category("http://192.168.3.20:5000/mn_delete", ht);
                    //MessageBox.Show("삭제하셨습니다.");
                    this.Close();
                    //Close();
                    break;
                case "btn3":
                    this.Close();
                    MessageBox.Show("취소하셨습니다.");
                    break;
            }
        }
    }
}
