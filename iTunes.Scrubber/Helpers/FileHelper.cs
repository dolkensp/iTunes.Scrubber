using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Drawing;

namespace iTunes.Scrubber.Helpers
{
    public static class FileHelper
    {
        private static readonly object _httpLock = new object();

        public static Bitmap HttpGetBitmap(string url, string username = null, string password = null, Dictionary<String, String> cookies = null)
        {
            lock (_httpLock)
            {
                HttpWebRequest request = null;
                WebResponse response = null;
                Bitmap content = null;

                StringBuilder cookieData = new StringBuilder();

                cookies = cookies ?? new Dictionary<String, String>();

                foreach (String cookie in cookies.Keys)
                    cookieData.AppendFormat(";{0}={1}", cookie, cookies[cookie]);

                if (cookieData.Length == 0)
                    cookieData.Append(";");

                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.UserAgent = "Microsoft.Net/4.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.8) iTunes.Scrubber/" + Assembly.GetEntryAssembly().GetName().Version;
                    request.KeepAlive = false;
                    request.AllowAutoRedirect = true;
                    request.Timeout = 30000;
                    request.Headers.Add(String.Format("Cookie: {0}", cookieData.ToString().Substring(1)));
                    if (username != null && password != null)
                    {
                        request.Credentials = new NetworkCredential(username, password);
                        request.PreAuthenticate = true;
                    }

                    response = request.GetResponse();

                    content = new Bitmap(response.GetResponseStream());
                }
                catch (Exception ex)
                {
                    if (request != null)
                        request.Abort();
                }
                finally
                {
                    if (response != null)
                        response.Close();
                }

                return content;
            }
        }

        public static string HttpGet(string url, string username, string password, Dictionary<String, String> cookies)
        {
            lock (_httpLock)
            {
                HttpWebRequest request = null;
                WebResponse response = null;
                string content = null;

                StringBuilder cookieData = new StringBuilder();

                cookies = cookies ?? new Dictionary<String, String>();

                foreach (String cookie in cookies.Keys)
                    cookieData.AppendFormat(";{0}={1}", cookie, cookies[cookie]);

                if (cookieData.Length == 0)
                    cookieData.Append(";");

                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.UserAgent = "Microsoft.Net/4.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.8) iTunes.Scrubber/" + Assembly.GetEntryAssembly().GetName().Version;
                    request.KeepAlive = false;
                    request.AllowAutoRedirect = true;
                    request.Timeout = 30000;
                    request.Headers.Add(String.Format("Cookie: {0}", cookieData.ToString().Substring(1)));
                    if (username != null && password != null)
                    {
                        request.Credentials = new NetworkCredential(username, password);
                        request.PreAuthenticate = true;
                    }

                    response = request.GetResponse();
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader responseReader = new System.IO.StreamReader(responseStream, Encoding.UTF8))
                            {
                                content = responseReader.ReadToEnd();
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    if (request != null)
                        request.Abort();
                }
                finally
                {
                    if (response != null)
                        response.Close();
                }

                return content;
            }
        }

        public static string HttpGet(string url)
        {
            return HttpGet(url, null, null);
        }

        public static string HttpGet(string url, string username, string password)
        {
            return HttpGet(url, username, password, null);
        }

        public static SimpleWebResponse HttpPost(String url, String username, String password, Dictionary<String, String> form, Dictionary<String, String> cookies)
        {
            lock (_httpLock)
            {
                HttpWebRequest request = null;
                WebResponse response = null;
                SimpleWebResponse content = new SimpleWebResponse();

                try
                {
                    StringBuilder postData = new StringBuilder();

                    form = form ?? new Dictionary<String, String>();

                    foreach (String field in form.Keys)
                        postData.AppendFormat("&{0}={1}", field, form[field]);

                    if (postData.Length == 0)
                        postData.Append("&");

                    StringBuilder cookieData = new StringBuilder();

                    cookies = cookies ?? new Dictionary<String, String>();

                    foreach (String cookie in cookies.Keys)
                        cookieData.AppendFormat(";{0}={1}", cookie, cookies[cookie]);

                    if (cookieData.Length == 0)
                        cookieData.Append(";");

                    Byte[] data = Encoding.ASCII.GetBytes(postData.ToString().Substring(1));

                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.UserAgent = "Microsoft.Net/4.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.8) iTunes.Scrubber/" + Assembly.GetEntryAssembly().GetName().Version;
                    request.KeepAlive = false;
                    request.AllowAutoRedirect = true;
                    request.Timeout = 30000;
                    request.Method = "POST";
                    request.Headers.Add(String.Format("Cookie: {0}", cookieData.ToString().Substring(1)));
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = data.Length;
                    if (username != null && password != null)
                    {
                        request.Credentials = new NetworkCredential(username, password);
                        request.PreAuthenticate = true;
                    }

                    Stream newStream = request.GetRequestStream();
                    newStream.Write(data, 0, data.Length);

                    response = request.GetResponse();

                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader responseReader = new System.IO.StreamReader(responseStream, Encoding.UTF8))
                            {
                                content.Content = responseReader.ReadToEnd();
                            }

                            content.Headers = new Dictionary<String, String>();

                            foreach (var header in response.Headers.AllKeys)
                                content.Headers.Add(header, response.Headers[header]);

                            content.Cookies = new Dictionary<String, String>();

                            if (content.Headers.ContainsKey("Set-Cookie"))
                            {
                                var cookieValue = Regex.Match(content.Headers["Set-Cookie"], "^(.*?)=(.*?);( expires=.*?;)? path=.*?(,(.*?)=(.*?);( expires=.*?;)? path=.*?)*$");

                                for (Int32 i = 0; i < cookieValue.Groups[1].Captures.Count; i++)
                                    content.Cookies[cookieValue.Groups[1].Captures[i].Value] = cookieValue.Groups[2].Captures[i].Value;

                                for (Int32 i = 0; i < cookieValue.Groups[5].Captures.Count; i++)
                                    content.Cookies[cookieValue.Groups[5].Captures[i].Value] = cookieValue.Groups[6].Captures[i].Value;
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    if (request != null)
                        request.Abort();
                }
                finally
                {
                    if (response != null)
                        response.Close();
                }

                return content;
            }
        }

        public class SimpleWebResponse
        {
            public Dictionary<String, String> Headers { get; set; }
            public Dictionary<String, String> Cookies { get; set; }
            public String Content { get; set; }
        }
    }
}
