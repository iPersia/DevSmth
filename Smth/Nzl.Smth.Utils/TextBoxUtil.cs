﻿namespace Nzl.Smth.Utils
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    /// <summary>
    /// 基于.NET 2.0的TextBox工具类
    /// </summary>
    public static class TextBoxUtil
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        private static extern Int32 SendMessage
         (IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        /// <summary>
        /// 为TextBox设置水印文字
        /// </summary>
        /// <param name="textBox">TextBox</param>
        /// <param name="watermark">水印文字</param>
        public static void SetWatermark(this Control ctl, string watermark)
        {
            SendMessage(ctl.Handle, EM_SETCUEBANNER, 0, watermark);
        }

        /// <summary>
        /// 清除水印文字
        /// </summary>
        /// <param name="textBox">TextBox</param>
        public static void ClearWatermark(this Control ctl)
        {
            SendMessage(ctl.Handle, EM_SETCUEBANNER, 0, string.Empty);
        }
    }
}
