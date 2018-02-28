using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace com.soeasystem.spider.src.utils
{
    public class FileUtils
    {
        public static String read(String filePath)
        {
            String result = null;

            StreamReader sr = null;

            try
            {
                sr = new StreamReader(filePath);
                result = sr.ReadToEnd();
            }
            catch
            {
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }

            return result;
        }

        public static String write(String filePath, String content)
        {
            String result = null;

            StreamWriter sw = null;

            try
            {
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    file.Delete();
                }

                sw = new StreamWriter(filePath);
                sw.Write(content);
            }
            catch
            {
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }

            return result;
        }
    }
}
