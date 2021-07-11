using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReLink {
    public partial class ToastForm : Form {
        int blinkCount = 0;
        const int DURATION = 5;

        public ToastForm() {
            InitializeComponent();
        }

        internal static void ShowToast(string message) {
            ShowToast(message, false);
        }

        internal static void ShowToast(string message, bool isDialog) {
            ToastForm toast = new ToastForm();
            toast.lblMessage.Text = message;
            toast.tmrClose.Interval = DURATION * 1000;
            toast.tmrClose.Start();
            toast.TopMost = true;

            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            toast.Location = new Point((screenWidth - toast.Size.Width) / 2, (screenHeight - toast.Size.Height) - 10);

            if (isDialog) {
                toast.ShowDialog();
            } else {
                toast.Show();
            }
        }

        private void TmrBlinkTick(object sender, EventArgs e) {
            blinkCount++;

            if (blinkCount <= 4) {
                Opacity = Opacity == 1 ? 0 : 1; 
                Refresh();
            }
        }

        private void TmrCloseTick(object sender, EventArgs e) {
            this.Close();
        }
    }
}
