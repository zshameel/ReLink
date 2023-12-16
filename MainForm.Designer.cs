namespace ReLink
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.imlButtons = new System.Windows.Forms.ImageList(this.components);
            this.grdRules = new System.Windows.Forms.DataGridView();
            this.colSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatchType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrowserImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colBrowser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFallback = new System.Windows.Forms.Label();
            this.lblDefaultDesc = new System.Windows.Forms.Label();
            this.chkUseDefault = new System.Windows.Forms.CheckBox();
            this.grpDefaultsSection = new System.Windows.Forms.GroupBox();
            this.cboDefaultBrowser = new ImageComboBox.ImageComboBox();
            this.imlBrowsers = new System.Windows.Forms.ImageList(this.components);
            this.grpRulesSection = new System.Windows.Forms.GroupBox();
            this.cboMatchType = new ImageComboBox.ImageComboBox();
            this.cboBrowser = new ImageComboBox.ImageComboBox();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnRemoveUrl = new System.Windows.Forms.Button();
            this.btnAddUrl = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRegister = new System.Windows.Forms.ToolStripButton();
            this.tsbUnregister = new System.Windows.Forms.ToolStripButton();
            this.tsbSetDefault = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdRules)).BeginInit();
            this.grpDefaultsSection.SuspendLayout();
            this.grpRulesSection.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUrl.Location = new System.Drawing.Point(14, 22);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(22, 15);
            this.lblUrl.TabIndex = 0;
            this.lblUrl.Text = "Url";
            // 
            // txtUrl
            // 
            this.txtUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtUrl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.txtUrl.Location = new System.Drawing.Point(168, 21);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(450, 23);
            this.txtUrl.TabIndex = 2;
            // 
            // imlButtons
            // 
            this.imlButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlButtons.ImageStream")));
            this.imlButtons.TransparentColor = System.Drawing.Color.Transparent;
            this.imlButtons.Images.SetKeyName(0, "delete_16x.ico");
            this.imlButtons.Images.SetKeyName(1, "112_UpArrowShort_Green.ico");
            this.imlButtons.Images.SetKeyName(2, "112_DownArrowShort_Orange.ico");
            this.imlButtons.Images.SetKeyName(3, "112_Plus_Green.ico");
            // 
            // grdRules
            // 
            this.grdRules.AllowUserToAddRows = false;
            this.grdRules.AllowUserToDeleteRows = false;
            this.grdRules.AllowUserToOrderColumns = true;
            this.grdRules.AllowUserToResizeRows = false;
            this.grdRules.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSerial,
            this.colMatchType,
            this.colUrl,
            this.colBrowserImage,
            this.colBrowser});
            this.grdRules.Location = new System.Drawing.Point(14, 54);
            this.grdRules.MultiSelect = false;
            this.grdRules.Name = "grdRules";
            this.grdRules.ReadOnly = true;
            this.grdRules.RowHeadersVisible = false;
            this.grdRules.RowTemplate.Height = 24;
            this.grdRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRules.Size = new System.Drawing.Size(763, 360);
            this.grdRules.TabIndex = 6;
            this.grdRules.SelectionChanged += new System.EventHandler(this.grdRules_SelectionChanged);
            // 
            // colSerial
            // 
            this.colSerial.HeaderText = "#";
            this.colSerial.Name = "colSerial";
            this.colSerial.ReadOnly = true;
            this.colSerial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSerial.Width = 45;
            // 
            // colMatchType
            // 
            this.colMatchType.HeaderText = "Match";
            this.colMatchType.Name = "colMatchType";
            this.colMatchType.ReadOnly = true;
            this.colMatchType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMatchType.Width = 80;
            // 
            // colUrl
            // 
            this.colUrl.HeaderText = "Url";
            this.colUrl.Name = "colUrl";
            this.colUrl.ReadOnly = true;
            this.colUrl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colUrl.Width = 435;
            // 
            // colBrowserImage
            // 
            this.colBrowserImage.HeaderText = "";
            this.colBrowserImage.Name = "colBrowserImage";
            this.colBrowserImage.ReadOnly = true;
            this.colBrowserImage.Width = 24;
            // 
            // colBrowser
            // 
            this.colBrowser.HeaderText = "Browser";
            this.colBrowser.Name = "colBrowser";
            this.colBrowser.ReadOnly = true;
            this.colBrowser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBrowser.Width = 150;
            // 
            // lblFallback
            // 
            this.lblFallback.AutoSize = true;
            this.lblFallback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFallback.Location = new System.Drawing.Point(13, 25);
            this.lblFallback.Name = "lblFallback";
            this.lblFallback.Size = new System.Drawing.Size(95, 15);
            this.lblFallback.TabIndex = 0;
            this.lblFallback.Text = "Fallback Browser";
            // 
            // lblDefaultDesc
            // 
            this.lblDefaultDesc.AutoSize = true;
            this.lblDefaultDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDefaultDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDefaultDesc.Location = new System.Drawing.Point(287, 25);
            this.lblDefaultDesc.Name = "lblDefaultDesc";
            this.lblDefaultDesc.Size = new System.Drawing.Size(275, 15);
            this.lblDefaultDesc.TabIndex = 3;
            this.lblDefaultDesc.Text = "(This browser will be used if no rules match the url)";
            // 
            // chkUseDefault
            // 
            this.chkUseDefault.AutoSize = true;
            this.chkUseDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkUseDefault.Location = new System.Drawing.Point(14, 52);
            this.chkUseDefault.Name = "chkUseDefault";
            this.chkUseDefault.Size = new System.Drawing.Size(238, 19);
            this.chkUseDefault.TabIndex = 2;
            this.chkUseDefault.Text = "Use this browser for all Urls (ignore rules)";
            this.chkUseDefault.UseVisualStyleBackColor = true;
            this.chkUseDefault.CheckedChanged += new System.EventHandler(this.chkUseDefault_CheckedChanged);
            // 
            // grpDefaultsSection
            // 
            this.grpDefaultsSection.Controls.Add(this.cboDefaultBrowser);
            this.grpDefaultsSection.Controls.Add(this.chkUseDefault);
            this.grpDefaultsSection.Controls.Add(this.lblFallback);
            this.grpDefaultsSection.Controls.Add(this.lblDefaultDesc);
            this.grpDefaultsSection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpDefaultsSection.Location = new System.Drawing.Point(14, 502);
            this.grpDefaultsSection.Name = "grpDefaultsSection";
            this.grpDefaultsSection.Size = new System.Drawing.Size(826, 85);
            this.grpDefaultsSection.TabIndex = 1;
            this.grpDefaultsSection.TabStop = false;
            this.grpDefaultsSection.Text = "Default Settings";
            // 
            // cboDefaultBrowser
            // 
            this.cboDefaultBrowser.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDefaultBrowser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDefaultBrowser.ImageList = this.imlBrowsers;
            this.cboDefaultBrowser.Indent = 0;
            this.cboDefaultBrowser.ItemHeight = 16;
            this.cboDefaultBrowser.Location = new System.Drawing.Point(128, 21);
            this.cboDefaultBrowser.Name = "cboDefaultBrowser";
            this.cboDefaultBrowser.Size = new System.Drawing.Size(151, 22);
            this.cboDefaultBrowser.TabIndex = 1;
            // 
            // imlBrowsers
            // 
            this.imlBrowsers.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imlBrowsers.ImageSize = new System.Drawing.Size(16, 16);
            this.imlBrowsers.TransparentColor = System.Drawing.Color.Black;
            // 
            // grpRulesSection
            // 
            this.grpRulesSection.Controls.Add(this.cboMatchType);
            this.grpRulesSection.Controls.Add(this.cboBrowser);
            this.grpRulesSection.Controls.Add(this.lblUrl);
            this.grpRulesSection.Controls.Add(this.txtUrl);
            this.grpRulesSection.Controls.Add(this.btnMoveDown);
            this.grpRulesSection.Controls.Add(this.btnMoveUp);
            this.grpRulesSection.Controls.Add(this.btnRemoveUrl);
            this.grpRulesSection.Controls.Add(this.btnAddUrl);
            this.grpRulesSection.Controls.Add(this.grdRules);
            this.grpRulesSection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpRulesSection.Location = new System.Drawing.Point(14, 61);
            this.grpRulesSection.Name = "grpRulesSection";
            this.grpRulesSection.Size = new System.Drawing.Size(826, 434);
            this.grpRulesSection.TabIndex = 0;
            this.grpRulesSection.TabStop = false;
            this.grpRulesSection.Text = "Rules";
            // 
            // cboMatchType
            // 
            this.cboMatchType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMatchType.ImageList = this.imlBrowsers;
            this.cboMatchType.Indent = 0;
            this.cboMatchType.ItemHeight = 16;
            this.cboMatchType.Location = new System.Drawing.Point(51, 21);
            this.cboMatchType.Name = "cboMatchType";
            this.cboMatchType.Size = new System.Drawing.Size(111, 22);
            this.cboMatchType.TabIndex = 10;
            // 
            // cboBrowser
            // 
            this.cboBrowser.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBrowser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrowser.ImageList = this.imlBrowsers;
            this.cboBrowser.Indent = 0;
            this.cboBrowser.ItemHeight = 16;
            this.cboBrowser.Location = new System.Drawing.Point(625, 21);
            this.cboBrowser.Name = "cboBrowser";
            this.cboBrowser.Size = new System.Drawing.Size(151, 22);
            this.cboBrowser.TabIndex = 3;
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveDown.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMoveDown.ImageKey = "112_DownArrowShort_Orange.ico";
            this.btnMoveDown.ImageList = this.imlButtons;
            this.btnMoveDown.Location = new System.Drawing.Point(784, 177);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(33, 32);
            this.btnMoveDown.TabIndex = 9;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveUp.ImageKey = "112_UpArrowShort_Green.ico";
            this.btnMoveUp.ImageList = this.imlButtons;
            this.btnMoveUp.Location = new System.Drawing.Point(784, 143);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(33, 32);
            this.btnMoveUp.TabIndex = 8;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnRemoveUrl
            // 
            this.btnRemoveUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveUrl.ImageKey = "delete_16x.ico";
            this.btnRemoveUrl.ImageList = this.imlButtons;
            this.btnRemoveUrl.Location = new System.Drawing.Point(784, 93);
            this.btnRemoveUrl.Name = "btnRemoveUrl";
            this.btnRemoveUrl.Size = new System.Drawing.Size(33, 32);
            this.btnRemoveUrl.TabIndex = 7;
            this.btnRemoveUrl.UseVisualStyleBackColor = true;
            this.btnRemoveUrl.Click += new System.EventHandler(this.btnRemoveUrl_Click);
            // 
            // btnAddUrl
            // 
            this.btnAddUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUrl.ImageKey = "112_Plus_Green.ico";
            this.btnAddUrl.ImageList = this.imlButtons;
            this.btnAddUrl.Location = new System.Drawing.Point(784, 54);
            this.btnAddUrl.Name = "btnAddUrl";
            this.btnAddUrl.Size = new System.Drawing.Size(33, 32);
            this.btnAddUrl.TabIndex = 4;
            this.btnAddUrl.UseVisualStyleBackColor = true;
            this.btnAddUrl.Click += new System.EventHandler(this.btnAddUrl_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRegister,
            this.tsbUnregister,
            this.tsbSetDefault,
            this.toolStripSeparator1,
            this.tsbSave,
            this.toolStripSeparator2,
            this.tsbAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(852, 39);
            this.toolStrip1.TabIndex = 2;
            // 
            // tsbRegister
            // 
            this.tsbRegister.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRegister.Image = global::ReLink.Properties.Resources.register;
            this.tsbRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRegister.Name = "tsbRegister";
            this.tsbRegister.Size = new System.Drawing.Size(36, 36);
            this.tsbRegister.Text = "Register Re:Link as a browser";
            this.tsbRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // tsbUnregister
            // 
            this.tsbUnregister.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUnregister.Image = global::ReLink.Properties.Resources.unregister;
            this.tsbUnregister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUnregister.Name = "tsbUnregister";
            this.tsbUnregister.Size = new System.Drawing.Size(36, 36);
            this.tsbUnregister.Text = "Unregister Re:Link";
            this.tsbUnregister.Click += new System.EventHandler(this.btnUnregister_Click);
            // 
            // tsbSetDefault
            // 
            this.tsbSetDefault.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSetDefault.Image = global::ReLink.Properties.Resources.setdefault;
            this.tsbSetDefault.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetDefault.Name = "tsbSetDefault";
            this.tsbSetDefault.Size = new System.Drawing.Size(36, 36);
            this.tsbSetDefault.Text = "Set Re:Link as the Default Browser";
            this.tsbSetDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = global::ReLink.Properties.Resources.Save2;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(36, 36);
            this.tsbSave.Text = "Save Rules";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbAbout
            // 
            this.tsbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAbout.Image = global::ReLink.Properties.Resources.About;
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(36, 36);
            this.tsbAbout.Text = "About Re:Link";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(852, 601);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.grpRulesSection);
            this.Controls.Add(this.grpDefaultsSection);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Re:Link";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grdRules)).EndInit();
            this.grpDefaultsSection.ResumeLayout(false);
            this.grpDefaultsSection.PerformLayout();
            this.grpRulesSection.ResumeLayout(false);
            this.grpRulesSection.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnAddUrl;
        private System.Windows.Forms.DataGridView grdRules;
        private System.Windows.Forms.Button btnRemoveUrl;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Label lblFallback;
        private System.Windows.Forms.Label lblDefaultDesc;
        private System.Windows.Forms.CheckBox chkUseDefault;
        private System.Windows.Forms.GroupBox grpDefaultsSection;
        private System.Windows.Forms.GroupBox grpRulesSection;
        private System.Windows.Forms.ImageList imlButtons;
        private System.Windows.Forms.ImageList imlBrowsers;
        private ImageComboBox.ImageComboBox cboDefaultBrowser;
        private ImageComboBox.ImageComboBox cboBrowser;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRegister;
        private System.Windows.Forms.ToolStripButton tsbUnregister;
        private System.Windows.Forms.ToolStripButton tsbSetDefault;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbAbout;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private ImageComboBox.ImageComboBox cboMatchType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatchType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUrl;
        private System.Windows.Forms.DataGridViewImageColumn colBrowserImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrowser;
    }
}

