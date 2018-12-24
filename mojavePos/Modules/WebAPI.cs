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
        /// 
        public bool Post2(string url, Hashtable ht)
        {
            WebClient client = new WebClient(); // 웹 접속 객체 생성
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)"); // 웹 호출 시 보낸쪽 정보 설정
            client.Encoding = Encoding.UTF8; // UTF-8 설정 하여 한글 처리하기



            
            NameValueCollection param = new NameValueCollection();
            byte[] result = client.UploadValues(url, "POST", param);
            string strResult = Encoding.UTF8.GetString(result);
            ArrayList strJ = JsonConvert.DeserializeObject<ArrayList>(strResult);
            for (int i = 0; i < strJ.Count; i++)
            {

                JObject jo = (JObject)strJ[i];
                //listView.Items.Add((string)jp.Value);
                string[] arr = new string[jo.Count];
                foreach (JProperty jp in jo.Properties())
                {//jp.Name,jp.Value

                    //Console.WriteLine("{0} : {1}", jp.Name, jp.Value); 
                    if (jp.Name == "m_bNo")
                    {
                        arr[0] = (string)jp.Value;
                    }
                    else if (jp.Name == "c_Menu")
                    {
                        arr[1] = (string)jp.Value;
                    }
                    else if (jp.Name == "sum(cm.c_Count)")
                    {
                        arr[2] = (string)jp.Value;
                    }
                   
                }
            }
            return true;
        }
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
       


        public ArrayList Select(string url, Hashtable ht)
        {
            try
            {
                WebClient wc = new WebClient();
                NameValueCollection param = new NameValueCollection();

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
                MessageBox.Show("성공");
                return arrayList;
            }
            catch
            {
                MessageBox.Show("실패");
                return null;
            }
        }
    }
}
