using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mojavePos
{
    class _Create
    {
        //버튼
        public Button btn(btnSet bS)
        {
            Button btn = new Button();
            btn.DialogResult = DialogResult.OK;
            btn.Name = btn.Name;
            btn.Text = btn.Text;
            btn.Size = new Size(bS.SX,bS.SY);
            btn.Location = new Point(bS.PX,bS.PY);
            btn.Cursor = Cursors.Hand;
            btn.Click += bS.eh_btn;
            return btn;
        }

        //라벨
        public Label lable(lbSet lb)
        {
            Label label = new Label();
            label.Name = lb.Name;
            label.Text = lb.Text;
            label.Font = new Font("굴림",lb.FS);
            label.Size = new Size(lb.SX, lb.SY);
            label.Location = new Point(lb.PX, lb.PY);
            label.BackColor = Color.Transparent;
            return label;
        }

        //패널
        public Panel panel(pnSet pn)
        {
            Panel panel = new Panel();
            panel.Size = new Size(pn.SX,pn.SY);
            panel.Location = new Point(pn.PX,pn.PY);
            return panel;
        }
        
       
    }
}
