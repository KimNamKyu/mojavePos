﻿using Newtonsoft.Json;
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
        public bool SelectListView(string url, ListView listView)
        {
            try
            {
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url);
                //출력
                StreamReader sr = new StreamReader(stream);
                string result = sr.ReadToEnd(); 
                ArrayList list = JsonConvert.DeserializeObject<ArrayList>(result);  
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
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///  NonQuery
        /// </summary>
        /// <returns></returns>
        public bool Post(string url, Hashtable ht)
        {
            MessageBox.Show(url);
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
                MessageBox.Show(resultStr);
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
                return false;
            }
        }
    }
}
