using System;
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
    public partial class FORM_03 : Form
    {
        int sX = 1500, sY = 900;
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;

        public FORM_03()
        {
            InitializeComponent();
            Load += FORM_03_Load;
        }

        private void FORM_03_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(sX, sY);
            _Create ct = new _Create();
            Point_Print();


            pnSet pn1 = new pnSet(this, 500, 750, 0, 0);
            Panel 패널1 = ct.panel(pn1);
            패널1.BackColor = Color.LightBlue;
            Controls.Add(패널1);   //패널 화면 출력
          

            pnSet pn2 = new pnSet(this, 400, 350, 570, 200);
            Panel 패널2 = ct.panel(pn2);
            패널2.BackColor = Color.LightGray;
            Controls.Add(패널2);   //패널 화면 출력

            pnSet pn3 = new pnSet(this, 400, 350, 1040, 200);
            Panel 패널3 = ct.panel(pn3);
            패널3.BackColor = Color.LightGray;
            Controls.Add(패널3);   //패널 화면 출력

            pnSet pn4 = new pnSet(this, 1500, 150, 0, 800);
            Panel 패널4 = ct.panel(pn4);
            패널4.BackColor = Color.LightGray;
            Controls.Add(패널4);   
        }

        ///////////////////////// 좌표 체크시 추가 /////////////////////////////

        private void Point_Print()
        {

            MouseMove += new MouseEventHandler(this.Current_FORM_MouseMove);
            statusStrip = new StatusStrip();
            StripLb = new ToolStripStatusLabel();
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { StripLb });
            statusStrip.Location = new Point(0, sY);
            statusStrip.Name = "statusStrip1";
            statusStrip.Size = new Size(sX, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // toolStripStatusLabel1
            StripLb.Name = "StripLb1";
            StripLb.Size = new Size(121, 17);
            StripLb.Text = "StripLb1";
            Controls.Add(statusStrip);
        }
        private void Current_FORM_MouseMove(object sender, MouseEventArgs e)
        {
            StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }
        ///////////////////////////////////////////////////////////////////////
    }
}
