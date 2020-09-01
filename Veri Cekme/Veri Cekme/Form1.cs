using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;

namespace Veri_Cekme
{
    public partial class Form1 : Form
    {
        public String html;
        public Uri url;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VeriAl("https://altin.in/", "//*[@id='icerik']/div[1]/div[2]/div[20]/ul/li[2]", listBox1);
            this.webBrowser1.Navigate("https://altin.in/");
        }
        public void VeriAl(String Url, String Xpath, ListBox CikanSonuc)
        {
            try
            {
                url = new Uri(Url);
            }
            catch (UriFormatException)
            {
                if( MessageBox.Show("Hatalı Url","Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }
            }
            catch(ArgumentNullException)
            {
                if(MessageBox.Show("Hatalı Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }

            }
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            try
            {
                html = client.DownloadString(url);

            }
            catch(WebException)
            {
                if (MessageBox.Show("Hatalı Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }
            }
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            try
            {
                CikanSonuc.Items.Add(doc.DocumentNode.SelectSingleNode(Xpath).InnerText);

            }
            catch (NullReferenceException)
            {
                if (MessageBox.Show("Hatalı XPath", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }

            }
        }
    }
}
