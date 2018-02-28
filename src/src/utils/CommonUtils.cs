using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace com.soeasystem.spider.src.utils
{
    public class CommonUtils
    {
        public static Boolean isNumber(String str)
        {
            Boolean result = true;
            try
            {
                int tmp = Convert.ToInt32(str);
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public static string getBaseURL(string strUri)
        {
            string baseUri;
            Uri uri = new Uri(strUri);
            string port = string.Empty;
            if (!uri.IsDefaultPort)
                port = ":" + uri.Port;
            baseUri = uri.Scheme + "://" + uri.Host + port + "/";

            return baseUri;
        }

        public static string[] getHTMLinkArray(string baseUri, string html)
        {
            Hashtable urlArray = new Hashtable();

            string strRef = @"(href|HREF|src|SRC)[ ]*=[ ]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);

            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\'', '#', ' ', '>');

                if (!strRef.ToLower().StartsWith("javascript:"))
                {
                    String url = CommonUtils.getRealURL(baseUri, strRef);
                    if (urlArray[url] == null)
                    {
                        urlArray.Add(url, url);
                    }
                }
            }

            return urlArray.Keys.Cast<String>().ToArray();
        }

        public static string[] getHTMLMailArray(string html)
        {
            Hashtable mailArray = new Hashtable();

            string strRef = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.[\w]*?([-.]\w+)*?\w+";
            MatchCollection matches = new Regex(strRef).Matches(html);

            foreach (Match match in matches)
            {
                string mailAddress = match.Value;
                if (mailArray[mailAddress] == null)
                {
                    mailArray.Add(mailAddress, mailAddress);
                }
            }

            return mailArray.Keys.Cast<String>().ToArray();
        }

        public static String getRealURL(String srcURL, String linkURL)
        {

            if (!linkURL.ToLower().StartsWith("http"))
            {
                if (linkURL.StartsWith("/"))
                {
                    linkURL = CommonUtils.getBaseURL(srcURL) + linkURL.Substring(1);
                }
                else
                {
                    linkURL = srcURL.Substring(0, srcURL.LastIndexOf("/")) + "/" + linkURL;

                }
            }

            return linkURL.Replace("&amp;", "&");
        }

    }
}
