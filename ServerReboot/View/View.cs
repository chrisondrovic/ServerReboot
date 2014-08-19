using System;

namespace ServerReboot
{
    public class View
    {
        public View()
        {
            this.ServerName = Environment.GetEnvironmentVariable("COMPUTERNAME");
        }

        private string _server;
        private string _rfc;
        private string _manager;
        public string ServerName { get { return _server; } set { _server = value; } }
        public string RFCNumber { get { return _rfc; } set { _rfc = value; } }
        public string Manager { get { return _manager; } set { _manager = value; } }

    }
}
