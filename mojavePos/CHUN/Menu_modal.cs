﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public Menu_modal()
        {
            InitializeComponent();
            Load += Menu_modal_Load;
        }

        private void Menu_modal_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(300, 50);
            pnSet pn = new pnSet(this, 300, 50, 0, 0);
            Panel panel = ct.panel(pn);
            Controls.Add(panel);

            ArrayList arr = new ArrayList();

            arr.Add(new tbSet(this, "tb1", 200, 50, 0, 0));
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
                    textbox.ReadOnly = true;
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
                    
                    break;
                case "btn2":
                    this.Close();
                    break;
            }
        }
        
    }
}
