using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ServerReboot.EventLogging
{
    /// <summary>
    ///  Event Log IDS
    ///
    ///  Event Log Ids
    ///     2000 - Mode Selection
    ///     2001 - RFC Checked
    ///     2002 - Manager Checked
    ///     2003 - Peer Approval Checked
    ///     2004 - Disconnected Remote Sessions
    ///     2005 - Verify Server rebooting
    ///     2006 - All Requirements Met
    ///     2007 -
    ///     2008 -
    ///     2009 -
    ///     2010 -
    ///     2011 -
    ///     2012 -
    ///     2013 - Reboot Button Clicked
    ///     2014 - Reboot No Button Clicked
    ///     2015 - Reboot Yes Button Clicked
    ///     
    /// </summary>
    
    /// <summary>
    /// 
    /// </summary>
    public class EventLogger
    {
        /// <summary>
        /// The application
        /// </summary>
        private string Application;
        /// <summary>
        /// The event log name
        /// </summary>
        private string EventLogName;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventLogger" /> class.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="log">The log.</param>
        public EventLogger(string app, string log)
        {
            Application = app;
            EventLogName = log;

            if (!EventLog.SourceExists(Application))
            {
                EventLog.CreateEventSource(Application, EventLogName);
            }
        }

        /// <summary>
        /// Writes to event log.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="type">The type.</param>
        /// <param name="id">The identifier.</param>
        public void WriteToEventLog(string message, string type, int id)
        {
            switch (type.ToUpper())
            {
                case "INFO":
                    EventLog.WriteEntry(Application, message, EventLogEntryType.Information, id);
                    break;
                case "ERROR":
                    EventLog.WriteEntry(Application, message, EventLogEntryType.Error, id);
                    break;
                case "WARN":
                    EventLog.WriteEntry(Application, message, EventLogEntryType.Warning, id);
                    break;
                default:
                    EventLog.WriteEntry(Application, message, EventLogEntryType.Information, id);
                    break;
            }
        }
    }
}