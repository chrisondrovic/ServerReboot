using ServerReboot.EventLogging;
using System;
using System.Diagnostics;
using System.Windows;

namespace ServerReboot.UI
{
    /// <summary>
    /// Interaction logic for RebootConfirmation.xaml
    /// </summary>
    public partial class RebootConfirmation : Window
    {
        EventLogger events = new EventLogger("Server-Reboot", "Application");
        private string currentUser = Environment.UserDomainName + "\\" + Environment.UserName;
        int NoButtonClicked = 2007;
        int YesButtonClicked = 2008;
        /// <summary>
        /// Initializes a new instance of the <see cref="RebootConfirmation"/> class.
        /// </summary>
        public RebootConfirmation()
        {
            InitializeComponent();
            this.DataContext = new View();
        }

        /// <summary>
        /// Handles the Click event of the btnYES control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnYES_Click(object sender, RoutedEventArgs e)
        {
            events.WriteToEventLog("Yes button clicked on " + DateTime.Now.ToString() + " by " + currentUser, "warn", YesButtonClicked);
            events.WriteToEventLog("Rebooting server on " + DateTime.Now.ToString() + " by " + currentUser, "warn", YesButtonClicked);
            Process.Start("Shutdown.exe", "/r");
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Handles the Click event of the btnNO control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnNO_Click(object sender, RoutedEventArgs e)
        {
            events.WriteToEventLog("No button clicked on " + DateTime.Now.ToString() + " by " + currentUser, "info", NoButtonClicked);
            Application.Current.Shutdown();
        }
    }
}