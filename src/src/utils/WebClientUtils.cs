﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.IO;
using com.soeasystem.spider.src.service;
using System.Threading;
using log4net;

namespace com.soeasystem.spider.src.utils
{
    public class WebClientUtils
    {
        private static ILog logger = LogManager.GetLogger("WebClientUtils");

        private static CookieContainer cookieContainer = new CookieContainer();

        public static String getHTML(String url, Int32 timeout)
        {
            String html = String.Empty;
            HttpWebResponse response = WebClientUtils.request(url, timeout);

            if (HttpStatusCode.OK.Equals(response.StatusCode))
            {
                html = WebClientUtils.getResponseHTML(response);
            }
            return html;
        }

        public static HttpWebResponse request(String url, Int32 timeout)
        {
            HttpWebResponse response = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = timeout;
            //request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0))";

            //带cookie
            request.CookieContainer = cookieContainer;

            //超时后自动重新请求
            Int32 reparseCnt = 0;
            while (reparseCnt < 3)
            {
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                    break;
                }
                catch (WebException webException)
                {
                    reparseCnt++;

                    // TODO
                    if (reparseCnt >= 3 || (webException.Status != WebExceptionStatus.Timeout && webException.Status != WebExceptionStatus.ReceiveFailure))
                    {
                        logger.Error("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@" + webException.Status);
                        throw webException;
                    }
                }
            }

            return response;
        }



        public static String getResponseHTML(HttpWebResponse response)
        {
            String html = String.Empty; ;

            StreamReader rs = null;

            string contentType = response.ContentType;

            try
            {
                if (contentType.IndexOf("text/html") > -1)
                {
                    rs = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(response.CharacterSet));
                    html = rs.ReadToEnd();
                }
            }
            finally
            {
                if (rs != null)
                {
                    rs.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }

            return html;
        }
    }


    //MyWebResponse response = null;



    /**
    MyWebRequest request = null;
    request = MyWebRequest.Create(new MyUri(url), request, false);
    //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    request.Timeout = Convert.ToInt32(ConfigUtils.get("parse.request.timeout")) * 1000;
    //request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)";

    //response = (HttpWebResponse)request.GetResponse();
    response = request.GetResponse();

    string contentType = response.ContentType;

    if (contentType.IndexOf("text/html") > -1)
    {
        byte[] RecvBuffer = new byte[10240];
        int nBytes, nTotalBytes = 0;
        while ((nBytes = response.socket.Receive(RecvBuffer, 0, 10240, SocketFlags.None)) > 0)
        {
            nTotalBytes += nBytes;
            sb.Append(Encoding.ASCII.GetString(RecvBuffer, 0, nBytes));


            if (response.KeepAlive && nTotalBytes >= response.ContentLength && response.ContentLength > 0)
            {
                break;
            }

        }
    }
     * */

    public class MyUri : System.Uri
    {
        public MyUri(string uriString)
            : base(uriString)
        {
        }
        public int Depth;
    }

    public class MyWebRequest
    {
        public MyWebRequest(Uri uri, bool bKeepAlive)
        {
            Headers = new WebHeaderCollection();
            RequestUri = uri;
            Headers["Host"] = uri.Host;
            KeepAlive = bKeepAlive;
            if (KeepAlive)
                Headers["Connection"] = "Keep-Alive";
            Method = "GET";
        }
        public static MyWebRequest Create(Uri uri, MyWebRequest AliveRequest, bool bKeepAlive)
        {
            if (bKeepAlive &&
                AliveRequest != null &&
                AliveRequest.response != null &&
                AliveRequest.response.KeepAlive &&
                AliveRequest.response.socket.Connected &&
                AliveRequest.RequestUri.Host == uri.Host)
            {
                AliveRequest.RequestUri = uri;
                return AliveRequest;
            }
            return new MyWebRequest(uri, bKeepAlive);
        }
        public MyWebResponse GetResponse()
        {
            if (response == null || response.socket == null || response.socket.Connected == false)
            {
                response = new MyWebResponse();
                response.Connect(this);
                response.SetTimeout(Timeout);
            }
            response.SendRequest(this);
            response.ReceiveHeader();
            return response;
        }

        public int Timeout;
        public WebHeaderCollection Headers;
        public string Header;
        public Uri RequestUri;
        public string Method;
        public MyWebResponse response;
        public bool KeepAlive;
    }
    public class MyWebResponse
    {
        public MyWebResponse()
        {
        }
        public void Connect(MyWebRequest request)
        {
            ResponseUri = request.RequestUri;

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint remoteEP = new IPEndPoint(Dns.Resolve(ResponseUri.Host).AddressList[0], ResponseUri.Port);
            socket.Connect(remoteEP);
        }
        public void SendRequest(MyWebRequest request)
        {
            ResponseUri = request.RequestUri;

            request.Header = request.Method + " " + ResponseUri.PathAndQuery + " HTTP/1.0\r\n" + request.Headers;
            socket.Send(Encoding.ASCII.GetBytes(request.Header));
        }
        public void SetTimeout(int Timeout)
        {
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, Timeout * 1000);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, Timeout * 1000);
        }
        public void ReceiveHeader()
        {
            Header = "";
            Headers = new WebHeaderCollection();

            byte[] bytes = new byte[10];
            while (socket.Receive(bytes, 0, 1, SocketFlags.None) > 0)
            {
                Header += Encoding.ASCII.GetString(bytes, 0, 1);
                if (bytes[0] == '\n' && Header.EndsWith("\r\n\r\n"))
                    break;
            }
            MatchCollection matches = new Regex("[^\r\n]+").Matches(Header.TrimEnd('\r', '\n'));
            for (int n = 1; n < matches.Count; n++)
            {
                string[] strItem = matches[n].Value.Split(new char[] { ':' }, 2);
                if (strItem.Length > 0)
                    Headers[strItem[0].Trim()] = strItem[1].Trim();
            }
            // check if the page should be transfered to another location
            if (matches.Count > 0 && (
                matches[0].Value.IndexOf(" 302 ") != -1 ||
                matches[0].Value.IndexOf(" 301 ") != -1))
                // check if the new location is sent in the "location" header
                if (Headers["Location"] != null)
                {
                    try { ResponseUri = new Uri(Headers["Location"]); }
                    catch { ResponseUri = new Uri(ResponseUri, Headers["Location"]); }
                }
            ContentType = Headers["Content-Type"];
            if (Headers["Content-Length"] != null)
                ContentLength = int.Parse(Headers["Content-Length"]);
            KeepAlive = (Headers["Connection"] != null && Headers["Connection"].ToLower() == "keep-alive") ||
                        (Headers["Proxy-Connection"] != null && Headers["Proxy-Connection"].ToLower() == "keep-alive");
        }
        public void Close()
        {
            socket.Close();
        }
        public Uri ResponseUri;
        public string ContentType;
        public int ContentLength;
        public WebHeaderCollection Headers;
        public string Header;
        public Socket socket;
        public bool KeepAlive;
    }
}
