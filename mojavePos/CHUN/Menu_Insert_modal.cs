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
    public partial class Menu_Insert_modal : Form
    {
        _Create ct = new _Create();
        TextBox textbox1, textbox2;
        MenuForm MenuForm;
        string abb;
        public Menu_Insert_modal()
        {
            InitializeComponent();
            Load += Menu_Insert_modal_Load;
        }

        private void Menu_Insert_modal_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(300, 100);
          

            pnSet pn = new pnSet(this, 300, 100, 0, 0);
            Panel panel = ct.panel(pn);
            Controls.Add(panel);

            tbSet tb = new tbSet(this, "tb1", 200, 50, 0, 0);
            textbox1 = ct.txtbox(tb);
            panel.Controls.Add(textbox1);

            tbSet tb2 = new tbSet(this, "tb2", 200, 50, 0, 50);
            textbox2 = ct.txtbox(tb2);
            panel.Controls.Add(textbox2);

            ArrayList arr = new ArrayList();
            arr.Add(new btnSet(this, "btn1", "추가", 50, 50, 200, 0, btn_click));
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
            Module api = new Module();
            MenuForm = new MenuForm();
            switch (btn.Name)
            {
                case "btn1":
                    Hashtable ht = new Hashtable();
                    api = new Module();
                    ht.Add("m_bNo", abb);
                    ht.Add("m_Name", textbox1.Text);
                    ht.Add("m_Price",textbox2.Text);
                    api.insert_Category("http://192.168.3.28:5000/mn_insert", ht);
                    break;

                case "btn2":
                    this.Close();
                    break;
            }
        }
        public string value1
        {
            get;
            set;
        }
        public string value2
        {
            get;
            set;
        }

        public void sss()
        {

            abb = value1;
            MessageBox.Show(abb);
        }
    }
}
