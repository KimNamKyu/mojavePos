using System;
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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            Load += MenuForm_Load;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(1500, 800);
            this.BackColor = Color.BurlyWood;

            _Create ct = new _Create();

            lbSet lb1 = new lbSet(this, "lb1", "Category", 200, 35, 350, 80, 25);
            Label 카테고리 = ct.lable(lb1);
            카테고리.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(카테고리);

            btnSet btn_1 = new btnSet(this, "btn_1", "//사진으로 대체", 30, 30, 460, 125, btn_Click);
            Button 카테고리추가버튼 = ct.btn(btn_1);
            Controls.Add(카테고리추가버튼);

            pictureBoxSet picturebox_1 = new pictureBoxSet(this, 40, 40, 410, 120, " ");
            PictureBox 카테고리픽쳐 = ct.picture(picturebox_1);
            카테고리픽쳐.BackColor = Color.Green;
            Controls.Add(카테고리픽쳐);

            lbSet lb2 = new lbSet(this, "lb2", "Menu", 200, 35, 1000, 80, 25);
            Label 메뉴 = ct.lable(lb2);
            카테고리.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(메뉴);

            btnSet btn_2 = new btnSet(this, "btn_2", "//사진으로 대체", 30, 30, 1060, 125, btn2_Click);
            Button 메뉴추가버튼 = ct.btn(btn_2);
            Controls.Add(메뉴추가버튼);

            pictureBoxSet picturebox_2 = new pictureBoxSet(this, 40, 40, 1010, 120, " ");
            PictureBox 메뉴픽쳐 = ct.picture(picturebox_2);
            메뉴픽쳐.BackColor = Color.Green;
            Controls.Add(메뉴픽쳐);

        }
        private void btn_Click(object sender, EventArgs e)
        {

        }
        private void btn2_Click(object sender, EventArgs e)
        {

        }
    }
}
