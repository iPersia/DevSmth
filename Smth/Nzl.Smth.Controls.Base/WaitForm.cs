namespace Nzl.Smth.Controls.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraSplashScreen;
    using DevExpress.XtraWaitForm;

    /// <summary>
    /// 
    /// </summary>
    internal partial class WaitForm : DevExpress.XtraWaitForm.WaitForm
    {
        /// <summary>
        /// 
        /// </summary>
        public WaitForm()
        {
            InitializeComponent();
            this.ppWaitInfor.AutoHeight = true;
        }

        #region Overrides

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.ppWaitInfor.Caption = caption;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.ppWaitInfor.Description = description;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="arg"></param>
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);

            ///SetCaption
            WaitFormCommand command = (WaitFormCommand)cmd;
            if (command == WaitFormCommand.SetCaption)
            {
                string caption = arg as string;
                if (caption != null)
                {
                    this.ppWaitInfor.Caption = caption;
                }
            }

            ///SetDescription
            if (command == WaitFormCommand.SetDescription)
            {
                string description = arg as string;
                if (description != null)
                {
                    this.ppWaitInfor.Description = description;
                }
            }
        }

        #endregion

        /// <summary>
        /// Common enum.
        /// </summary>
        public enum WaitFormCommand
        {
            SetCaption,
            SetDescription
        }
    }
}