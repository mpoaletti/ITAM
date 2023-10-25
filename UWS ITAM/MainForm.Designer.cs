
namespace UWS_ITAM
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.lblBarCodeInput = new System.Windows.Forms.Label();
			this.txtBarCode = new System.Windows.Forms.TextBox();
			this.btnBarCodeClear = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.btnGetSystemInfo = new System.Windows.Forms.Button();
			this.txtMake = new System.Windows.Forms.TextBox();
			this.txtSerialNumber = new System.Windows.Forms.TextBox();
			this.txtModel = new System.Windows.Forms.TextBox();
			this.lblMake = new System.Windows.Forms.Label();
			this.lblSerialNumber = new System.Windows.Forms.Label();
			this.lblModel = new System.Windows.Forms.Label();
			this.lblISVersion = new System.Windows.Forms.Label();
			this.txtOSVersion = new System.Windows.Forms.TextBox();
			this.lblMachineName = new System.Windows.Forms.Label();
			this.txtMachineName = new System.Windows.Forms.TextBox();
			this.lblUserName = new System.Windows.Forms.Label();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.lblRam = new System.Windows.Forms.Label();
			this.txtRAM = new System.Windows.Forms.TextBox();
			this.lblCPUID = new System.Windows.Forms.Label();
			this.txtCPU = new System.Windows.Forms.TextBox();
			this.lblMacAddress = new System.Windows.Forms.Label();
			this.txtMACAddress = new System.Windows.Forms.TextBox();
			this.lblDate = new System.Windows.Forms.Label();
			this.txtDate = new System.Windows.Forms.TextBox();
			this.lblAssetNumber = new System.Windows.Forms.Label();
			this.lblPurchaseDate = new System.Windows.Forms.Label();
			this.txtPurchaseDate = new System.Windows.Forms.TextBox();
			this.chkCapitalItem = new System.Windows.Forms.CheckBox();
			this.lblCapitalItem = new System.Windows.Forms.Label();
			this.lblCPUSpeed = new System.Windows.Forms.Label();
			this.txtCPUSpeed = new System.Windows.Forms.TextBox();
			this.lblRamSlots = new System.Windows.Forms.Label();
			this.txtRAMSlots = new System.Windows.Forms.TextBox();
			this.lblNumberOfProcessors = new System.Windows.Forms.Label();
			this.txtNoProcessors = new System.Windows.Forms.TextBox();
			this.cbxAssetType = new System.Windows.Forms.ComboBox();
			this.lblAssetType = new System.Windows.Forms.Label();
			this.lblIPAddress = new System.Windows.Forms.Label();
			this.txtIPAddress = new System.Windows.Forms.TextBox();
			this.lblUpdateDate = new System.Windows.Forms.Label();
			this.lblAssignedUser = new System.Windows.Forms.Label();
			this.txtAssignedUser = new System.Windows.Forms.TextBox();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnAdmin = new System.Windows.Forms.Button();
			this.lblBuioldingName = new System.Windows.Forms.Label();
			this.txtRoomNumber = new System.Windows.Forms.TextBox();
			this.lblRoomNumber = new System.Windows.Forms.Label();
			this.lblOSLicense = new System.Windows.Forms.Label();
			this.txtLicense = new System.Windows.Forms.TextBox();
			this.lblInfo = new System.Windows.Forms.Label();
			this.cbxBuildingName = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// lblBarCodeInput
			// 
			resources.ApplyResources(this.lblBarCodeInput, "lblBarCodeInput");
			this.lblBarCodeInput.Name = "lblBarCodeInput";
			// 
			// txtBarCode
			// 
			resources.ApplyResources(this.txtBarCode, "txtBarCode");
			this.txtBarCode.Name = "txtBarCode";
			// 
			// btnBarCodeClear
			// 
			this.btnBarCodeClear.AutoEllipsis = true;
			resources.ApplyResources(this.btnBarCodeClear, "btnBarCodeClear");
			this.btnBarCodeClear.Name = "btnBarCodeClear";
			this.btnBarCodeClear.UseVisualStyleBackColor = true;
			this.btnBarCodeClear.Click += new System.EventHandler(this.btnBarCode_Click);
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// btnGetSystemInfo
			// 
			this.btnGetSystemInfo.AutoEllipsis = true;
			resources.ApplyResources(this.btnGetSystemInfo, "btnGetSystemInfo");
			this.btnGetSystemInfo.Name = "btnGetSystemInfo";
			this.btnGetSystemInfo.UseVisualStyleBackColor = true;
			this.btnGetSystemInfo.Click += new System.EventHandler(this.btnGetSystemInfo_Click);
			// 
			// txtMake
			// 
			resources.ApplyResources(this.txtMake, "txtMake");
			this.txtMake.Name = "txtMake";
			// 
			// txtSerialNumber
			// 
			resources.ApplyResources(this.txtSerialNumber, "txtSerialNumber");
			this.txtSerialNumber.Name = "txtSerialNumber";
			// 
			// txtModel
			// 
			resources.ApplyResources(this.txtModel, "txtModel");
			this.txtModel.Name = "txtModel";
			// 
			// lblMake
			// 
			resources.ApplyResources(this.lblMake, "lblMake");
			this.lblMake.Name = "lblMake";
			// 
			// lblSerialNumber
			// 
			resources.ApplyResources(this.lblSerialNumber, "lblSerialNumber");
			this.lblSerialNumber.Name = "lblSerialNumber";
			// 
			// lblModel
			// 
			resources.ApplyResources(this.lblModel, "lblModel");
			this.lblModel.Name = "lblModel";
			// 
			// lblISVersion
			// 
			resources.ApplyResources(this.lblISVersion, "lblISVersion");
			this.lblISVersion.Name = "lblISVersion";
			// 
			// txtOSVersion
			// 
			resources.ApplyResources(this.txtOSVersion, "txtOSVersion");
			this.txtOSVersion.Name = "txtOSVersion";
			// 
			// lblMachineName
			// 
			resources.ApplyResources(this.lblMachineName, "lblMachineName");
			this.lblMachineName.Name = "lblMachineName";
			// 
			// txtMachineName
			// 
			resources.ApplyResources(this.txtMachineName, "txtMachineName");
			this.txtMachineName.Name = "txtMachineName";
			// 
			// lblUserName
			// 
			resources.ApplyResources(this.lblUserName, "lblUserName");
			this.lblUserName.Name = "lblUserName";
			// 
			// txtUserName
			// 
			resources.ApplyResources(this.txtUserName, "txtUserName");
			this.txtUserName.Name = "txtUserName";
			// 
			// lblRam
			// 
			resources.ApplyResources(this.lblRam, "lblRam");
			this.lblRam.Name = "lblRam";
			// 
			// txtRAM
			// 
			resources.ApplyResources(this.txtRAM, "txtRAM");
			this.txtRAM.Name = "txtRAM";
			// 
			// lblCPUID
			// 
			resources.ApplyResources(this.lblCPUID, "lblCPUID");
			this.lblCPUID.Name = "lblCPUID";
			// 
			// txtCPU
			// 
			resources.ApplyResources(this.txtCPU, "txtCPU");
			this.txtCPU.Name = "txtCPU";
			// 
			// lblMacAddress
			// 
			resources.ApplyResources(this.lblMacAddress, "lblMacAddress");
			this.lblMacAddress.Name = "lblMacAddress";
			// 
			// txtMACAddress
			// 
			resources.ApplyResources(this.txtMACAddress, "txtMACAddress");
			this.txtMACAddress.Name = "txtMACAddress";
			// 
			// lblDate
			// 
			resources.ApplyResources(this.lblDate, "lblDate");
			this.lblDate.Name = "lblDate";
			// 
			// txtDate
			// 
			resources.ApplyResources(this.txtDate, "txtDate");
			this.txtDate.Name = "txtDate";
			// 
			// lblAssetNumber
			// 
			resources.ApplyResources(this.lblAssetNumber, "lblAssetNumber");
			this.lblAssetNumber.Name = "lblAssetNumber";
			// 
			// lblPurchaseDate
			// 
			resources.ApplyResources(this.lblPurchaseDate, "lblPurchaseDate");
			this.lblPurchaseDate.Name = "lblPurchaseDate";
			// 
			// txtPurchaseDate
			// 
			resources.ApplyResources(this.txtPurchaseDate, "txtPurchaseDate");
			this.txtPurchaseDate.Name = "txtPurchaseDate";
			// 
			// chkCapitalItem
			// 
			resources.ApplyResources(this.chkCapitalItem, "chkCapitalItem");
			this.chkCapitalItem.Name = "chkCapitalItem";
			this.chkCapitalItem.UseVisualStyleBackColor = true;
			// 
			// lblCapitalItem
			// 
			resources.ApplyResources(this.lblCapitalItem, "lblCapitalItem");
			this.lblCapitalItem.Name = "lblCapitalItem";
			// 
			// lblCPUSpeed
			// 
			resources.ApplyResources(this.lblCPUSpeed, "lblCPUSpeed");
			this.lblCPUSpeed.Name = "lblCPUSpeed";
			// 
			// txtCPUSpeed
			// 
			resources.ApplyResources(this.txtCPUSpeed, "txtCPUSpeed");
			this.txtCPUSpeed.Name = "txtCPUSpeed";
			// 
			// lblRamSlots
			// 
			resources.ApplyResources(this.lblRamSlots, "lblRamSlots");
			this.lblRamSlots.Name = "lblRamSlots";
			// 
			// txtRAMSlots
			// 
			resources.ApplyResources(this.txtRAMSlots, "txtRAMSlots");
			this.txtRAMSlots.Name = "txtRAMSlots";
			// 
			// lblNumberOfProcessors
			// 
			resources.ApplyResources(this.lblNumberOfProcessors, "lblNumberOfProcessors");
			this.lblNumberOfProcessors.Name = "lblNumberOfProcessors";
			// 
			// txtNoProcessors
			// 
			resources.ApplyResources(this.txtNoProcessors, "txtNoProcessors");
			this.txtNoProcessors.Name = "txtNoProcessors";
			// 
			// cbxAssetType
			// 
			resources.ApplyResources(this.cbxAssetType, "cbxAssetType");
			this.cbxAssetType.FormattingEnabled = true;
			this.cbxAssetType.Items.AddRange(new object[] {
            resources.GetString("cbxAssetType.Items"),
            resources.GetString("cbxAssetType.Items1"),
            resources.GetString("cbxAssetType.Items2"),
            resources.GetString("cbxAssetType.Items3"),
            resources.GetString("cbxAssetType.Items4"),
            resources.GetString("cbxAssetType.Items5"),
            resources.GetString("cbxAssetType.Items6"),
            resources.GetString("cbxAssetType.Items7"),
            resources.GetString("cbxAssetType.Items8"),
            resources.GetString("cbxAssetType.Items9")});
			this.cbxAssetType.Name = "cbxAssetType";
			// 
			// lblAssetType
			// 
			resources.ApplyResources(this.lblAssetType, "lblAssetType");
			this.lblAssetType.Name = "lblAssetType";
			// 
			// lblIPAddress
			// 
			resources.ApplyResources(this.lblIPAddress, "lblIPAddress");
			this.lblIPAddress.Name = "lblIPAddress";
			// 
			// txtIPAddress
			// 
			resources.ApplyResources(this.txtIPAddress, "txtIPAddress");
			this.txtIPAddress.Name = "txtIPAddress";
			// 
			// lblUpdateDate
			// 
			resources.ApplyResources(this.lblUpdateDate, "lblUpdateDate");
			this.lblUpdateDate.Name = "lblUpdateDate";
			// 
			// lblAssignedUser
			// 
			resources.ApplyResources(this.lblAssignedUser, "lblAssignedUser");
			this.lblAssignedUser.Name = "lblAssignedUser";
			// 
			// txtAssignedUser
			// 
			resources.ApplyResources(this.txtAssignedUser, "txtAssignedUser");
			this.txtAssignedUser.Name = "txtAssignedUser";
			// 
			// btnUpdate
			// 
			this.btnUpdate.AutoEllipsis = true;
			resources.ApplyResources(this.btnUpdate, "btnUpdate");
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnAdmin
			// 
			this.btnAdmin.AutoEllipsis = true;
			resources.ApplyResources(this.btnAdmin, "btnAdmin");
			this.btnAdmin.Name = "btnAdmin";
			this.btnAdmin.UseVisualStyleBackColor = true;
			this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
			// 
			// lblBuioldingName
			// 
			resources.ApplyResources(this.lblBuioldingName, "lblBuioldingName");
			this.lblBuioldingName.Name = "lblBuioldingName";
			// 
			// txtRoomNumber
			// 
			resources.ApplyResources(this.txtRoomNumber, "txtRoomNumber");
			this.txtRoomNumber.Name = "txtRoomNumber";
			// 
			// lblRoomNumber
			// 
			resources.ApplyResources(this.lblRoomNumber, "lblRoomNumber");
			this.lblRoomNumber.Name = "lblRoomNumber";
			// 
			// lblOSLicense
			// 
			resources.ApplyResources(this.lblOSLicense, "lblOSLicense");
			this.lblOSLicense.Name = "lblOSLicense";
			// 
			// txtLicense
			// 
			resources.ApplyResources(this.txtLicense, "txtLicense");
			this.txtLicense.Name = "txtLicense";
			// 
			// lblInfo
			// 
			resources.ApplyResources(this.lblInfo, "lblInfo");
			this.lblInfo.Name = "lblInfo";
			// 
			// cbxBuildingName
			// 
			resources.ApplyResources(this.cbxBuildingName, "cbxBuildingName");
			this.cbxBuildingName.FormattingEnabled = true;
			this.cbxBuildingName.Items.AddRange(new object[] {
            resources.GetString("cbxBuildingName.Items"),
            resources.GetString("cbxBuildingName.Items1"),
            resources.GetString("cbxBuildingName.Items2"),
            resources.GetString("cbxBuildingName.Items3"),
            resources.GetString("cbxBuildingName.Items4"),
            resources.GetString("cbxBuildingName.Items5"),
            resources.GetString("cbxBuildingName.Items6"),
            resources.GetString("cbxBuildingName.Items7"),
            resources.GetString("cbxBuildingName.Items8"),
            resources.GetString("cbxBuildingName.Items9"),
            resources.GetString("cbxBuildingName.Items10"),
            resources.GetString("cbxBuildingName.Items11"),
            resources.GetString("cbxBuildingName.Items12"),
            resources.GetString("cbxBuildingName.Items13"),
            resources.GetString("cbxBuildingName.Items14"),
            resources.GetString("cbxBuildingName.Items15"),
            resources.GetString("cbxBuildingName.Items16"),
            resources.GetString("cbxBuildingName.Items17"),
            resources.GetString("cbxBuildingName.Items18"),
            resources.GetString("cbxBuildingName.Items19")});
			this.cbxBuildingName.Name = "cbxBuildingName";
			// 
			// frmMain
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cbxBuildingName);
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.lblOSLicense);
			this.Controls.Add(this.txtLicense);
			this.Controls.Add(this.lblRoomNumber);
			this.Controls.Add(this.txtRoomNumber);
			this.Controls.Add(this.lblBuioldingName);
			this.Controls.Add(this.btnAdmin);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.lblAssignedUser);
			this.Controls.Add(this.txtAssignedUser);
			this.Controls.Add(this.lblUpdateDate);
			this.Controls.Add(this.lblIPAddress);
			this.Controls.Add(this.txtIPAddress);
			this.Controls.Add(this.lblAssetType);
			this.Controls.Add(this.cbxAssetType);
			this.Controls.Add(this.lblNumberOfProcessors);
			this.Controls.Add(this.txtNoProcessors);
			this.Controls.Add(this.lblRamSlots);
			this.Controls.Add(this.txtRAMSlots);
			this.Controls.Add(this.lblCPUSpeed);
			this.Controls.Add(this.txtCPUSpeed);
			this.Controls.Add(this.lblCapitalItem);
			this.Controls.Add(this.chkCapitalItem);
			this.Controls.Add(this.lblPurchaseDate);
			this.Controls.Add(this.txtPurchaseDate);
			this.Controls.Add(this.lblAssetNumber);
			this.Controls.Add(this.lblDate);
			this.Controls.Add(this.txtDate);
			this.Controls.Add(this.lblMacAddress);
			this.Controls.Add(this.txtMACAddress);
			this.Controls.Add(this.lblCPUID);
			this.Controls.Add(this.txtCPU);
			this.Controls.Add(this.lblRam);
			this.Controls.Add(this.txtRAM);
			this.Controls.Add(this.lblUserName);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.lblMachineName);
			this.Controls.Add(this.txtMachineName);
			this.Controls.Add(this.lblISVersion);
			this.Controls.Add(this.txtOSVersion);
			this.Controls.Add(this.lblModel);
			this.Controls.Add(this.lblSerialNumber);
			this.Controls.Add(this.lblMake);
			this.Controls.Add(this.txtModel);
			this.Controls.Add(this.txtSerialNumber);
			this.Controls.Add(this.txtMake);
			this.Controls.Add(this.btnGetSystemInfo);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnBarCodeClear);
			this.Controls.Add(this.txtBarCode);
			this.Controls.Add(this.lblBarCodeInput);
			this.Name = "frmMain";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBarCodeInput;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Button btnBarCodeClear;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGetSystemInfo;
        private System.Windows.Forms.TextBox txtMake;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label lblMake;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblISVersion;
        private System.Windows.Forms.TextBox txtOSVersion;
        private System.Windows.Forms.Label lblMachineName;
        private System.Windows.Forms.TextBox txtMachineName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblRam;
        private System.Windows.Forms.TextBox txtRAM;
        private System.Windows.Forms.Label lblCPUID;
        private System.Windows.Forms.TextBox txtCPU;
        private System.Windows.Forms.Label lblMacAddress;
        private System.Windows.Forms.TextBox txtMACAddress;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label lblAssetNumber;
        private System.Windows.Forms.Label lblPurchaseDate;
        private System.Windows.Forms.TextBox txtPurchaseDate;
        private System.Windows.Forms.CheckBox chkCapitalItem;
        private System.Windows.Forms.Label lblCapitalItem;
        private System.Windows.Forms.Label lblCPUSpeed;
        private System.Windows.Forms.TextBox txtCPUSpeed;
        private System.Windows.Forms.Label lblRamSlots;
        private System.Windows.Forms.TextBox txtRAMSlots;
        private System.Windows.Forms.Label lblNumberOfProcessors;
        private System.Windows.Forms.TextBox txtNoProcessors;
        private System.Windows.Forms.ComboBox cbxAssetType;
        private System.Windows.Forms.Label lblAssetType;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label lblUpdateDate;
        private System.Windows.Forms.Label lblAssignedUser;
        private System.Windows.Forms.TextBox txtAssignedUser;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Label lblBuioldingName;
        private System.Windows.Forms.TextBox txtRoomNumber;
        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.Label lblOSLicense;
        private System.Windows.Forms.TextBox txtLicense;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ComboBox cbxBuildingName;
    }
}

