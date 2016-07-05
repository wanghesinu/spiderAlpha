using HtmlAgilityPack;
using System;
using System.Data;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace spiderAlpha
{
    public partial class MainForm : Form
    {
        //初始化系统变量
        HtmlWeb web = new HtmlWeb();
        HtmlAgilityPack.HtmlDocument doc;
        HtmlAgilityPack.HtmlNodeCollection htmlnodec;
        HtmlAgilityPack.HtmlNode htmlnode;
        //初始化channel参数
        string showDate = DateTime.Now.ToString("yyyy-MM-dd");
        string showDate1 = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
        string showDate1day = DateTime.Now.AddDays(-1).ToString("dd");
        string begintime = "";
        string endtime = "";
        string goodsname = "";
        string goodscode = "";
        float goodsprice = 0;
        string error = "";


        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);

        private string strFilePath = Application.StartupPath + "\\EmailList.ini";//获取INI文件路径
        private string strSec = ""; //INI文件名

        public MainForm()
        {
            InitializeComponent();
        }
        //程序入口
        private void MainForm_Load(object sender, EventArgs e)
        {
            channel_set();
            channelInfo_set();
            progressBar.Value = 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = 19;

            //sendEmail();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            //progressBar.Value = 0;
            //getInfo();
            channelInfo_set();
            progressBar.Visible = true;
            Thread myThread = new Thread(getInfo);
            myThread.IsBackground = true;
            myThread.Start(); //线程开始 
            //Application.Exit();
        }

        //设置进度条
        public void SetProgressValue(string pname)
        {
            progressBar.Value = progressBar.Value + 1;
            getInfoButton.Text = pname;
            channelInfo_set();
        }

        private delegate void MyInvoke(string pname);

        //开始抓取节目信息
        private void getInfo()
        {
            MyInvoke mi = new MyInvoke(SetProgressValue);
            
            string sql = "select * from tv_provider ";
            DataSet ds = DBHelper.ExecuteDataSet(sql);
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                Provider p = new Provider(dr);
                this.BeginInvoke(mi, p.name);
                bool hasInfo = hasInfomation(p.id);
                //没有获取节目信息才往下走

                if (!hasInfo)
                {
                    switch (p.functionname)
                    {
                        case "getInfomation1":
                            try
                            {
                                getInfomation1(p.website, p.id, p.name + "11频道", "01");
                                getInfomation1(p.website, p.id, p.name + "12频道", "03");
                            }
                            catch (Exception exc)
                            {
                                error = error + "," + p.name + ":" + p.id;
                            }
                            break;
                        case "getInfomation2":
                            try
                            {
                                getInfomation2(p.website, p.id, p.name);
                            }
                            catch (Exception exc)
                            {
                                error = error + "," + p.name + ":" + p.id;
                            }
                            break;
                        case "getInfomation3":
                            try
                            {
                                getInfomation3(p.website, p.id, p.name);
                            }
                            catch (Exception exc)
                            {
                                error = error + "," + p.name + ":" + p.id;
                            }
                            break;
                        case "getInfomation4":
                            try
                            {
                                getInfomation4(p.website, p.id, p.name);
                            }
                            catch (Exception exc)
                            {
                                error = error + "," + p.name + ":" + p.id;
                            }
                            break;
                        case "getInfomation5":
                            try
                            {
                                getInfomation5(p.website, p.id, p.name);
                            }
                            catch (Exception exc)
                            {
                                error = error + "," + p.name + ":" + p.id;
                            }
                            break;
                        case "getInfomation6":
                            try { getInfomation6(p.website, p.id, p.name); }
                            catch (Exception exc)
                            {
                                error = error + "," + p.name + ":" + p.id;
                            }
                            break;
                        //到此为止
                        case "getInfomation7":
                            try { getInfomation7(p.website, p.id, p.name); }
                            catch (Exception exc) { error = error + "," + p.name + ":" + p.id; }
                            break;
                        case "getInfomation8":
                            try
                            {
                                getInfomation8(p.website, p.id, p.name);
                            }
                            catch (Exception exc)
                            {
                                error = error + "," + p.name + ":" + p.id;
                            }
                            break;
                        case "getInfomation9":
                            try
                            {
                                getInfomation9(p.website, p.id, p.name);
                            }
                            catch (Exception exc)
                            {
                                error = error + "," + p.name + ":" + p.id;
                            }
                            break;
                        case "getInfomation10":
                            try
                            {
                                getInfomation10(p.website, p.id, p.name);
                            }
                            catch (Exception exc)
                            {
                                error = error + "," + p.name + ":" + p.id;
                            }
                            break;
                        case "getInfomation11":
                            try
                            {
                                getInfomation11(p.website, p.id, p.name);
                            }
                            catch (Exception exc)
                            {
                                error = error + "," + p.name + ":" + p.id;
                            }
                            break;
                        case "getInfomation12":
                            try
                            {
                                getInfomation12(p.website, p.id, p.name);
                            }
                            catch (Exception exc)
                            {
                                error = error + "," + p.name + ":" + p.id;
                            }
                            break;
                        case "getInfomation13":
                            try
                            {
                                getInfomation13(p.website, p.id, p.name);
                            }
                            catch (Exception exc)
                            {
                                error = error + "," + p.name + ":" + p.id;
                            }
                            break;
                        case "getInfomation14":
                            try
                            {
                                getInfomation14(p.website, p.id, p.name);
                            }
                            catch (Exception exc)
                            {
                                error = error + "," + p.name + ":" + p.id;
                            }
                            break;
                        case "getInfomation15":
                            try
                            {
                                getInfomation15(p.website, p.id, p.name);
                            }
                            catch (Exception exc)
                            {
                                error = error + "," + p.name + ":" + p.id;
                            }
                            break;
                        case "getInfomation16":
                            try
                            {
                                getInfomation16(p.website, p.id, p.name);
                            }
                            catch (Exception exc)
                            {
                                error = error + "," + p.name + ":" + p.id;
                            }
                            break;
                        case "getInfomation17":
                            try
                            {
                                getInfomation17(p.website, p.id, p.name);
                            }
                            catch (Exception exc)
                            {
                                error = error + "," + p.name + ":" + p.id;
                            }
                            break;
                        case "getInfomation18":
                            try
                            {
                                getInfomation18(p.website, p.id, p.name);
                            }
                            catch (Exception exc)
                            {
                                error = error + "," + p.name + ":" + p.id;
                            }
                            break;
                        case "getInfomation19":
                            try
                            {
                                getInfomation19(p.website, p.id, p.name);
                            }
                            catch (Exception exc)
                            {
                                error = error + "," + p.name + ":" + p.id;
                            }
                            break;

                    }

                }

            }
            Application.Exit();
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error + "抓取错误");
            }
        }

        private void channel_set()
        {
            string sql = "select id,name from tv_provider";
            DataSet ds = DBHelper.ExecuteDataSet(sql);
            DataTable dt = ds.Tables[0];
            comboBox.DataSource = dt;
            comboBox.ValueMember = "id";
            comboBox.DisplayMember = "name";
        }

        private void getInfo_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            //Thread myThread = new Thread(getInfo);
            //myThread.IsBackground = true;
            //myThread.Start(); //线程开始 
            //channelInfo_set();
        }
        //填充节目信息表
        private void channelInfo_set()
        {
            string sql = "select ID,provider_name as 电视台,showdate as 日期,begintime as 开始时间,endtime as 结束时间,goodsname as 商品名称,goodscode as 商品编码,goodsprice as 商品价格,duration as 时长 from tv_channel order by id desc";
            DataSet ds = DBHelper.ExecuteDataSet(sql);
            channelDataView.DataSource = ds.Tables[0];
        }
        //判断今天是否已经获取数据
        public bool hasInfomation(int provider_id)
        {
            bool hasInfo = false;
            string sql = "select * from tv_channel where showdate = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and provider_id = " + provider_id;
            DataSet ds = DBHelper.ExecuteDataSet(sql);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                hasInfo = true;
            }
            return hasInfo;
        }
        //东方购物
        public void getInfomation1(string url, int provider_id, string provider_name, string msale_code)
        {
            int dayTypeM = DateTime.Now.Month;
            int dayType = DateTime.Now.Day;
            string strurl = url + "?dayType=" + dayType + "&dayTypeM=" + dayTypeM + "&msale_code=" + msale_code;
            doc = web.Load(strurl);
            htmlnodec = doc.DocumentNode.SelectNodes("//*[@id='containerContent']/div/div[2]/div/div[4]/div[3]/div/ul/li");
            //初始化变量        
            foreach (HtmlNode child in htmlnodec)
            {
                //核心模块分析HTML变量赋值
                string datetime = child.SelectSingleNode("div/div[1]/p[1]").InnerText;
                if (!datetime.Equals("&nbsp;"))
                {
                    string[] datearr = datetime.Split('-');
                    begintime = datearr[0];
                    endtime = datearr[1];
                }
                try
                {
                    goodsprice = float.Parse(child.SelectSingleNode("div/div[3]/p[@class='price']").InnerText.Replace("￥", "").Replace(",", ""));
                }
                catch (Exception e)
                {
                    goodsprice = 0;
                }
                goodsname = child.SelectSingleNode("div/div[2]/div[2]/p[1]").InnerText;
                goodscode = child.SelectSingleNode("div/div[2]/div[2]/p[1]/a").GetAttributeValue("href", "").Replace("http://www.ocj.com.cn/detail/", "").Replace("2015", "").Replace("2014", "");
                Channel channel = new Channel(showDate, begintime, endtime, goodsname, goodscode, goodsprice, provider_id, provider_name);
                int result = channel_add(channel);
            }

        }
        //河北三佳
        public void getInfomation2(string url, int provider_id, string provider_name)
        {
            doc = web.Load(url);
            string html = HttpUtility.UrlDecode(doc.DocumentNode.OuterHtml.ToString());
            doc.LoadHtml(html);
            htmlnode = doc.DocumentNode.SelectSingleNode("/html/body/script[1]");

            htmlnodec = htmlnode.SelectNodes("li");
            //初始化变量        
            foreach (HtmlNode child in htmlnodec)
            {
                //核心模块分析HTML变量赋值
                string datetime = child.SelectSingleNode("dd[@class='sj']").InnerText;
                string[] datearr = datetime.Split('～');
                goodsprice = float.Parse(child.SelectSingleNode("dd[@class='jg']").InnerText.Replace("￥", ""));
                begintime = datearr[0];
                endtime = datearr[1];
                goodsname = child.SelectSingleNode("dt/a").GetAttributeValue("title", "");
                goodscode = child.SelectSingleNode("dt/a").GetAttributeValue("href", "").Substring(10, 6);
                Channel channel = new Channel(showDate, begintime, endtime, goodsname, goodscode, goodsprice, provider_id, provider_name);
                int result = channel_add(channel);
            }
        }
        //天津三佳
        public void getInfomation3(string url, int provider_id, string provider_name)
        {
        }
        //中视购物
        public void getInfomation4(string url, int provider_id, string provider_name)
        {
        }
        //家有购物
        public void getInfomation5(string url, int provider_id, string provider_name)
        {
            url = url.Replace("$day", showDate1);
            string strJson = PostMoths(url, "");
            JObject obj = JObject.Parse(strJson);
            JToken record = obj["products"];
            foreach (JObject obj2 in record)
            {
                begintime = (string)obj2["playTime"];
                begintime = begintime.Substring(11, 5);
                endtime = (string)obj2["endTime"];
                endtime = endtime.Substring(11, 5);
                goodsname = (string)obj2["name"];
                goodscode = (string)obj2["id"];
                goodsprice = (float)obj2["salePrice"];
                Channel channel = new Channel(showDate1, begintime, endtime, goodsname, goodscode, goodsprice, provider_id, provider_name);
                int result = channel_add(channel);
            }
        }
        //环球购物
        public void getInfomation6(string url, int provider_id, string provider_name)
        {
            
            url = url.Replace("date", showDate1day);
            doc = web.Load(url);//*[@id="tv2013list"]/div[3]

            htmlnode = doc.DocumentNode.SelectSingleNode("/html/body/div[7]/div[2]/div[2]/div[3]/div[2]/table");
            htmlnodec = htmlnode.SelectNodes("tr");
            foreach (HtmlNode child in htmlnodec)
            {
                //核心模块分析HTML变量赋值
                string datetime = child.SelectSingleNode("td[@width='205']").InnerText;
                datetime = datetime.Substring(10, 13);
                string[] datearr = datetime.Split('-');
                begintime = datearr[0].Trim();
                endtime = datearr[1].Trim();
                string strPrice = child.SelectSingleNode("td[@class='tv2013texx']/span[@class='tv2013red']").InnerText;
                strPrice = strPrice.Replace("￥document.write(parseFloat(", "").Replace("));", "");
                goodsprice = float.Parse(strPrice);
                goodsname = child.SelectSingleNode("td[@class='tv2013texx']/a").InnerText;
                goodscode = child.SelectSingleNode("td[@class='tv2013texx']/a").GetAttributeValue("href", "").Substring(9, 7);
                Channel channel = new Channel(showDate1, begintime, endtime, goodsname, goodscode, goodsprice, provider_id, provider_name);
                int result = channel_add(channel);
            }
        }

        //优购物
        public void getInfomation7(string url, int provider_id, string provider_name)
        {
            doc = web.Load(url);
            htmlnodec = doc.DocumentNode.SelectNodes("//*[@id='seachTvList']/div");
            //初始化变量        
            foreach (HtmlNode child in htmlnodec)
            {
                string datetime = "";
                try
                {
                    datetime = child.SelectSingleNode("dl/dt/div[@class='timetv']").InnerText;
                }
                catch (Exception e)
                {
                    datetime = child.SelectSingleNode("dl/dt/div[@class='timetvzhi']").InnerText.Replace("正在直播", "");
                }
                string[] datearr = datetime.Split('～');
                begintime = datearr[0];
                endtime = datearr[1];
                goodsprice = float.Parse(child.SelectSingleNode("dl/dd[@id='goods-picmass']/div[1]/div[2]/div[2]").InnerText.Replace("￥", "").Replace(",", ""));
                goodsname = child.SelectSingleNode("dl/dd[@class='goods-tittle']/a").InnerText;
                goodscode = child.SelectSingleNode("dl/dd[@class='goods-tittle']/a").GetAttributeValue("href", "").Substring(29, 5);
                Channel channel = new Channel(showDate, begintime, endtime, goodsname, goodscode, goodsprice, provider_id, provider_name);
                int result = channel_add(channel);
            }
        }
        //家家购物
        public void getInfomation8(string url, int provider_id, string provider_name)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream ResStream = response.GetResponseStream();
            Encoding encoding = Encoding.GetEncoding("gbk");
            StreamReader streamReader = new StreamReader(ResStream, encoding);
            string strHtml = streamReader.ReadToEnd();
            strHtml = strHtml.Replace("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n<!DOCTYPE html>\r\n<html>\r\n<head>\r\n", "<!DOCTYPE html><html><head><meta http-equiv='content-type' content='text/html; charset=GBK'>").Replace("\r", "").Replace("\t", "").Replace("\n", "").Replace("\"", "'").Replace("javascript:goDetailView('", "").Replace("','Y');", "");
            doc = web.Load(url);
            doc.LoadHtml(strHtml);
            htmlnodec = doc.DocumentNode.SelectNodes("//div[@class='tv_zbb_ri']/div[2]/table/tr");
            //初始化变量        
            int i = 1;
            foreach (HtmlNode child in htmlnodec)
            {

                if (i == 1)
                {
                    i = 0;
                    continue;
                }
                string datetime = child.SelectSingleNode("td[1]").InnerText;
                string[] datearr = datetime.Split('~');
                begintime = datearr[0].Replace(" ", "");
                endtime = datearr[1].Replace(" ", "");
                goodsprice = float.Parse(child.SelectSingleNode("td[3]").InnerText.Replace("￥", "").Replace(",", ""));
                goodsname = child.SelectSingleNode("td[2]").InnerText;
                goodscode = child.SelectSingleNode("td[2]/a").GetAttributeValue("href", "");
                Channel channel = new Channel(showDate, begintime, endtime, goodsname, goodscode, goodsprice, provider_id, provider_name);
                int result = channel_add(channel);
            }
        }
        //快乐购
        public void getInfomation9(string url, int provider_id, string provider_name)
        {
            //tv5/schedule/20151123/tv2/2/2
            doc = web.Load(url);//*[@id="tv2013list"]/div[3]
            htmlnodec = doc.DocumentNode.SelectNodes("//*[@class='living_list']/ul/li");
            foreach (HtmlNode child in htmlnodec)
            {
                //核心模块分析HTML变量赋值
                string datetime = child.SelectSingleNode("div[1]").InnerText;
                //datetime = datetime.Substring(10, 13);
                string[] datearr = datetime.Split('~');
                begintime = datearr[0];
                endtime = datearr[1];
                goodsprice = float.Parse(child.SelectSingleNode("a/div[1]/div/p[2]/span[1]/span[1]").InnerText);
                goodsname = child.SelectSingleNode("a/div[1]/div/p[1]").InnerText.Replace("\n", "").Replace("\t", "").Replace("\r", "");
                goodscode = child.SelectSingleNode("a").GetAttributeValue("href", "").Replace("http://www.happigo.com/item-", "").Replace(".html", "");
                Channel channel = new Channel(showDate, begintime, endtime, goodsname, goodscode, goodsprice, provider_id, provider_name);
                int result = channel_add(channel);
            }

        }
        //宜家购物
        public void getInfomation10(string url, int provider_id, string provider_name)
        {
            doc = web.Load(url);//*[@id="tv2013list"]/div[3]
            htmlnodec = doc.DocumentNode.SelectNodes("//*[@id='UpdatePanel1']/dl");
            foreach (HtmlNode child in htmlnodec)
            {
                //核心模块分析HTML变量赋值
                string datetime = child.SelectSingleNode("dd/span[1]/font").InnerText;
                //datetime = datetime.Substring(10, 13);
                //string[] datearr = datetime.Split('-');
                begintime = datetime;
                endtime = begintime;
                goodsprice = float.Parse(child.SelectSingleNode("dd/span[2]").InnerText.Replace("￥", ""));
                goodsname = child.SelectSingleNode("dd/span[1]/a").InnerText;
                goodscode = child.SelectSingleNode("dd/span[1]/a").GetAttributeValue("href", "").Replace("../prod/p.aspx?skn=", "");
                Channel channel = new Channel(showDate, begintime, endtime, goodsname, goodscode, goodsprice, provider_id, provider_name);
                int result = channel_add(channel);
            }

        }
        //好易购
        public void getInfomation11(string url, int provider_id, string provider_name)
        {
            doc = web.Load(url);
            string strJson = PostMoths(url, "date=" + showDate);
            JObject obj = JObject.Parse(strJson);
            string strhtml = (string)obj["contents"];
            string sss = strhtml.Replace("\t", "").Replace("\n", "").Replace("\r", "").Replace("\"", "'").Replace("<!--", "").Replace("-->", "").Replace("<div class='clear'></div>", "");
            doc.LoadHtml(sss);
            htmlnodec = doc.DocumentNode.SelectNodes("ul/li");
            foreach (HtmlNode child in htmlnodec)
            {
                //核心模块分析HTML变量赋值
                string datetime = child.SelectSingleNode("p[2]").InnerText.Replace("直播时间：", "").Trim();
                string[] datearr = datetime.Split('~');
                begintime = datearr[0];
                endtime = datearr[1];
                goodsprice = float.Parse(child.SelectSingleNode("p[4]").InnerText.Replace("￥", ""));
                goodsname = child.SelectSingleNode("p[3]").InnerText;
                goodscode = child.SelectSingleNode("p[3]/a").GetAttributeValue("href", "").Replace("/product-", "").Replace(".html", "");
                Channel channel = new Channel(showDate, begintime, endtime, goodsname, goodscode, goodsprice, provider_id, provider_name);
                int result = channel_add(channel);
            }
        }
        //风尚购物
        public void getInfomation12(string url, int provider_id, string provider_name)
        {
            url = url + "?date=" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream ResStream = response.GetResponseStream();
            Encoding encoding = Encoding.GetEncoding("utf-8");
            StreamReader streamReader = new StreamReader(ResStream, encoding);
            string strJson = streamReader.ReadToEnd();
            JObject obj = JObject.Parse(strJson);
            JToken record = obj["data"];
            foreach (JObject obj2 in record)
            {
                string showDate2 = (string)obj2["SecheDuleDate"];
                begintime = (string)obj2["StartTime"];
                endtime = (string)obj2["EndTime"];
                goodsname = (string)obj2["ProductName"];
                goodscode = (string)obj2["SKN"];
                goodsprice = (float)obj2["WebPrice"];
                Channel channel = new Channel(showDate2, begintime, endtime, goodsname, goodscode, goodsprice, provider_id, provider_name);
                int result = channel_add(channel);
            }



        }
        //宜和购物
        public void getInfomation13(string url, int provider_id, string provider_name)
        {
            doc = web.Load(url);//*[@id="tv2013list"]/div[3]
            string strHtml = doc.DocumentNode.InnerHtml.Replace("\r", "").Replace("\t", "").Replace("\n", "").Replace("\"", "'");
            doc.LoadHtml(strHtml);

            htmlnodec = doc.DocumentNode.SelectNodes("/html/body/div[8]/table/tr");
            foreach (HtmlNode child in htmlnodec)
            {
                //核心模块分析HTML变量赋值
                try
                {
                    string datetime = child.SelectSingleNode("td[1]").InnerText.Trim();
                    string[] datearr = datetime.Split('-');
                    begintime = datearr[0].Trim();
                    endtime = datearr[1].Trim();
                    string aa = child.SelectSingleNode("td[3]/p[5]").InnerText;

                    goodsprice = float.Parse(aa.Replace("宜和价:￥", ""));
                    goodsname = child.SelectSingleNode("td[3]").ChildNodes[4].InnerText;
                    goodscode = child.SelectSingleNode("td[3]/p[1]").InnerText.Replace("商品编号:", "");
                }
                catch (Exception e)
                {
                    continue;
                }
                //datetime = datetime.Substring(10, 13);
                //string[] datearr = datetime.Split('-');

                Channel channel = new Channel(showDate, begintime, endtime, goodsname, goodscode, goodsprice, provider_id, provider_name);
                int result = channel_add(channel);
            }

        }
        //乐拍商城
        public void getInfomation14(string url, int provider_id, string provider_name)
        {
            doc = web.Load(url);//*[@id="tv2013list"]/div[3]
            string strHtml = doc.DocumentNode.InnerHtml.Replace("\r", "").Replace("\t", "").Replace("\n", "").Replace("\"", "'").Replace("<form method='post' action='./vod.aspx' id='form1'>", "").Replace("</form>", "");
            doc.LoadHtml(strHtml);
            htmlnodec = doc.DocumentNode.SelectNodes("//*[@class='sdtvlist']/div[2]/div[2]/ul/li");
            foreach (HtmlNode child in htmlnodec)
            {
                //核心模块分析HTML变量赋值
                string datetime = child.SelectSingleNode("a/p/span[3]").InnerText.Replace("播出时间：", "");
                //datetime = datetime.Substring(10, 13);
                //string[] datearr = datetime.Split('-');
                begintime = datetime;
                endtime = begintime;
                goodsprice = float.Parse(child.SelectSingleNode("a/p/span[2]").InnerText.Replace("售　　价：", "").Replace("元", ""));
                goodsname = child.SelectSingleNode("a/p/span[1]").InnerText;
                goodscode = child.SelectSingleNode("a").GetAttributeValue("href", "").Replace("../product/product.aspx?video=y&skn=", "");
                Channel channel = new Channel(showDate, begintime, endtime, goodsname, goodscode, goodsprice, provider_id, provider_name);
                int result = channel_add(channel);
            }
        }
        //全心购物
        public void getInfomation15(string url, int provider_id, string provider_name)
        {
            doc = web.Load(url);//*[@id="tv2013list"]/div[3]
            int dayOfWeek = (int)DateTime.Now.DayOfWeek;
            htmlnodec = doc.DocumentNode.SelectNodes("//*[@id='myTab1_Content" + (dayOfWeek - 1) + "']/div/ul");
            foreach (HtmlNode child in htmlnodec)
            {
                //核心模块分析HTML变量赋值
                string datetime = child.SelectSingleNode("li[2]/p[3]/span/font").InnerText.Substring(11, 5);
                begintime = datetime;
                endtime = begintime;
                goodsprice = float.Parse(child.SelectSingleNode("li[2]/p[2]/span[3]").InnerText);
                goodsname = child.SelectSingleNode("li[2]/p[1]").InnerText.Replace("\r\n\t", "").Trim();
                goodscode = child.SelectSingleNode("li[2]/p[1]/a").GetAttributeValue("href", "").Replace("/qxmall/dwitem-01.jsp?MULTISALENO=", "");
                Channel channel = new Channel(showDate, begintime, endtime, goodsname, goodscode, goodsprice, provider_id, provider_name);
                int result = channel_add(channel);
            }
        }
        //央广购物
        public void getInfomation16(string url, int provider_id, string provider_name)
        {
            int dayOfWeek = (int)DateTime.Now.DayOfWeek;
            url = url.Replace("date", DateTime.Now.AddDays(-1 * (dayOfWeek - 1)).ToString("yyyy-MM-dd"));
            doc = web.Load(url);//*[@id="tv2013list"]/div[3]
            string strHtml = doc.DocumentNode.InnerHtml.Replace("\r", "").Replace("\t", "").Replace("\n", "").Replace("\"", "'");
            doc.LoadHtml(strHtml);

            htmlnodec = doc.DocumentNode.SelectNodes("//*[@id='myTab1_Content" + (dayOfWeek - 1) + "']/div/ul");
            foreach (HtmlNode child in htmlnodec)
            {
                //核心模块分析HTML变量赋值
                //string datetime = child.SelectSingleNode("li[2]/p[3]/span/font").InnerText.Substring(11, 5);
                begintime = "00:00";
                endtime = begintime;
                goodsprice = float.Parse(child.SelectSingleNode("li[2]/p[2]/span[2]").InnerText);
                goodsname = child.SelectSingleNode("li[2]/p[1]").InnerText.Replace("\r\n\t", "").Trim();
                goodscode = child.SelectSingleNode("li[2]/p[1]/a").GetAttributeValue("href", "").Replace("http://www.cnrmall.com/dwitem-", "").Replace(".html", "");
                Channel channel = new Channel(showDate, begintime, endtime, goodsname, goodscode, goodsprice, provider_id, provider_name);
                int result = channel_add(channel);
            }
        }
        //好享购
        public void getInfomation17(string url, int provider_id, string provider_name)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?area=02&day=" + showDate);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream ResStream = response.GetResponseStream();
            Encoding encoding = Encoding.GetEncoding("gbk");
            StreamReader streamReader = new StreamReader(ResStream, encoding);
            string strHtml = streamReader.ReadToEnd();
            strHtml = strHtml.Replace("\r", "").Replace("\t", "").Replace("\n", "");
            doc = web.Load(url);
            doc.LoadHtml(strHtml);
            htmlnodec = doc.DocumentNode.SelectNodes("//*[@class='newtv_tvguide_l_list_l']");
            foreach (HtmlNode child in htmlnodec)
            {
                //核心模块分析HTML变量赋值
                string datetime = child.SelectSingleNode("ul[1]/li[1]").InnerText;
                string[] datearr = datetime.Split('~');
                begintime = datearr[0];
                endtime = datearr[1];
                goodsprice = float.Parse(child.SelectSingleNode("ul[2]/li[3]").InnerText.Replace("￥", ""));
                goodsname = child.SelectSingleNode("ul[2]/li[2]").InnerText;
                goodscode = child.SelectSingleNode("ul[1]/li[2]").InnerText.Replace("商品编号：", "");
                Channel channel = new Channel(showDate, begintime, endtime, goodsname, goodscode, goodsprice, provider_id, provider_name);
                int result = channel_add(channel);
            }
        }
        //好享购（全国）
        public void getInfomation19(string url, int provider_id, string provider_name)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?area=03&day=" + showDate);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream ResStream = response.GetResponseStream();
            Encoding encoding = Encoding.GetEncoding("gbk");
            StreamReader streamReader = new StreamReader(ResStream, encoding);
            string strHtml = streamReader.ReadToEnd();
            strHtml = strHtml.Replace("\r", "").Replace("\t", "").Replace("\n", "");
            doc = web.Load(url);
            doc.LoadHtml(strHtml);
            htmlnodec = doc.DocumentNode.SelectNodes("//*[@class='newtv_tvguide_l_list_l']");
            foreach (HtmlNode child in htmlnodec)
            {
                //核心模块分析HTML变量赋值
                string datetime = child.SelectSingleNode("ul[1]/li[1]").InnerText;
                string[] datearr = datetime.Split('~');
                begintime = datearr[0];
                endtime = datearr[1];
                goodsprice = float.Parse(child.SelectSingleNode("ul[2]/li[3]").InnerText.Replace("￥", ""));
                goodsname = child.SelectSingleNode("ul[2]/li[2]").InnerText;
                goodscode = child.SelectSingleNode("ul[1]/li[2]").InnerText.Replace("商品编号：", "");
                Channel channel = new Channel(showDate, begintime, endtime, goodsname, goodscode, goodsprice, provider_id, provider_name);
                int result = channel_add(channel);
            }
        }
        //南方购物
        public void getInfomation18(string url, int provider_id, string provider_name)
        {
            doc = web.Load(url);
            htmlnodec = doc.DocumentNode.SelectNodes("//*[@id='goods_list']/li[@data='1']");
            foreach (HtmlNode child in htmlnodec)
            {
                //核心模块分析HTML变量赋值
                string datetime = child.SelectSingleNode("div/a/b").InnerText;
                string[] datearr = datetime.Split('-');
                begintime = datearr[0];
                endtime = datearr[1];
                string price = "0";
                try
                {
                    price = child.SelectSingleNode("div/div[3]/span[2]").InnerText;
                }
                catch (Exception e)
                {
                    price = child.SelectSingleNode("div/div[2]/span[2]").InnerText;
                }
                goodsprice = float.Parse(price);
                goodsname = child.SelectSingleNode("div/a/img").GetAttributeValue("title", "");
                goodscode = child.SelectSingleNode("div/a").GetAttributeValue("href", "").Replace("/mall/disp/itemInfo.htm?itemCode=", "");
                Channel channel = new Channel(showDate, begintime, endtime, goodsname, goodscode, goodsprice, provider_id, provider_name);
                int result = channel_add(channel);
            }
        }
        //封装channel类
        private class Channel
        {
            public int id;
            public string showdate;//日期
            public string begintime;//开始时间
            public string endtime;//结束时间
            public string goodsname;
            public string goodscode;
            public float goodsprice;
            public int provider_id;//提供者ID
            public string provider_name;
            public int duration;//时长
            //获取节目时长
            public void setDuration()
            {
                DateTime dt = DateTime.Parse(this.begintime);
                DateTime dt2 = DateTime.Parse(this.endtime);
                if (dt2.Hour == 0 && dt.Hour == 23)
                {
                    dt2 = dt2.AddDays(1);
                }
                TimeSpan timeDiff = dt2.Subtract(dt);
                if (Math.Abs(timeDiff.Hours) > 0)
                {
                    duration = Math.Abs(timeDiff.Hours) * 60;
                }
                duration = duration + Math.Abs(timeDiff.Minutes);
            }
            //构造函数
            public Channel(string showdate, string begintime, string endtime, string goodsname, string goodscode, float goodsprice, int provider_id, string provider_name)
            {
                this.showdate = showdate;
                this.goodsprice = goodsprice;
                this.begintime = begintime;
                this.endtime = endtime;
                this.goodsname = goodsname;
                this.goodscode = goodscode;
                this.provider_id = provider_id;
                this.provider_name = provider_name;
                setDuration();
            }
        }
        //封装提供者的类
        private class Provider
        {
            public int id;
            public string name;//电视台名称
            public string channel;//节目名称
            public string area;//地区
            public string website;//网址
            public string content = "";//备注
            public string rules = "";//截取规则(扩展用)
            public string functionname = "";//函数名称
            //构造函数
            public Provider(DataRow row)
            {
                id = (int)row["id"];
                name = row["name"].ToString();//电视台名称
                channel = row["channel"].ToString();//节目名称
                area = row["area"].ToString();//地区
                website = row["website"].ToString();//网址
                content = row["content"].ToString();//备注
                rules = row["rules"].ToString();//截取规则(扩展用)
                functionname = row["functionname"].ToString();//函数名称
            }

        }
        //插入数据库
        private int channel_add(Channel channel)
        {
            string sql = "insert into tv_channel(showdate,begintime,endtime,goodsname,goodscode,goodsprice,duration,provider_id,provider_name) " +
                            "values('" + channel.showdate + "','" + channel.begintime + "','" + channel.endtime + "','" + channel.goodsname.Replace("'", "") +
                            "','" + channel.goodscode + "'," + channel.goodsprice + ",'" + channel.duration + "'," + channel.provider_id + ",'" + channel.provider_name + "')";
            int result = DBHelper.ExecuteNonQuery(sql);
            return result;
        }
        //POST请求数据
        public string PostMoths(string url, string param)
        {
            string strURL = url;
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            string paraUrlCoded = param;
            byte[] payload;
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            request.ContentLength = payload.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(payload, 0, payload.Length);
            writer.Close();
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            string StrDate = "";
            string strValue = "";
            StreamReader Reader = new StreamReader(s, Encoding.UTF8);
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate + "\r\n";
            }
            return strValue;
        }
        //gbk 转 utf-8
        public string gbk_utf8(string text)
        {
            byte[] buffer = Encoding.GetEncoding("GBK").GetBytes(text);
            string utf_str = Encoding.UTF8.GetString(buffer);
            return utf_str;
        }
        //gb2312转uft-8
        public string gb2312_utf8(string text)
        {
            byte[] buffer = Encoding.GetEncoding("gb2312").GetBytes(text);
            string utf_str = Encoding.UTF8.GetString(buffer);

            return utf_str;

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int intprovider_id = (int)comboBox.SelectedValue;
                //string strdate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string sql = "select ID,provider_name as 电视台,showdate as 日期,begintime as 开始时间,endtime as 结束时间,goodsname as 商品名称,goodscode as 商品编码,goodsprice as 商品价格,duration as 时长 from tv_channel where provider_id = " + intprovider_id;
                DataSet ds = DBHelper.ExecuteDataSet(sql);
                channelDataView.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("请选择条件");

            }
        }

        //运行结果发送邮件
        public void sendEmail()
        {
            try
            {
                MailMessage mm = new MailMessage();
                MailAddress Fromma = new MailAddress("weimingjie@live.com");
                //MailAddress Toma = new MailAddress("yijimuyu@qq.com", "wxx");
                mm.From = Fromma;
                //收件人
                string emailList = getEmailList();
                string[] email_arr = emailList.Split(',');
                for (int i = 0;i<email_arr.Length;i++) {
                    mm.To.Add(email_arr[i]);
                }

                //邮箱标题
                mm.Subject = DateTime.Now.ToString("yyyy-MM-dd") + "页面抓取结果";
                mm.IsBodyHtml = true;
                mm.Body = "";
                if (!string.IsNullOrEmpty(error))
                {
                    mm.Body = DateTime.Now.ToString("yyyy-MM-dd") + "<br> 页面抓取结果如下：" + error + "抓取失败！";
                }
                else {
                    mm.Body = DateTime.Now.ToString("yyyy-MM-dd") + "<br> 全部成功！";
                }
                //内容的编码格式
                mm.BodyEncoding = System.Text.Encoding.UTF8;
                //mm.ReplyTo = Toma;
                //mm.Sender =Fromma;
                //mm.IsBodyHtml = false;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;

                SmtpClient sc = new SmtpClient();
                NetworkCredential nc = new NetworkCredential();

                nc.UserName = "weimingjie@Live.com";//你的邮箱地址
                nc.Password = "zhixinghe1";//你的邮箱密码,这里的密码是xxxxx@qq.com邮箱的密码，特别说明下~
                sc.UseDefaultCredentials = true;
                sc.EnableSsl = true;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.Credentials = nc;
                //如果这里报mail from address must be same as authorization user这个错误，是你的QQ邮箱没有开启SMTP，
                //到你自己的邮箱设置一下就可以啦！在帐户下面,如果是163邮箱的话，下面该成smtp.163.com
                sc.Host = "smtp.live.com";
                sc.Send(mm);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //获取Emaillist
        public string getEmailList()
        {
            strSec = Path.GetFileNameWithoutExtension(strFilePath);
            return ContentValue(strSec, "EmailList");
        }
        //获取ini数据
        private string ContentValue(string Section, string key)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(Section, key, "", temp, 1024, strFilePath);
            return temp.ToString();
        }
    }
    

}
