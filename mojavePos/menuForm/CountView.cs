
using mojavePos.Modal;
using mojavePos.Modules;
using Newtonsoft.Json.Linq;
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

    public partial class CountView : Form
    {
        _Create ct = new _Create();
        Panel panel2;
        private Panel panel;
        private ListView lv;
        private WebAPI api;
        private Hashtable ht;
        private string _bNo;
        private string _tNo;
        private ArrayList list;
        private string _mNo;

        public CountView()
        {
            InitializeComponent();

        }
        public CountView(string tNo, ArrayList list)
        {
            Load += CountView_Load;
            this._tNo = tNo;
            this.list = list;
        }

        private void CountView_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            listView();
            menu_view();
            MessageBox.Show(_tNo);
            ArrayList arrayList = api.ListView(lv, list);
            if (list != null)
            {
                arrayList = api.ListView(lv, list);
                for (int i = 0; i < arrayList.Count; i++)
                {
                    Controls.Add(lv);
                }
            }
        }

        public void listView()
        {
            ArrayList arr = new ArrayList();
            arr.Add(new pnSet(this, 580, 760, 10, 10));
            arr.Add(new lvSet(this, "", 570, 300, 5, 5, list_Click));
            arr.Add(new btnSet(this, "btn1", "+", 130, 70, 12, 310, btn_Click));
            arr.Add(new btnSet(this, "btn2", "현금결제", 230, 100, 320, 520, btn_Click));
            arr.Add(new btnSet(this, "btn3", "주문", 230, 100, 320, 400, btn_Click));
            arr.Add(new btnSet(this, "btn4", "카드결제", 230, 100, 320, 640, btn_Click));
            arr.Add(new btnSet(this, "btn5", "-", 130, 70, 152, 310, btn_Click));
            arr.Add(new btnSet(this, "btn6", "선택 취소", 130, 70, 292, 310, btn_Click));
            arr.Add(new btnSet(this, "btn7", "전체 취소", 130, 70, 432, 310, btn_Click));

            for (int i = 0; i < arr.Count; i++)
            {
                if (typeof(pnSet) == arr[i].GetType())
                {
                    panel = ct.panel((pnSet)arr[i]);
                    panel.BackColor = Color.Gainsboro;
                    Controls.Add(panel);
                }
                else if (typeof(lvSet) == arr[i].GetType())
                {
                    lv = ct.listview((lvSet)arr[i]);
                    lv.BackColor = Color.WhiteSmoke;
                    panel.Controls.Add(lv);
                    lv.Columns.Add("No", 30, HorizontalAlignment.Center);
                    lv.Columns.Add("메뉴명", 250, HorizontalAlignment.Center);
                    lv.Columns.Add("단가", 100, HorizontalAlignment.Center);
                    lv.Columns.Add("수량", 85, HorizontalAlignment.Center);
                    lv.Columns.Add("금액", 100, HorizontalAlignment.Center);
                    lv.Font = new Font("굴림",15, FontStyle.Bold);
                }
                else if (typeof(btnSet) == arr[i].GetType())
                {
                    Button button = ct.btn((btnSet)arr[i]);
                    panel.Controls.Add(button);
                }
            }
        }

        private void list_Click(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            lv.FullRowSelect = true;
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;
            
            for (int i = 0; i < itemGroup.Count; i++)
            {
                ListViewItem item = itemGroup[i];
                _mNo = item.SubItems[0].Text;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            api = new WebAPI();
            ht = new Hashtable();
            switch (btn.Name)
            {
                case "btn1":
                    for (int j = 0; j < Orderlist.Count; j++)
                    {
                        string[] row = (string[])Orderlist[j];
                        if (_mNo == row[0])
                        {
                            int cnt = Convert.ToInt32(row[3]);
                            //MessageBox.Show(cnt.ToString());
                            cnt++;
                            //MessageBox.Show(cnt.ToString());
                            row[3] = cnt.ToString();
                            Orderlist[j] = row;
                            ListCommon();
                            break;
                        }
                    }
                    break;
                case "btn2":
                    Cash cash = new Cash(_tNo);
                    cash.StartPosition = FormStartPosition.CenterParent;
                    cash.Show();
                    break;

                case "btn3":
                    api = new WebAPI();
                    ht = new Hashtable();
                    //for(int i = 0; i<list.Count; i++)
                    //{
                    //    ht.Add("spName", "sp_Order_Insert");
                    //    JArray ja = (JArray)list[i];
                    //    string[] arr = new string[ja.Count];
                    //    ht.Add("mNo", arr[0]);
                    //    ht.Add("tNo", _tNo);
                    //    if(!api.Post("http://localhost:5000/sp_insert", ht))
                    //    {
                    //        MessageBox.Show("주문오류");
                    //        break;
                    //    }
                    //}
                    MessageBox.Show(_mNo);
                    ht.Add("spName", "sp_Order_Insert");    
                    ht.Add("mNo", _tNo);
                    ht.Add("tNo", _tNo);
                    for (int j = 0; j < Orderlist.Count; j++)
                    {
                        string[] arr = (string[])Orderlist[j];
                    }
                    
                    foreach(DictionaryEntry arry in ht)
                    {
                        string ab = (string)arry.Value;
                        MessageBox.Show(ab);
                    }
                    if (!api.Post("http://localhost:5000/sp_insert", ht))
                    {
                        MessageBox.Show("주문오류");
                        break;
                    }

                    this.Visible = false;
                    break;

                case "btn4":
                    MessageBox.Show("서비스준비중입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case "btn5":
                    for (int j = 0; j < Orderlist.Count; j++)
                    {
                        string[] row = (string[])Orderlist[j];
                        if (_mNo == row[0])
                        {
                            int cnt = Convert.ToInt32(row[3]);
                            if (cnt > 1)
                            {
                                cnt--;
                            }
                            else if( cnt < 0)
                            {
                                cnt = 1;
                            }
                            row[3] = cnt.ToString();
                            Orderlist[j] = row;
                            ListCommon();
                            break;
                        }
                    }
                    break;
                case "btn6":
                    for (int i = 0; i < list.Count; i++)
                    {
                        JArray ja = (JArray)list[i];
                        string[] arr = new string[ja.Count];
                        //MessageBox.Show(ja.Count.ToString());
                        if (_mNo == arr[0])
                        {
                            lv.Items.Remove(lv.SelectedItems[0]);
                        }  
                    }
                    break;
                case "btn7":
                    lv.Items.Clear();
                    break;

            }
        }

        /// <summary>
        /// 메뉴 카테고리 뷰 화면
        /// </summary>
        private void menu_view()
        {
            pnSet pn1 = new pnSet(this, 100, 760, 600, 10);
            Panel panel = ct.panel(pn1);
            panel.BackColor = Color.Gainsboro;
            Controls.Add(panel);
            pnSet pn2 = new pnSet(this, 570, 760, 700, 10);
            panel2 = ct.panel(pn2);
            panel2.BackColor = Color.Gainsboro;
            Controls.Add(panel2);

            api = new WebAPI();
            ht = new Hashtable();
            ht.Add("spName", "sp_MenuCategory_Select");
            ht.Add("param", "");
            ArrayList list = api.Select("http://localhost:5000/select", ht);
            if (list != null)
            {
                ArrayList arrayList = api.Button(this, list, Category_Click);
                for (int i = 0; i < arrayList.Count; i++)
                {
                    Button button = ct.btn((btnSet)arrayList[i]);

                    panel.Controls.Add(button);
                }
            }
        }

        /// <summary>
        /// 카테고리 클릭 버튼 이벤트
        /// </summary>
        private void Category_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            _bNo = btn.Name;
            //MessageBox.Show(_bNo);

            ht = new Hashtable();
            ht.Add("spName", "sp_Menu_Select");
            ht.Add("param", "_bNo:" + _bNo);
            panel2.Controls.Clear();
            list = api.Select("http://localhost:5000/select", ht);
            if (list != null)
            {
                ArrayList arrayList = api.Button2(panel2, list, Menu_Click);
                for (int i = 0; i < arrayList.Count; i++)
                {
                    Button button = ct.btn((btnSet)arrayList[i]);
                    panel2.Controls.Add(button);
                }
            }
        }

        /// <summary>
        ///  메뉴 클릭 버튼 이벤트
        /// </summary>
        private void Menu_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            _mNo = btn.Name;

            //MessageBox.Show(btn.Name);
            //Commons(btn.Name);
            // lv.Items.Clear();
            //MessageBox.Show(list.Count.ToString());

          
            for (int i = 0; i < list.Count; i++)
            {
                JArray ja = (JArray)list[i];
                string[] arr = new string[ja.Count];
                //MessageBox.Show(ja.Count.ToString());
                for (int j = 0; j < ja.Count; j++)
                {
                    arr[j] = ja[j].ToString();
                }
                if (_mNo == arr[0])
                {
                    Orderlist.Add(arr);
                    break;
                }
                //if (_mNo == arr[0])
                //{
                //    if (isFirstClick)
                //    {
                //        isFirstClick = false;
                //        Orderlist.Add(arr);
                //    }
                //    else
                //    {
                //        isSecondClick = true;
                //    }
                //}
                //if (isSecondClick == true)
                //{
                //   
                //    break;
                //}
            }
            ListCommon();
        }

        ArrayList Orderlist = new ArrayList();

        private void ListCommon()
        {
            lv.Items.Clear();
            for (int i = 0; i < Orderlist.Count; i++)
            {
                string[] row = (string[]) Orderlist[i];
                lv.Items.Add(new ListViewItem(row));
            }
        }
    }
}
