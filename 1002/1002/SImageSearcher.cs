using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _1002
{
    class SImageSearcher
    {
        public List<SImage> imagelist = new List<SImage>();
        public String ImageName { get; private set; }
        public String XmlString { get; private set; }
        XmlDocument doc = null;
        public void SearchImage(string str)
        {
            imagelist.Clear();

            XmlString = Find(str);
            doc =new XmlDocument();
            doc.LoadXml(XmlString);
            string name = string.Format("{0}.xml", str);
            //doc.Save(name);
            ////=====================================================
            XmlNode node = doc.SelectSingleNode("rss");
            XmlNode n = node.SelectSingleNode("channel");

            SImage simage = null;
            foreach (XmlNode el in n.SelectNodes("item"))
            {
                simage = SImage.MakeImage(el);
                imagelist.Add(simage);
            }

        }



        public string Find(string str)
        {
            string query = str; // 검색할 문자열
                                //string url = "https://openapi.naver.com/v1/search/image?query=" + query; // 결과가 JSON 포맷
            string url = "https://openapi.naver.com/v1/search/image.xml?query=" + query;  // 결과가 XML 포맷

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", "RCMD8haT8sqtiEyI8oWF"); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", "AEcxThW8zj");       // 클라이언트 시크릿
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string status = response.StatusCode.ToString();

            if (status == "OK")
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string text = reader.ReadToEnd();
                return text;
            }
            else
            {
                return string.Format("Error 발생={0}" + status);
            }
        }




    }

}
