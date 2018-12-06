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
    public partial class InsertForm : Form
    {
        Commons comm;
        _Create ct = new _Create();
        public InsertForm()
        {
            InitializeComponent();
            Load += InsertForm_Load;
        }
        //이름(텍스트) 생년월일(date) 전화번호(텍스트박스) 등급(콤보박스) 주문금액(텍스틉ㄱ스)
        private void InsertForm_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(400, 650);
            get_label();
            get_text();
        }
        public void get_label()
        {
            ArrayList lb_list = new ArrayList();
            lb_list.Add(new lbSet(this, "lbname", "이름", 100, 30, 50, 40, 14));
            lb_list.Add(new lbSet(this, "lbdate", "생년월일", 100, 30, 50, 150, 14));
            lb_list.Add(new lbSet(this, "lbhone", "전화번호", 100, 30, 50, 270, 14));
            lb_list.Add(new lbSet(this, "lbrate", "등급", 100, 30, 50, 390, 14));
            lb_list.Add(new lbSet(this, "lbtotal", "주문금액", 100, 30, 50, 510, 14));

            for (int i = 0; i < lb_list.Count; i++)
            {
                Label lb = ct.lable((lbSet)lb_list[i]);
                lb.Font = new Font(FontFamily.GenericSansSerif, 14.0F, FontStyle.Bold);
                Controls.Add(lb);
            }
        }
        public void get_text()
        {
            ArrayList rtb_list = new ArrayList();
            rtb_list.Add(new Richtb(this, "tbname", 300, 35, 50, 70));
            rtb_list.Add(new Richtb(this, "tbyear", 100, 35, 50, 180));
            rtb_list.Add(new Richtb(this, "tbday", 100, 35,250, 180));
            rtb_list.Add(new Richtb(this, "tbphone", 200, 35, 150, 300));
            rtb_list.Add(new Richtb(this, "tbtotal", 300, 35, 50, 540));

            for (int i = 0; i < rtb_list.Count; i++)
            {
                RichTextBox rtb = ct.richbox((Richtb)rtb_list[i]);
                rtb.SelectionFont = new Font("Verdana", 13, FontStyle.Bold);
                Controls.Add(rtb);
            }
        }
    }
}
