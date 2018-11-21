﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mojavePos
{
    class pnSet
    {
        Form form;
        int sX, sY, pX, pY;

        public pnSet(Form form, int sX, int sY, int pX, int pY)
        {
            this.form = form;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
        }
        public Form Form
        {
            get { return form; }
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
