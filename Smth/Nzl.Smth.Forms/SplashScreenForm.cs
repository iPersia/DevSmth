using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace Nzl.Smth.Forms
{
    public partial class SplashScreenForm : SplashScreen
    {
        public SplashScreenForm()
        {
            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);

            SplashScreenCommand ssCmd = (SplashScreenCommand)cmd;
            if (ssCmd == SplashScreenCommand.Loading)
            {
                string status = arg as string;
                this.lblMsg.Text = "Loading " + status + "...";
            }

            if (ssCmd == SplashScreenCommand.Loaded)
            {
                string status = arg as string;
                this.lblMsg.Text = "Initializing is completed, the browser will be shown!";
            }
        }

        #endregion

        public enum SplashScreenCommand
        {
            Loading,
            Loaded
        }
    }
}