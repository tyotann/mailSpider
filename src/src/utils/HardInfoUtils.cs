﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using log4net;
using System.Management;

namespace com.soeasystem.spider.src.utils
{
    public class HardDiskInfo
    {
        /// <summary>
        /// 型号
        /// </summary>
        private string moduleNumber;

        public string ModuleNumber
        {
            get { return moduleNumber; }
            set { moduleNumber = value; }
        }

        /// <summary>
        /// 固件版本
        /// </summary>
        private string firmware;

        public string Firmware
        {
            get { return firmware; }
            set { firmware = value; }
        }

        /// <summary>
        /// 序列号
        /// </summary>
        private string serialNumber;

        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }

        /// <summary>
        /// 容量，以M为单位
        /// </summary>
        private uint capacity;

        public uint Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
    }



    #region Internal Structs

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct GetVersionOutParams
    {
        public byte bVersion;
        public byte bRevision;
        public byte bReserved;
        public byte bIDEDeviceMap;
        public uint fCapabilities;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] dwReserved; // For future use.
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct IdeRegs
    {
        public byte bFeaturesReg;
        public byte bSectorCountReg;
        public byte bSectorNumberReg;
        public byte bCylLowReg;
        public byte bCylHighReg;
        public byte bDriveHeadReg;
        public byte bCommandReg;
        public byte bReserved;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct SendCmdInParams
    {
        public uint cBufferSize;
        public IdeRegs irDriveRegs;
        public byte bDriveNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] bReserved;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] dwReserved;
        public byte bBuffer;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct DriverStatus
    {
        public byte bDriverError;
        public byte bIDEStatus;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] bReserved;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] dwReserved;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct SendCmdOutParams
    {
        public uint cBufferSize;
        public DriverStatus DriverStatus;
        public IdSector bBuffer;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 512)]
    internal struct IdSector
    {
        public ushort wGenConfig;
        public ushort wNumCyls;
        public ushort wReserved;
        public ushort wNumHeads;
        public ushort wBytesPerTrack;
        public ushort wBytesPerSector;
        public ushort wSectorsPerTrack;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public ushort[] wVendorUnique;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] sSerialNumber;
        public ushort wBufferType;
        public ushort wBufferSize;
        public ushort wECCSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] sFirmwareRev;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] sModelNumber;
        public ushort wMoreVendorUnique;
        public ushort wDoubleWordIO;
        public ushort wCapabilities;
        public ushort wReserved1;
        public ushort wPIOTiming;
        public ushort wDMATiming;
        public ushort wBS;
        public ushort wNumCurrentCyls;
        public ushort wNumCurrentHeads;
        public ushort wNumCurrentSectorsPerTrack;
        public uint ulCurrentSectorCapacity;
        public ushort wMultSectorStuff;
        public uint ulTotalAddressableSectors;
        public ushort wSingleWordDMA;
        public ushort wMultiWordDMA;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] bReserved;
    }


    #endregion




    /// <summary>
    /// ATAPI驱动器相关
    /// </summary>
    public class HardInfoUtils
    {

        private static ILog logger = LogManager.GetLogger("HardDiskUtils");

        #region DllImport

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateFile(
        string lpFileName,
        uint dwDesiredAccess,
        uint dwShareMode,
        IntPtr lpSecurityAttributes,
        uint dwCreationDisposition,
        uint dwFlagsAndAttributes,
        IntPtr hTemplateFile);


        [DllImport("kernel32.dll")]
        static extern int DeviceIoControl(
        IntPtr hDevice,
        uint dwIoControlCode,
        IntPtr lpInBuffer,
        uint nInBufferSize,
        ref GetVersionOutParams lpOutBuffer,
        uint nOutBufferSize,
        ref uint lpBytesReturned,
        [Out] IntPtr lpOverlapped);


        [DllImport("kernel32.dll")]
        static extern int DeviceIoControl(
        IntPtr hDevice,
        uint dwIoControlCode,
        ref SendCmdInParams lpInBuffer,
        uint nInBufferSize,
        ref SendCmdOutParams lpOutBuffer,
        uint nOutBufferSize,
        ref uint lpBytesReturned,
        [Out] IntPtr lpOverlapped);

        const uint DFP_GET_VERSION = 0x00074080;
        const uint DFP_SEND_DRIVE_COMMAND = 0x0007c084;
        const uint DFP_RECEIVE_DRIVE_DATA = 0x0007c088;

        const uint GENERIC_READ = 0x80000000;
        const uint GENERIC_WRITE = 0x40000000;
        const uint FILE_SHARE_READ = 0x00000001;
        const uint FILE_SHARE_WRITE = 0x00000002;
        const uint CREATE_NEW = 1;
        const uint OPEN_EXISTING = 3;

        #endregion


        #region GetHddInfo


        /**
        /// <summary>
        /// 获得硬盘信息
        /// </summary>
        /// <param name="driveIndex">硬盘序号</param>
        /// <returns>硬盘信息</returns>
        /// <remarks>
        /// 参考lu0的文章：http://lu0s1.3322.org/App/2k1103.html
        /// by sunmast for everyone
        /// thanks lu0 for his great works
        /// 在Windows 98/ME中，S.M.A.R.T并不缺省安装，请将SMARTVSD.VXD拷贝到%SYSTEM%\IOSUBSYS目录下。
        /// 在Windows 2000/2003下，需要Administrators组的权限。
        /// </remarks>
        /// <example>
        /// AtapiDevice.GetHddInfo()
        /// </example>
        public static HardDiskInfo get(byte driveIndex)
        {
            HardDiskInfo hardDiskInfo = new HardDiskInfo();

            try
            {
                switch (Environment.OSVersion.Platform)
                {
                    case PlatformID.Win32Windows:
                        hardDiskInfo = GetHddInfo9x(driveIndex);
                        break;
                    case PlatformID.Win32NT:
                        hardDiskInfo = GetHddInfoNT(driveIndex);
                        break;
                    case PlatformID.Win32S:
                        throw new NotSupportedException("此应用程序不支持Win32s类型平台系统.");
                    case PlatformID.WinCE:
                        throw new NotSupportedException("此应用程序不支持WinCE类型平台系统.");
                    default:
                        throw new NotSupportedException("未知的平台系统.");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }

            return hardDiskInfo;
        }


        #region GetHddInfo9x


        private static HardDiskInfo GetHddInfo9x(byte driveIndex)
        {
            GetVersionOutParams vers = new GetVersionOutParams();
            SendCmdInParams inParam = new SendCmdInParams();
            SendCmdOutParams outParam = new SendCmdOutParams();
            uint bytesReturned = 0;

            IntPtr hDevice = CreateFile(@"\\.\Smartvsd", 0, 0, IntPtr.Zero, CREATE_NEW, 0, IntPtr.Zero);
            if (hDevice == IntPtr.Zero)
            {
                throw new Exception("Open smartvsd.vxd failed.");
            }
            if (0 == DeviceIoControl(hDevice, DFP_GET_VERSION, IntPtr.Zero, 0, ref vers, (uint)Marshal.SizeOf(vers), ref bytesReturned, IntPtr.Zero))
            {
                CloseHandle(hDevice);
                throw new Exception("DeviceIoControl failed:DFP_GET_VERSION");
            }
            // If IDE identify command not supported, fails
            if (0 == (vers.fCapabilities & 1))
            {
                CloseHandle(hDevice);
                throw new Exception("Error: IDE identify command not supported.");
            }
            if (0 != (driveIndex & 1))
            {
                inParam.irDriveRegs.bDriveHeadReg = 0xb0;
            }
            else
            {
                inParam.irDriveRegs.bDriveHeadReg = 0xa0;
            }
            if (0 != (vers.fCapabilities & (16 >> driveIndex)))
            {
                // We don''t detect a ATAPI device.
                CloseHandle(hDevice);
                throw new Exception(string.Format("Drive {0} is a ATAPI device, we don''t detect it", driveIndex + 1));
            }
            else
            {
                inParam.irDriveRegs.bCommandReg = 0xec;
            }
            inParam.bDriveNumber = driveIndex;
            inParam.irDriveRegs.bSectorCountReg = 1;
            inParam.irDriveRegs.bSectorNumberReg = 1;
            inParam.cBufferSize = 512;
            if (0 == DeviceIoControl(hDevice, DFP_RECEIVE_DRIVE_DATA, ref inParam, (uint)Marshal.SizeOf(inParam), ref outParam, (uint)Marshal.SizeOf(outParam), ref bytesReturned, IntPtr.Zero))
            {
                CloseHandle(hDevice);
                throw new Exception("DeviceIoControl failed: DFP_RECEIVE_DRIVE_DATA");
            }
            CloseHandle(hDevice);

            return GetHardDiskInfo(outParam.bBuffer);
        }


        #endregion


        #region GetHddInfoNT


        private static HardDiskInfo GetHddInfoNT(byte driveIndex)
        {
            GetVersionOutParams vers = new GetVersionOutParams();
            SendCmdInParams inParam = new SendCmdInParams();
            SendCmdOutParams outParam = new SendCmdOutParams();
            uint bytesReturned = 0;

            // We start in NT/Win2000
            IntPtr hDevice = CreateFile(string.Format(@"\\.\PhysicalDrive{0}", driveIndex), GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
            if (hDevice == IntPtr.Zero)
            {
                throw new Exception("CreateFile faild.");
            }
            if (0 == DeviceIoControl(hDevice, DFP_GET_VERSION, IntPtr.Zero, 0, ref vers, (uint)Marshal.SizeOf(vers), ref bytesReturned, IntPtr.Zero))
            {
                CloseHandle(hDevice);
                throw new Exception(string.Format("Drive {0} may not exists.", driveIndex + 1));
            }
            // If IDE identify command not supported, fails
            if (0 == (vers.fCapabilities & 1))
            {
                CloseHandle(hDevice);
                throw new Exception("Error: IDE identify command not supported.");
            }
            // Identify the IDE drives
            if (0 != (driveIndex & 1))
            {
                inParam.irDriveRegs.bDriveHeadReg = 0xb0;
            }
            else
            {
                inParam.irDriveRegs.bDriveHeadReg = 0xa0;
            }

            if (0 != (vers.fCapabilities & (16 >> driveIndex)))
            {
                // We don''t detect a ATAPI device.
                CloseHandle(hDevice);
                throw new Exception(string.Format("Drive {0} is a ATAPI device, we don''t detect it.", driveIndex + 1));
            }
            else
            {
                inParam.irDriveRegs.bCommandReg = 0xec;
            }

            inParam.bDriveNumber = driveIndex;
            inParam.irDriveRegs.bSectorCountReg = 1;
            inParam.irDriveRegs.bSectorNumberReg = 1;
            inParam.cBufferSize = 512;


            if (0 == DeviceIoControl(hDevice, DFP_RECEIVE_DRIVE_DATA, ref inParam, (uint)Marshal.SizeOf(inParam), ref outParam, (uint)Marshal.SizeOf(outParam), ref bytesReturned, IntPtr.Zero))
            {
                CloseHandle(hDevice);
                throw new Exception("DeviceIoControl failed: DFP_RECEIVE_DRIVE_DATA");
            }
            CloseHandle(hDevice);

            return GetHardDiskInfo(outParam.bBuffer);
        }


        #endregion


        private static HardDiskInfo GetHardDiskInfo(IdSector phdinfo)
        {
            HardDiskInfo hddInfo = new HardDiskInfo();

            ChangeByteOrder(phdinfo.sModelNumber);
            hddInfo.ModuleNumber = Encoding.ASCII.GetString(phdinfo.sModelNumber).Trim();


            ChangeByteOrder(phdinfo.sFirmwareRev);
            hddInfo.Firmware = Encoding.ASCII.GetString(phdinfo.sFirmwareRev).Trim();


            ChangeByteOrder(phdinfo.sSerialNumber);
            hddInfo.SerialNumber = Encoding.ASCII.GetString(phdinfo.sSerialNumber).Trim();

            hddInfo.Capacity = phdinfo.ulTotalAddressableSectors / 2 / 1024;

            return hddInfo;
        }
        */



        public static HardDiskInfo getDiskInfo(byte driveIndex)
        {
            HardDiskInfo hddInfo = new HardDiskInfo();

            IntPtr hDevice = IntPtr.Zero;

            try
            {
                switch (Environment.OSVersion.Platform)
                {
                    case PlatformID.Win32Windows:
                        hDevice = CreateFile(@"\\.\Smartvsd", 0, 0, IntPtr.Zero, CREATE_NEW, 0, IntPtr.Zero);
                        break;
                    case PlatformID.Win32NT:
                        hDevice = CreateFile(string.Format(@"\\.\PhysicalDrive{0}", driveIndex), GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
                        break;
                    case PlatformID.Win32S:
                        throw new NotSupportedException("此应用程序不支持Win32s类型平台系统.");
                    case PlatformID.WinCE:
                        throw new NotSupportedException("此应用程序不支持WinCE类型平台系统.");
                    default:
                        throw new NotSupportedException("未知的平台系统.");
                }

                GetVersionOutParams vers = new GetVersionOutParams();
                SendCmdInParams inParam = new SendCmdInParams();
                SendCmdOutParams outParam = new SendCmdOutParams();
                uint bytesReturned = 0;

                if (hDevice == IntPtr.Zero)
                {
                    throw new Exception("读取存储信息失败");
                }
                if (0 == DeviceIoControl(hDevice, DFP_GET_VERSION, IntPtr.Zero, 0, ref vers, (uint)Marshal.SizeOf(vers), ref bytesReturned, IntPtr.Zero))
                {
                    throw new Exception(string.Format("存储{0}不存在.", driveIndex + 1));
                }
                if (0 == (vers.fCapabilities & 1))
                {
                    throw new Exception("异常:存储取得语句失效.");
                }
                if (0 != (driveIndex & 1))
                {
                    inParam.irDriveRegs.bDriveHeadReg = 0xb0;
                }
                else
                {
                    inParam.irDriveRegs.bDriveHeadReg = 0xa0;
                }

                if (0 != (vers.fCapabilities & (16 >> driveIndex)))
                {
                    throw new Exception(string.Format("磁盘 {0} 为ATAPI设备,无法取得信息!.", driveIndex + 1));
                }
                else
                {
                    inParam.irDriveRegs.bCommandReg = 0xec;
                }

                inParam.bDriveNumber = driveIndex;
                inParam.irDriveRegs.bSectorCountReg = 1;
                inParam.irDriveRegs.bSectorNumberReg = 1;
                inParam.cBufferSize = 512;

                if (0 == DeviceIoControl(hDevice, DFP_RECEIVE_DRIVE_DATA, ref inParam, (uint)Marshal.SizeOf(inParam), ref outParam, (uint)Marshal.SizeOf(outParam), ref bytesReturned, IntPtr.Zero))
                {
                    throw new Exception("异常: DFP_RECEIVE_DRIVE_DATA");
                }

                IdSector phdinfo = outParam.bBuffer;

                ChangeByteOrder(phdinfo.sModelNumber);
                hddInfo.ModuleNumber = Encoding.ASCII.GetString(phdinfo.sModelNumber).Trim();


                ChangeByteOrder(phdinfo.sFirmwareRev);
                hddInfo.Firmware = Encoding.ASCII.GetString(phdinfo.sFirmwareRev).Trim();


                ChangeByteOrder(phdinfo.sSerialNumber);
                hddInfo.SerialNumber = Encoding.ASCII.GetString(phdinfo.sSerialNumber).Trim();

                hddInfo.Capacity = phdinfo.ulTotalAddressableSectors / 2 / 1024;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }
            finally
            {
                CloseHandle(hDevice);
            }

            return hddInfo;
        }

        private static void ChangeByteOrder(byte[] charArray)
        {
            byte temp;
            for (int i = 0; i < charArray.Length; i += 2)
            {
                temp = charArray[i];
                charArray[i] = charArray[i + 1];
                charArray[i + 1] = temp;
            }
        }

        #endregion

        public static String getCpuSerialNumber()
        {
            String cpuNo = null;

            ManagementClass mcpu = null;
            ManagementObjectCollection mncpu = null;
            try
            {
                mcpu = new ManagementClass("Win32_Processor");
                mncpu = mcpu.GetInstances();
                foreach (ManagementObject MyObject in mncpu)
                {
                    cpuNo = MyObject.Properties["ProcessorId"].Value.ToString();
                    break;
                }
            }
            catch
            {
            }
            finally
            {
                if (mncpu != null)
                {
                    mncpu.Dispose();
                }
                if (mcpu != null)
                {
                    mcpu.Dispose();
                }
            }

            return cpuNo;
        }
    }
}
