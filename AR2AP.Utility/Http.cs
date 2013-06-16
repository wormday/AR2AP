using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR2AP.Utility
{
    public class Http
    {
        public string HttpPost(string URI, string Parameters)
        {
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URI);
            //req.Proxy = new System.Net.WebProxy(ProxyString, true);
            req.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            req.Headers.Add("Accept-Encoding:gzip, deflate");
            req.Headers.Add("Accept-Language:utf-8");
            req.Headers.Add("UA-CPU:x86");

            req.Headers.Add(System.Net.HttpRequestHeader.CacheControl, "no-cache");
            req.AllowAutoRedirect = true;
            req.ContentType = "application/x-www-form-urlencoded";
            req.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-silverlight, */*";
            req.Method = "POST";

            req.ServicePoint.Expect100Continue = false;

            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(Parameters);
            req.ContentLength = bytes.Length;

            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();

            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;

            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        public string HttpGet(string URI)
        {
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URI);
            req.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            req.Headers.Add("Accept-Encoding:deflate");
            req.Headers.Add("Accept-Language:utf-8");
            req.Headers.Add("UA-CPU:x86");

            req.Headers.Add(System.Net.HttpRequestHeader.CacheControl, "no-cache");
            req.AllowAutoRedirect = true;
            req.ContentType = "application/x-www-form-urlencoded";
            req.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-silverlight, */*";
            req.Method = "GET";

            req.ServicePoint.Expect100Continue = false;

            System.Net.WebResponse resp = req.GetResponse();


            if (resp == null) return null;

            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            return sr.ReadToEnd().Trim();
        }
    }
}
