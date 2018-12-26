using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    class Module
    {
        public bool selectListView(string url, ListView listview)
        {

            try
            {
                WebClient wc = new WebClient();
                Stream myStream = wc.OpenRead(url);
                StreamReader sr = new StreamReader(myStream);
                string result = sr.ReadToEnd();
                ArrayList list = JsonConvert.DeserializeObject<ArrayList>(result);
                listview.Items.Clear();
                for (int i = 0; i < list.Count; i++)
                {

                    JArray ja = (JArray)list[i];
                    string[] arr = new string[2];
                    for (int j = 0; j < ja.Count; j++)
                    {
                        arr[j] = ja[j].ToString();
                    }
                    listview.Items.Add(new ListViewItem(arr));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool post(string url, Hashtable ht)
        {
            try
            {
                WebClient wb = new WebClient();
                NameValueCollection param = new NameValueCollection();

                foreach (DictionaryEntry data in ht)
                {
                    param.Add(data.Key.ToString(), data.Value.ToString());
                }
                byte[] result = wb.UploadValues(url, "POST", param);
                string resultStr = Encoding.UTF8.GetString(result);
                if ("1" == resultStr)
                {
                    MessageBox.Show("성공");
                }
                else
                {
                    MessageBox.Show("실패");
                }
                MessageBox.Show(resultStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string getIdPass(string url)
        {
            try
            {
                WebClient wc = new WebClient();
                Stream myStream = wc.OpenRead(url);
                StreamReader sr = new StreamReader(myStream);
                string result = sr.ReadToEnd();
                return result;
            }
            catch
            {
                return "";
            }
        }
    }
}
