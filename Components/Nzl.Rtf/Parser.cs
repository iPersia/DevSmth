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

namespace Nzl.Rtf
{
    /// <summary>
    /// RTF plain text container
    /// </summary>
    internal class RTFTextContainer
    {
        /// <summary>
        /// initialize instance
        /// </summary>
        /// <param name="doc">owner document</param>
        public RTFTextContainer(RTFDomDocument doc)
        {
            myDocument = doc;
        }

        private System.Text.StringBuilder myStr = new System.Text.StringBuilder();
        private ByteBuffer myBuffer = new ByteBuffer();

        private RTFDomDocument myDocument = null;
        /// <summary>
        /// Owner document
        /// </summary>
        public RTFDomDocument Document
        {
            get { return myDocument; }
            set { myDocument = value; }
        }

        /// <summary>
        /// Accept rtf token
        /// </summary>
        /// <param name="token">RTF token</param>
        /// <returns>Is accept it?</returns>
        public bool Accept(RTFToken token)
        {
            if (token == null)
                return false;
            if (token.Type == RTFTokenType.Text)
            {
                CheckBuffer();
                myStr.Append(token.Key);
                return true ;
            }
            else if (token.Type == RTFTokenType.Control 
                && token.Key == "'" && token.HasParam )
            {
                myBuffer.Add((byte)token.Param);
                return true;
            }
            if ( token.Key == "tab")
            {
                CheckBuffer();
                myStr.Append("\t");
                return true;
            }
            if ( token.Key == "emdash")
            {
                CheckBuffer();
                myStr.Append('��');
                return true;
            }
            if ( token.Key == "")
            {
                CheckBuffer();
                myStr.Append('-');
                return true;
            }
            return false;
        }

        /// <summary>
        /// this container has some text
        /// </summary>
        public bool HasContent
        {
            get
            {
                CheckBuffer();
                return myStr.Length > 0;
            }
        }

        /// <summary>
        /// text value
        /// </summary>
        public string Text
        {
            get
            {
                CheckBuffer();   
                return myStr.ToString();
            }
        }

        private int intLevel = 0;

        public int Level
        {
            get { return intLevel; }
            set { intLevel = value; }
        }

        /// <summary>
        /// clear value
        /// </summary>
        public void Clear()
        {
            myBuffer.Clear();
            myStr = new System.Text.StringBuilder();
        }
        private void CheckBuffer()
        {
            if (myBuffer.Count > 0)
            {
                string txt = myBuffer.GetString(myDocument.RuntimeEncoding);
                myStr.Append(txt);
                myBuffer.Clear();
            }
        }
    }

	public class RTFReader : System.IDisposable
	{
		/// <summary>
		/// initialize instance
		/// </summary>
		public RTFReader( )
		{
		}

        public RTFReader(string fileName)
        {
            LoadRTFFile(fileName);
        }

        public RTFReader(System.IO.Stream stream)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(stream, System.Text.Encoding.ASCII);
            LoadReader(reader);
            myBaseStream = stream;
        }

        public RTFReader(System.IO.TextReader reader)
        {
            LoadReader(reader);
        }

		private RTFLex myLex = null;
		//private RTFToken myToken = null ;

		private System.IO.TextReader myReader = null;

        //private System.Collections.ArrayList myTokenStack = new System.Collections.ArrayList();
        //public System.Collections.ArrayList TokenStack
        //{
        //    get
        //    {
        //        return myTokenStack ;
        //    }
        //}

        private System.IO.Stream myBaseStream = null;

		/// <summary>
		/// load rtf document
		/// </summary>
		/// <param name="strFileName">spcial file name</param>
		/// <returns>is operation successful</returns>
		public bool LoadRTFFile( string strFileName )
		{
			//myTokenStack.Clear();
			myCurrentToken = null ;
			if( System.IO.File.Exists( strFileName ))
			{
				System.IO.FileStream stream = new System.IO.FileStream( strFileName , System.IO.FileMode.Open , System.IO.FileAccess.Read );
				myReader = new System.IO.StreamReader( stream , System.Text.Encoding.ASCII );
                myBaseStream = stream;
				myLex = new RTFLex( myReader );
				return true ;
			}
			return false;
		}
		/// <summary>
		/// load rtf document
		/// </summary>
		/// <param name="reader">text reader</param>
		/// <returns>is operation successful</returns>
		public bool LoadReader( System.IO.TextReader reader )
		{
			//myTokenStack.Clear();
			myCurrentToken = null;
			if( reader != null )
			{
				myReader = reader;
				myLex = new RTFLex( myReader );
				return true ;
			}
			return false;
		}

		/// <summary>
		/// load rtf text
		/// </summary>
		/// <param name="strText">RTF text</param>
		/// <returns>is operation successful</returns>
		public bool LoadRTFText( string strText )
		{
			//myTokenStack.Clear();
			myCurrentToken = null;
			if( strText != null && strText.Length > 3 )
			{
				myReader = new System.IO.StringReader( strText );
				myLex = new RTFLex( myReader );
				return true ;
			}
			return false ;
		}

		public void Close()
		{
			if( myReader != null )
			{
				myReader.Close();
				myReader = null ;
			}
		}
		private RTFToken myCurrentToken = null;
		/// <summary>
		/// current token
		/// </summary>
		public RTFToken CurrentToken
		{
			get{ return myCurrentToken ;}
		}
		/// <summary>
		/// current token's type
		/// </summary>
		public RTFTokenType TokenType
		{
			get
			{
				if( myCurrentToken == null )
					return RTFTokenType.None ;
				else
					return myCurrentToken.Type ;
			}
		}

        /// <summary>
		/// current keyword
		/// </summary>
		public string Keyword
		{
			get
			{
				if( myCurrentToken == null )
					return null;
				else
					return myCurrentToken.Key ;
			}
		}
		/// <summary>
		/// is current token has a parameter
		/// </summary>
		public bool HasParam
		{
			get
			{
				if( myCurrentToken == null )
					return false ;
				else
					return myCurrentToken.HasParam ;
			}
		}
		/// <summary>
		/// current parameter
		/// </summary>
		public int Parameter
		{
			get
			{
				if( myCurrentToken == null )
					return 0 ;
				else
					return myCurrentToken.Param ;
			}
		}

        public int ContentPosition
        {
            get
            {
                if (myBaseStream == null)
                    return 0;
                else
                    return ( int ) myBaseStream.Position;
            }
        }

        public int ContentLength
        {
            get
            {
                if (myBaseStream == null)
                    return 0;
                else
                    return ( int ) myBaseStream.Length;
            }
        }

        /// <summary>
        /// next token type
        /// </summary>
        /// <returns></returns>
        public RTFTokenType PeekTokenType()
        {
            return myLex.PeekTokenType();
        }

        //private RTFToken myLastToken = null;
        //public RTFToken LastToken
        //{
        //    get
        //    {
        //        return myLastToken;
        //    }
        //}

        private bool bolFirstTokenInGroup = false;
        /// <summary>
        /// Current token is the first token in owner group
        /// </summary>
        public bool FirstTokenInGroup
        {
            get
            {
                return bolFirstTokenInGroup; 
            }
        }

        private RTFToken myLastToken = null;
        /// <summary>
        /// lost token
        /// </summary>
        public RTFToken LastToken
        {
            get
            {
                return myLastToken; 
            }
        }

        private int intLevel = 0;
        public int Level
        {
            get
            {
                return intLevel;
            }
        }

        private int intTokenCount = 0;
        /// <summary>
        /// total of this object handle tokens
        /// </summary>
        public int TokenCount
        {
            get
            {
                return intTokenCount; 
            }
            set
            {
                intTokenCount = value; 
            }
        }

		/// <summary>
		/// read token
		/// </summary>
		/// <returns>token readed</returns>
		public RTFToken ReadToken()
		{
            bolFirstTokenInGroup = false;
            myLastToken = myCurrentToken;
            if (myLastToken != null && myLastToken.Type == RTFTokenType.GroupStart)
            {
                bolFirstTokenInGroup = true;
            }
			myCurrentToken = myLex.NextToken( );
			if( myCurrentToken == null || myCurrentToken.Type == RTFTokenType.Eof )
			{
				myCurrentToken = null;
				return null;
			}
            intTokenCount++;
            if (myCurrentToken.Type == RTFTokenType.GroupStart)
            {
                intLevel++;
            }
            else if (myCurrentToken.Type == RTFTokenType.GroupEnd)
            {
                intLevel--;
            }
   
            //if (myTokenStack.Count > 0)
            //{
            //    myCurrentToken.Parent = (RTFToken)myTokenStack[myTokenStack.Count - 1];
            //}
            //myTokenStack.Add( myCurrentToken );
			return myCurrentToken ;
		}

        /// <summary>
        /// read and ignore data , until just the end of current group,preserve the end.
        /// </summary>
        public void ReadToEndGround( )
        {
            int level = 0;
            while (true)
            {
                int c = myReader.Peek();
                if (c == -1)
                {
                    break;
                }
                else if (c == '{')
                {
                    level++;
                }
                else if (c == '}')
                {
                    level--;
                    if (level < 0)
                    {
                        break;
                    }
                }
                c = myReader.Read();
            }
        }

		public void Dispose()
		{
			this.Close();
		}

        public override string ToString()
        {
            return "RTFReader Level:" + intLevel + " " + this.Keyword ;
        }
	}
 
	public class RTFLex
	{
		/// <summary>
		/// Initialize instance
		/// </summary>
		/// <param name="reader">reader</param>
		public RTFLex( System.IO.TextReader reader )
		{
			myReader = reader ;
		}

		private System.IO.TextReader myReader = null;
		private const int EOF = -1 ;

        public RTFTokenType PeekTokenType()
        {
            int c = myReader.Peek();

            while (c == '\r'
                || c == '\n'
                || c == '\t'
                || c == '\0')
            {
                c = myReader.Read();
                c = myReader.Peek();
            }
            if (c == EOF)
            {
                return RTFTokenType.Eof;
            }
            else
            {
                switch (c)
                {
                    case '{':
                        return RTFTokenType.GroupStart;
                    case '}':
                        return RTFTokenType.GroupEnd;
                    case '\\':
                        return RTFTokenType.Control;
                    default:
                        return RTFTokenType.Text;
                }
            }
        }


		/// <summary>
		/// read next token
		/// </summary>
		/// <returns>token</returns>
		public RTFToken NextToken( )
		{
			int c = 0 ;
			RTFToken token = new RTFToken();

			//myReader.Read();

			c = myReader.Read();

			while( c == '\r'
				|| c == '\n'
				|| c == '\t'
				|| c == '\0' )
			{
				c = myReader.Read();
				//c = myReader.Peek();
			}

			//
//			c = myReader.Read();
//			while( c == '\r'
//				|| c == '\n' 
//				|| c == '\t'
//				|| c == '\0')
//			{
//				c = myReader.Read();
//			}
			if( c != EOF )
			{
				switch( c )
				{
					case '{' :
						token.Type = RTFTokenType.GroupStart ;
						break;
					case '}' :
						token.Type = RTFTokenType.GroupEnd ;
						break;
					case '\\' :
						ParseKeyword( token );
						break;
					default:
						token.Type = RTFTokenType.Text ;
                        ParseText(c, token);
						break;
				}
			}
			else
			{
				token.Type = RTFTokenType.Eof ;
			}
			return token ;
		}

		private void ParseKeyword( RTFToken token )
		{
			int c = 0 ;
			bool ext = false;
			c = myReader.Peek();
			if( char.IsLetter( ( char ) c ) == false )
			{
				myReader.Read();
				if( c == '*' )
				{
					// expend keyword
					token.Type = RTFTokenType.Keyword ;
					myReader.Read();
					//myReader.Read();
					ext = true ;
					goto ReadKeywrod ;
				}
				else if( c == '\\' || c == '{' || c == '}' )
				{
					// special character
					token.Type = RTFTokenType.Text ;
					token.Key = ( ( char ) c).ToString();
				}
				else
				{
					token.Type = RTFTokenType.Control ;
					token.Key = ( ( char ) c ).ToString();
					if( token.Key == "\'" )
					{
						// read 2 hex characters
						System.Text.StringBuilder text = new System.Text.StringBuilder();
						text.Append( ( char ) myReader.Read());
						text.Append( ( char ) myReader.Read());
						token.HasParam = true ;
						token.Param = Convert.ToInt32( text.ToString().ToLower() , 16 );
						if( token.Param == 0 )
						{
							token.Param = 0 ;
						}
					}
				}
				return ;
			}//if( char.IsLetter( ( char ) c ) == false )

		ReadKeywrod :

			// read keyword
			System.Text.StringBuilder Keyword = new System.Text.StringBuilder();
			c = myReader.Peek();
			while( char.IsLetter ( ( char ) c ))
			{
				myReader.Read();
				Keyword .Append( ( char ) c );
				c = myReader.Peek();
			}

			if( ext )
				token.Type = RTFTokenType.ExtKeyword ;
			else
				token.Type = RTFTokenType.Keyword ;
			token.Key = Keyword.ToString();

			// read a interger
			if( char.IsDigit( ( char ) c ) || c == '-' )
			{
				token.HasParam = true ;
				bool Negative = false;
				if( c == '-' )
				{
					Negative = true ;
					myReader.Read();
				}
				c = myReader.Peek();
				System.Text.StringBuilder text = new System.Text.StringBuilder();
				while( char.IsDigit( ( char ) c ))
				{
					myReader.Read();
					text.Append( ( char ) c );
					c = myReader.Peek();
				}
				int p = Convert.ToInt32( text.ToString());
				if( Negative )
					p = - p ;
				token.Param = p ;
			}//if( char.IsDigit( ( char ) c ) || c == '-' )

			if( c == ' ' )
			{
				myReader.Read();
			}
		}

		private void ParseText( int c , RTFToken token )
		{
			System.Text.StringBuilder myStr = new System.Text.StringBuilder( ( ( char ) c ).ToString());

			c = ClearWhiteSpace();

			while( c != '\\' && c != '}' && c != '{' && c != EOF )
			{
				myReader.Read();
				myStr.Append( ( char ) c );
				c = ClearWhiteSpace();
			}

			token.Key = myStr.ToString();
		}
		
		private int ClearWhiteSpace( )
		{
			int c = myReader.Peek();
			while( c == '\r'
				|| c == '\n'
				|| c == '\t'
				|| c == '\0' )
			{
				myReader.Read();
				c = myReader.Peek();
			}
			return c ;
		}
	}
	/// <summary>
	/// rtf token type
	/// </summary>
	public class RTFToken
	{
		private RTFTokenType intType = RTFTokenType.None ;
		/// <summary>
		/// type
		/// </summary>
		public RTFTokenType Type
		{
			get{ return intType ;}
			set{ intType = value;}
		}

		private string strKey = null;
		/// <summary>
		/// keyword
		/// </summary>
		public string Key
		{
			get{ return strKey ;}
			set{ strKey = value;}
		}

		private bool bolHasParam = false;
		/// <summary>
		/// 
		/// </summary>
		public bool HasParam
		{
			get{ return bolHasParam ;}
			set{ bolHasParam = value;}
		}

		private int intParam = 0 ;
		public int Param
		{
			get{ return intParam ;}
			set{ intParam = value;}
		}

        private RTFToken myParent = null;
        /// <summary>
        /// parent token
        /// </summary>
        public RTFToken Parent
        {
            get { return myParent; }
            set { myParent = value; }
        }
        public bool IsTextToken
        {
            get
            {
                if (intType == RTFTokenType.Text)
                    return true;
                if (intType == RTFTokenType.Control && strKey == "'" && bolHasParam)
                    return true;
                return false;
            }
        }
	}

	/// <summary>
	/// rtf token type
	/// </summary>
	public enum RTFTokenType
	{
		None ,
		Keyword ,
		ExtKeyword ,
		Control ,
		Text ,
		Eof ,
		GroupStart ,
		GroupEnd 
	}
	
}