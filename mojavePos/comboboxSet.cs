using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mojavePos
{
    class comboboxSet
    {
        Form form;
        string name;
        int sX, sY, pX, pY;
        public MouseEventHandler eh_cbox;

        public comboboxSet(Form form, string name, int sX, int sY, int pX, int pY, MouseEventHandler eh_cbox)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_cbox = eh_cbox;
        }
        public Form Form
        {
            get { return form; }
        }
        public string Name
        {
            get { return name; }
        }
        public int SX
        {
            get { return sX; }
        }
        public int SY
        {
            get { return sY; }
        }
        public int PX
        {
            get { return pX; }
        }
        public int PY
        {
            get { return pY; }
        }
    }
}
