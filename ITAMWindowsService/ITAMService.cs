using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Configuration;

namespace ITAMWindowsService
{
    public partial class ITAMService : ServiceBase
    {
        Timer timer = new Timer();
        private bool inAdminMode = false;


        public ITAMService()
        {
            InitializeComponent();
            timer.Elapsed += Timer_Elapsed;
        }

        bool inElapsed = false;

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!inElapsed)
            {
                inElapsed = true;
                GetSystemInfo();
                inElapsed = false;
            }
        }

        protected override void OnStart(string[] args)
        {
            WriteToServiceLog("Service is started at " + DateTime.Now);
            GetSystemInfoToFile();
            //timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 5000;
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            WriteToServiceLog("Service is stopped at " + DateTime.Now);
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            WriteToServiceLog("Service was ran at " + DateTime.Now);
        }

        public void WriteToFile(string message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\SystemInfo";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\SystemInfo\\CurrentUserSystemInfo_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a database file to write to.
                using (StreamWriter writer = File.CreateText(filepath))
                {
                    writer.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter writer = File.AppendText(filepath))
                {
                    writer.WriteLine(message);
                }
            }
        }

        public void WriteToServiceLog(string message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a log file to write to.
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(message);
                }
            }
        }

        public String GetDSN()
        {
            string str = DecryptString(ConfigurationManager.ConnectionStrings["encryptKey"].ToString(), ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
            return str;
        }

        public void GetSystemInfo()
        {
            String SQLStatement = @"
	            exec dbo.cs_spCheckAddUpdateInventoryItem
		            @InventoryIdentifierBarCode, 
                    @Make, 
                    @ModelNumber,
                    @AssignedUser,
                    @SerialNumber,
                    @OSVersion,
		            @OSLicenseNumber, 
                    @MachineName, 
                    @LastLoggedInUser, 
                    @RAMInGigabytes,
		            @MACAddress, 
                    @LastLoggedIPAddress,
                    @CPUID 
                    @CPUSpeed, 
                    @NumberOfProcessors, 
                    @NumberOfRAMSlots 
		            @BuildingName,
                    @RoomNumber,
                    @AssetTypeID,
                    @CapitalItem,
                    @PurchasedDate, 
                    @InventoryDate
	            ";

            using (SqlConnection cn = new SqlConnection(GetDSN()))
            {
                SqlCommand cmd = new SqlCommand(SQLStatement, cn);
                SqlParameter sp = new SqlParameter("InventoryItentifierBarCode", SqlDbType.Int) { Value = null };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@Make", SqlDbType.VarChar, 32) { Value = GetManufacturer() };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@ModelNumber", SqlDbType.VarChar, 32) { Value = "" };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@AssignedUser", SqlDbType.VarChar, 32) { Value = Environment.UserName };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@SerialNumber", SqlDbType.VarChar, 32) { Value = GetSerialNumber() };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@OSVersion", SqlDbType.VarChar, 32) { Value = Environment.OSVersion.ToString() };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@OSLicenseNumber", SqlDbType.VarChar, 32) { Value = "" };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@MachineName", SqlDbType.VarChar, 32) { Value = Environment.MachineName };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@LastLoggedInUser", SqlDbType.VarChar, 32) { Value = "" };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@RAMInGigabytes", SqlDbType.VarChar, 32) { Value = "" };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@MACAddress", SqlDbType.VarChar, 32) { Value = GetMACAddress() };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@LastLoggedIPAddress", SqlDbType.VarChar, 32) { Value = GetLocalIpAddress() };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@CPUID", SqlDbType.VarChar, 32) { Value = GetProcessorId() };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@CPUSpeed", SqlDbType.VarChar, 32) { Value = GetCpuSpeedInGHz().ToString() };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@NumberOfProcessors", SqlDbType.Int) { Value = Environment.ProcessorCount.ToString() };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@NumberOfRAMSlots", SqlDbType.Int) { Value = GetNoRamSlots() };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@BuildingName", SqlDbType.VarChar, 32) { Value = "" };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@RoomNumber", SqlDbType.VarChar, 32) { Value = "" };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@AssetTypeID", SqlDbType.VarChar, 32) { Value = "2" };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@CapitalItem", SqlDbType.Bit) { Value = null };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@PurchasedDate", SqlDbType.Date) { Value = null };
                cmd.Parameters.Add(sp);
                sp = new SqlParameter("@InventoryDate", SqlDbType.Date) { Value = null };
                cmd.Parameters.Add(sp);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void GetSystemInfoToFile()
        {
            WriteToFile($"Manufacturer: {GetManufacturer()}");
            WriteToFile($"Model Number: {GetModelNumber()}");
            WriteToFile(Environment.OSVersion.ToString());
            WriteToFile(Environment.MachineName);
            WriteToFile(Environment.UserName);
            WriteToFile(GetMACAddress()); // Get the MAC Address
            WriteToFile(GetProcessorId()); // Get the ProcessorID
            WriteToFile(GetPhysicalMemory()); // Get RAM Info
            WriteToFile(GetCpuSpeedInGHz().ToString()); // Get the CPU GHz Speed
            WriteToFile(GetNoRamSlots()); // Get the total number of RAM slots
            WriteToFile(Environment.ProcessorCount.ToString());
            WriteToFile(GetLocalIpAddress());
            WriteToFile(GetSerialNumber());
        }

        public static string GetManufacturer()
        {
            string make = null;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Manufacturer FROM Win32_ComputerSystem");
            foreach (ManagementObject process in searcher.Get())
            {
                foreach (PropertyData data in process.Properties)
                    make = data.Value.ToString();
            }
            return make;
        }

        public static string GetModelNumber()
        {
            string model = null;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Model FROM Win32_ComputerSystem");
            foreach (ManagementObject process in searcher.Get())
            {
                foreach (PropertyData data in process.Properties)
                    model = data.Value.ToString();
            }
            return model;
        }

        public static string GetMACAddress()
        {
            ManagementClass mancl = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection manageobcl = mancl.GetInstances();
            string MACAddress = String.Empty;
            foreach (ManagementObject myObj in manageobcl)
            {
                if (MACAddress == String.Empty)
                {
                    if ((bool)myObj["IPEnabled"] == true) MACAddress = myObj["MacAddress"].ToString();
                }
                myObj.Dispose();
            }
            MACAddress = MACAddress.Replace(":", "");
            return MACAddress;
        }

        public static String GetProcessorId()
        {
            ManagementClass mancl = new ManagementClass("win32_processor");
            ManagementObjectCollection manageobcl = mancl.GetInstances();
            String Id = String.Empty;
            foreach (ManagementObject myObj in manageobcl)
            {
                Id = myObj.Properties["processorID"].Value.ToString();
                break;
            }
            return Id;
        }

        public static string GetPhysicalMemory()
        {
            ManagementScope osmanagesys = new ManagementScope();
            ObjectQuery myobjQry = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
            ManagementObjectSearcher oFinder = new ManagementObjectSearcher(osmanagesys, myobjQry);
            ManagementObjectCollection oCollection = oFinder.Get();
            long liveMSize = 0;
            long livecap = 0;
            foreach (ManagementObject obj in oCollection)
            {
                livecap = Convert.ToInt64(obj["Capacity"]);
                liveMSize += livecap;
            }
            liveMSize = (liveMSize / 1024) / 1024 / 1024;
            return liveMSize.ToString() + "GB";
        }

        public static double? GetCpuSpeedInGHz()
        {
            double? GHz = null;
            using (ManagementClass mancl = new ManagementClass("Win32_Processor"))
            {
                foreach (ManagementObject myObj in mancl.GetInstances())
                {
                    GHz = 0.001 * (UInt32)myObj.Properties["CurrentClockSpeed"].Value;
                    break;
                }
            }
            return GHz;
        }

        public static string GetNoRamSlots()
        {
            int MemSlots = 0;
            ManagementScope osmanagesys = new ManagementScope();
            ObjectQuery oQuery2 = new ObjectQuery("SELECT MemoryDevices FROM Win32_PhysicalMemoryArray");
            ManagementObjectSearcher oSearcher2 = new ManagementObjectSearcher(osmanagesys, oQuery2);
            ManagementObjectCollection oCollection2 = oSearcher2.Get();
            foreach (ManagementObject obj in oCollection2)
            {
                MemSlots = Convert.ToInt32(obj["MemoryDevices"]);
            }
            return MemSlots.ToString();
        }

        public string GetLocalIpAddress()
        {
            UnicastIPAddressInformation mostSuitableIp = null;
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var network in networkInterfaces)
            {
                if (network.OperationalStatus != OperationalStatus.Up)
                    continue;
                var properties = network.GetIPProperties();
                if (properties.GatewayAddresses.Count == 0)
                    continue;
                foreach (var address in properties.UnicastAddresses)
                {
                    if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                        continue;
                    if (IPAddress.IsLoopback(address.Address))
                        continue;
                    if (!address.IsDnsEligible)
                    {
                        if (mostSuitableIp == null)
                            mostSuitableIp = address;
                        continue;
                    }
                    // The best IP is the IP got from the DHCP server
                    if (address.PrefixOrigin != PrefixOrigin.Dhcp)
                    {
                        if (mostSuitableIp == null || !mostSuitableIp.IsDnsEligible)
                            mostSuitableIp = address;
                        continue;
                    }
                    return address.Address.ToString();
                }
            }
            return mostSuitableIp != null ? mostSuitableIp.Address.ToString() : "";
        }

        public static string GetSerialNumber()
        {
            string serialNumber = null;
            ManagementObjectSearcher searcher =
                        new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
            ManagementObjectCollection information = searcher.Get();
            foreach (ManagementObject obj in information)
            {
                foreach (PropertyData data in obj.Properties)
                    serialNumber = data.Value.ToString();
            }
            searcher.Dispose();
            return serialNumber;
        }

        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
