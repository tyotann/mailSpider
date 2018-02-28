using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;
using com.soeasystem.spider.src.utils;
using System.Management;
using mailSpider;

namespace com.soeasystem.spider.src.service
{
    [Serializable]
    public struct RegisterInfo
    {
        /// <summary>
        /// 公司名
        /// </summary>
        public String CompanyName;

        /// <summary>
        /// 结束使用日期
        /// </summary>
        public String EndDate;

        /// <summary>
        /// 正式版(FULL)，试用版(TRIAL)，无许可(UN_SUPPORT)，直接关闭(CLOSE)
        /// </summary>
        public String VersionType;
    }

    public static class RegisterService
    {
        private static RegisterInfo registerInfo = new RegisterInfo();

        private static String pubkey = "<RSAKeyValue><Modulus>z0ESWgyE+vNtpa9V3DcKe4Lopq4+QNe0mrd6DOxzYI4+2Or2ay8cq9Hj/ZzXkr4qDzSVhdDxVX413pNNwsLuH1563EJUZhfrWE2LA/rdwIpMb29fYQO75uD5fx9dS9b2aSiF6s7N5HEQIjCLf6FgmcG1Webyst5G1mHjfgz3+Dc=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        public static RegisterInfo getRegisterInfo()
        {
            if (registerInfo.VersionType == null)
            {
                registerInfo.VersionType = "UN_SUPPORT";

                try
                {
                    if (File.Exists(SystemUtils.getCurrentPath() + "\\license.info"))
                    {
                        //0:company_name,1:end_date,2:version_type
                        String[] info = FileUtils.read("license.info").Split('#');

                        registerInfo.CompanyName = info[0];

                        registerInfo.EndDate = info[1];

                        String keyData = FileUtils.read("license.key");

                        if (keyData != null)
                        {
                            HardDiskInfo hardDiskInfo = HardInfoUtils.getDiskInfo(0);

                            if (RegisterService.verify(keyData, RegisterService.getRegisterString(registerInfo.CompanyName, "1900-01-01", registerInfo.EndDate, HardInfoUtils.getCpuSerialNumber(), hardDiskInfo.SerialNumber, Convert.ToString(hardDiskInfo.Capacity), info[2])))
                            {
                                String newDate = DateUtils.getRealSysDate();

                                if (newDate.Length < 10)
                                {
                                    MessageBox.Show("没有取得时间,请在保证网络能连接情况下重启该程序");
                                    registerInfo.VersionType = "CLOSE";
                                }

                                //判断日期
                                DateTime nowDT = Convert.ToDateTime(newDate.Substring(0, 10));
                                DateTime end = Convert.ToDateTime(registerInfo.EndDate);

                                if (nowDT.Subtract(end).TotalDays <= 0)
                                {
                                    registerInfo.VersionType = info[2];
                                }
                                else
                                {
                                    MessageBox.Show("您的授权日期:" + end + "已过期,~请与销售联系购买新的许可");
                                    registerInfo.VersionType = "CLOSE";
                                }
                            }
                            else
                            {
                                MessageBox.Show("序列号不一致~请与销售联系");
                                registerInfo.VersionType = "CLOSE";
                            }
                        }
                        else
                        {
                            MessageBox.Show("当前目录下无法找到注册文件license.key,请联系销售购买获得序列号!");
                            registerInfo.VersionType = "CLOSE";
                        }
                    }
                }
                catch { MessageBox.Show("检查软件许可时出现异常,请重新启动软件"); }
            }


            return registerInfo;
        }

        public static String getRegisterString(String companyName, String startDate, String endDate, String cpuNo, String diskNo, String diskCapacity, String versionType)
        {
            return companyName + "#" + startDate + "#" + endDate + "#" + cpuNo + "#" + diskNo + "#" + diskCapacity + "#" + versionType;
        }


        /**
         * 公钥加密
         * */
        public static String encode(String instr)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(pubkey);

            return Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(instr), false));
        }

        /**
         * 私钥解密
         * */
        public static String decode(String prikey, String instr)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(prikey);

            return Encoding.UTF8.GetString(rsa.Decrypt(Convert.FromBase64String(instr), false));
        }

        /**
         * 私钥签名
         * */
        public static String signature(String prikey, String instr)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(prikey);

            RSAPKCS1SignatureFormatter f = new RSAPKCS1SignatureFormatter(rsa);
            f.SetHashAlgorithm("SHA1");

            byte[] b = f.CreateSignature(new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(instr)));

            return Convert.ToBase64String(b);
        }

        /**
         * 公钥验签
         * */
        public static Boolean verify(String signStr, String instr)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(pubkey);


            return rsa.VerifyData(Encoding.UTF8.GetBytes(instr), "SHA1", Convert.FromBase64String(signStr));
        }
    }
}
