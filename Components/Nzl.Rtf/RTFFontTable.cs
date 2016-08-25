/***************************************************************************

  Rtf Dom Parser

  Copyright (c) 2010 sinosoft , written by yuans.
  http://www.sinoreport.net

  This program is free software; you can redistribute it and/or
  modify it under the terms of the GNU General Public License
  as published by the Free Software Foundation; either version 2
  of the License, or (at your option) any later version.
  
  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.
  
  You should have received a copy of the GNU General Public License
  along with this program; if not, write to the Free Software
  Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

****************************************************************************/
using System;
using System.Collections ;
namespace Nzl.Rtf
{
    

    /// <summary>
    /// font table
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("Count={ Count }")]
    [System.Diagnostics.DebuggerTypeProxy(typeof(RTFInstanceDebugView))]
	public class RTFFontTable : System.Collections.CollectionBase
	{

		/// <summary>
		/// initialize instance
		/// </summary>
		public RTFFontTable()
		{
		}

		//private ArrayList myItems = new ArrayList();

		/// <summary>
		/// get font information special index
		/// </summary>
		public RTFFont this[ int fontIndex ]
		{
			get
			{
                foreach (RTFFont item in this)
                {
                    if (item.Index == fontIndex)
                        return item;
                }
                return null;
			}
		}

        /// <summary>
        /// get font object special name
        /// </summary>
        /// <param name="fontName">font name</param>
        /// <returns>font object</returns>
        public RTFFont this[string fontName]
        {
            get
            {
                foreach (RTFFont item in this)
                {
                    if (item.Name == fontName)
                        return item;
                }
                return null;
            }
        }

        /// <summary>
        /// get font object special font index
        /// </summary>
        /// <param name="fontIndex">font index</param>
        /// <returns>font object</returns>
        public string GetFontName(int fontIndex)
        {
            RTFFont font = this[fontIndex];
            if (font != null)
                return font.Name ;
            else
                return null;
        }

		/// <summary>
		/// add font
		/// </summary>
		/// <param name="f">font name</param>
		public void Add( string f )
		{
            if ( this[f] == null)
            {
                this.List.Add(new RTFFont(this.Count, f));
            }
		}
		/// <summary>
		/// add font
		/// </summary>
		/// <param name="index">special font index</param>
		/// <param name="f">font name</param>
		public void Add( int index , string f )
		{
            this.List.Add(new RTFFont(index, f));
		}

        public void Add(RTFFont f)
        {
            this.List.Add(f);
        }

		/// <summary>
		/// Remove font
		/// </summary>
		/// <param name="f">font name</param>
		public void Remove( string f )
		{
            RTFFont item = this[f];
            if (item != null)
                this.List.Remove( item );
		}

		/// <summary>
		/// Get font index special font name
		/// </summary>
		/// <param name="f">font name</param>
		/// <returns>font index</returns>
		public int IndexOf( string f )
		{
            foreach (RTFFont item in this)
            {
                if (item.Name == f)
                {
                    return item.Index;
                }
            }
			return -1 ;
		}
		  
		/// <summary>
		/// Write font table rtf
		/// </summary>
		/// <param name="writer">rtf text writer</param>
		public void Write( RTFWriter writer )
		{
			writer.WriteStartGroup();
			writer.WriteKeyword( RTFConsts._fonttbl );
			foreach( RTFFont item in this )
			{
				writer.WriteStartGroup();
				writer.WriteKeyword( "f" + item.Index );
                if (item.Charset != 0)
                {
                    writer.WriteKeyword("fcharset" + item.Charset);
                }
				writer.WriteText( item.Name );
				writer.WriteEndGroup();
			}
			writer.WriteEndGroup();
		}

		public override string ToString()
		{
			System.Text.StringBuilder str = new System.Text.StringBuilder();
			foreach( RTFFont item in this )
			{
				str.Append( System.Environment.NewLine );
				str.Append( "Index " + item.Index + "   Name:" + item.Name );
			}
			return str.ToString();
		}

        /// <summary>
        /// close object
        /// </summary>
        /// <returns>new object</returns>
        public RTFFontTable Clone()
        {
            RTFFontTable table = new RTFFontTable();
            foreach (RTFFont item in this )
            {
                RTFFont newItem = item.Clone();
                table.List.Add(newItem);
            }
            return table;
        }
	}

    /// <summary>
    /// rtf font information
    /// </summary>
    public class RTFFont
    {
        /// <summary>
        /// initialize instance
        /// </summary>
        /// <param name="index">font index</param>
        /// <param name="name">font name</param>
        public RTFFont(int index, string name)
        {
            intIndex = index;
            strName = name;
        }

        private int intIndex = 0;
        /// <summary>
        /// font index
        /// </summary>
        public int Index
        {
            get
            {
                return intIndex; 
            }
            set
            {
                intIndex = value; 
            }
        }

        private string strName = null;
        /// <summary>
        /// font name
        /// </summary>
        public string Name
        {
            get
            {
                return strName; 
            }
            set
            {
                strName = value; 
            }
        }

        private int intCharset = 0;
        /// <summary>
        /// charset 
        /// </summary>
        public int Charset
        {
            get
            {
                return intCharset;
            }
            set
            {
                intCharset = value;
                myEncoding = GetRTFEncoding(intCharset);
            }
        }

        internal static System.Text.Encoding GetRTFEncoding(int fchartset)
        {
            switch (fchartset)
            {
                case 0: 	// ANSI
                    return ANSIEncoding.Instance;
                case 1:	// Default
                    return System.Text.Encoding.Default;
                    
                //case 2:	// Symbol
                //case 3:	// Invalid
                case 77:   // Mac
                    return System.Text.Encoding.GetEncoding(10000); //macintosh ��ŷ�ַ�(Mac)
                    
                case 128:	// Shift Jis
                    return System.Text.Encoding.GetEncoding(932);// ANSI/OEM - Japanese, Shift-JIS 
                    
                //case 129:	// Hangul
                case 130:	// Johab
                    return System.Text.Encoding.GetEncoding(1361);// Korean (Johab) 
                    
                case 134:	// GB2312
                    return System.Text.Encoding.GetEncoding(936);
                    
                case 136:	// Big5
                    return System.Text.Encoding.GetEncoding(10002);// MAC - Traditional Chinese (Big5) 
                    
                case 161:	// Greek
                    return System.Text.Encoding.GetEncoding(1253);// ANSI - Greek 
                    
                case 162:	// Turkish
                    return System.Text.Encoding.GetEncoding(1254);//ANSI - Turkish 
                    
                case 163:	// Vietnamese
                    return System.Text.Encoding.GetEncoding(1258);// ANSI/OEM - Vietnamese 
                    
                case 177:	// Hebrew
                    return System.Text.Encoding.GetEncoding(1255);// ANSI - Hebrew 
                    
                case 178:	// Arabic
                    return System.Text.Encoding.GetEncoding(864);//OEM - Arabic 
                    
                case 179:	// Arabic Traditional
                    return System.Text.Encoding.GetEncoding(864);//OEM - Arabic 
                    
                case 180:	// Arabic user
                    return System.Text.Encoding.GetEncoding(864);//OEM - Arabic 
                    
                case 181:	// Hebrew user
                    return System.Text.Encoding.GetEncoding(864);//OEM - Arabic 
                    
                case 186:	// Baltic
                    return System.Text.Encoding.GetEncoding(775);//OEM - Baltic 
                    
                case 204:	// Russian
                    return System.Text.Encoding.GetEncoding(866);//OEM - Russian 
                    
                case 222:	// Thai
                    return System.Text.Encoding.GetEncoding(874);//ANSI/OEM - Thai (same as 28605, ISO 8859-15) 
                    
                //case 238:	// Eastern European
                //case 254:	// PC 437
                case 255:	// OEM
                    return System.Text.Encoding.GetEncoding(437);//OEM - United States 
                    
                default:
                    return null;
            }
        }

        private System.Text.Encoding myEncoding = null ;
        /// <summary>
        /// encoding
        /// </summary>
        public System.Text.Encoding Encoding
        {
            get 
            {
                return myEncoding; 
            }
        }

        public RTFFont Clone()
        {
            RTFFont f = new RTFFont( this.intIndex , this.strName );
            f.intCharset = this.intCharset;
            f.intIndex = this.intIndex;
            f.myEncoding = this.myEncoding;
            f.strName = this.strName;
            return f;
        }

        public override string ToString()
        {
            return intIndex + ":" + strName + " Charset:" + intCharset;
        }
    }

    
    /// <summary>
    /// internal encoding for ansi
    /// </summary>
    internal class ANSIEncoding : System.Text.Encoding
    {
        public static ANSIEncoding Instance = new ANSIEncoding();
        public override string GetString(byte[] bytes, int index, int count)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            int endIndex = Math.Min(bytes.Length-1, index + count -1);
            for (int iCount = index ; iCount <= endIndex ; iCount++)
            {
                str.Append(System.Convert.ToChar(bytes[iCount]));
            }
            return str.ToString();
        }

        public override int GetByteCount(char[] chars, int index, int count)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override int GetCharCount(byte[] bytes, int index, int count)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override int GetMaxByteCount(int charCount)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override int GetMaxCharCount(int byteCount)
        {
            throw new Exception("The method or operation is not implemented.");
        }

    }
}