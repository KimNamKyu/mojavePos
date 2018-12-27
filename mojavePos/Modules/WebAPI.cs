using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mojavePos.Modules
{
    class WebAPI
    {
        /// <summary>
        /// Select API 작성
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public ArrayList Select(string url, Hashtable ht)
        {
            try
            {
                WebClient wc = new WebClient();
                NameValueCollection param = new NameValueCollection();  // Key : Value 형식

                foreach (DictionaryEntry data in ht)
                {
                    //MessageBox.Show(string.Format("{0},{1}", data.Key.ToString(), data.Value.ToString()));
                    param.Add(data.Key.ToString(), data.Value.ToString());
                }
                
                //byte로 반환
                byte[] results = wc.UploadValues(url, "POST", param);
                string resultStr = Encoding.UTF8.GetString(results);
                //MessageBox.Show(resultStr);
                
                ArrayList list = JsonConvert.DeserializeObject<ArrayList>(resultStr);
                
                //MessageBox.Show("성공");
                return list;
            }
            catch
            {
                //MessageBox.Show("실패");
                return null;
            }
        }

        public ArrayList ListView(ListView listView, ArrayList list)
        {
            ArrayList arrayList = new ArrayList();
            try
            {
                listView.Items.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    JArray ja = (JArray)list[i];
                    string[] arr = new string[ja.Count];
                    for (int j = 0; j < ja.Count; j++)
                    {
                        //MessageBox.Show(list.Count.ToString());
                        //MessageBox.Show(ja[j].ToString());
                        arr[j] = ja[j].ToString();
                    }
                    listView.Items.Add(new ListViewItem(arr));
                }
                //MessageBox.Show("성공");
                return arrayList;
            }
            catch
            {
                //MessageBox.Show("실패");
                return null;
            }            
        }

        public ArrayList Button(Form form, ArrayList list, EventHandler eh_btn)
        {
            ArrayList arrayList = new ArrayList();
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    JArray ja = (JArray)list[i];
                    string[] arr = new string[ja.Count];
                    for (int j = 0; j < ja.Count; j++)
                    {
                        arr[j] = ja[j].ToString();
                    }
                    arrayList.Add(new btnSet(form, arr[0], arr[1], 100, 100, 0, (100 * i), eh_btn));
                }                
                return arrayList;
            }
            catch
            {
                return null;
            }            
        }

        public ArrayList Button2(Control control, ArrayList list, EventHandler eh_btn)
        {
            ArrayList arrayList = new ArrayList();
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    JArray ja = (JArray)list[i];
                    string[] arr = new string[ja.Count];
                    
                    for (int j = 0; j < ja.Count; j++)
                    {
                        arr[j] = ja[j].ToString();
                    }
                    arrayList.Add(new btnSet(control, arr[0], arr[1], 200, 100, 200 * (i % 3), 100 * (i / 3), eh_btn));
                    string Price = arr[2];
                    string Count = arr[3];
                   // MessageBox.Show(Price);
                    //MessageBox.Show(Count);
                }
                return arrayList;
            }
            catch
            {
                return null;
            }
        }

        public ArrayList Button3(Control control, ArrayList list, EventHandler eh_btn)
        {
            ArrayList arrayList = new ArrayList();
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    JArray ja = (JArray)list[i];
                    string[] arr = new string[ja.Count];
                    for (int j = 0; j < ja.Count; j++)
                    {
                        arr[j] = ja[j].ToString();
                    }
                    arrayList.Add(new btnSet(control, arr[1], arr[2], Convert.ToInt32(arr[3]), Convert.ToInt32(arr[4]), Convert.ToInt32(arr[5]), Convert.ToInt32(arr[6]), eh_btn));
                }
                return arrayList;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///  NonQuery
        /// </summary>
        /// <returns></returns>
        public bool Post(string url, Hashtable ht)
        {
            //MessageBox.Show(url);
            try
            {
                WebClient wc = new WebClient();
                NameValueCollection param = new NameValueCollection();  // Key : Value 형식

                foreach (DictionaryEntry data in ht)
                {
                    MessageBox.Show(string.Format("{0},{1}", data.Key.ToString(), data.Value.ToString()));
                    param.Add(data.Key.ToString(), data.Value.ToString());
                }

                //byte로 반환
                byte[] result = wc.UploadValues(url, "POST", param);
                string resultStr = Encoding.UTF8.GetString(result);
                //MessageBox.Show(resultStr);
                if ("1" == resultStr)
                {
                    MessageBox.Show("성공");
                }
                else
                {
                    MessageBox.Show("실패");
                }

                return true;
            }
            catch
            {
                MessageBox.Show("실패");
                return false;
            }
        }
    }
}
