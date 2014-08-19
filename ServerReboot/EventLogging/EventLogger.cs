using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ServerReboot.EventLogging
{
    /*
        Event Log Ids
        2000 - Mode Selection
        2001 - RFC Checked
        2002 - Manager Checked
        2003 - Remote Sessions Disconnected
        2004 - Server Verificaiton
        2005 - Requirments Met
        2006 - Reboot Button Clicked
        2007 - No Button Clicked
        2008 - Yes Button Clicled
    */
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