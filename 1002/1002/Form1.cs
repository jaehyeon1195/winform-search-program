using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace _1002
{
    public partial class Form1 : Form
    {
        SImageSearcher s = new SImageSearcher();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            s.SearchImage(textBox1.Text);
            textBox2.Text = s.XmlString;
            TitlePrint();
            
        }

        private void TitlePrint()
        {
            listBox1.Items.Clear();
            foreach (SImage s in s.imagelist)
            {
                listBox1.Items.Add(s.Title);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx=listBox1.SelectedIndex;
            string title = listBox1.SelectedItem.ToString();

            //타이틀바에 정보출력
            string temp = string.Format("{0} {1}", idx, title);
            this.Text = temp;
            string filepath=s.imagelist[idx].Link;
            //이미지를 출력
            byte[] data = new System.Net.WebClient().DownloadData(filepath);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(data);
            Image img = Image.FromStream(ms);

            Graphics gp = listBox2.CreateGraphics();
            gp.DrawImage(img, 0, 0);
        }
    }
}
