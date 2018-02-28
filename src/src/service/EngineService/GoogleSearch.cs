using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.soeasystem.spider.src.entity;
using System.Net;
using com.soeasystem.spider.src.utils;
using com.soeasystem.spider.src.form;
using System.Drawing;
using com.soeasystem.spider.src.service;

namespace com.soeasystem.spider.src.searchEngine
{
    public class GoogleSearch : EngineNormal
    {
        private static CaptchaForm captchaForm = new CaptchaForm();

        public override Boolean isEndPage(String html, EngineEntity entity)
        {
            return html.IndexOf("找不到和您的查询") > 0;
        }

        public override void error(EngineEntity entity, Exception ex)
        {
            try
            {
                if (ex.GetType() == typeof(WebException))
                {
                    WebException exception = (WebException)ex;

                    //exception.Response
                    String html = WebClientUtils.getResponseHTML((HttpWebResponse)exception.Response);

                    //得到image路径
                    String imagepath = String.Empty;
                    foreach (String url in CommonUtils.getHTMLinkArray(entity.Url, html))
                    {

                        if (url.IndexOf("/sorry/image") > -1)
                        {
                            imagepath = url;
                            break;
                        }
                    }

                    HttpWebResponse response = null;

                    try
                    {
                        response = WebClientUtils.request(imagepath, 60000);

                        captchaForm.tb_captcha.Text = String.Empty;
                        captchaForm.pb_captcha.Image = Image.FromStream(response.GetResponseStream());
                        captchaForm.ShowDialog();
                    }
                    finally
                    {
                        if (response != null)
                        {
                            response.Close();
                        }
                    }

                    String id = imagepath.Substring(imagepath.IndexOf("id=") + 3, imagepath.IndexOf("&") - imagepath.IndexOf("id=") - 3);

                    WebClientUtils.request("http://www.google.com.hk/sorry/Captcha?id=" + id + "&captcha=" + Convert.ToString(captchaForm.Tag), 60000);
                }

            }
            catch { }
        }
    }
}
