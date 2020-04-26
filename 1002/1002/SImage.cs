using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _1002
{
    class SImage
    {
        #region 프로퍼티
        public string Title { get; private set; }
        public string Link { get; private set; }
        public string Thumbnail { get; private set; }
        public int SizeHeight { get; private set; }
        public int SizeWidth { get; private set; }
        #endregion

        public SImage(string title, string link, string thumbnail, int sizeheight, int sizewidth)
        {
            Title = title;
            Link = link;
            Thumbnail = thumbnail;
            SizeHeight = sizeheight;
            SizeWidth = sizewidth;
        }


        #region 파서 (XML문서 ->객체화)
        static public SImage MakeImage(XmlNode xn)
        {
            string title = string.Empty; 
            string link = string.Empty;
            string thumbnail = string.Empty;
            int sizeheight = 0;
            int sizewidth = 0;

            XmlNode title_node = xn.SelectSingleNode("title"); 
            title = ConvertString(title_node.InnerText);

            XmlNode link_node = xn.SelectSingleNode("link");
            link = ConvertString(link_node.InnerText);

            XmlNode thumbnail_node = xn.SelectSingleNode("thumbnail");
            thumbnail = ConvertString(thumbnail_node.InnerText);

            XmlNode sizeheight_node = xn.SelectSingleNode("sizeheight");
            sizeheight = int.Parse(sizeheight_node.InnerText);

            XmlNode sizewidth_node = xn.SelectSingleNode("sizewidth");
            sizewidth = int.Parse(sizewidth_node.InnerText);
            return new SImage(title, link, thumbnail, sizeheight, sizewidth);
        }

        private static string ConvertString(string str)
        {
            return str;
        }
        #endregion
    }
}
