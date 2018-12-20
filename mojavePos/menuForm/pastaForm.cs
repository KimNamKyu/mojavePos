using mojavePos.Modules;
using MySql.Data.MySqlClient;
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

namespace mojavePos
{
    public partial class pastaForm : Form
    {
        _Create ct = new _Create();
        private ListView lv;
        private CountView cv;
        private int tNo;
        private int mNo;

        public pastaForm()
        {
            InitializeComponent();
            Load += PastForm_Load;
        }
        public pastaForm(ListView lv)
        {
            this.lv = lv;
        }
        
        private void PastForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(600, 500);
            //BackColor = Color.Blue;
            
            ArrayList arr = new ArrayList();
            arr.Add(new btnSet(this, "btn1", "봉골레파스타", 200, 100, 0, 0,btn_Click));
            arr.Add(new btnSet(this, "btn2", "대파알리오올리오", 200, 100, 200, 0, btn_Click));
            arr.Add(new btnSet(this, "btn3", "단호박치즈크림파스타", 200, 100, 400, 0, btn_Click));
            arr.Add(new btnSet(this, "btn4", "먹물빠네 까르보나라", 200, 100, 0, 100, btn_Click));
            arr.Add(new btnSet(this, "btn5", "트럼프 크림리조또", 200, 100, 200, 100, btn_Click));
            arr.Add(new btnSet(this, "btn6", "클래식 볼로노제", 200, 100, 400, 100, btn_Click));
            arr.Add(new btnSet(this, "btn7", "시푸드 토마토파스타", 200, 100, 0, 200, btn_Click));
            arr.Add(new btnSet(this, "btn8", "시푸드 크림파스타", 200, 100, 200, 200, btn_Click));
            arr.Add(new btnSet(this, "btn9", "점보 랍스타파스타", 200, 100, 400, 200, btn_Click));
            for (int i = 0; i < arr.Count; i++)
            {
                ct.btn((btnSet)arr[i]);
               
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Commons(btn.Name);
        }

        public void Commons(string type)
        {
            WebAPI api = new WebAPI();
            Hashtable ht = new Hashtable();
            tNo = 2;
             
            switch (type)
            {
                case "btn1":
                    ht.Add("tNo", tNo);
                    ArrayList list = api.Select("http://localhost:5000/select",ht);
                    if(list != null)
                    {
                        api.ListView(lv, list);
                    }
                    break;
                case "btn2":
                    break;
                case "btn3":
                    break;
                case "btn4":
                    break;
                case "btn5":
                    ht.Add("mNo", mNo);
                    ht.Add("tNo", tNo);
                    api.Post("http://localhost:5000/insert", ht);
                    break;
                case "btn6":
                    break;
                case "btn7":
                    break;
                case "btn8":
                    break;
                case "btn9":
                    break;
            }
        }  
    }
}
