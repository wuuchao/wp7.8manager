using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using 背单词对战.model;

namespace 背单词对战.connection
{
    class HTTPconnect
    {
        public HTTPconnect()
        {
            ProcessHttp();
        }
        private void ProcessHttp()
        {
            string uri = "https://www.google.com/";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(uri));
            request.BeginGetResponse(new AsyncCallback(WebResponseCallback), request);
        }


        private void WebResponseCallback(IAsyncResult result)
        {
            transDOC.str = "begin";
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

            //这里不为空代表获得回复了
            if (response != null)
            {
                //因为HttpWebRequest的回调是异步，不在UI线程上。所以要改变UI线程上的控件属性就要用Dispatcher.BeginInvoke()。
                transDOC.str = response;
            }
            else
            {
                transDOC.str = "response != null";
            }
        }
    } 
}
