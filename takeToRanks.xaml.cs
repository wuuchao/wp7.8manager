using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using 背单词对战.listWords;
using System.IO;
using System.Text;
using 背单词对战.view.test;
using System.Windows.Documents;

namespace 背单词对战.view
{
    public partial class takeToRanks : PhoneApplicationPage
    {
        public takeToRanks()
        {
            InitializeComponent();
        }
        private void ProcessHttp()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri("http://wuuchao.cloudapp.net/Server/ranks"));
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);

        }

        private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {

            HttpWebRequest webRequest = (HttpWebRequest)asynchronousResult.AsyncState;

            // End the stream request operation 
            Stream postStream = webRequest.EndGetRequestStream(asynchronousResult);

            // Create the post data

            // Demo POST data

            string postData = "rank=" + cet4.max + " &name=" + showResult.name1;

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Add the post data to the web request 
            postStream.Write(byteArray, 0, byteArray.Length);

            postStream.Close();

            // Start the web request 
            webRequest.BeginGetResponse(new AsyncCallback(WebResponseCallback), webRequest);

        }


        private void WebResponseCallback(IAsyncResult result)
        {
            string response = null;
            Stream stream = null;

            try
            {
                //获取异步操作返回的的信息 
                HttpWebRequest httpWebRequest = (HttpWebRequest)result.AsyncState;
                //结束对 Internet 资源的异步请求
                WebResponse webResponse = httpWebRequest.EndGetResponse(result);
                stream = webResponse.GetResponseStream();
                using (StreamReader sr = new StreamReader(stream))
                {
                    response = sr.ReadToEnd();
                }
            }
            catch { }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
                Dispatcher.BeginInvoke(() =>
                {
                    Paragraph myPa = new Paragraph();
                    Run run = new Run();
                    for (int i = 0; i < response.Length; i++)
                    {
                        run.Text += response[i];
                        myPa.Inlines.Add(run);
                        if (response[i] == ' ')
                        {
                            Run run1 = new Run();
                            myPa.Inlines.Add(run1);
                            //run.Text = "";
                        }
                        ranks.Blocks.Add(myPa);
                    }
                    myPa.Inlines.Add(new Run().Text = "done");
                    ranks.Blocks.Add(myPa);
                });

        }
    }
}