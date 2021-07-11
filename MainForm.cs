/********************************************************************
Copyright (c) Shameel Ahmed.  All rights reserved.
********************************************************************/

using ImageComboBox;
using ReLink.Core;
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ReLink
{
    public partial class MainForm : Form {
        static MainForm _instance;

        static MainForm() {
            _instance = new MainForm();
        }

        public MainForm() {
            InitializeComponent();
        }

        static internal MainForm Instance {
            get {
                return _instance;
            }
        }

        private void MainForm_Load(object sender, EventArgs e) {
            InitBrowserList(cboBrowser);
            InitBrowserList(cboDefaultBrowser);
            InitMatchTypesList();
            InitSettings();
        }

        private void MainForm_Shown(object sender, EventArgs e) {
            CheckIfDefault();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = !SaveSettings();
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            BrowserManager.RegisterOrUnregisterAsAdmin(true);
            ToastForm.ShowToast("Re:Link has been successfully registered as a browser.");
        }

        private void btnUnregister_Click(object sender, EventArgs e) {
            BrowserManager.RegisterOrUnregisterAsAdmin(false);
            ToastForm.ShowToast("Re:Link has been unregistered as a browser.");
        }

        private void btnDefault_Click(object sender, EventArgs e) {
            BrowserManager.SetRelinkAsDefaultBrowser();
            ToastForm.ShowToast("Select ReLink as your default browser under Web Browser");
        }

        private void btnAddUrl_Click(object sender, EventArgs e) {
            string url = BrowserManager.GetSanitizedUrl(txtUrl.Text);
            string browserName = cboBrowser.Text;
            string matchType = cboMatchType.Text;
            if (string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(browserName)) {
                return;
            }

            BrowserInfo browser = BrowserManager.GetBrowserByName(browserName);

            int rowIndex = -1;
            foreach (DataGridViewRow r in grdRules.Rows) {
                if (Convert.ToString(r.Cells[2].Value) == url) {
                    rowIndex = r.Index;
                    break;
                }
            }
            DataGridViewRow row;
            if (rowIndex >= 0) {
                row = grdRules.Rows[rowIndex];
            } else {
                row = grdRules.Rows[grdRules.Rows.Add()];
                rowIndex = row.Index;
            }

            row.Cells[0].Value = grdRules.Rows.Count - 1;
            row.Cells[1].Value = matchType;
            row.Cells[2].Value = url;
            row.Cells[3].Value = imlBrowsers.Images[browserName];
            row.Cells[4].Value = browserName;

            RenumberGridRows();
            SelectRow(rowIndex);
        }

        private void btnRemoveUrl_Click(object sender, EventArgs e) {
            if (grdRules.SelectedRows.Count == 0) {
                return;
            }

            int rowIndex = grdRules.SelectedRows[0].Index;
            string url = Convert.ToString(grdRules.Rows[rowIndex].Cells[2].Value);

            if (MessageBox.Show(string.Format("Remove '{0}'?", url),
                                Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) {
                return;
            }

            grdRules.Rows.RemoveAt(grdRules.SelectedRows[0].Index);
            RenumberGridRows();
            SelectRow(rowIndex);
        }

        private void btnMoveUp_Click(object sender, EventArgs e) {
            if (grdRules.Rows.Count <= 1
                    || grdRules.SelectedRows.Count == 0
                    || grdRules.SelectedRows[0].Index == 0) {
                return;
            }

            int rowIndex = grdRules.SelectedRows[0].Index;
            DataGridViewRow row = (DataGridViewRow)grdRules.Rows[rowIndex];
            int ruleId = Convert.ToInt32(row.Cells[0].Value);
            string matchType = Convert.ToString(row.Cells[1].Value);
            string url = Convert.ToString(row.Cells[2].Value);
            string browserName = Convert.ToString(row.Cells[4].Value);

            grdRules.Rows.RemoveAt(rowIndex);

            grdRules.Rows.Insert(rowIndex - 1, row);
            row.Cells[0].Value = ruleId;
            row.Cells[1].Value = matchType;
            row.Cells[2].Value = url;
            row.Cells[3].Value = imlBrowsers.Images[browserName];
            row.Cells[4].Value = browserName;

            RenumberGridRows();
            SelectRow(rowIndex - 1);
        }

        private void btnMoveDown_Click(object sender, EventArgs e) {
            if (grdRules.Rows.Count <= 1
                    || grdRules.SelectedRows.Count == 0
                    || grdRules.SelectedRows[0].Index == grdRules.Rows.Count - 1) {
                return;
            }

            int rowIndex = grdRules.SelectedRows[0].Index;
            DataGridViewRow row = (DataGridViewRow)grdRules.Rows[rowIndex];
            int ruleId = Convert.ToInt32(row.Cells[0].Value);
            string matchType = Convert.ToString(row.Cells[1].Value);
            string url = Convert.ToString(row.Cells[2].Value);
            string browserName = Convert.ToString(row.Cells[4].Value);

            grdRules.Rows.RemoveAt(rowIndex);

            grdRules.Rows.Insert(rowIndex + 1, row);
            row.Cells[0].Value = ruleId;
            row.Cells[1].Value = matchType;
            row.Cells[2].Value = url;
            row.Cells[3].Value = imlBrowsers.Images[browserName];
            row.Cells[4].Value = browserName;

            RenumberGridRows();
            SelectRow(rowIndex + 1);
        }

        private void btnOpenUrl_Click(object sender, EventArgs e) {
            BrowserManager.LaunchUrlWithBrowser(txtUrl.Text, cboBrowser.Text);
        }

        private void grdRules_SelectionChanged(object sender, EventArgs e) {
            if (grdRules.SelectedRows.Count == 0) {
                return;
            }

            int rowIndex = grdRules.SelectedRows[0].Index;

            if (rowIndex < 0) {
                txtUrl.Clear();
                return;
            } else {
                DataGridViewRow row = grdRules.Rows[rowIndex];
                cboMatchType.Text = Convert.ToString(row.Cells[1].Value);
                txtUrl.Text = Convert.ToString(row.Cells[2].Value);
                cboBrowser.Text = Convert.ToString(row.Cells[4].Value);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }


        private void tsbAbout_Click(object sender, EventArgs e) {
            new Process() {
                StartInfo =
                new ProcessStartInfo() {
                    FileName = "http://getrelink.com"
                }
            }.Start();
        }

        private void tsbSave_Click(object sender, EventArgs e) {
            SaveSettings();
            PropertyService.Save();
            MessageBox.Show("Rules have been successfully saved.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chkUseDefault_CheckedChanged(object sender, EventArgs e) {
            grpRulesSection.Enabled = !chkUseDefault.Checked;
            var backgroundColor = grpRulesSection.Enabled ? SystemColors.Window : Color.FromArgb(232, 232, 232);
            try {
                grdRules.SuspendLayout();

                grdRules.BackgroundColor = backgroundColor;
                foreach (DataGridViewRow row in grdRules.Rows) {
                    row.DefaultCellStyle.BackColor = backgroundColor;
                }
            } finally {
                grdRules.ResumeLayout();
            }
        }

        private void RenumberGridRows() {
            for (int r = 0; r < grdRules.Rows.Count; r++) {
                grdRules.Rows[r].Cells[0].Value = r;
            }
        }

        private void SelectRow(int rowIndex) {
            if (grdRules.Rows.Count == 0) {
                return;
            }
            if (rowIndex < 0) {
                rowIndex = 0;
            } else if (rowIndex > grdRules.Rows.Count - 1) {
                rowIndex = grdRules.Rows.Count - 1;
            }

            grdRules.Rows[rowIndex].Selected = true;
            grdRules.CurrentCell = grdRules.Rows[rowIndex].Cells[0];
        }

        private void CheckIfDefault() {
            if (!BrowserManager.IsRelinkTheDefaultBrowser) {
                if (MessageBox.Show("ReLink is not currently your default browser, would you like to set it as default?",
                                Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    BrowserManager.RegisterOrUnregisterAsAdmin(true);
                    BrowserManager.SetRelinkAsDefaultBrowser();
                    ToastForm.ShowToast("Select ReLink as your default browser under Web Browser");
                }
            }
        }

        private void InitSettings() {
            try {
                cboDefaultBrowser.Text = BrowserSettings.DefaultBrowserName;

                grdRules.Rows.Clear();
                ArrayList rules = BrowserSettings.Rules;
                if (rules != null) {
                    foreach (object objRule in rules) {
                        Rule rule = Rule.Parse(Convert.ToString(objRule));
                        if (rule != null) {
                            DataGridViewRow row = grdRules.Rows[grdRules.Rows.Add()];
                            row.Cells[0].Value = rule.RuleId;
                            row.Cells[1].Value = rule.MatchType;
                            row.Cells[2].Value = rule.Url;
                            row.Cells[3].Value = imlBrowsers.Images[rule.BrowserName];
                            row.Cells[4].Value = rule.BrowserName;
                        }
                    }
                }

                chkUseDefault.Checked = BrowserSettings.UseDefaultBrowserForAllLinks;
            } catch {
            }
        }

        private bool SaveSettings() {
            try {
                BrowserSettings.DefaultBrowserName = cboDefaultBrowser.Text;
                BrowserSettings.UseDefaultBrowserForAllLinks = chkUseDefault.Checked;

                ArrayList rules = new ArrayList();
                foreach (DataGridViewRow row in grdRules.Rows) {
                    rules.Add(new Rule()
                    {
                        RuleId = row.Index,
                        MatchType = (MatchType)Enum.Parse(typeof(MatchType), Convert.ToString(row.Cells[1].Value)),
                        Url = Convert.ToString(row.Cells[2].Value),
                        BrowserName = Convert.ToString(row.Cells[4].Value)
                    });
                }

                BrowserSettings.Rules = rules;
                return true;
            } catch {
                return false;
            }
        }

        private void InitBrowserList(ImageComboBox.ImageComboBox dropdownBox) {
            dropdownBox.Items.Clear();
            imlBrowsers.Images.Clear();

            BrowserInfo[] browsers = BrowserManager.Browsers;

            foreach (BrowserInfo browser in browsers) {
                imlBrowsers.Images.Add(browser.Name, browser.Icon);
                dropdownBox.Items.Add(new ImageComboBoxItem(imlBrowsers.Images.IndexOfKey(browser.Name), browser.Name, 0));
            }

            if (dropdownBox.Items.Count > 0) {
                dropdownBox.SelectedIndex = 0;
            }
        }

        private void InitMatchTypesList() {
            cboMatchType.Items.Clear();
            foreach (string name in Enum.GetNames(typeof(MatchType))) {
                cboMatchType.Items.Add(new ImageComboBoxItem() { Text = name });
            }
            cboMatchType.SelectedIndex = 0;
        }
    }
}
