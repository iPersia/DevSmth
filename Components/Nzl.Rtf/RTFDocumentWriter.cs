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
//using XDesigner.Drawer ;
//using XDesigner.Printing ;

namespace Nzl.Rtf
{
	
	/// <summary>
	/// RTF document writer
	/// </summary>
	public class RTFDocumentWriter
	{
		/// <summary>
		/// initialize instance
		/// </summary>
		public RTFDocumentWriter()
		{
            myColorTable.CheckValueExistWhenAdd = true ;
		}

		public RTFDocumentWriter( System.IO.TextWriter writer )
		{
            myColorTable.CheckValueExistWhenAdd = true;
			Open( writer );
		}

		public RTFDocumentWriter( string strFileName )
		{
            myColorTable.CheckValueExistWhenAdd = true;
			Open( strFileName );
		}

		public RTFDocumentWriter( System.IO.Stream stream )
		{
            myColorTable.CheckValueExistWhenAdd = true;
			System.IO.StreamWriter writer = new System.IO.StreamWriter( stream , System.Text.Encoding.ASCII );
			Open( writer );
		}

		public virtual bool Open( System.IO.TextWriter writer )
		{
			myWriter = new RTFWriter( writer );
			myWriter.Encoding = System.Text.Encoding.GetEncoding( 936 );
			myWriter.Indent = false;
			return true ;
		}

		public virtual bool Open( string strFileName )
		{
			myWriter = new RTFWriter( strFileName );
			myWriter.Encoding = System.Text.Encoding.GetEncoding( 936 );
			myWriter.Indent = false ;
			return true ;
		}
		public virtual void Close()
		{
			myWriter.Close();
		}
		private RTFWriter myWriter = null;
		/// <summary>
		/// base writer
		/// </summary>
		public RTFWriter Writer
		{
			get{ return myWriter ;}
			set{ myWriter = value;}
		}

		/// <summary>
		/// document information
		/// </summary>
		private Hashtable myInfo = new Hashtable();
		public Hashtable Info
		{
			get
			{
				return myInfo ;
			}
		}

		/// <summary>
		/// rtf font table
		/// </summary>
		private RTFFontTable myFontTable = new RTFFontTable();
		/// <summary>
		/// rtf font table
		/// </summary>
		public RTFFontTable FontTable
		{
			get
			{
				return myFontTable ;
			}
		}

		/// <summary>
		/// rtf color table
		/// </summary>
		private RTFColorTable myColorTable = new RTFColorTable();
		/// <summary>
		/// rtf color table
		/// </summary>
		public RTFColorTable ColorTable
		{
			get
			{
				return myColorTable ;
			}
		}

		private bool bolCollectionInfo = true ;
		/// <summary>
		/// system collectiong document's information , maby generating
        /// font table and color table , not writting content.
		/// </summary>
		public bool CollectionInfo
		{
			get
			{
				return bolCollectionInfo ;
			}
			set
			{
				bolCollectionInfo = value;
			}
		}

		public void WriteStartGroup()
		{
			if( bolCollectionInfo == false )
			{
				myWriter.WriteStartGroup();
			}
		}
		public void WriteEndGroup()
		{
			if( bolCollectionInfo == false )
			{
				myWriter.WriteEndGroup();
			}
		}
		/// <summary>
		/// write rtf keyword
		/// </summary>
		/// <param name="Keyword">keyword</param>
		public void WriteKeyword( string Keyword )
		{
			if( bolCollectionInfo == false )
			{
				myWriter.WriteKeyword( Keyword );
			}
		}

		public void WriteBorderLineDashStyle( System.Drawing.Drawing2D.DashStyle style )
		{
			if( bolCollectionInfo == false )
			{
				if( style == System.Drawing.Drawing2D.DashStyle.Dot )
				{
					this.WriteKeyword("brdrdot");
				}
				else if( style == System.Drawing.Drawing2D.DashStyle.DashDot )
				{
					this.WriteKeyword("brdrdashd");
				}
				else if( style == System.Drawing.Drawing2D.DashStyle.DashDotDot )
				{
					this.WriteKeyword("brdrdashdd");
				}
				else if( style == System.Drawing.Drawing2D.DashStyle.Dash )
				{
					this.WriteKeyword("brdrdash");
				}
				else
				{
					this.WriteKeyword("brdrs");
				}
			}
		}

		/// <summary>
		/// start write document
		/// </summary>
		public void WriteStartDocument()
		{
			this.myLastParagraphInfo = null ;
			this.bolFirstParagraph = true ;
			if( bolCollectionInfo )
			{
				myInfo.Clear();
				myFontTable.Clear();
				myColorTable.Clear();
				myFontTable.Add( System.Windows.Forms.Control.DefaultFont.Name );
			}
			else
			{
				myWriter.WriteStartGroup();
				myWriter.WriteKeyword( RTFConsts._rtf );
				myWriter.WriteKeyword("ansi");
				myWriter.WriteKeyword("ansicpg" + myWriter.Encoding.CodePage );
				// write document information
				if( myInfo.Count > 0 )
				{
					myWriter.WriteStartGroup();
					myWriter.WriteKeyword("info");
					foreach( string strKey in myInfo.Keys )
					{
						myWriter.WriteStartGroup();

						object v = myInfo[ strKey ] ;
						if( v is string )
						{
							myWriter.WriteKeyword( strKey );
							myWriter.WriteText( ( string ) v );
						}
						else if( v is int )
						{
							myWriter.WriteKeyword( strKey + v );
						}
						else if( v is DateTime )
						{
							DateTime dtm = ( DateTime ) v ;
							myWriter.WriteKeyword( strKey );
							myWriter.WriteKeyword( "yr" + dtm.Year );
							myWriter.WriteKeyword( "mo" + dtm.Month );
							myWriter.WriteKeyword( "dy" + dtm.Day );
							myWriter.WriteKeyword( "hr" + dtm.Hour );
							myWriter.WriteKeyword( "min" + dtm.Minute );
							myWriter.WriteKeyword( "sec" + dtm.Second );
						}
						else
						{
							myWriter.WriteKeyword( strKey );
						}
						
						myWriter.WriteEndGroup();
					}
					myWriter.WriteEndGroup();
				}
				// writing font table
				myWriter.WriteStartGroup();
				myWriter.WriteKeyword( RTFConsts._fonttbl );
				for( int iCount = 0 ; iCount < myFontTable.Count ; iCount ++ )
				{
					//string f = myFontTable[ iCount ] ;
					myWriter.WriteStartGroup();
					myWriter.WriteKeyword( "f" + iCount );
					//myWriter.WriteKeyword( "fcharset" + f.GdiCharSet );
                    myWriter.WriteText(myFontTable.GetFontName(iCount));
					myWriter.WriteEndGroup();
				}
				myWriter.WriteEndGroup();

				// write color table
				myWriter.WriteStartGroup();
				myWriter.WriteKeyword( RTFConsts._colortbl );
				myWriter.WriteRaw(";");
				for( int iCount = 0 ; iCount < myColorTable.Count ; iCount ++ )
				{
					System.Drawing.Color c = myColorTable[ iCount ] ;
					myWriter.WriteKeyword( "red" + c.R );
					myWriter.WriteKeyword( "green" + c.G );
					myWriter.WriteKeyword( "blue" + c.B );
					myWriter.WriteRaw(";");
				}
				myWriter.WriteEndGroup();
				myWriter.WriteKeyword("viewkind1");
			}
		}

		/// <summary>
		/// end write document
		/// </summary>
		public void WriteEndDocument()
		{
			if( this.bolCollectionInfo == false )
			{
				myWriter.WriteEndGroup();
			}
		}

		/// <summary>
		/// start write header
		/// </summary>
		public void WriteStartHeader()
		{
			if( this.bolCollectionInfo == false )
			{
				myWriter.WriteStartGroup();
				myWriter.WriteKeyword("header");
			}
		}

		/// <summary>
		/// end write header
		/// </summary>
		public void WriteEndHeader()
		{
			if( this.bolCollectionInfo == false )
			{
				myWriter.WriteEndGroup();
			}
		}
		
		/// <summary>
		/// start write footer
		/// </summary>
		public void WriteStartFooter()
		{
			if( this.bolCollectionInfo == false )
			{
				myWriter.WriteStartGroup();
				myWriter.WriteKeyword("footer");
			}
		}

		/// <summary>
		/// end write end footer
		/// </summary>
		public void WriteEndFooter()
		{
			if( this.bolCollectionInfo == false )
			{
				myWriter.WriteEndGroup();
			}
		}
		 
		private DocumentFormatInfo myLastParagraphInfo = null;

		private bool bolFirstParagraph = true ;

		public void WriteStartParagraph( )
		{
			WriteStartParagraph( new DocumentFormatInfo());
		}

		/// <summary>
		/// write write paragraph
		/// </summary>
		/// <param name="info">format</param>
		public void WriteStartParagraph( DocumentFormatInfo info )
		{
			if( this.bolCollectionInfo )
			{
				myFontTable.Add("Wingdings");
			}
			else
			{
				if( bolFirstParagraph )
				{
					bolFirstParagraph = false ;
					myWriter.WriteRaw(System.Environment.NewLine );
					//myWriter.WriteKeyword("par");
				}
				else
				{
					myWriter.WriteKeyword("par");
				}
				if( info.NumberedList || info.BulletedList )
				{
					if( info.NumberedList )
					{
						if( myLastParagraphInfo == null || myLastParagraphInfo.NumberedList != info.NumberedList )
						{
							myWriter.WriteKeyword("pard");
							myWriter.WriteStartGroup();
							myWriter.WriteKeyword("pn" , true );
							myWriter.WriteKeyword("pnlvlbody");
							myWriter.WriteKeyword("pnindent400");
							myWriter.WriteKeyword("pnstart1");
							myWriter.WriteKeyword("pndec");
							myWriter.WriteEndGroup();
						}
					}
					else
					{
						if( myLastParagraphInfo == null || myLastParagraphInfo.BulletedList != info.BulletedList )
						{
							myWriter.WriteKeyword("pard");
							myWriter.WriteStartGroup();
							myWriter.WriteKeyword("pn" , true );
							myWriter.WriteKeyword("pnlvlblt");
							myWriter.WriteKeyword("pnindent400");
							myWriter.WriteKeyword("pnf" + myFontTable.IndexOf( "Wingdings" ));
							myWriter.WriteStartGroup();
							myWriter.WriteKeyword("pntxtb");
							myWriter.WriteText("l");
							//myWriter.WriteKeyword("'B7");
							myWriter.WriteEndGroup();
							myWriter.WriteEndGroup();
						}
					}
					myWriter.WriteKeyword("fi-400");
				}
				else
				{
					if( myLastParagraphInfo != null )
					{
						if( myLastParagraphInfo.NumberedList || myLastParagraphInfo.BulletedList )
							myWriter.WriteKeyword("pard");
					}
				}

				switch( info.Align )
				{
					case RTFAlignment.Left  :
						myWriter.WriteKeyword("ql");
						break;
					case RTFAlignment.Center :
						myWriter.WriteKeyword("qc");
						break;
					case RTFAlignment.Right :
						myWriter.WriteKeyword("qr");
						break;
					case RTFAlignment.Justify :
						myWriter.WriteKeyword("qj");
						break;
				}
//
//				if( info.LeftAlign )
//					myWriter.WriteKeyword("ql");
//				if( info.CenterAlign )
//					myWriter.WriteKeyword("qc");
//				else if( info.RigthAlign )
//					myWriter.WriteKeyword("qr");
				if( info.NumberedList == false && info.BulletedList == false )
				{
					if( info.ParagraphFirstLineIndent != 0 )
						myWriter.WriteKeyword("fi" + Convert.ToInt32( info.ParagraphFirstLineIndent * 400 / info.StandTabWidth ));
					else
						myWriter.WriteKeyword("fi0");
				}
				//if( info.NumberedList == false && info.BulletedList == false )
				{
					if( info.LeftIndent != 0 )
						myWriter.WriteKeyword("li" + Convert.ToInt32( info.LeftIndent * 400 / info.StandTabWidth ));
					else
						myWriter.WriteKeyword("li0");
				}
				myWriter.WriteKeyword("plain");
			}
			myLastParagraphInfo = info ;
		}

		/// <summary>
		/// end write paragraph
		/// </summary>
		public void WriteEndParagraph()
		{
		}

		/// <summary>
		/// write plain text
		/// </summary>
		/// <param name="strText">text</param>
		public void WriteText( string strText )
		{
			if( strText != null && this.bolCollectionInfo == false )
			{
				myWriter.WriteText( strText );
			}
		}

		/// <summary>
		/// write font format
		/// </summary>
		/// <param name="font">font</param>
		public void WriteFont( System.Drawing.Font font )
		{
			if( font == null )
			{
				throw new ArgumentNullException("font");
			}
			if( this.bolCollectionInfo )
			{
				myFontTable.Add( font.Name );
			}
			else
			{
				int index = myFontTable.IndexOf( font.Name );
				if( index >= 0 )
				{
					myWriter.WriteKeyword( "f" + index );
				}
				if( font.Bold )
				{
					myWriter.WriteKeyword("b");
				}
				if( font.Italic )
				{
					myWriter.WriteKeyword("i");
				}
				if( font.Underline )
				{
					myWriter.WriteKeyword("ul");
				}
				if( font.Strikeout )
				{
					myWriter.WriteKeyword("strike");
				}
				myWriter.WriteKeyword("fs" + Convert.ToInt32( font.Size * 2 ));
			}
		}

		/// <summary>
		/// start write formatted text
		/// </summary>
		/// <param name="info">format</param>
		/// <remarks>
        /// This function must assort with WriteEndString strict
		/// </remarks>
		public void WriteStartString( DocumentFormatInfo info )
		{
			if( this.bolCollectionInfo )
			{
				myFontTable.Add( info.FontName );
				myColorTable.Add( info.TextColor );
				myColorTable.Add( info.BackColor );
                if( info.BorderColor.A != 0 )
                {
                    myColorTable.Add( info.BorderColor );
                }
				return ;
			}
			if( info.Link != null && info.Link.Length > 0 )
			{
				myWriter.WriteStartGroup();
				myWriter.WriteKeyword("field");
				myWriter.WriteStartGroup();
				myWriter.WriteKeyword("fldinst" , true );
				myWriter.WriteStartGroup();
				myWriter.WriteKeyword("hich");
				myWriter.WriteText(" HYPERLINK \"" + info.Link + "\"");
				myWriter.WriteEndGroup();
				myWriter.WriteEndGroup();
				myWriter.WriteStartGroup();
				myWriter.WriteKeyword("fldrslt");
				myWriter.WriteStartGroup();
			}

			switch( info.Align )
			{
				case RTFAlignment.Left :
					myWriter.WriteKeyword("ql");
					break;
				case RTFAlignment.Center :
					myWriter.WriteKeyword("qc");
					break;
				case RTFAlignment.Right :
					myWriter.WriteKeyword("qr");
					break;
				case RTFAlignment.Justify :
					myWriter.WriteKeyword("qj");
					break;
			}

			myWriter.WriteKeyword("plain");
			int index = 0 ;
			index = myFontTable.IndexOf( info.FontName );
			if( index >= 0 )
				myWriter.WriteKeyword("f" + index );
			if( info.Bold )
				myWriter.WriteKeyword("b");
			if( info.Italic )
				myWriter.WriteKeyword("i");
			if( info.Underline )
				myWriter.WriteKeyword("ul");
			if( info.Strikeout )
				myWriter.WriteKeyword("strike");
			myWriter.WriteKeyword("fs" + Convert.ToInt32( info.FontSize * 2 ));
			index = myColorTable.IndexOf( info.BackColor );
			if( index >= 0 )
			{
				myWriter.WriteKeyword("chcbpat" + Convert.ToString( index + 1 ) );
			}
			index = myColorTable.IndexOf( info.TextColor );
			if( index >= 0 )
				myWriter.WriteKeyword("cf" + Convert.ToString( index  + 1 ) );
			if( info.Subscript )
				myWriter.WriteKeyword("sub");
			if( info.Superscript )
				myWriter.WriteKeyword("super");
            if (info.NoWwrap)
                myWriter.WriteKeyword("nowwrap");
            if (info.BorderColor.A != 0)
            {
                myWriter.WriteKeyword("chbrdr");
                myWriter.WriteKeyword("brdrs");
                myWriter.WriteKeyword("brdrw10");
                index = myColorTable.IndexOf( info.BorderColor );
                if (index >= 0)
                {
                    myWriter.WriteKeyword("brdrcf" + Convert.ToString(index + 1));
                }
            }
		}

		public void WriteEndString( DocumentFormatInfo info )
		{
			if( this.bolCollectionInfo )
			{
				return ;
			}
			
			if( info.Subscript )
				myWriter.WriteKeyword("sub0");
			if( info.Superscript )
				myWriter.WriteKeyword("super0");

			if( info.Bold )
				myWriter.WriteKeyword("b0");
			if( info.Italic )
				myWriter.WriteKeyword("i0");
			if( info.Underline )
				myWriter.WriteKeyword("ul0");
			if( info.Strikeout )
				myWriter.WriteKeyword("strike0");
			if( info.Link != null && info.Link.Length > 0 )
			{
				myWriter.WriteEndGroup();
				myWriter.WriteEndGroup();
				myWriter.WriteEndGroup();
			}
		}

		/// <summary>
		/// write formatted string
		/// </summary>
        /// <param name="strText">text</param>
		/// <param name="info">format</param>
		public void WriteString( string strText , DocumentFormatInfo info )
		{
			if( this.bolCollectionInfo )
			{
				myFontTable.Add( info.FontName );
				myColorTable.Add( info.TextColor );
				myColorTable.Add( info.BackColor );
			}
			else
			{
				this.WriteStartString( info );

				if( info.Multiline )
				{
					if( strText != null )
					{
						strText = strText.Replace( "\n" , "");
						System.IO.StringReader reader = new System.IO.StringReader( strText );
						string strLine = reader.ReadLine();
						int iCount = 0 ;
						while( strLine != null )
						{
							if( iCount > 0 )
							{
								myWriter.WriteKeyword("line");
							}

							iCount ++ ;
							myWriter.WriteText( strLine );
							strLine = reader.ReadLine();
						}
						reader.Close();
					}
				}
				else
				{
					myWriter.WriteText( strText );
				}

				this.WriteEndString( info );
			}
		}

		/// <summary>
		/// end write string
		/// </summary>
		public void WriteEndString()
		{
		}

		/// <summary>
		/// start write bookmark
		/// </summary>
		/// <param name="strName">bookmark name</param>
		public void WriteStartBookmark( string strName )
		{
			if( this.bolCollectionInfo == false )
			{
				myWriter.WriteStartGroup();
				myWriter.WriteKeyword("bkmkstart" , true );
				myWriter.WriteKeyword("f0");
				myWriter.WriteText( strName );
				myWriter.WriteEndGroup();

				myWriter.WriteStartGroup();
				myWriter.WriteKeyword("bkmkend" , true );
				myWriter.WriteKeyword("f0");
				myWriter.WriteText( strName );
				myWriter.WriteEndGroup();
			}
		}

		/// <summary>
		/// end write bookmark
		/// </summary>
		/// <param name="strName">bookmark name</param>
		public void WriteEndBookmark( string strName )
		{
		}

		/// <summary>
		/// write a line break
		/// </summary>
		public void WriteLineBreak( )
		{
			if( this.bolCollectionInfo == false )
			{
				myWriter.WriteKeyword("line");
			}
		}

        /// <summary>
        /// write image
        /// </summary>
        /// <param name="img">image</param>
        /// <param name="width">pixel width</param>
        /// <param name="height">pixel height</param>
        /// <param name="ImageData">image binary data</param>
        public void WriteImage(System.Drawing.Image image, int width, int height)
        {
            if (this.bolCollectionInfo)
            {
                return;
            }
            else
            {
                if (image == null)
                {
                    return;
                }

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Close();
                byte[] bs = ms.ToArray();
                myWriter.WriteStartGroup();

                myWriter.WriteKeyword("pict");
                myWriter.WriteKeyword("jpegblip");
                myWriter.WriteKeyword("picscalex" + Convert.ToInt32(width * 100.0 / image.Size.Width));
                myWriter.WriteKeyword("picscaley" + Convert.ToInt32(height * 100.0 / image.Size.Height));
                myWriter.WriteKeyword("picwgoal" + Convert.ToString(image.Size.Width * 15));
                myWriter.WriteKeyword("pichgoal" + Convert.ToString(image.Size.Height * 15));
                myWriter.WriteBytes(bs);
                myWriter.WriteEndGroup();
            }
        }

        /// <summary>
        /// write image
        /// </summary>
        /// <param name="img">image</param>
        /// <param name="width">pixel width</param>
        /// <param name="height">pixel height</param>
        /// <param name="ImageData">image binary data</param>
        public void WriteImage( System.Drawing.Image img , int width , int height , byte[] ImageData )
		{
			if( this.bolCollectionInfo )
			{
				return ;
			}
			else
			{
				if( ImageData == null )
					return ;

				System.IO.MemoryStream ms = new System.IO.MemoryStream();
				img.Save( ms , System.Drawing.Imaging.ImageFormat.Jpeg );
				ms.Close();
				byte[] bs = ms.ToArray();
				myWriter.WriteStartGroup();
				
				myWriter.WriteKeyword("pict");
				myWriter.WriteKeyword("jpegblip");
				myWriter.WriteKeyword("picscalex" + Convert.ToInt32( width * 100.0 / img.Size.Width ));
				myWriter.WriteKeyword("picscaley" + Convert.ToInt32( height * 100.0 / img.Size.Height ));
				myWriter.WriteKeyword("picwgoal" + Convert.ToString( img.Size.Width * 15 ));
				myWriter.WriteKeyword("pichgoal" + Convert.ToString( img.Size.Height * 15 ));
				myWriter.WriteBytes( bs );
				myWriter.WriteEndGroup();
			}
		}
	}
}