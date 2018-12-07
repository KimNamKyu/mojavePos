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

namespace mojavePos.Han
{
    public partial class MoneyForm : Form
    {
        Commons comm;
        _Create ct = new _Create();
        public MoneyForm()
        {
            InitializeComponent();
            Load += MoneyForm_Load;
        }

        private void MoneyForm_Load(object sender, EventArgs e)
        {
            
            ClientSize = new Size(1500, 800);
            this.BackColor = Color.Beige;
            get_Combo();
            get_Date();
            get_button();
        }

        public void get_Combo()
        {
            comm = new Commons();
            ComboBox combo = new ComboBox();
            comboboxSet cb1 = new comboboxSet(this, "period", 120, 35, 650, 40);
            combo = ct.combobox(cb1);
            combo.Font = new Font("Verdana", 10.5f, FontStyle.Italic);
            combo.Text = "분기선택";
            combo.Items.Add("1분기");
            combo.Items.Add("2분기");
            combo.Items.Add("3분기");
            combo.Items.Add("4분기");

            Controls.Add(combo);
        }
        private void get_Date()
        {
            ArrayList list = new ArrayList();
            list.Add(new DateSet(this, "first", 150, 50, 270, 40));
            list.Add(new DateSet(this, "second", 150, 50, 450, 40));
            for (int i = 0; i < list.Count; i++)
            {
                ct.datepic((DateSet)list[i]);
            }
            list.Add(new lbSet(this, "lb1", " ~ ", 30, 15, 420, 40, 13));
            Label label1 = ct.lable((lbSet)list[2]);
            label1.BackColor = Color.Beige;
            label1.Font = new Font(FontFamily.GenericSansSerif, 13.0F, FontStyle.Bold);
            Controls.Add(label1);
        }
        private void get_button()
        {
            comm = new Commons();
            Button btn = new Button();
            btnSet bs1 = new btnSet(this, "ok", "검색", 50, 22, 600, 40, ok_Click);
            btn = ct.btn(bs1);
            Controls.Add(btn);
        }

        private void ok_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
