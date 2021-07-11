/********************************************************************
Copyright (c) Shameel Ahmed.  All rights reserved.
********************************************************************/

using ReLink.Core;
using System;
using System.IO;
using System.Windows.Forms;

namespace ReLink
{
    static class ReLinkMain {
        internal const string ARG_REGISTER = "--register";
        internal const string ARG_UNREGISTER = "--unregister";
        internal const string RUNAS_VERB = "runas";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            try {
                var osVersion = NativeHelper.GetOSVersion();
                if (osVersion == OSVersion.Win8 || osVersion == OSVersion.Win10) {
                    Run(args);
                } else {
                    ToastForm.ShowToast($"{Application.ProductName} runs only Windows 8 and above.");
                }
            } catch (Exception ex) {
                HandleMainException(ex);
            }
        }

        static void Run(string[] args) {
            InitializeServices();

            if (args.Length > 0) {
                //If any arguments are passed, handle it and exit.
                //The UI shows only when no arguments are passed.
                HandleArgs(args);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);

            //Run main form
            MainForm mainForm = MainForm.Instance;
            Application.Run(mainForm);
        }

        static void HandleArgs(string[] args) {
            foreach (string arg in args) {
                if (string.Equals(arg, ARG_REGISTER, StringComparison.OrdinalIgnoreCase)) {
                    BrowserManager.RegisterRelinkAsBrowser();
                } else if (string.Equals(arg, ARG_UNREGISTER, StringComparison.OrdinalIgnoreCase)) {
                    BrowserManager.UnregisterRelinkAsBrowser();
                } else {
                    BrowserInfo browser = BrowserManager.LaunchUrl(arg);
                    ToastForm.ShowToast($"Re:Link opened {arg} in {browser.Name}", true);
                }
            }
        }

        private static void InitializeServices() {
            string applicationName = Application.ProductName;

            string configDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), applicationName);
            PropertyService.InitializeService(configDirectory, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data"), applicationName);
            PropertyService.Load();

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.Automatic);
            Application.ThreadException += Application_ThreadException;
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }

        private static void ShutdownServices() {
            PropertyService.Save();
        }

        static void HandleMainException(Exception ex) {
            MessageBox.Show(ex.ToString(), "Critical error");
        }

        private static void Application_ApplicationExit(object sender, EventArgs e) {
            ShutdownServices();
        }
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) {
            MessageBox.Show(e.Exception.ToString(), "Critical error");
        }
    }
}
