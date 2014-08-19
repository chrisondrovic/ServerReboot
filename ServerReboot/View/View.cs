using System;

namespace ServerReboot
{
    /// <summary>
    /// 
    /// </summary>
    public class View
    {
        public View()
        {
            this.ServerName = Environment.GetEnvironmentVariable("COMPUTERNAME");
        }

        private string _server;
        private string _rfc;
        private string _manager;
        /// <summary>
        /// Gets or sets the name of the server.
        /// </summary>
        /// <value>
        /// The name of the server.
        /// </value>
        public string ServerName { get { return _server; } set { _server = value; } }
        /// <summary>
        /// Gets or sets the RFC number.
        /// </summary>
        /// <value>
        /// The RFC number.
        /// </value>
        public string RFCNumber { get { return _rfc; } set { _rfc = value; } }
        /// <summary>
        /// Gets or sets the manager.
        /// </summary>
        /// <value>
        /// The manager.
        /// </value>
        public string Manager { get { return _manager; } set { _manager = value; } }

    }
}
