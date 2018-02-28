using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace com.soeasystem.spider.src.utils
{
    public class DateUtils
    {
        public static String getSysDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private static String[] hostArray = { "time.nist.gov", "time-a.timefreq.bldrdoc.gov", "time-b.timefreq.bldrdoc.gov", "time-c.timefreq.bldrdoc.gov", "utcnist.colorado.edu", "time-nw.nist.gov", "time-a.nist.gov", "time-b.nist.gov", "tick.mit.edu", "time.windows.com", "clock.sgi.com" };

        public static String getRealSysDate()
        {
            String result = String.Empty;

            Socket socket = null;

            foreach (String host in hostArray)
            {
                try
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.ReceiveTimeout = 30000;

                    socket.Connect(new IPEndPoint(Dns.GetHostEntry(host).AddressList[0], 13));

                    if (socket.Connected)
                    {
                        byte[] RecvBuffer = new byte[1024];
                        int nBytes, nTotalBytes = 0;
                        StringBuilder sb = new StringBuilder();

                        while ((nBytes = socket.Receive(RecvBuffer, 0, 1024, SocketFlags.None)) > 0)
                        {
                            nTotalBytes += nBytes;
                            sb.Append(Encoding.UTF8.GetString(RecvBuffer, 0, nBytes));
                        }

                        if (sb.ToString().Trim().Length != 0)
                        {
                            string[] o = sb.ToString().Split(' ');

                            //北京时间+8
                            result = Convert.ToDateTime(o[1] + " " + o[2]).AddHours(8).ToString("yyyy-MM-dd HH:mm:ss");
                            break;
                        }
                    }
                }
                catch
                {
                }
                finally
                {
                    if (socket != null)
                    {
                        socket.Close();
                    }
                }
            }


            return result;
        }

    }
}
