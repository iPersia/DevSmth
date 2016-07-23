#region Apache License
//
// Licensed to the Apache Software Foundation (ASF) under one or more 
// contributor license agreements. See the NOTICE file distributed with
// this work for additional information regarding copyright ownership. 
// The ASF licenses this file to you under the Apache License, Version 2.0
// (the "License"); you may not use this file except in compliance with 
// the License. You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

using System;
using System.Text;
using System.IO;

using Nzl.Log4Net.Core;
using Nzl.Log4Net.Util;
using Nzl.Log4Net.DateFormatter;

namespace Nzl.Log4Net.Layout.Pattern
{
	/// <summary>
	/// Date pattern converter, uses a <see cref="IDateFormatter"/> to format 
	/// the date of a <see cref="LoggingEvent"/>.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Render the <see cref="LoggingEvent.TimeStamp"/> to the writer as a string.
	/// </para>
	/// <para>
	/// The value of the <see cref="Nzl.Log4Net.Util.PatternConverter.Option"/> determines 
	/// the formatting of the date. The following values are allowed:
	/// <list type="definition">
	///		<listheader>
	/// 		<term>Option value</term>
	/// 		<description>Output</description>
	/// 	</listheader>
	///		<item>
	/// 		<term>ISO8601</term>
	/// 		<description>
	/// 		Uses the <see cref="Iso8601DateFormatter"/> formatter. 
	/// 		Formats using the <c>"yyyy-MM-dd HH:mm:ss,fff"</c> pattern.
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<term>DATE</term>
	/// 		<description>
	/// 		Uses the <see cref="DateTimeDateFormatter"/> formatter. 
	/// 		Formats using the <c>"dd MMM yyyy HH:mm:ss,fff"</c> for example, <c>"06 Nov 1994 15:49:37,459"</c>.
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<term>ABSOLUTE</term>
	/// 		<description>
	/// 		Uses the <see cref="AbsoluteTimeDateFormatter"/> formatter. 
	/// 		Formats using the <c>"HH:mm:ss,yyyy"</c> for example, <c>"15:49:37,459"</c>.
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<term>other</term>
	/// 		<description>
	/// 		Any other pattern string uses the <see cref="SimpleDateFormatter"/> formatter. 
	/// 		This formatter passes the pattern string to the <see cref="DateTime"/> 
	/// 		<see cref="M:DateTime.ToString(string)"/> method.
	/// 		For details on valid patterns see 
	/// 		<a href="http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpref/html/frlrfsystemglobalizationdatetimeformatinfoclasstopic.asp">DateTimeFormatInfo Class</a>.
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </para>
	/// <para>
	/// The <see cref="LoggingEvent.TimeStamp"/> is in the local time zone and is rendered in that zone.
	/// To output the time in Universal time see <see cref="UtcDatePatternConverter"/>.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	internal class DatePatternConverter : PatternLayoutConverter, IOptionHandler
	{
		/// <summary>
		/// The <see cref="IDateFormatter"/> used to render the date to a string
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <see cref="IDateFormatter"/> used to render the date to a string
		/// </para>
		/// </remarks>
		protected IDateFormatter m_dateFormatter;
	
		#region Implementation of IOptionHandler

		/// <summary>
		/// Initialize the converter pattern based on the <see cref="PatternConverter.Option"/> property.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This is part of the <see cref="IOptionHandler"/> delayed object
		/// activation scheme. The <see cref="ActivateOptions"/> method must 
		/// be called on this object after the configuration properties have
		/// been set. Until <see cref="ActivateOptions"/> is called this
		/// object is in an undefined state and must not be used. 
		/// </para>
		/// <para>
		/// If any of the configuration properties are modified then 
		/// <see cref="ActivateOptions"/> must be called again.
		/// </para>
		/// </remarks>
		public void ActivateOptions()
		{
			string dateFormatStr = Option;
			if (dateFormatStr == null)
			{
				dateFormatStr = AbsoluteTimeDateFormatter.Iso8601TimeDateFormat;
			}
			
			if (string.Compare(dateFormatStr, AbsoluteTimeDateFormatter.Iso8601TimeDateFormat, true, System.Globalization.CultureInfo.InvariantCulture) == 0) 
			{
				m_dateFormatter = new Iso8601DateFormatter();
			}
			else if (string.Compare(dateFormatStr, AbsoluteTimeDateFormatter.AbsoluteTimeDateFormat, true, System.Globalization.CultureInfo.InvariantCulture) == 0)
			{
				m_dateFormatter = new AbsoluteTimeDateFormatter();
			}
			else if (string.Compare(dateFormatStr, AbsoluteTimeDateFormatter.DateAndTimeDateFormat, true, System.Globalization.CultureInfo.InvariantCulture) == 0)
			{
				m_dateFormatter = new DateTimeDateFormatter();
			}
			else 
			{
				try 
				{
					m_dateFormatter = new SimpleDateFormatter(dateFormatStr);
				}
				catch (Exception e) 
				{
					LogLog.Error(declaringType, "Could not instantiate SimpleDateFormatter with ["+dateFormatStr+"]", e);
					m_dateFormatter = new Iso8601DateFormatter();
				}	
			}
		}

		#endregion

		/// <summary>
		/// Convert the pattern into the rendered message
		/// </summary>
		/// <param name="writer"><see cref="TextWriter" /> that will receive the formatted result.</param>
		/// <param name="loggingEvent">the event being logged</param>
		/// <remarks>
		/// <para>
		/// Pass the <see cref="LoggingEvent.TimeStamp"/> to the <see cref="IDateFormatter"/>
		/// for it to render it to the writer.
		/// </para>
		/// <para>
		/// The <see cref="LoggingEvent.TimeStamp"/> passed is in the local time zone.
		/// </para>
		/// </remarks>
		override protected void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			try 
			{
				m_dateFormatter.FormatDate(loggingEvent.TimeStamp, writer);
			}
			catch (Exception ex) 
			{
				LogLog.Error(declaringType, "Error occurred while converting date.", ex);
			}
		}

	    #region Private Static Fields

	    /// <summary>
	    /// The fully qualified type of the DatePatternConverter class.
	    /// </summary>
	    /// <remarks>
	    /// Used by the internal logger to record the Type of the
	    /// log message.
	    /// </remarks>
	    private readonly static Type declaringType = typeof(DatePatternConverter);

	    #endregion Private Static Fields
	}
}
