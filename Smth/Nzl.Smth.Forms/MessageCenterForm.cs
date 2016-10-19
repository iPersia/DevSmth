﻿namespace Nzl.Smth.Forms
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Nzl.Messaging;
    using Nzl.Smth.Loaders;
    using Nzl.Smth.Logger;

    /// <summary>
    /// 
    /// </summary>
    public partial class MessageCenterForm : BaseForm
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly MessageCenterForm Instance = new MessageCenterForm();

        /// <summary>
        /// 
        /// </summary>
        private Form _parentForm = null;

        /// <summary>
        /// 
        /// </summary>
        private Timer _updatingTimer = new Timer();

        /// <summary>
        /// 
        /// </summary>
        MessageCenterForm()
        {
            InitializeComponent();
            this._updatingTimer.Interval = 1000;
            this._updatingTimer.Tick += _updatingTimer_Tick;
            this._updatingTimer.Start();

#if (DEBUG)
            this.panelUp.Height = 360;
            this.panelUp.Height = 25;
#else            
            this.panelUp.Height = 25;
            this.txtCache.ReadOnly = true;
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _updatingTimer_Tick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.txtCache.Clear();
#if (DEBUG)
                this.txtCache.AppendText("PageDispatcher queue count is "
                                       + PageDispatcher.Instance.Count
                                       + "\n"
                                       + Nzl.Recycling.RecycledQueues.GetStatistics());
#else
                this.txtCache.AppendText("The number of page which will be fetched in queue is "
                                       + PageDispatcher.Instance.Count 
                                       + "!");
#endif
            }
        }

        /// <summary>
        /// 
        /// </summary>
        MessageCenterForm(Form parent)
            : this()
        {
            this._parentForm = parent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.bgwMessager.WorkerReportsProgress = true;
            this.bgwMessager.DoWork +=new DoWorkEventHandler(bgwMessager_DoWork);
            this.bgwMessager.ProgressChanged += new ProgressChangedEventHandler(bgwMessager_ProgressChanged);
            this.bgwMessager.RunWorkerCompleted +=new RunWorkerCompletedEventHandler(bgwMessager_RunWorkerCompleted);
            this.bgwMessager.RunWorkerAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwMessager_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (true)
                {
                    Nzl.Messaging.Message msg = MessageQueue.Dequeue();
                    if (msg != null)
                    {
                        this.bgwMessager.ReportProgress(1, msg);
                        System.Threading.Thread.Sleep(50);
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(1500);
                    }
                }
            }
            catch (Exception exp)
            {
                if (Logger.Enabled)
                {
                    Logger.Instance.Error(exp.Message + "\n" + exp.StackTrace);
                }

                e.Cancel = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwMessager_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Nzl.Messaging.Message msg = e.UserState as Nzl.Messaging.Message;
            if (msg != null)
            {
                this.txtMsg.AppendText(msg.DateTime.TimeOfDay.ToString() + "\t\t" + msg.Source + "\n");
                this.txtMsg.AppendText(msg.Detail + "\n");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwMessager_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.txtMsg.AppendText(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                this.txtMsg.AppendText("MessageQueue Error!");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageCenterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;            
        }
    }
}
