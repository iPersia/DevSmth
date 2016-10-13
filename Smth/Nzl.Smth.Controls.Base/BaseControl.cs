namespace Nzl.Smth.Controls.Base
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using DevExpress.XtraEditors;
    using Nzl.Recycling;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Utils;

    /// <summary>
    /// 
    /// </summary>
    //public class BaseControl<TBaseData> : DevExpress.Utils.Controls.ControlBase, IRecycled
    public abstract class BaseControl<TBaseData> : DevExpress.XtraEditors.XtraUserControl, IRecycled
        where TBaseData : BaseData
    {
        /// <summary>
        /// 
        /// </summary>
        private IList<HyperlinkLabelControl> _hlcList = new List<HyperlinkLabelControl>();

        /// <summary>
        /// 
        /// </summary>
        public BaseControl()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            ///For initializing.
            this.PrepareControls();

            ///Initializing.
            foreach (HyperlinkLabelControl ctl in this.HyperlinkLabelControls)
            {
                ctl.Initialize();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        public TBaseData Data
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        protected IList<HyperlinkLabelControl> HyperlinkLabelControls
        {
            get
            {
                return this._hlcList;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void PrepareControls()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public virtual void Initialize(TBaseData data)
        {
            this.Data = data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        public virtual void SetWidth(int width)
        {
            this.Width = width;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lbl"></param>
        /// <param name="url"></param>
        protected void InitializeLabel(LabelControl lbl, string text)
        {
            if (lbl != null)
            {
                lbl.Text = text;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lbl"></param>
        /// <param name="url"></param>
        protected void InitializeLinkLabel(DevExpress.XtraEditors.HyperlinkLabelControl lbl, string url)
        {
            this.InitializeLinkLabel(lbl, lbl != null ? lbl.Text : "", url);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lbl"></param>
        /// <param name="url"></param>
        protected void InitializeLinkLabel(DevExpress.XtraEditors.HyperlinkLabelControl lbl, string text, string url)
        {
            if (lbl != null)
            {
                lbl.Visible = false;
                if (string.IsNullOrEmpty(url) == false)
                {
                    lbl.Visible = true;
                    lbl.Text = "<href=" + url + ">" + text + "</href>";
                }
            }
        }

        #region IRecycled
        /// <summary>
        /// A boolean indicated whether the object is recycled.
        /// </summary>
        public bool IsRecycled
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public RecycledStatus Status
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Reusing()
        {
            this.Status = RecycledStatus.Using;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Recycling()
        {
            this.Status = RecycledStatus.Recycled;
        }
        #endregion
    }
}
