using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security.Principal;

namespace com.soeasystem.spider.src.utils
{
    public class SystemUtils
    {
        private static String companyName = "soeasystem";

        private static String softwareName = "mailSpider";

        public static String getWindowsPath()
        {
            return new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.System)).Directory.FullName;
        }

        public static Boolean isSingleProcesses()
        {
            return Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length == 1;
        }

        public static String getCurrentPath()
        {
            return new FileInfo(Application.ExecutablePath).Directory.FullName;
        }

        public static String getRegAsmPath()
        {
            DirectoryInfo dir = new DirectoryInfo(SystemUtils.getWindowsPath() + "\\Microsoft.NET\\Framework");

            FileInfo[] result = dir.GetFiles("regasm.exe", SearchOption.AllDirectories);

            foreach (FileInfo fi in result)
            {
                if (fi.Name.ToLower().Equals("regasm.exe"))
                {
                    if (fi.FullName.IndexOf("v2.0") > -1 || fi.FullName.IndexOf("v3") > -1 || fi.FullName.IndexOf("v4") > -1)
                    {
                        return fi.FullName;
                    }
                }
            }

            return null;
        }

        public static String executeCmd(string command)
        {
            Process p = null;

            String result = String.Empty;

            try
            {
                p = new Process();

                p.StartInfo.FileName = "cmd.exe";

                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;

                p.Start();
                p.StandardInput.WriteLine(command);
                p.StandardInput.WriteLine("exit");
                p.WaitForExit();
                result = p.StandardOutput.ReadToEnd();
            }
            finally
            {
                if (p != null)
                {
                    p.Close();
                }
            }



            return result;
        }

        public static void setRegistry(string key, string value)
        {
            RegistryKey softwareKey = null;
            RegistryKey companyKey = null;
            RegistryKey softwareNameKey = null;

            try
            {
                softwareKey = Registry.LocalMachine.OpenSubKey("Software", true);
                companyKey = softwareKey.CreateSubKey(companyName);
                softwareNameKey = companyKey.CreateSubKey(softwareName);
                softwareNameKey.SetValue(key, value);
            }
            finally
            {
                if (softwareNameKey != null)
                {
                    softwareNameKey.Close();
                }
                if (companyKey != null)
                {
                    companyKey.Close();
                }
                if (softwareKey != null)
                {
                    softwareKey.Close();
                }
            }
        }

        public static String getRegistry(string key)
        {
            String result = null;

            RegistryKey softwareKey = null;
            RegistryKey companyKey = null;
            RegistryKey softwareNameKey = null;

            try
            {
                softwareKey = Registry.LocalMachine.OpenSubKey("Software", true);
                companyKey = softwareKey.CreateSubKey(companyName);
                softwareNameKey = companyKey.CreateSubKey(softwareName);
                result = softwareNameKey.GetValue(key) as String;
            }
            catch { }
            finally
            {
                if (softwareNameKey != null)
                {
                    softwareNameKey.Close();
                }
                if (companyKey != null)
                {
                    companyKey.Close();
                }
                if (softwareKey != null)
                {
                    softwareKey.Close();
                }
            }

            return result;
        }

        public static int WM_COPYDATA = 0x004A;

        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {

            /// <summary>
            /// 用户自定义数据
            /// </summary>

            public IntPtr dwData;
            /// <summary>
            /// 数据长度
            /// </summary>
            public int cbData;

            /// <summary>
            /// 数据地址指针
            /// </summary>
            public IntPtr lpData;
        }

        [DllImport("User32.dll", EntryPoint = "SendMessage", SetLastError = true)]
        public static extern int SendMessage(int hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 通过 SendMessage 向指定句柄发送数据
        /// </summary>
        /// <param name="hWnd">接收方的窗口句柄</param>
        /// <param name="dwData">附加数据</param>
        /// <param name="lpdata">发送的数据</param>
        public static int sendMsg(String winName, int dwData, byte[] lpdata)
        {
            COPYDATASTRUCT cds = new COPYDATASTRUCT();
            cds.dwData = (IntPtr)dwData;
            cds.cbData = lpdata.Length;
            cds.lpData = Marshal.AllocHGlobal(lpdata.Length);

            Marshal.Copy(lpdata, 0, cds.lpData, lpdata.Length);
            IntPtr lParam = Marshal.AllocHGlobal(Marshal.SizeOf(cds));
            Marshal.StructureToPtr(cds, lParam, true);

            int result = 0;

            try
            {
                result = SendMessage(FindWindow(null, winName), SystemUtils.WM_COPYDATA, IntPtr.Zero, lParam);
            }
            finally
            {
                Marshal.FreeHGlobal(cds.lpData);
                Marshal.DestroyStructure(lParam, typeof(COPYDATASTRUCT));
                Marshal.FreeHGlobal(lParam);
            }

            return result;
        }


        /// <summary>
        /// 获取消息类型为 WM_COPYDATA 中的数据
        /// </summary>
        /// <param name="m"></param>
        /// <param name="dwData"> 附加数据 </param>
        /// <param name="lpdata"> 接收到的发送数据 </param>
        public static void receiveMsg(ref Message m, out int dwData, out byte[] lpdata)
        {
            COPYDATASTRUCT cds = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));

            dwData = cds.dwData.ToInt32();

            lpdata = new byte[cds.cbData];

            Marshal.Copy(cds.lpData, lpdata, 0, cds.cbData);

            m.Result = (IntPtr)0;
        }


        /**
         * 是否管理员登录
         * */
        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

    }
}
