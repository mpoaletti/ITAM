using System;
using System.IO;
using System.Management;
using System.Management.Instrumentation;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;


namespace UWS_ITAM {
  public partial class frmMain : Form {
		private bool inAdminMode = false;

		public frmMain() {
			InitializeComponent();
			DateTime dt = DateTime.Now;
			txtDate.Text = Convert.ToDateTime(dt.ToString("d")).ToString("d");
			}

		private void btnBarCode_Click(object sender, EventArgs e) {
			txtBarCode.Text = "";
			txtBarCode.Focus();
			}

		public void btnGetSystemInfo_Click(object sender, EventArgs e) {
			try {
				txtOSVersion.Text = Environment.OSVersion.ToString();
				txtMachineName.Text = Environment.MachineName;
				txtUserName.Text = Environment.UserName;
				txtMACAddress.Text = GetMACAddress(); //Get the MAC Address;
				txtCPU.Text = GetProcessorId(); // Get the ProcessorID
				txtRAM.Text = GetPhysicalMemory(); //Get Ram Info 
				txtCPUSpeed.Text = GetCpuSpeedInGHz().Value.ToString(); // Getthe CPU GHz Speed 
				txtRAMSlots.Text = GetNoRamSlots(); // Get the total number of RAM Slots
				txtNoProcessors.Text = Environment.ProcessorCount.ToString();
				txtIPAddress.Text = GetLocalIpAddress();
				//txtWindowsLicense.Text = GetRegistryDigitalProductId(Key.Windows).ToString();
				// Get the Serial Number from the BIOS using WMI 
				ManagementObjectSearcher searcher =
						new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
				ManagementObjectCollection information = searcher.Get();
				foreach (ManagementObject obj in information) {
					foreach (PropertyData data in obj.Properties)
						txtSerialNumber.Text = data.Value.ToString();
					}
				RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
				RegistryKey windowsNTKey = localMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion");
				object productID = windowsNTKey.GetValue("ProductId");
				txtLicense.Text = productID.ToString();
				}
			catch (Exception ex) {
				MessageBox.Show(ex.Message);
				}
			}

		public enum Key { Windows };
		public static byte[] GetRegistryDigitalProductId(Key key) {
			byte[] digitalProductId = null;
			RegistryKey registry = null;
			switch (key) {
				case Key.Windows:
						registry =
							Registry.LocalMachine.
								OpenSubKey(
									@"SOFTWARE\Microsoft\Windows NT\CurrentVersion",
										false);
						break;
				}
			if (registry != null) {
				digitalProductId = registry.GetValue("ProductId") as byte[];
				registry.Close();
				}
			return digitalProductId;
			}

		public static string DecodeProductKey(byte[] digitalProductId) {
			const int keyStartIndex = 52;
			const int keyEndIndex = keyStartIndex + 15;
			char[] digits = new char[] {
				'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'M', 'P', 'Q', 'R',
				'T', 'V', 'W', 'X', 'Y', '2', '3', '4', '6', '7', '8', '9',
				};
			const int decodeLength = 29;
			const int decodeStringLength = 15;
			char[] decodedChars = new char[decodeLength];
			ArrayList hexPid = new ArrayList();
			for (int i = keyStartIndex; i <= keyEndIndex; i++) {
				hexPid.Add(digitalProductId[i]);
				}
			for (int i = decodeLength - 1; i >= 0; i--) {
				if ((i + 1) % 6 == 0) {
					decodedChars[i] = '-';
					}
				else {
					int digitMapIndex = 0;
					for (int j = decodeStringLength - 1; j >= 0; j--) {
						int byteValue = (digitMapIndex << 8) | (byte)hexPid[j];
						hexPid[j] = (byte)(byteValue / 24);
						digitMapIndex = byteValue % 24;
						decodedChars[i] = digits[digitMapIndex];
						}
					}
				}
			return new string(decodedChars);
			}
		public string GetLocalIpAddress() {
			UnicastIPAddressInformation mostSuitableIp = null;
			var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
			foreach (var network in networkInterfaces) {
				if (network.OperationalStatus != OperationalStatus.Up)
					continue;
				var properties = network.GetIPProperties();
				if (properties.GatewayAddresses.Count == 0)
					continue;
				foreach (var address in properties.UnicastAddresses) {
					if (address.Address.AddressFamily != AddressFamily.InterNetwork)
						continue;
					if (IPAddress.IsLoopback(address.Address))
						continue;
					if (!address.IsDnsEligible) {
						if (mostSuitableIp == null)
							mostSuitableIp = address;
						continue;
						}
					// The best IP is the IP got from DHCP server
					if (address.PrefixOrigin != PrefixOrigin.Dhcp) {
						if (mostSuitableIp == null || !mostSuitableIp.IsDnsEligible)
							mostSuitableIp = address;
						continue;
						}
					return address.Address.ToString();
					}
				}
			return mostSuitableIp != null ? mostSuitableIp.Address.ToString() : "";
			}

		public static String GetComputerName() {
			ManagementClass mancl = new ManagementClass("Win32_ComputerSystem");
			ManagementObjectCollection manageobcl = mancl.GetInstances();
			String info = String.Empty;
			foreach (ManagementObject myObj in manageobcl) {
				info = (string)myObj["Name"];
				//myObj.Properties["Name"].Value.ToString();
				//break;
				}
			return info;
			}

		public static double? GetCpuSpeedInGHz() {
			double? GHz = null;
			using (ManagementClass mancl = new ManagementClass("Win32_Processor")) {
				foreach (ManagementObject myObj in mancl.GetInstances()) {
					GHz = 0.001 * (UInt32)myObj.Properties["CurrentClockSpeed"].Value;
					break;
					}
				}
			return GHz;
			}

		public static string GetPhysicalMemory() {
			ManagementScope osmanagesys = new ManagementScope();
			ObjectQuery myobjQry = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
			ManagementObjectSearcher oFinder = new ManagementObjectSearcher(osmanagesys, myobjQry);
			ManagementObjectCollection oCollection = oFinder.Get();
			long liveMSize = 0;
			long livecap = 0;
			foreach (ManagementObject obj in oCollection) {
				livecap = Convert.ToInt64(obj["Capacity"]);
				liveMSize += livecap;
				}
			liveMSize = (liveMSize / 1024) / 1024;
			return liveMSize.ToString() + "MB";
			}

		public static string GetNoRamSlots() {
			int MemSlots = 0;
			ManagementScope osmanagesys = new ManagementScope();
			ObjectQuery oQuery2 = new ObjectQuery("SELECT MemoryDevices FROM Win32_PhysicalMemoryArray");
			ManagementObjectSearcher oSearcher2 = new ManagementObjectSearcher(osmanagesys, oQuery2);
			ManagementObjectCollection oCollection2 = oSearcher2.Get();
			foreach (ManagementObject obj in oCollection2) {
				MemSlots = Convert.ToInt32(obj["MemoryDevices"]);
				}
			return MemSlots.ToString();
			}
  
		public static String GetProcessorId() {
			ManagementClass mancl = new ManagementClass("win32_processor");
			ManagementObjectCollection manageobcl = mancl.GetInstances();
			String Id = String.Empty;
			foreach (ManagementObject myObj in manageobcl) {
				Id = myObj.Properties["processorID"].Value.ToString();
				break;
				}
			return Id;
			}

		public static string GetMACAddress() {
			ManagementClass mancl = new ManagementClass("Win32_NetworkAdapterConfiguration");
			ManagementObjectCollection manageobcl = mancl.GetInstances();
			string MACAddress = String.Empty;
			foreach (ManagementObject myObj in manageobcl) {
				if (MACAddress == String.Empty) {
					if ((bool)myObj["IPEnabled"] == true) MACAddress = myObj["MacAddress"].ToString();
					}
				myObj.Dispose();
				}
			MACAddress = MACAddress.Replace(":", "");
			return MACAddress;
			}

		//IsAdministrationRules is only for the software that insatlls on new computers.  
		//Do not add this to the service app.

		private static bool IsAdministrationRules() {
			// do not add this code to the service app - we need the service app to update the record every two weeks.
			try {
				using (WindowsIdentity identity = WindowsIdentity.GetCurrent()) {
					bool b = (new WindowsPrincipal(identity)).IsInRole(WindowsBuiltInRole.Administrator);
					if (!b) {
						MessageBox.Show("You are not Administrator on your PC.  Contact the help desk and submit a ticket for Professional Services");
						System.Windows.Forms.Application.Exit();
						}  
					return b;   
					}
				}
			catch {
				return false;
				}
			}

		private void frmMain_Load(object sender, EventArgs e) {
			//Do not add this nexst line of code to the service app.  
			IsAdministrationRules();
			btnAdmin.Visible = false;
			string Admin;
			Admin = Environment.UserName.ToUpper();
			switch (Admin) {
				case "JCONLEY1":  case "CBARNAB1": case "MPOALETT": case "RMONTGO3": case "EFURZLAN":
					btnAdmin.Visible = true;
					break;
				default:
					btnAdmin.Visible = false;
					break;
				}
			chkCapitalItem.Enabled = false;
			}

		private void btnUpdate_Click(object sender, EventArgs e) {
			// Needs code to push what is on the screen to push info to the database
			// Needs SQL Control Code from WinMon app --  see below the 1st try - catch statemewnt
			// Add SQL Code here to update what is in the text fields to the database 
			// Use a try-catch-finally where the last line of code in th catch closes the db connection.
			// Theoretically the finally will never run but I want it in there anyway as a best practice (Mike P)
			// Add that same line of code in the finally to ensure it will always close the db connection 
			txtOSVersion.Text= "";
			txtMachineName.Text = ""; ;
			txtUserName.Text = "";
			txtMACAddress.Text = "";
			txtCPU.Text = "";
			txtRAM.Text = "";
			txtCPUSpeed.Text = "";
			txtRAMSlots.Text = "";
			txtNoProcessors.Text = "";
			txtIPAddress.Text = "";
			txtSerialNumber.Text = "";
			txtMake.Text = "";
			txtModel.Text = "";
			txtAssignedUser.Text = "";
			txtRoomNumber.Text = "";
			cbxBuildingName.Text = "";
			txtLicense.Text = "";
			chkCapitalItem.Text = "";
			cbxAssetType.Text = "";
			}

		private void btnAdmin_Click(object sender, EventArgs e) {
			if(inAdminMode==true) {
				try {
					txtOSVersion.Enabled = false;
					txtMachineName.Enabled = false;
					txtUserName.Enabled = false;
					txtMACAddress.Enabled = false;
					txtCPU.Enabled = false;
					txtRAM.Enabled = false;
					txtCPUSpeed.Enabled = false;
					txtRAMSlots.Enabled = false;
					txtNoProcessors.Enabled = false;
					txtIPAddress.Enabled = false;
					txtSerialNumber.Enabled = false;
					txtMake.Enabled = false;
					txtModel.Enabled = false;
					txtAssignedUser.Enabled = false;
					txtRoomNumber.Enabled = false;
					cbxBuildingName.Enabled = false;
					txtLicense.Enabled = false;
					chkCapitalItem.Enabled = false;
					cbxAssetType.Enabled = false;
					btnAdmin.Text = "Admin Override";
					inAdminMode = false;
					}
				catch (Exception ex) {
					MessageBox.Show(ex.Message);
					}
				}
			else {
				try {
					txtOSVersion.Enabled = true;
					txtMachineName.Enabled = true;
					txtUserName.Enabled = true;
					txtMACAddress.Enabled = true;
					txtCPU.Enabled = true;
					txtRAM.Enabled = true;
					txtCPUSpeed.Enabled = true;
					txtRAMSlots.Enabled = true;
					txtNoProcessors.Enabled = true;
					txtIPAddress.Enabled = true;
					txtSerialNumber.Enabled = true;
					txtMake.Enabled = true;
					txtModel.Enabled = true;
					txtAssignedUser.Enabled = true;
					txtRoomNumber.Enabled = true;
					cbxBuildingName.Enabled = true;
					txtLicense.Enabled = true;
					chkCapitalItem.Enabled = true;
					cbxAssetType.Enabled = true;
					btnAdmin.Text = "Exit Admin";
					inAdminMode = true;
					}
				catch (Exception ex) {
					MessageBox.Show(ex.Message);
					}
				}
			}
		}
	}






