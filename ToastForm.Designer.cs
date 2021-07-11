
namespace ReLink {
    partial class ToastForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tmrClose = new System.Windows.Forms.Timer(this.components);
            this.tmrBlink = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.SteelBlue;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Yellow;
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(800, 48);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "[Toast Text]";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrClose
            // 
            this.tmrClose.Enabled = true;
            this.tmrClose.Interval = 5000;
            this.tmrClose.Tick += new System.EventHandler(this.TmrCloseTick);
            // 
            // tmrBlink
            // 
            this.tmrBlink.Enabled = true;
            this.tmrBlink.Interval = 500;
            this.tmrBlink.Tick += new System.EventHandler(this.TmrBlinkTick);
            // 
            // ToastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 48);
            this.Controls.Add(this.lblMessage);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToastForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ToastForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Timer tmrClose;
        private System.Windows.Forms.Timer tmrBlink;
    }
}